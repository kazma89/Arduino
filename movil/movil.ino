#include <SoftwareSerial.h>

SoftwareSerial sim900(7, 8); // RX, TX (conexión a la tarjeta ICOM SAT 1.1)

void setup() {
  Serial.begin(9600);
  sim900.begin(9600);

  Serial.println("Configurando modulo SIM900...");
  delay(2000);

  // Ingresar el número PIN de la tarjeta SIM
  String pinSIM = "1234"; // Reemplazar con tu número PIN

  // Ingresar el número de teléfono al que se enviará el mensaje
  String numeroDestino = "+506xxxxxxxx"; // Reemplazar con el número de Costa Rica

  // Mensaje a enviar
  String mensaje = "Mensaje de prueba...";
  
  // Enviar comando AT+CPIN para desbloquear la tarjeta SIM
  sim900.print("AT+CPIN=");
  sim900.println(pinSIM);
  delay(1000);

  // Verificar la respuesta del módulo SIM900
  while (sim900.available()) {
    char c = sim900.read();
    Serial.write(c);
  }
  
  delay(1000);
}

void loop() {
  // Configurar el modo de texto para enviar mensajes SMS
  sim900.println("AT+CMGF=1");
  delay(1000);
  
  // Componer el comando para enviar el mensaje
  String comandoMensaje = "AT+CMGS=\"" + numeroDestino + "\"";
  
  // Enviar el comando para iniciar el mensaje
  sim900.println(comandoMensaje);
  delay(1000);
  
  // Enviar el contenido del mensaje
  sim900.print(mensaje);
  sim900.write((char)26); // Enviar Ctrl+Z para finalizar el mensaje
  delay(1000);
  
  // Mostrar respuesta del módulo SIM900
  while (sim900.available()) {
    char c = sim900.read();
    Serial.write(c);
  }
  
  delay(5000); // Esperar antes de enviar otro mensaje
}
