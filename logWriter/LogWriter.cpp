// LogWriter.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "Log.h"
#include "Clock.h"
#include "Engine.h"
#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <ctime>

#pragma warning(disable : 4996).

using namespace std;

int main()
{
   Clock c;
   string input;
   int index;
   bool running = true;

   //UPDATED / CHANGE CODE HERE
   // ***********************************
   // ***********************************
   // ***********************************
   // ADD WHERE MASTER FOLDER IS
   // EX: Engine e("../Test Folder Data/log_master.txt");
   Engine e("logs_master.txt");
   // ***********************************
   // ***********************************
   // ***********************************
   // ADD TARGET LOGS HERE
   // EX: e.AddLog("name", "location.txt");
   e.AddLog("Art Assets Log", "art_assets/logs_artAssets.txt");
   e.AddLog("Documentation Log", "documentation/logs_documentation.txt");
   e.AddLog("Builds Log", "prototype/logs_builds.txt");
   e.AddLog("SFX Assets", "sfx_assets/logs_SFX.txt");
   // ***********************************
   // ***********************************
   // ***********************************

   e.GetUsername();
   while (running)
   {
	   Clock clock;
	   running = e.RunEngine();
   }
}
