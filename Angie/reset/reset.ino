int boton = 2;

void setup() {
  // put your setup code here, to run once:
  pinMode(12,OUTPUT);
  pinMode(boton,INPUT); 
}

void loop() {
  // put your main code here, to run repeatedly:
  if(boton==LOW){
    digitalWrite(12,HIGH);
  }
  else{
    digitalWrite(12,LOW);
  }
}
