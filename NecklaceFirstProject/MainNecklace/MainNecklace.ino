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


#define TFT_DC   41   
#define TFT_CS   40  
#define TFT_SCK  36   
#define TFT_MOSI 35 
#define TFT_MISO -1  
#define TFT_RST  42 
#define TFT_BL   48 


 /*Arduino_GFX try to find the settings depends on selected board in Arduino IDE
 * Or you can define the display dev kit not in the board list
 * Defalult pin list for non display dev kit:
 * ESP32-S3 various dev board  : CS: 40, DC: 41, RST: 42, BL: 48, SCK: 36, MOSI: 35, MISO: nil*/


Arduino_DataBus *bus = new Arduino_ESP32SPI(
    TFT_DC, TFT_CS, TFT_SCK, TFT_MOSI, TFT_MISO
);
Arduino_GFX *gfx = 
  new Arduino_ST7789(
    bus, 
    TFT_RST, 
    0 /* rotation: 0-3 */, 
    true /* IPS screen? true/false */, 
    LCD_H_RES /* width */, 
    LCD_V_RES /* height */
);
  //(bus, -1 /* RST */, LCD_ROTATION /*rotation*/, true /* IPS */,LCD_H_RES /*width*/, LCD_V_RES /*height*/);

void setup() {
  //Initialization


  //Serial.begin(115200);
  gfx->begin();
    //Backlight
  digitalWrite(LCD_BL, HIGH);
  //gfx->setRotation(0);
  //gfx->displayOn();

  //Design
  /*gfx->fillScreen(WHITE);
  gfx->setTextSize(2);
  gfx->setTextColor(MAGENTA);
  gfx->setCursor(50, 50);
  gfx->print("Hello World!");*/


  

}

void loop() {
  // put your main code here, to run repeatedly:

}
