Aca se encuentran los archivos que conforman el sistema del carro controlado por un dispositivo terminal Android.
El mecanismo consiste en:
	(1) Basic Chassis with gear motors and wheels
	(2) Arduino Leonardo
	(3) Motor Driver 1A Dual TB6612FNG
	(4) Stackable Bluetooth Shield v2.1 (Slave only)
	(3) Battery Holder - 4xAA Square
	(4) Breadboard Mini Modular (White)
	(5) Breadboard Jumper Wires 75 pack

En el primer archivo (Carro_BT.ino) es el sketch que se carga al Arduino (2) del carro, este posee la configuracion
inicial del modulo (4): pines de comunicacion (0=RX y 1=TX) SSID, el canal, contraseña. La configuracion del 
driver (3) en donde se asignan los pines: 3=velocidad motor A, 5=velocidad motor B, 8 y 9=Polaridad del motor A,
11 y 12=Polaridad del motor B y 10=Espera. En la funcion loop posee las condiciones de como se mueve el carro segun
las instrucciones que se le envian por medio de la aplicacion explicada mas adelante. Este recibe numeros del 1 al 5
para moverse en diferentes direcciones y poder frenar.