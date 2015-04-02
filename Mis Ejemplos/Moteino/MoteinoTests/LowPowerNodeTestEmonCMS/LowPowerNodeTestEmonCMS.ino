#include <LowPower.h>   //https://github.com/rocketscream/Low-Power

// Simplified Moteino Node Test

#include <RFM69.h>    //get it here: https://www.github.com/lowpowerlab/rfm69
#include <SPI.h>

#define NODEID        50    //ID del nodo, debe ser unico para saber de cual nodo vino
#define NETWORKID     200   //ID de la red, todos los nodos deben tener el mismo networkID
#define GATEWAYID     1     //ID del dispositivo gateway 
//Match frequency to the hardware version of the radio on your Moteino (uncomment one):
//#define FREQUENCY   RF69_433MHZ
//#define FREQUENCY   RF69_868MHZ
#define FREQUENCY     RF69_915MHZ
#define ENCRYPTKEY    "sampleEncryptKey" //exactly the same 16 characters/bytes on all nodes!
//#define IS_RFM69HW    //uncomment only for RFM69HW! Leave out if you have RFM69W!
#ifdef __AVR_ATmega1284P__
  #define LED           15 // Moteino MEGAs have LEDs on D15
  #define FLASH_SS      23 // and FLASH SS on D23
#else
  #define LED           9 // Moteinos have LEDs on D9
  #define FLASH_SS      8 // and FLASH SS on D8
#endif

#define SERIAL_BAUD   9600

int TRANSMITPERIOD = 1000; //transmit a packet to gateway so often (in ms)
char payload[30];
boolean requestACK = false;
RFM69 radio;

typedef struct {
  int           nodeId; //store this nodeId
  unsigned long uptime; //uptime in ms
  float         temp;   //temperature
  int           moisture; //soil moisture
} Payload;
Payload theData;

void setup() {
  Serial.begin(SERIAL_BAUD);
  radio.initialize(FREQUENCY,NODEID,NETWORKID);
#ifdef IS_RFM69HW
  radio.setHighPower(); //uncomment only for RFM69HW!
#endif
  radio.encrypt(ENCRYPTKEY);
  char buff[50];
  sprintf(buff, "\nTransmitting at %d Mhz...", FREQUENCY==RF69_433MHZ ? 433 : FREQUENCY==RF69_868MHZ ? 868 : 915);
  Serial.println(buff);
  
}

void loop() {

  //check for any received packets
  if (radio.receiveDone())
  {
    Serial.print('[');Serial.print(radio.SENDERID, DEC);Serial.print("] ");
    for (byte i = 0; i < radio.DATALEN; i++)
      Serial.print((char)radio.DATA[i]);
    Serial.print("   [RX_RSSI:");Serial.print(radio.RSSI);Serial.print("]");

    if (radio.ACKRequested())
    {
      radio.sendACK();
      Serial.print(" - ACK sent");
    }
    Blink(LED,3);
    Serial.println();
  }

    // Send data
      int sensorReading = radio.readTemperature(0); // El pin en donde se lee el sensor de temperatura
      theData.nodeId = NODEID;
      theData.uptime = millis();
      theData.temp = sensorReading;
      theData.moisture = 0;
      
      /* 
        Aca se envian los datos 
        GATEWAYID el nombre de nodo al que envia 
        2 el numero de reintentos 
        100 tiempo en ms
      */
      if (radio.sendWithRetry(GATEWAYID, (const void*)(&theData), sizeof(theData)),2,100)
      {
        Serial.print(" ok!");
      }
      else {
        Serial.print(" nothing...");
      }
    Blink(LED,3);

  Serial.flush();
  radio.sleep();
  LowPower.powerDown(SLEEP_8S, ADC_OFF, BOD_OFF);

}

void Blink(byte PIN, int DELAY_MS)
{
  pinMode(PIN, OUTPUT);
  digitalWrite(PIN,HIGH);
  delay(DELAY_MS);
  digitalWrite(PIN,LOW);
}
