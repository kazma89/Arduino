
void setup() {
  // put your setup code here, to run once:
  pinMode(12,OUTPUT);
  pinMode(2,INPUT); 
}

void loop() {
  // put your main code here, to run repeatedly:
 int estado = digitalRead(2); 
  if(estado==LOW){
    digitalWrite(12,HIGH);
  }
  else{
    digitalWrite(12,LOW);
  }
}
