#!/bin/bash

#Author: Cindy Chheng
#Course: CPSC223n
#Semester: Fall 2021
#Assignment: 1
#Due: September 4, 2021.

#This is a bash shell script to be used for compiling, linking, and executing the C sharp files of this assignment.
#Execute this file by navigating the terminal window to the folder where this file resides, and then enter the command: ./build.sh

#System requirements: 
#  A Linux system with BASH shell (in a terminal window).
#  The mono compiler must be installed.  If not installed run the command "sudo apt install mono-complete" without quotes.
#  The three source files and this script file must be in the same folder.
#  This file, build.sh, must have execute permission.  Go to the properties window of build.sh and put a check in the 
#  permission to execute box.


echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo Compile CircleInterface.cs to create the file: CircleInterface.dll
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:CircleInterface.dll CircleInterface.cs

echo Compile CircleMain.cs to create the file: CircleMain.dll
mcs -r:System -r:System.Windows.Forms -r:CircleInterface.dll -out:Circle.exe CircleMain.cs


echo View the list of files in the current folder
ls -l

echo Run the Assignment 1 program.
./Circle.exe

echo The script has terminated.
