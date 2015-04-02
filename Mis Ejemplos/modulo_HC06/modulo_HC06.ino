#include <SoftwareSerial.h>

SoftwareSerial mySerial(0,1); // RX, TX

// Opciones de configuracion:
char ssid[11]        = "Bose";    // Nombre para el modulo Bluetooth.
char baudios         = '4';           // 1=>1200 baudios, 2=>2400, 3=>4800, 4=>9600 (por defecto), 5=>19200, 6=>38400, 7=>57600, 8=>115200
char password[5]    = "0000";        // Contraseña para el emparejamiento del modulo.

void setup(){
  mySerial.begin(9600);
  Serial.begin(9600);
  // Ahora se procede a la configuraciÃ³n del modulo:

  // Se inicia la configuraciÃ³n:
  mySerial.print("AT"); 
  delay(1000);

  // Se ajusta el nombre del Bluetooth:
  mySerial.print("AT+NAME"); 
  mySerial.println(ssid); 
  delay(1000);

  // Se ajustan los baudios:
  mySerial.print("AT+BAUD"); 
  mySerial.println(baudios); 
  delay(1000);

  // Se ajusta la contraseÃ±a:
  mySerial.print("AT+PIN"); 
  mySerial.println(password); 
  delay(1000);    
  Serial.println("Configurada");
}

void loop(){
}
