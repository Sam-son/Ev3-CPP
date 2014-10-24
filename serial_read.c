#include "serial_read.h"
int SerialInit()
{
 int file;
 //Open the device file
 if((file = open(UART_DEVICE_NAME, O_RDWR | O_SYNC)) == -1)
 {
  perror("Failed to open device");
  return 0;                                               /*File error! Serial might be open somehow.*/
 }
 //The next line will put the serial data in memory. UART is a nicely formatted Struct to make it easy to get specific parts of the serial data stream
 pUart  =  (UART*)mmap(0, sizeof(UART), PROT_READ | PROT_WRITE, MAP_FILE | MAP_SHARED, file, 0);
 if (pUart == MAP_FAILED)
 {
  perror("Failed to map device");
  return 0;                                               /*Memory Mapping error.*/
 }
 return 1;
}
//In ReadSerial, we take in a port number and the serial stream in memory, pointed to by pUart.
//We use the nice format of the struct to return the raw value of the sensor at the requested port.
//For more information on the UART struct, look at defines.h
int ReadSerial(char port)
{
 unsigned char LSB = (unsigned char)(pUart->Raw[(port-1)][pUart->Actual[(port-1)]][0]); //The 8 Least-Significant bits of our return value are stored here.
 unsigned char MSB = (unsigned char)(pUart->Raw[(port-1)][pUart->Actual[(port-1)]][1]) & 0x7; //The three most-significant bytes of the return value are the 3 LSB of the next byte of memory.
 short rtn = MSB << 8; //Assuming short is 16 bit, rtn = 0000 0MMM 0000 0000 where MMM are the values in MSB
 rtn |= LSB; //rtn= 0000 0MMM LLLL LLLL
 return rtn;
}

void SerialExit()
{
 munmap(pUart,sizeof(UART));                                  //Finished with the serial ports so we close them up
}
