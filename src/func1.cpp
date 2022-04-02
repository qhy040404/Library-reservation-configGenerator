//func1.cpp
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <cstdio>
#include <Windows.h>
#include <lmcons.h>
#include <LMat.h>
#include "func1.h"

#pragma comment(lib,"NETAPI32.LIB")

void Jobadd()
{
	DWORD JobID, ret;
	AT_INFO ai;
	char* filepath;
	long Len;
	char AppPath[MAX_PATH];
	WCHAR szFilePath[256];
	GetCurrentDirectoryA(MAX_PATH, AppPath);
	filepath = new char[strlen(AppPath) + 11];
	strcpy(filepath, AppPath);
	strcat(filepath, "\\run.bat");
	memset(&ai, 0, sizeof(ai));
	Len = MultiByteToWideChar(CP_ACP, 0, filepath, int(strlen(filepath)), szFilePath, (sizeof(szFilePath) / sizeof(WCHAR)));
	szFilePath[Len] = '\0';
	ai.Command = szFilePath;
	ai.DaysOfMonth = 0;
	ai.DaysOfWeek = 0;
	ai.Flags = JOB_NONINTERACTIVE;
	ai.JobTime = 6 * 60 * 60 * 1000 + 30 * 60 * 1000 + 5 * 1000;
	ret = NetScheduleJobAdd(NULL, LPBYTE(&ai), &JobID);
	if (ret == NERR_Success)
		std::cout << "添加成功" << std::endl;
	else
		std::cout << "添加失败" << std::endl;
}