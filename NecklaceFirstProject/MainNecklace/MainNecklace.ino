#include <Arduino_GFX_Library.h>

#define LCD_ROTATION 1
#define LCD_H_RES 240
#define LCD_V_RES 320
#define LCD_BL 1


#define BLACK 0x0000
#define BLUE 0x001F
#define RED 0xF800
#define GREEN 0x07E0
#define CYAN 0x07FF
#define MAGENTA 0xF81F
#define YELLOW 0xFFE0
#define WHITE 0xFFFF



Arduino_DataBus *bus = new Arduino_ESP32SPI(42 /* DC */, 45 /* CS */,39 /* SCK */, 38 /* MOSI */, 40 /* MISO */);
Arduino_GFX *gfx = new Arduino_ST7789(bus, -1 /* RST */, LCD_ROTATION /*rotation*/, true /* IPS */,LCD_H_RES /*width*/, LCD_V_RES /*height*/);

void setup() {
  //Initialization


  Serial.begin(115200);
    //Backlight
  digitalWrite(LCD_BL, HIGH);
  gfx->setRotation(0);
  gfx->displayOn();

  //Design
  gfx->fillScreen(WHITE);
  gfx->setTextSize(2);
  gfx->setTextColor(MAGENTA);
  gfx->setCursor(50, 50);
  gfx->print("Hello World!");


  

}

void loop() {
  // put your main code here, to run repeatedly:

}
