//Author: Cindy Chheng
//Mail: cindychheng@csu.fullerton.edu

//Program name: Circle Calculator
//Programming language: C Sharp

//Purpose:  This program will compute a circle's area and surface area using the radius inputted by the user.

//Files in project: FCircleInterface.cs  CircleMain.cs  build.sh

//This file's name: CircleInterface.cs
//This file purpose: This file builds the interface.

//To compile CircleInterface.cs:
//     mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:CircleInterface.dll CircleInterface.cs

//Function: The Circle Calculator.  Enter a non-negative sequence integer in the input field, then
//click on the compute button, and the result will appear as a string.


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class CircleInterface: Form {
    private Panel headerPanel = new Panel();
    private Label welcome = new Label();
    private Label author = new Label();
    private Panel displayPanel = new Panel();
    private Label question = new Label();
    private TextBox input = new TextBox();
    private Label circumferenceOutput = new Label();
    private Label surfaceAreaOutput = new Label();
    private Panel controlPanel = new Panel();
    private Button compute = new Button();
    private Button clear = new Button();
    private Button exit = new Button();
    private Size maxInterfaceSize = new Size(1024,800);
    private Size minInterfaceSize = new Size(1024,800);
    private enum Status {Initial_display,Successful_calculation,Error};
    private enum Execution_state {Executing, Waiting_to_terminate};             //<== New in version 2.2
    private Execution_state current_state = Execution_state.Executing;
    private static System.Timers.Timer exit_clock = new System.Timers.Timer();  //<== New in version 2.2

public CircleInterface() {
    // Max and Min interface size
    MaximumSize = maxInterfaceSize;
    MinimumSize = minInterfaceSize;

    // Set text
    Text = "Circle Calculator";
    welcome.Text = "Welcome to the Circle Calculator!";
    author.Text = "By: Cindy Chheng";
    question.Text = "Enter a radius: ";
    circumferenceOutput.Text = "The circumference will be displayed here: ";
    surfaceAreaOutput.Text = "The surface area will be displayed here: ";
    compute.Text = "Compute";
    clear.Text = "Clear";
    exit.Text = "Exit";

    // Set sizes
    Size = new Size(400,240);
    welcome.Size = new Size(800,44);
    author.Size = new Size(320,34);
    question.Size = new Size(400,36);
    input.Size = new Size(200,30);
    circumferenceOutput.Size = new Size(800,80);   
    surfaceAreaOutput.Size = new Size(800,80);   
    compute.Size = new Size(140,60);
    clear.Size = new Size(140,60);
    exit.Size = new Size(140,60);
    headerPanel.Size = new Size(1024,150);
    displayPanel.Size = new Size(1024,500);
    controlPanel.Size = new Size(1024,200);

    // Set colors
    headerPanel.BackColor = Color.PaleGreen;
    displayPanel.BackColor = Color.Thistle;
    controlPanel.BackColor = Color.SkyBlue;
    compute.BackColor = Color.MediumTurquoise;
    clear.BackColor = Color.MediumOrchid;
    exit.BackColor = Color.LightCoral;

    // Set fonts
    welcome.Font = new Font("Calibri",27,FontStyle.Bold);
    author.Font = new Font("Calibri",20,FontStyle.Regular);
    question.Font = new Font("Calibri",25,FontStyle.Regular);
    input.Font = new Font("Calibri",25,FontStyle.Regular);
    circumferenceOutput.Font = new Font("Calibri",20,FontStyle.Regular);
    surfaceAreaOutput.Font = new Font("Calibri",20,FontStyle.Regular);
    compute.Font = new Font("Calibri",18,FontStyle.Regular);
    clear.Font = new Font("Calibri",18,FontStyle.Regular);
    exit.Font = new Font("Calibri",18,FontStyle.Regular);

    // Set position of text
    welcome.TextAlign = ContentAlignment.MiddleCenter;
    author.TextAlign = ContentAlignment.MiddleCenter;
    question.TextAlign = ContentAlignment.MiddleLeft;
    circumferenceOutput.TextAlign = ContentAlignment.MiddleLeft;
    surfaceAreaOutput.TextAlign = ContentAlignment.MiddleLeft;

   //Set locations 
    welcome.Location = new Point(112,26);
    author.Location = new Point(330,85);
    question.Location = new Point(100,100);
    input.Location = new Point(600,100);
    circumferenceOutput.Location = new Point(100,200);
    surfaceAreaOutput.Location = new Point(100,350);
    compute.Location = new Point(150,50);
    clear.Location = new Point(450,50);
    exit.Location = new Point(750,50);
    headerPanel.Location = new Point(0,0);
    displayPanel.Location = new Point(0,100);
    controlPanel.Location = new Point(0,600);

    //Associate the Compute button with the Enter key of the keyboard
    AcceptButton = compute;

    //Add controls to the form
    Controls.Add(headerPanel);
    headerPanel.Controls.Add(welcome);
    headerPanel.Controls.Add(author);
    Controls.Add(displayPanel);
    displayPanel.Controls.Add(question);
    displayPanel.Controls.Add(input);
    displayPanel.Controls.Add(circumferenceOutput);
    displayPanel.Controls.Add(surfaceAreaOutput);
    Controls.Add(controlPanel);
    controlPanel.Controls.Add(compute);
    controlPanel.Controls.Add(clear);
    controlPanel.Controls.Add(exit);

    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
    compute.Click += new EventHandler(computeCircle);
    clear.Click += new EventHandler(cleartext);
    exit.Click += new EventHandler(stoprun);  //The '+' is required.

    //Configure the clock that controls the shutdown    
    exit_clock.Enabled = false;     //Clock is turned off at start program execution.
    exit_clock.Interval = 3500;     //3500ms = 3.5seconds.  Clock will tick at intervals of 3.5 seconds
    exit_clock.Elapsed += new ElapsedEventHandler(shutdown);   //Attach a method to the clock.

    //Open this user interface window in the center of the display.
    CenterToScreen();

   }//End of constructor CircleInterface

protected void computeCircle(Object sender, EventArgs events)
   {double radius;        //Formerly: uint sequencenum;
    string output1;
    string output2;
    try
       {radius = int.Parse(input.Text);
        if(radius < 0)
            {Console.WriteLine("Negative integer input received.  Please try again.");
             output1 = "Negative integer received.  Please try again.";
             output2 = "Negative integer received.  Please try again.";
            }
        else
            {   
                double circumference = 0;
                circumference = 2 * 3.14 * radius;  
                output1 = "The circumference will be displayed here:    " + circumference;
                
                double surfaceArea = 0;
                surfaceArea = 3.14 * radius * radius;
                output2 = "The surface area will be displayed here:    " + surfaceArea;
            }
        }
    //End of try

   catch(FormatException malformed_input)
       {Console.WriteLine("Non-integer input received.  Please try again.\n{0}",malformed_input.Message);
        output1 = "Invalid input: No computations made.";
        output2 = "Invalid input: No computations made.";
       }//End of catch
     catch(OverflowException too_big)
       {Console.WriteLine("The value inputted is greater than the largest 32-bit integer.  Try again.\n{0}",too_big.Message);
        output1 = "The input number was too large for 32-bit integers.";
        output2 = "The input number was too large for 32-bit integers.";
       }//End of catch
    circumferenceOutput.Text = output1;
    surfaceAreaOutput.Text = output2;
    displayPanel.Invalidate();
   }//End of computefibnumber
   
 //Method to execute when the clear button receives an event, namely: receives a mouse click
 protected void cleartext(Object sender, EventArgs events)
   {input.Text = ""; //Empty string
    circumferenceOutput.Text = "Result will display here.";
    surfaceAreaOutput.Text = "Result will display here.";
    displayPanel.Invalidate();
   }//End of cleartext

//Method to execute when the exit button receives an event, namely: receives a mouse click  <== New in version 2.2
protected void stoprun(Object sender, EventArgs events)
   {switch(current_state)
    {case Execution_state.Executing:
             exit_clock.Interval= 3500;     
             exit_clock.Enabled = true;
             exit.Text = "Resume";
             exit.BackColor = Color.LightSlateGray;
             current_state = Execution_state.Waiting_to_terminate;
             break;
     case Execution_state.Waiting_to_terminate:
             exit_clock.Enabled = false;
             exit.Text = "Quit";
             exit.BackColor = Color.LightCoral;
             current_state = Execution_state.Executing;
             break;
     }//End of switch statement
  }//End of method stoprun.  In C Sharp language "method" means "function".

protected void shutdown(System.Object sender, EventArgs even)                   //<== Revised for version 2.2
    {//This function is called when the clock makes its first "tick", 
     //which occurs 3.5 seconds after the clock starts.
     Close();       //That means close the main user interface window.
    }//End of method shutdown

}


