#include <Servo.h>                       //Se incluye la libreria para control de servo

Servo servo;                             //Variable para invocar la funcion Servo
int servoPin = A1;                       //Pin en donde se coloca el servo
int sensorMov = A0;                      //Pin en donde se coloca el sensor
int sensorVal = 0;                       //Variable para colocar el valor que posee el servo
int sensorTrigger = 650;                 //Valor para accionar el movil
int timer = 2000;                        //Tiempo de espera

void setup() {
  Serial.begin(9600);                    //Inicia la comunicacion con el puerto serial
  servo.attach(servoPin);                //Asignamos el pin al servo
  Serial.println("Iniciando Movil!!!");  //Mensaje de configuracion
}

void loop() {
  sensorVal = analogRead(sensorMov);     //Lee el valor del sensor y lo almacena 
  Serial.println(sensorVal);
  if(sensorVal > sensorTrigger){
    servo.write(0);                     //Mueve el servo a maxima velocidad en una direccion
  }
  else{
    servo.write(95);                    //Detiene el servo
  }
  delay(timer);  
}
