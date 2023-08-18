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

#include <SoftwareSerial.h>

SoftwareSerial sim900(0, 1); // RX, TX (conexión a la tarjeta ICOM SAT 1.1)

void setup() {
  Serial.begin(9600);
  sim900.begin(9600);

  Serial.println("Configurando modulo SIM900...");
  delay(2000);
  
  // Verificar la conexión con el módulo SIM900
  if (sim900.available()) {
    Serial.println("Modulo SIM900 conectado correctamente.");
  } else {
    Serial.println("Error al conectar con el modulo SIM900.");
  }
  
  delay(1000);
}

void loop() {
  // Enviar comando AT para verificar la comunicación con el módulo SIM900
  sim900.println("AT");
  delay(1000);
  
  while (sim900.available()) {
    char c = sim900.read();
    Serial.write(c);
  }
  
  // Configurar el modo de texto para enviar mensajes SMS
  sim900.println("AT+CMGF=1");
  delay(1000);
  
  // Ingresar el número de teléfono al que se enviará el mensaje
  String numeroDestino = "+506xxxxxxxx"; // Reemplazar con el número de Costa Rica
  
  // Mensaje a enviar
  String mensaje = "Hola desde Arduino!";
  
  // Componer el comando para enviar el mensaje
  String comandoMensaje = "AT+CMGS=\"" + numeroDestino + "\"";
  
  // Enviar el comando para iniciar el mensaje
  sim900.println(comandoMensaje);
  delay(1000);
  
  // Enviar el contenido del mensaje
  sim900.println(mensaje);
  delay(100);
  
  // Enviar Ctrl+Z para finalizar el mensaje
  sim900.println((char)26);
  delay(1000);
  
  // Mostrar respuesta del módulo SIM900
  while (sim900.available()) {
    char c = sim900.read();
    Serial.write(c);
  }
  
  delay(5000); // Esperar antes de enviar otro mensaje
}
