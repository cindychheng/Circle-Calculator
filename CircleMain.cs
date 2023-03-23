//Author: Cindy Chheng
//Mail: cindychheng@csu.fullerton.edu

//Program name: Circle Calculator
//Programming language: C Sharp

//Purpose:  This program will compute a circle's area and surface area using the radius inputted by the user.

//Files in project: FCircleInterface.cs  CircleMain.cs  build.sh

//This file's name: CircleMain.cs
//This file purpose: This file is circle's main.

//To compile CircleInterface.cs:
//     mcs -r:System -r:System.Windows.Forms -r:CircleInterface.dll -out:Circle.exe CircleMain.cs

//Function: The Circle Calculator.  Enter a non-negative sequence integer in the input field, then
//click on the compute button, and the result will appear as a string.


using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class CircleMain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the the Circle Calculator!");
    CircleInterface circleApp = new CircleInterface();
    Application.Run(circleApp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of CircleMain
