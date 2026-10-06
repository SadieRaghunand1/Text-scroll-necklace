#include <Arduino_GFX_Library.h>
#include <TouchDrv.hpp>
#include "TAMC_GT911.h"
#include <bb_captouch.h>

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

////////////
#pragma region Colors

#define BLACK 0x0000
#define BLUE 0x001F
#define RED 0xF800
#define WHITE 0xffff
#define LBLUE 0x7e3f
#define DBLUE 0x1239
#define YELLOW 0xffe0
#define LYELLOW 0xfff2
#define PINK 0xfc3f
#define DRED 0x7800
#define ORANGE 0xfc40
#define BLUEGRAY 0x8518
#define GRAY 0x8c71
#define PURPLE 0x821f
#define GREEN 0x0fe0
#define DPURPLE 0x4817


#pragma endregion
//////////////

const int freq = 50000;
const int channel = 0;
const int resolution = 8;



//Object definitions
Arduino_DataBus *bus = new Arduino_ESP32SPI(
  LCD_DC /* DC */, LCD_CS /* CS */,
  LCD_SCLK /* SCK */, LCD_MOSI /* MOSI */, LCD_MISO /* MISO */);

Arduino_GFX *gfx = new Arduino_ST7789(
  bus, LCD_RST /* RST */, LCD_ROTATION /* rotation */, true /* IPS */,
  LCD_H_RES /* width */, LCD_V_RES /* height */);

//Touch variables
static BBCapTouch touch;
bool isTouched = false;

//Variables
int messageIndex;
int textX;      // Tracks the current X position of the text
int minX;       // Stores the minimum boundaries where text completely goes off-screen
int scrollSpeed = 2; // Pixels to move per frame (higher = faster)

int textY;

//Color collections
char messagePool[][100] = 
{
  {"Hello World!"}, //Text white, black bg
  {":<"}, //Text light blue, blue bg
  {":D"}, //Text black, yellow bg
  {"(＾v＾)"}, //Does not work //Text blue, light yellow bg
  {";)"}, //Text pink, dark red bg
  {"(＃ ` O `)"}, //Does not work //Text light orange, red bg
  {"(o^o)"}, //Text dark blue, light blue/gray bg
  {"(O_O)"}, //Text grey, bg white
  {"(＠_＠)"}, //Text purple, green bg
  {"<3"}, //Text dark red, light pink bg
  {"(-_-) zzZ"}, //Text white, dark purple bg
  {"(X_X)"} //Text green, black bg
};

//Store colors, first index is equal to # of messages, second should be 2 where first element in that row is text color, and second is background color
//PROBLEM! TEXT IS ALWAYS whatever messageIndex is initialized to!
uint16_t textBGColors[][2] = 
{
  {WHITE, BLACK},
  {LBLUE, BLUE},
  {BLACK, YELLOW},
  {BLUE, LYELLOW},
  {PINK, DRED},
  {BLACK, RED},
  {DBLUE, BLUEGRAY},
  {GRAY, WHITE},
  {PURPLE, GREEN},
  {DRED, PINK},
  {WHITE, DPURPLE},
  {GREEN, BLACK}
};

//Change text on tap
void ChangeMessage()
{
  int i = (sizeof(messagePool) / sizeof(messagePool[0])) - 1;
  if(messageIndex == i)
  {
    messageIndex = 0;
  }
  else
    messageIndex++;

  gfx->setTextColor(textBGColors[messageIndex][0]);
}


#pragma region Non-custom functions
void setup(void)
{

//Defintions
/*#define BLACK 0x0000
#define BLUE 0x001F
#define RED 0xF800*/


//Start
  Serial.begin(115200);

    // Start text off-screen right
  textX = 320;
  textY = 85;
  messageIndex = -1;

#ifdef GFX_EXTRA_PRE_INIT
  GFX_EXTRA_PRE_INIT();
#endif

  // Init Display
  if (!gfx->begin())
  {
    Serial.println("gfx->begin() failed!");
  }
  gfx->fillScreen(textBGColors[messageIndex][1]);

#ifdef LCD_BL
  pinMode(LCD_BL, OUTPUT);
  digitalWrite(LCD_BL, HIGH);
#endif

  //Set initial text appearance
  gfx->setCursor(textX, textY);
  gfx->setTextColor(textBGColors[messageIndex][0]);
  gfx->setTextSize(5);
  gfx->setTextWrap(false);
  //gfx->println(messagePool[messageIndex]);

  //Init touch
  touch.init(48, 47, -1, -1, 400000);
  touch.setOrientation(0, LCD_H_RES, LCD_V_RES);


  // Calculate the pixel boundary to reset text (approx 12 pixels wide per char at size 2)
  minX = -30 * strlen(messagePool[messageIndex]); 
  ChangeMessage();

}

void loop()
{

   gfx->fillScreen(textBGColors[messageIndex][1]);
  
  // Set current cursor coordinate
  gfx->setCursor(textX, textY); // Center vertically on 64px tall screen


  gfx->println(messagePool[messageIndex]);
  
  // Shift left
  textX -= scrollSpeed; 
  
  // Reset sequence when text disappears off the left edge
  if(textX < minX) {
    textX = 320; 
  }


  //Detect Touch
  TOUCHINFO ti;
   if (touch.getSamples(&ti) && ti.count > 0 && !isTouched) 
   {
    ChangeMessage();
    isTouched = true;
   }
   else {
    isTouched = false;
   }
  
  delay(10); // Smooth pacing frame rate
 
}
#pragma endregion 




