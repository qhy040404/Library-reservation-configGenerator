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
	cout << "��ӭ����ͼ����Զ�ԤԼ����������" << endl;
	cout << "������ɺ������ļ����Զ����ɵ������Ŀ¼������Ҫ����ĸ��Ʋ���" << endl;
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
		out << "# ���ļ�Ϊ�����ļ�����ȷ�ϴ��ļ������ڳ���Ŀ¼" << endl;
		cout << endl;
		cout << "���ȣ�������ѧ�ţ�";
		cin >> user_id;
		cout << "Ȼ���������룺";
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
		cout << "��������ȥ��ͼ��ݣ����ģ���";
		cin >> area_name;
		cout << "��ȥ�ĸ����䣨��֧�ֲ���3¥�������������������ң���ϣ2¥����";
		cin >> room_name;
		cout << endl << "�õģ�������Ϣ�������" << endl;
		system("timeout 1 >nul");
		cout << endl << "��������������λ�����������룬�Կո����������3λ����λ������0���㣩��";
		cin >> seats;
		cout << endl << "��λ�������" << endl;
		system("timeout 1 >nul");
		while (1)
		{
			cout << endl << "�Ƿ���Ҫ�ʼ����ѣ���Ҫ�밴y������Ҫ�밴n��";
			int ifMail;
			ifMail = _getch();
			cout << char(ifMail);
			if (ifMail == 89 || ifMail == 121)
			{
				string mail_user, mail_pass;
				cout << endl << endl << "�ʼ�����Լ��������Լ�" << endl;
				cout << "�����������ַ��Ŀǰֻ֧���������ʼ�QQ���䣩��";
				cin >> mail_user;
				cout << "��������Ȩ�루���ڸ�����smtp�����л�ȡ��Ȩ�룩��";
				cin >> mail_pass;
				system("cls");
				cout << "��������������ϣ��������������ļ������Ժ�..." << endl;
				out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name.c_str() << endl;
				out << seats.c_str() << endl;
				out << mail_user.c_str() << " " << mail_pass.c_str();
				out.close();
				system("timeout 1 >nul");
				cout << "������ϣ��������������Զ��رա�";
				system("timeout 3 >nul");
				break;
			}
			else if (ifMail == 78 || ifMail == 110)
			{
				system("cls");
				cout << "��������������ϣ��������������ļ������Ժ�..." << endl;
				out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name.c_str() << endl;
				out << seats.c_str();
				out.close();
				system("timeout 1 >nul");
				cout << endl << "������ϣ��������������Զ��رա�";
				system("timeout 3 >nul");
				break;
			}
			else
			{
				cout << "�������" << endl;
			}
		}
	}
	return 0;
}