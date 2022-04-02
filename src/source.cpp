//Using MBCS, not unicode.
#include <iostream>
#include <fstream>
#include <string>
#include <Windows.h>
#include <conio.h>
#include <cstdio>
//#include "func1.h"
using namespace std;

void ManagerRun(LPCSTR exe,LPCSTR param,INT nShow=SW_SHOW)
{
	SHELLEXECUTEINFO ShExecInfo;
	ShExecInfo.cbSize = sizeof(SHELLEXECUTEINFO);
	ShExecInfo.fMask = SEE_MASK_NOCLOSEPROCESS;
	ShExecInfo.hwnd = NULL;
	ShExecInfo.lpVerb = "runas";
	ShExecInfo.lpFile = (exe);
	ShExecInfo.lpParameters = param;
	ShExecInfo.lpDirectory = NULL;
	ShExecInfo.nShow = nShow;
	ShExecInfo.hInstApp = NULL;
	BOOL ret = ShellExecuteEx(&ShExecInfo);
	CloseHandle(ShExecInfo.hProcess);
	return;
}

void initialize()
{
	cout << "欢迎来到图书馆自动预约配置生成器" << endl;
	cout << "配置完成后，配置文件会自动生成到程序根目录，不需要额外的复制操作" << endl;
}

int main(int argc,char *argv[])
{
	if (argc == 1)
	{
		ShowWindow(GetConsoleWindow(), SW_HIDE);
		ManagerRun(argv[0], "2");
		return 1;
	}
	else if (argc == 2)
	{
		initialize();
		//初始化输出路径
		char AppPath[MAX_PATH] = { 0 };
		GetCurrentDirectoryA(MAX_PATH, AppPath);
		string outPath = AppPath;
		outPath += "\\config.conf";
		//初始化变量
		string user_id, area_name;
		int room_name = 0;
		string seats;
		//初始化其他变量
		const string validateLX("令希");
		const string validateBC("伯川");
		int val1 = rand(), val2 = rand();
		int i = 0;
		bool success = false;
		bool multi = true;
		int user_count = 0;
		//初始化输出流
		ofstream out;
		out.open(outPath.c_str());
		out << "# 此文件为配置文件，请确认此文件存在于程序目录" << endl;
		while (multi == true)
		{
			//main
			cout << endl;
			cout << "首先，请输入学号：";
			while (1)
			{
				cin >> user_id;
				if (user_id.size() == 9 || user_id.size() == 11)
				{
					break;
				}
				else
				{
					cout << endl << "学号位数好像不对哦，再输一次吧：";
				}
			}
			cout << endl << "然后输入密码：";
			char password[100];
			int index = 0;
			while (1)
			{
				char ch;
				ch = _getch();
				if (ch == 8)
				{
					if (index != 0)
					{
						cout << char(8) << " " << char(8);
						index--;
					}
				}
				else if (ch == '\r')//enter
				{
					password[index] = '\0';
					cout << endl;
					break;
				}
				else
				{
					cout << "*";
					password[index++] = ch;
				}
			}
			cout << endl << "输入你想去的图书馆（中文）：";
			while (1)
			{
				cin >> area_name;
				val1 = area_name.compare(validateLX);
				val2 = area_name.compare(validateBC);
				if (val1 == 0)
				{
					cout << endl << "想去哪个房间（不支持伯川3楼大厅，伯川电子阅览室，令希2楼）：";
					while (success == false)
					{
						cin >> room_name;
						int room_map[] = { 301,302,401,402,501,502,601,602 };
						for (i = 0; room_map[i] > 0; i++)
						{
							if (room_name == room_map[i])
							{
								success = true;
								break;
							}
						}
						if (success == false)
						{
							cout << endl << "这个图书馆没有这个房间哦，请重新输入：";
						}
					}
					break;
				}
				else if (val2 == 0)
				{
					cout << endl << "想去哪个房间（不支持伯川3楼大厅，伯川电子阅览室，令希2楼）：";
					while (success == false)
					{
						cin >> room_name;
						int room_map[] = { 301,312,401,404,409,501,504,507 };
						for (i = 0; room_map[i] > 0; i++)
						{
							if (room_name == room_map[i])
							{
								success = true;
								break;
							}
						}
						if (success == false)
						{
							cout << endl << "这个图书馆没有这个房间哦，请重新输入：";
						}
					}
					break;
				}
				else
				{
					cout << endl << "图书馆名字输错啦，请重新输入：";
				}
			}
			cout << endl << "好的，基础信息设置完成" << endl;
			system("timeout 1 >nul");
			cout << endl << "接下来是期望座位（可连续输入，以-隔开，不足3位的座位号需用0补足）：";
			cin >> seats;
			cout << endl << "座位输入完毕" << endl;
			system("timeout 1 >nul");
			while (1)
			{
				cout << endl << "是否需要邮件提醒？需要请按y，不需要请按n：";
				int ifMail;
				ifMail = _getch();
				cout << char(ifMail);
				if (ifMail == 89 || ifMail == 121)
				{
					string mail_user, mail_pass;
					cout << endl << endl << "邮件会从自己发送至自己" << endl;
					cout << "请输入邮箱地址（目前只支持网易普邮及QQ邮箱）：";
					cin >> mail_user;
					cout << "请输入授权码（请在各邮箱smtp设置中获取授权码）：";
					cin >> mail_pass;
					system("cls");
					cout << "所有数据输入完毕，正在生成当前用户的配置文件，请稍后..." << endl;
					out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name << endl;
					out << seats.c_str() << endl;
					out << mail_user.c_str() << " " << mail_pass.c_str();
					break;
				}
				else if (ifMail == 78 || ifMail == 110)
				{
					system("cls");
					cout << "所有数据输入完毕，正在生成当前用户的配置文件，请稍后..." << endl;
					out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name << endl;
					out << seats.c_str();
					break;
				}
				else
				{
					cout << "输入错误" << endl;
				}
			}
			// 是否多人
			user_count++;
			while (1)
			{
				printf("当前已输入 %d 个用户数据\n", user_count);
				cout << "是否继续？（y/n）";
				int multiVal;
				multiVal = _getch();
				cout << char(multiVal);
				if (multiVal == 89 || multiVal == 121)
				{
					cout << endl << "正在初始化..." << endl;
					success = false;
					out << endl;
					system("timeout 1 >nul && cls");
					break;
				}
				else if (multiVal == 78 || multiVal == 110)
				{
					multi = false;
					break;
				}
				else
				{
					cout << "输入错误" << endl;
				}
			}
		}
		out.close();
		system("cls");
		cout << "配置文件生成完毕！" << endl;
		cout << "程序将于三秒后关闭";
		system("timeout 3 >nul");
	}
	return 0;
}