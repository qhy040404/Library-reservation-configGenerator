//check.cpp
#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>
#include <cstdio>
using namespace std;

int checkIfExists()
{
	//��ʼ��·��
	char AppPath[MAX_PATH] = { 0 };
	GetCurrentDirectoryA(MAX_PATH, AppPath);
	string outPath = AppPath;
	outPath += "\\config.conf";
	//��ʼ���������ļ���
	int exist_user_count = -1;
	const string val = "#";
	string currentData;
	ifstream existData;
	existData.open(outPath.c_str());
	//checkIfExists
	while (getline(existData, currentData));
	{
		string::size_type idx = currentData.find(val);
		if (idx != string::npos)
		{
			exist_user_count++;
		}
	}
	return exist_user_count;
}