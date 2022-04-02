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
	cout << "��ӭ����ͼ����Զ�ԤԼ����������" << endl;
	cout << "������ɺ������ļ����Զ����ɵ������Ŀ¼������Ҫ����ĸ��Ʋ���" << endl;
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
		//��ʼ�����·��
		char AppPath[MAX_PATH] = { 0 };
		GetCurrentDirectoryA(MAX_PATH, AppPath);
		string outPath = AppPath;
		outPath += "\\config.conf";
		//��ʼ������
		string user_id, area_name;
		int room_name = 0;
		string seats;
		//��ʼ����������
		const string validateLX("��ϣ");
		const string validateBC("����");
		int val1 = rand(), val2 = rand();
		int i = 0;
		bool success = false;
		bool multi = true;
		int user_count = 0;
		//��ʼ�������
		ofstream out;
		out.open(outPath.c_str());
		out << "# ���ļ�Ϊ�����ļ�����ȷ�ϴ��ļ������ڳ���Ŀ¼" << endl;
		while (multi == true)
		{
			//main
			cout << endl;
			cout << "���ȣ�������ѧ�ţ�";
			while (1)
			{
				cin >> user_id;
				if (user_id.size() == 9 || user_id.size() == 11)
				{
					break;
				}
				else
				{
					cout << endl << "ѧ��λ�����񲻶�Ŷ������һ�ΰɣ�";
				}
			}
			cout << endl << "Ȼ���������룺";
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
			cout << endl << "��������ȥ��ͼ��ݣ����ģ���";
			while (1)
			{
				cin >> area_name;
				val1 = area_name.compare(validateLX);
				val2 = area_name.compare(validateBC);
				if (val1 == 0)
				{
					cout << endl << "��ȥ�ĸ����䣨��֧�ֲ���3¥�������������������ң���ϣ2¥����";
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
							cout << endl << "���ͼ���û���������Ŷ�����������룺";
						}
					}
					break;
				}
				else if (val2 == 0)
				{
					cout << endl << "��ȥ�ĸ����䣨��֧�ֲ���3¥�������������������ң���ϣ2¥����";
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
							cout << endl << "���ͼ���û���������Ŷ�����������룺";
						}
					}
					break;
				}
				else
				{
					cout << endl << "ͼ�����������������������룺";
				}
			}
			cout << endl << "�õģ�������Ϣ�������" << endl;
			system("timeout 1 >nul");
			cout << endl << "��������������λ�����������룬��-����������3λ����λ������0���㣩��";
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
					cout << "��������������ϣ��������ɵ�ǰ�û��������ļ������Ժ�..." << endl;
					out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name << endl;
					out << seats.c_str() << endl;
					out << mail_user.c_str() << " " << mail_pass.c_str();
					break;
				}
				else if (ifMail == 78 || ifMail == 110)
				{
					system("cls");
					cout << "��������������ϣ��������ɵ�ǰ�û��������ļ������Ժ�..." << endl;
					out << user_id.c_str() << " " << password << " " << area_name.c_str() << " " << room_name << endl;
					out << seats.c_str();
					break;
				}
				else
				{
					cout << "�������" << endl;
				}
			}
			// �Ƿ����
			user_count++;
			while (1)
			{
				printf("��ǰ������ %d ���û�����\n", user_count);
				cout << "�Ƿ��������y/n��";
				int multiVal;
				multiVal = _getch();
				cout << char(multiVal);
				if (multiVal == 89 || multiVal == 121)
				{
					cout << endl << "���ڳ�ʼ��..." << endl;
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
					cout << "�������" << endl;
				}
			}
		}
		out.close();
		system("cls");
		cout << "�����ļ�������ϣ�" << endl;
		cout << "�����������ر�";
		system("timeout 3 >nul");
	}
	return 0;
}