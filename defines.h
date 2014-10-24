//Cannibalized a bunch of stuff from lms2012.h
//(C) Whoever wrote that shit.
//Stolen by Samson!
#pragma once
#define   TYPE_NAME_LENGTH    11
#define   INPUTS              4
#define   OUTPUTS             4
#define   UART_DEVICE_NAME    "/dev/lms_uart"
#define   SYMBOL_LENGTH       4
#define   MAX_DEVICE_MODES    8
#define   COLORS              4
#define   CALPOINTS           3
#define   DATA8_NAN     ((DATA8)(-128))

#define   DEVICE_LOGBUF_SIZE  300
#define   ANALOG_DEVICE         "lms_analog"          //!< ANALOG device name
#define   ANALOG_DEVICE_NAME    "/dev/lms_analog"     //!< ANALOG device file name
#ifndef   UART_DATA_LENGTH
#define   UART_DATA_LENGTH    32
#endif
#include  <asm/types.h>

typedef   signed char           SBYTE;  //!< Basic Type used to symbolise 8  bit signed values
typedef   unsigned short        UWORD;  //!< Basic Type used to symbolise 16 bit unsigned values
typedef   unsigned int          ULONG;  //!< Basic Type used to symbolise 32 bit unsigned values
typedef   SBYTE                 DATA8;  //!< VM Type for 1 byte signed value
typedef   float                 DATAF;  //!< VM Type for 4 byte floating point value
typedef   signed short          SWORD;  //!< Basic Type used to symbolise 16 bit signed values

typedef   SWORD                 DATA16; //!< VM Type for 2 byte signed value



/*! \struct TYPES
 *          Device type data
 */
typedef   struct // if data type changes - remember to change "cInputTypeDataInit" !
{
  SBYTE     Name[TYPE_NAME_LENGTH + 1]; //!< Device name
  DATA8     Type;                       //!< Device type
  DATA8     Connection;
  DATA8     Mode;                       //!< Device mode
  DATA8     DataSets;
  DATA8     Format;
  DATA8     Figures;
  DATA8     Decimals;
  DATA8     Views;
  DATAF     RawMin;                     //!< Raw minimum value      (e.c. 0.0)
  DATAF     RawMax;                     //!< Raw maximum value      (e.c. 1023.0)
  DATAF     PctMin;                     //!< Percent minimum value  (e.c. -100.0)
  DATAF     PctMax;                     //!< Percent maximum value  (e.c. 100.0)
  DATAF     SiMin;                      //!< SI unit minimum value  (e.c. -100.0)
  DATAF     SiMax;                      //!< SI unit maximum value  (e.c. 100.0)
  UWORD     InvalidTime;                //!< mS from type change to valid data
  UWORD     IdValue;                    //!< Device id value        (e.c. 0 ~ UART)
  DATA8     Pins;                       //!< Device pin setup
  SBYTE     Symbol[SYMBOL_LENGTH + 1];  //!< SI unit symbol
  UWORD     Align;
}
TYPES;

typedef   struct
{
  TYPES   TypeData[INPUTS][MAX_DEVICE_MODES]; //!< TypeData

#ifndef DISABLE_FAST_DATALOG_BUFFER
  UWORD   Repeat[INPUTS][DEVICE_LOGBUF_SIZE];
  DATA8   Raw[INPUTS][DEVICE_LOGBUF_SIZE][UART_DATA_LENGTH];      //!< Raw value from UART device
  UWORD   Actual[INPUTS];
  UWORD   LogIn[INPUTS];
#else
  DATA8   Raw[INPUTS][UART_DATA_LENGTH];      //!< Raw value from UART device
#endif
  DATA8   Status[INPUTS];                     //!< Status
  DATA8   Output[INPUTS][UART_DATA_LENGTH];   //!< Bytes to UART device
  DATA8   OutputLength[INPUTS];
}
UART;

typedef   struct
{
  ULONG   Calibration[CALPOINTS][COLORS];
  UWORD   CalLimits[CALPOINTS - 1];
  UWORD   Crc;
  UWORD   ADRaw[COLORS];
  UWORD   SensorRaw[COLORS];
}
COLORSTRUCT;

typedef   struct
{
  DATA16  InPin1[INPUTS];         //!< Analog value at input port connection 1
  DATA16  InPin6[INPUTS];         //!< Analog value at input port connection 6
  DATA16  OutPin5[OUTPUTS];       //!< Analog value at output port connection 5
  DATA16  BatteryTemp;            //!< Battery temperature
  DATA16  MotorCurrent;           //!< Current flowing to motors
  DATA16  BatteryCurrent;         //!< Current flowing from the battery
  DATA16  Cell123456;             //!< Voltage at battery cell 1, 2, 3,4, 5, and 6
#ifndef DISABLE_FAST_DATALOG_BUFFER
  DATA16  Pin1[INPUTS][DEVICE_LOGBUF_SIZE];      //!< Raw value from analog device
  DATA16  Pin6[INPUTS][DEVICE_LOGBUF_SIZE];      //!< Raw value from analog device
  UWORD   Actual[INPUTS];
  UWORD   LogIn[INPUTS];
  UWORD   LogOut[INPUTS];
#endif
#ifndef   DISABLE_OLD_COLOR
  COLORSTRUCT  NxtCol[INPUTS];
#endif
  DATA16  OutPin5Low[OUTPUTS];    //!< Analog value at output port connection 5 when connection 6 is low

  DATA8   Updated[INPUTS];

  DATA8   InDcm[INPUTS];          //!< Input port device types
  DATA8   InConn[INPUTS];

  DATA8   OutDcm[OUTPUTS];        //!< Output port device types
  DATA8   OutConn[OUTPUTS];
#ifndef DISABLE_PREEMPTED_VM
  UWORD   PreemptMilliSeconds;
#endif
}
ANALOG;
