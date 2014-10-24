//Code Courtesy of Samson Bonfante. Latest version as of 10/10/14
#ifndef _SERIAL_H_
#define _SERIAL_H_
#include <fcntl.h>
#include <sys/mman.h>
#include <unistd.h>
#include "defines.h"

int ReadSerial(char port);
/*Close the Serial device*/
void SerialExit();

#endif