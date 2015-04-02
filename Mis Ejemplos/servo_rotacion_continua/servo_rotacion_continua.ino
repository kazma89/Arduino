// Prueba de servos giro continuo
// bricolabs.cc
// Este codigo es de uso libre
 
 
#include <Servo.h>
Servo myservo; // Cremos el objeto de servo
const int speed0 = 90; // valor en el que el servo se mantiene quieto (es posible que haga falta variarlo un poco)
int i; // iterador
void setup()
{
myservo.attach(8); // attaches the servo on pin 9 to the servo object
}
void loop()
{
for(i = 0; i < 90; i++) // vamos desde velocidad 0 hasta velocidad 90 (maximo)
{
myservo.write(speed0 + i);
delay(15);
}
myservo.write(speed0);
delay(1000);
// sentido contrario
for(int i = 0; i < 90; i++) // vamos desde velocidad 0 hasta velocidad 90 (maximo)
{
myservo.write(speed0 - i);
delay(15);
}
myservo.write(speed0);
delay(1000);
} 
