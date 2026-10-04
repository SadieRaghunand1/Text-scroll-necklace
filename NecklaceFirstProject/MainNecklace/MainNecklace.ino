#include <Arduino_GFX_Library.h>

#define LCD_SCLK 39
#define LCD_MOSI 38
#define LCD_MISO 40
#define LCD_DC 42
#define LCD_RST -1
#define LCD_CS 45
#define LCD_BL 1

#define LCD_ROTATION 1
#define LCD_H_RES 240
#define LCD_V_RES 320


Arduino_DataBus *bus = new Arduino_ESP32SPI(
  LCD_DC /* DC */, LCD_CS /* CS */,
  LCD_SCLK /* SCK */, LCD_MOSI /* MOSI */, LCD_MISO /* MISO */);

Arduino_GFX *gfx = new Arduino_ST7789(
  bus, LCD_RST /* RST */, LCD_ROTATION /* rotation */, true /* IPS */,
  LCD_H_RES /* width */, LCD_V_RES /* height */);


//Variables
char message[] = "Hello World!";
int textX;      // Tracks the current X position of the text
int minX;       // Stores the minimum boundaries where text completely goes off-screen
int scrollSpeed = 2; // Pixels to move per frame (higher = faster)

int textY;




void setup(void)
{

//Defintions
#define BLACK 0x0000
#define BLUE 0x001F
#define RED 0xF800



//Start
  Serial.begin(115200);

    // Start text off-screen right
  textX = 320;
  textY = 85;
  

#ifdef GFX_EXTRA_PRE_INIT
  GFX_EXTRA_PRE_INIT();
#endif

  // Init Display
  if (!gfx->begin())
  {
    Serial.println("gfx->begin() failed!");
  }
  gfx->fillScreen(BLACK);

#ifdef LCD_BL
  pinMode(LCD_BL, OUTPUT);
  digitalWrite(LCD_BL, HIGH);
#endif

  //Set initial text appearance
  gfx->setCursor(textX, textY);
  gfx->setTextColor(RED);
  gfx->setTextSize(5);
  gfx->setTextWrap(false);
  gfx->println(message);


  // Calculate the pixel boundary to reset text (approx 12 pixels wide per char at size 2)
  minX = -30 * strlen(message); 

}

void loop()
{

   gfx->fillScreen(BLACK);
  
  // Set current cursor coordinate
  gfx->setCursor(textX, textY); // Center vertically on 64px tall screen


  gfx->println(message);
  
  // Shift left
  textX -= scrollSpeed; 
  
  // Reset sequence when text disappears off the left edge
  if(textX < minX) {
    textX = 320; 
  }
  
  delay(10); // Smooth pacing frame rate
}

