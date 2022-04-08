using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigGenerator
{
    internal class GenerateFile
    {
        public static bool DataAlreadyExists()
        {
            int linesCount = 0;
            string line;
            StreamReader sr = new StreamReader("config.conf");
            line = sr.ReadLine();
            while (line != null)
            {
                linesCount++;
                line = sr.ReadLine();
            }
            sr.Close();
            if (linesCount == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void WriteBasicDataFirst(string user, string passwd, string area, string room)
        {
            FileStream fs = new FileStream("config.conf", FileMode.Create, FileAccess.Write);
            TextWriter tw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# config.conf DO NOT DELETE!");
            sb.AppendLine("# 1");
            string row = user + " " + passwd + " " + area + " " + room;
            sb.AppendLine(row);
            tw.Write(sb.ToString());
            tw.Flush();
            tw.Close();
            fs.Close();
        }

        public static void WriteSeatsData(string seats)
        {
            FileStream fsd = new FileStream("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tsd = new StreamWriter(fsd, Encoding.Default);
            StringBuilder ssd = new StringBuilder();
            ssd.AppendLine(seats);
            tsd.Write(ssd.ToString());
            tsd.Flush();
            tsd.Close();
            fsd.Close();
        }

        public static void WriteMailData(string mail, string mail_passwd)
        {
            FileStream fmd = new FileStream("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tmd = new StreamWriter(fmd, Encoding.Default);
            StringBuilder smd = new StringBuilder();
            smd.AppendLine(mail + " " + mail_passwd);
            tmd.Write(smd.ToString());
            tmd.Flush();
            tmd.Close();
            fmd.Close();
        }

        public static void WriteBasicData(string user, string passwd, string area, string room, int count)
        {
            FileStream fs = new FileStream("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# " + count);
            string row = user + " " + passwd + " " + area + " " + room;
            sb.AppendLine(row);
            tw.Write(sb.ToString());
            tw.Flush();
            tw.Close();
            fs.Close();
        }
    }
}
