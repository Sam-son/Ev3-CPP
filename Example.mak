PROGRAM=wumpus
DOBJECTS=ev3_command.o ev3_lcd.o ev3_output.o ev3_timer.o serial_read.o ev3_button.o ev3_sound.o wumpusrobotmove.o SerialMove.o 
TOOLPREFIX=arm-none-linux-gnueabi-

all:: realclean $(DOBJECTS) $(PROGRAM)

download:: all

clean::
	

realclean:: clean
	rm -f $(PROGRAM)

FLAGS=

CC=$(TOOLPREFIX)gcc

# how to link executable
wumpus: wumpus.c
	$(CC) $(FLAGS) $< -o$@ ev3_command.o ev3_lcd.o ev3_output.o ev3_timer.o serial_read.o ev3_button.o ev3_sound.o wumpusrobotmove.o SerialMove.o 

# how to compile source
%.o: %.c
	$(CC) $(FLAGS) -c $< -o$@

