
void setup() {
  Serial.begin(9600);
}

//Sends the Number 1234 Over the Serial Port Once Every Second
void loop() {
  Serial.write(1234);
  delay(1000);
}

