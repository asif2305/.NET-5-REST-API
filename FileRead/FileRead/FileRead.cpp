// FileRead.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<fstream>
#include<string>
#include <sstream>
#include "matplotlibcpp.h"
using namespace std;
int main()
{
   

    string line;
    string a, b,c;
    ifstream inputfile("C:/Users/Asif/Desktop/sensor_data/1.txt");

    //Defining the loop for getting input from the file

    while (getline(inputfile, line)) {
        istringstream ss(line);
        if (ss >> a >> b >> c)
        {
           // lider.push_back(stod(b));
            //rader.push_back(stod(c));
        }
    }
   /* for (int i = 0;i < lider.size();i++) {
        cout << lider.at(i)<<endl;
    }*/

   

   
    return 0;
}
