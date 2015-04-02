// Simplified Moteino Gateway test
#include <RFM69.h>    //with KiwiSinceBirth mods
#include <SPI.h>
#include <Ethernet.h>
#include <utility/w5100.h> //with KiwiSinceBirth mods
//#include <SPIFlash.h> //get it here: https://www.github.com/lowpowerlab/spiflash

byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress server (192,168,10,185); //my laptop running 'nc -lk 8000'
IPAddress ip(192,168,10,178); //ip to use in case of DHCP failure
EthernetClient client;

#define NODEID        1    //unique for each node on same network
#define NETWORKID     100  //the same on all nodes that talk to each other
//Match frequency to the hardware version of the radio on your Moteino (uncomment one):
//#define FREQUENCY     RF69_433MHZ
//#define FREQUENCY     RF69_868MHZ
#define FREQUENCY     RF69_915MHZ
#define ENCRYPTKEY    "sampleEncryptKey" //exactly the same 16 characters/bytes on all nodes!
#define IS_RFM69HW    //uncomment only for RFM69HW! Leave out if you have RFM69W!
#define ACK_TIME      30 // max # of ms to wait for an ack
#define SERIAL_BAUD   9600

#ifdef __AVR_ATmega1284P__
  #define LED           15 // Moteino MEGAs have LEDs on D15
  #define FLASH_SS      23 // and FLASH SS on D23
#else
  #define LED           9 // Moteinos have LEDs on D9
  #define FLASH_SS      8 // and FLASH SS on D8
#endif

RFM69 radio;
//SPIFlash flash(FLASH_SS, 0xEF30); //EF30 for 4mbit  Windbond chip (W25X40CL)


void setup() {
  
  W5100.select(7); //selects pin 7 as SS for Ethernet module (KiwiSinceBirth mod)

pinMode(8, OUTPUT);
digitalWrite(8, HIGH);

  Serial.begin(SERIAL_BAUD);
  delay(10);
  radio.initialize(FREQUENCY,NODEID,NETWORKID);
#ifdef IS_RFM69HW
  radio.setHighPower(); //only for RFM69HW!
#endif
  radio.encrypt(ENCRYPTKEY);
  char buff[50];
  sprintf(buff, "\nListening at %d Mhz...", FREQUENCY==RF69_433MHZ ? 433 : FREQUENCY==RF69_868MHZ ? 868 : 915);
  Serial.println(buff);
  Serial.println(F("Starting Ethernet..."));
  delay(100);
  // start the Ethernet connection:
  //Ethernet.begin(mac,ip);
  if (Ethernet.begin(mac) == 0) {
    Serial.println("Failed to configure Ethernet using DHCP");
    Ethernet.begin(mac, ip);
  }
  // give the Ethernet shield a second to initialize:
  delay(1000);
  Serial.println(F("Ethernet Ready..."));
}

byte ackCount=0;
uint32_t packetCount = 0;
void loop() {

  if (radio.receiveDone())
  {
    client.stop();
      if (client.connect(server, 8000)) {

    
    client.print("#[");
    client.print(++packetCount);
    client.print(']');
    client.print('[');client.print(radio.SENDERID, DEC);client.print("] ");
    for (byte i = 0; i < radio.DATALEN; i++)
      client.print((char)radio.DATA[i]);
    client.print("   [RX_RSSI:");client.print(radio.RSSI);client.print("]");client.println();
      } else {
        Serial.println("Connection Failed");
      }
    
    if (radio.ACKRequested())
    {
      byte theNodeID = radio.SENDERID;
      radio.sendACK();
      Serial.print(" - ACK sent.");

    }
    Serial.println();
    Blink(LED,3);
  }
}

void Blink(byte PIN, int DELAY_MS)
{
  pinMode(PIN, OUTPUT);
  digitalWrite(PIN,HIGH);
  delay(DELAY_MS);
  digitalWrite(PIN,LOW);
}
