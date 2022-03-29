#include <iostream>
#include <fstream>
#include <string>
#include <Windows.h>
#include <conio.h>
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
		return 0;//return 1;
	}
	else if (argc == 2)
	{
		char AppPath[MAX_PATH] = { 0 };
		GetCurrentDirectoryA(MAX_PATH, AppPath);
		string outPath = AppPath;
		outPath += "\\config.conf";
		string user_id, area_name, room_name;
		string seats;
		ofstream out;
		out.open(outPath.c_str());
		out << "# 此文件为配置文件，请确认此文件存在于程序目录" << endl;
		cout << endl;
		cout << "首先，请输入学号：";
		cin >> user_id;
		cout << "然后输入密码：";
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
		cout << "输入你想去的图书馆（中文）：";
		cin >> area_name;
		cout << "想去哪个房间（不支持伯川3楼大厅，伯川电子阅览室，令希2楼）：";
		cin >> room_name;
		cout << endl << "好的，基础信息设置完成" << endl;
		system("timeout 1 >nul");
		cout << endl << "接下来是期望座位（可连续输入，以空格隔开，不足3位的座位号需用0补足）：";
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
				cout << "所有数据输入完毕，正在生成配置文件，请稍后..." << endl;
				out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name.c_str() << endl;
				out << seats.c_str() << endl;
				out << mail_user.c_str() << " " << mail_pass.c_str();
				out.close();
				system("timeout 1 >nul");
				cout << "生成完毕！程序会在三秒后自动关闭。";
				system("timeout 3 >nul");
				break;
			}
			else if (ifMail == 78 || ifMail == 110)
			{
				system("cls");
				cout << "所有数据输入完毕，正在生成配置文件，请稍后..." << endl;
				out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name.c_str() << endl;
				out << seats.c_str();
				out.close();
				system("timeout 1 >nul");
				cout << endl << "生成完毕！程序会在三秒后自动关闭。";
				system("timeout 3 >nul");
				break;
			}
			else
			{
				cout << "输入错误" << endl;
			}
		}
	}
	return 0;
}