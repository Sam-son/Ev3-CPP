//Code Courtesy of Samson Bonfante. Latest version as of 10/10/14
#ifndef serial_read_h
#define serial_read_h
#include <fcntl.h>
#include <stdio.h>
#include <sys/mman.h>
#include <unistd.h>
#include "defines.h"

UART *pUart;

/*Open the serial device for later reading*/
int SerialInit();
/*Read the value of a Sensor*/
int ReadSerial(char port);
/*Close the Serial device*/
void SerialExit();
#endif
