#include "Ev3.h"
#include <iostream>
int main()
{
	Robot.SetSensor(1,'Light');
	std::cout << "Reading: " <<Robot.Read(1);
	Robot.Write("Preparing to go forward!");	//Show some text on the screen
	Robot.Motor('A',100); //Motor A on to 100% power
	Sleep(1000);	//Sleep for 1 second
	Robot.Motor('A',0);	//Motor A to 0% power.
	return 0;
}