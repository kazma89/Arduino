/*
  Programa para la placa Arduino del movil controlado por un
  terminal Android por medio de un escudo Bluetooth
*/ 

#include <SoftwareSerial.h> //Importa la libreria para la comunicacion serial con el Arduino

SoftwareSerial mySerial(0, 1); //RX, TX
 
// Opciones de configuración:
    char ssid[11] = "Bose"; // Nombre para el modulo Bluetooth.
    char baudios = '4'; // 1=>1200 baudios, 2=>2400, 3=>4800, 4=>9600 (por defecto), 5=>19200, 6=>38400, 7=>57600, 8=>115200
    char password[10] = "1455"; // Contraseña para el emparejamiento del modulo.
    char cadena[255];
    int i = 0;
    
//-------------------------- Motor ------------------------------
//motor A cnectado entre A01 y A02
//motor B conectado entre B01 y B02

int STBY = 10; //Espera

//Motor A
int PWMA = 3; //Controlar la velocidad
int AIN1 = 9; //Pin de direccion
int AIN2 = 8; //Pin de direccion

//Motor B
int PWMB = 5; //Controlar la velocidad
int BIN1 = 11; //Pin de direccion
int BIN2 = 12; //Pin de direccion

//Modulo Blutooth
int dato = 0;
int flag = 0;

void setup(){
    mySerial.begin(9600); //Se inicia la comunicacion con el modulo
    Serial1.begin(9600);//Se inicia la comunicacion serial del Arduino
    // Ahora se procede a la configuración del modulo
    
        // Se inicia la configuración:
            mySerial.print("AT"); 
            delay(1000);
 
        // Se ajusta el nombre del Bluetooth:
            mySerial.print("AT+NAME"); 
            mySerial.print(ssid); 
            delay(1000);
 
        // Se ajustan los baudios:
            mySerial.print("AT+BAUD"); 
            mySerial.print(baudios); 
            delay(1000);
 
        // Se ajusta la contraseña:
            mySerial.print("AT+PIN"); 
            mySerial.print(password); 
            delay(1000);    
            
            Serial.print("Configurada"); // Mensaje en donde se termina la configutacion
  
  // ---------------------- Motor -------------------------------
  pinMode(STBY, OUTPUT);
  pinMode(PWMA, OUTPUT);
  pinMode(AIN1, OUTPUT);
  pinMode(AIN2, OUTPUT);
  pinMode(PWMB, OUTPUT);
  pinMode(BIN1, OUTPUT);
  pinMode(BIN2, OUTPUT);
}
 
void loop(){
  detener(); // Mantiene el carro detenido
  // --------------- Comunicacion Bluetooth ---------------------
  //Cuando halla datos disponibles
  //if(mySerial.available()){
  if(Serial1.available()>0){
    dato = Serial1.read();
    flag = 0;
  }
    //Guarda los datos caracter por caracter en la variable "dato"
    //char dato = mySerial.read();
    if(dato == '1'){//Los motores se mueven hacia adelante
      mov(1,255,1);//motor A, full speed, izq
      mov(2,255,1);//motor A, full speed, izq
      delay(1000);
      dato = 0;
    }
    else if(dato == '2'){//Los motores se mueven hacia la izquierda
      mov(1,255,0);//motor A, full speed, der
      mov(1,255,1);//motor A, full speed, izq
      delay(1000);
      dato = 0;
    }
    else if(dato == '3'){//Los motores se mueven hacia la derecha
      mov(1,255,1); //motor A, full speed, izq
      mov(1,255,0); //motor A, full speed, der
      delay(1000);
      dato = 0;
    }
    else if(dato == '4'){//Los motores se mueven hacia atras
      mov(1,255,0); //motor A, full speed, der
      mov(1,255,0); //motor A, full speed, der
      delay(1000);
      dato = 0;
    }
    else if(dato == '5'){
      detener();
      delay(1000);
      dato = 0;
    }
    //Vamos colocando cada caracter recidibo en el array "cadena"
    //cadena[i++] = dato;
}
// ------------------------ Motor --------------------------------
void mov(int motor, int velocidad, int direccion){
//Mueve un motor a una velocidad y direccion especificas
//motor: 0 para B 1 para A
//speed: 0 es apagado, y 255 es la velocidad maxima
//direccion: 0 reloj, 1 contra-reloj

  digitalWrite(STBY, HIGH); //deshabilita el standby

  int inPin1; 
  int inPin2; 

  if(direccion == 0){
    inPin1 = LOW;
    inPin2 = HIGH;
  }else if(direccion == 1){
    inPin1 = HIGH;
    inPin2 = LOW;
  }

  if(motor == 1){
    digitalWrite(AIN1, inPin1);
    digitalWrite(AIN2, inPin2);
    analogWrite(PWMA, velocidad);
  }else{
    digitalWrite(BIN1, inPin1);
    digitalWrite(BIN2, inPin2);
    analogWrite(PWMB, velocidad);
  }
}

void detener(){
//enable standby  
  digitalWrite(STBY, LOW); 
}
