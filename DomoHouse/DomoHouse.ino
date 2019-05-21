#include <SoftwareSerial.h>

SoftwareSerial mySerial(0, 1); // RX, TX

// Opciones de configuracion:
char ssid[11]        = "DomoHouse";    // Nombre para el modulo Bluetooth.
char baudios         = '4';           // 1=>1200 baudios, 2=>2400, 3=>4800, 4=>9600 (por defecto), 5=>19200, 6=>38400, 7=>57600, 8=>115200
char password[5]    = "0000";        // Contraseña para el emparejamiento del modulo.


// Pines de los leds
int garage = 7;
int salacomedor = 8;
int cocina = 9;
int dormitorio1 = 3;
int dormitorio2 = 4;
int dormitorio3 = 5;
int bano = 6;

//Flags de los leds
boolean flagGarage;
boolean flagSalacomedor;
boolean flagCocina;
boolean flagDormitorio1;
boolean flagDormitorio2;
boolean flagDormitorio3;
boolean flagBano;

void setup() {
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

  //Seteo de pines
  pinMode(garage, OUTPUT);
  pinMode(salacomedor, OUTPUT);
  pinMode(cocina, OUTPUT);
  pinMode(dormitorio1, OUTPUT);
  pinMode(dormitorio2, OUTPUT);
  pinMode(dormitorio3, OUTPUT);
  pinMode(bano, OUTPUT);

  //Seteo de los flag
  flagGarage = false;
  flagSalacomedor = false;
  flagCocina = false;
  flagDormitorio1 = false;
  flagDormitorio2 = false;
  flagDormitorio3 = false;
  flagBano = false;
}

void loop() {
  char c = Serial.read();
  switch(c) {
  case 'a':
    if (flagGarage) {
      digitalWrite(garage, LOW);
      flagGarage = false;
    }
    digitalWrite(garage, HIGH);
    flagGarage = true;
    break;

  case 'b':
    if (flagSalacomedor) {
      digitalWrite(salacomedor, LOW);
      flagSalacomedor = false;
    }
    digitalWrite(salacomedor, HIGH);
    flagsalacomedor = true;
    break;

  case 'c':
    if (flagCocina) {
      digitalWrite(cocina, LOW);
      flagCocina = false;
    }
    digitalWrite(cocina, HIGH);
    flagCocina = true;
    break;

  case 'd':
    if (flagDormitorio1) {
      digitalWrite(dormitorio1, LOW);
      flagDormitorio1 = false;
    }
    digitalWrite(dormitorio1, HIGH);
    flagDormitorio1 = true;
    break;

  case 'e':
    if (flagDormitorio2) {
      digitalWrite(dormitorio2, LOW);
      flagDormitorio2 = false;
    }
    digitalWrite(dormitorio2, HIGH);
    flagDormitorio2 = true;
    break;

  case 'g':
    if (flagDormitorio3) {
      digitalWrite(dormitorio3, LOW);
      flagDormitorio3 = false;
    }
    digitalWrite(dormitorio3, HIGH);
    flagDormitorio3 = true;
    break;

  case 'h':
    if (flagBano) {
      digitalWrite(bano, LOW);
      flagBano = false;
    }
    digitalWrite(bano, HIGH);
    flagBano = true;
    break;
  }


  /*for(int x = 3; x < 10; x++){
    digitalWrite(x, HIGH);
    Serial.print("Encendido ");
    Serial.println(x);
    delay(5000);
    }*/
}
