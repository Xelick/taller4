int incli = 8;
  const int LEDPin = 3;        // pin para el LED
const int PIRPin = 7;         // pin de entrada (for PIR sensor)
 
int pirState = LOW;           // de inicio no hay movimiento
int val = 0;                  // estado del pin
const int x = A0;
const int y = A1;
const int button = 2;
 
int curX = 0;
int curY = 0;
int curB = 1;
void setup() {
  // put your setup code here, to run once:
  pinMode (incli,INPUT);
  pinMode(LEDPin, OUTPUT); 
  pinMode(PIRPin, INPUT);
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(button, INPUT);
  Serial.begin (9600);

 
  
}

void loop() {
  val = digitalRead(PIRPin);
   if (val == HIGH)   //si está activado
   { 
      digitalWrite(LEDPin, HIGH);  //LED ON
      if (pirState == LOW)  //si previamente estaba apagado
      {
        Serial.println("a");
        pirState = HIGH;
      }
   } 
   else   //si esta desactivado
   {
      digitalWrite(LEDPin, LOW); // LED OFF
      if (pirState == HIGH)  //si previamente estaba encendido
      {
        Serial.println("b");
        pirState = LOW;
      }
   }
  // put your main code here, to run repeatedly:
  
 if (digitalRead(incli) == HIGH) // if the switch is pressed
  {
    //Serial.println("L");
    Serial.write(0);
    //flush= espera a que termine de enviar la información completamente
    Serial.flush();
    delay(20);
  }
  else 
  {
    Serial.write(1);
    //flush= espera a que termine de enviar la información completamente
    Serial.flush();
    delay(20);
  }
  curX = analogRead(x);
  curY = analogRead(y);
  curB = digitalRead(button);
 
  if(analogRead(x) >=1000)
  {
    Serial.write(6);
    Serial.flush();
    //Serial.println(6);
    //delay(10);
  }else if(analogRead(x) <= 10)
  {
    Serial.write(4);
    Serial.flush();
    //Serial.println(4);
    //delay(10);
  }else if (analogRead(y) <= 10)
  {
    Serial.write(8);
    Serial.flush();
    //Serial.println(8);
   //delay(10);
  }else if (analogRead(y) >= 1000)
  {
    Serial.write(2);
    Serial.flush();
    //Serial.println(2);
    //delay(10);
  }else
  {
    Serial.write(0);
    Serial.flush();
    //Serial.println(0);
    //delay(10);
  }

  delay(10);
}
