using System.Text;

namespace ConfigGenerator.src.utils
{
    internal class GenerateFile
    {


        private static void InitializeFile()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "config.conf");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path);
        }
        public static bool DataAlreadyExists()
        {
            int linesCount = 0;
            string line;
            StreamReader sr = new("config.conf");
            line = sr.ReadLine();
            while (line != null)
            {
                linesCount++;
                line = sr.ReadLine();
            }
            sr.Close();
            return linesCount != 1;
        }
        public static void WriteBasicData(string user, string passwd, string area, string room, int count)
        {
            if (count == 1)
            {
                InitializeFile();
            }
            FileStream fs = new("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new();
            if (count == 1)
            {
                sb.AppendLine("# config.conf DO NOT DELETE!");
            }
            sb.AppendLine("# " + count);
            string row = user + " " + passwd + " " + area + " " + room;
            sb.AppendLine(row);
            tw.Write(sb.ToString());
            tw.Flush();
            tw.Close();
            fs.Close();
        }

        public static void WriteSeatsData(string seats)
        {
            FileStream fsd = new("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tsd = new StreamWriter(fsd, Encoding.Default);
            StringBuilder ssd = new();
            ssd.AppendLine(seats);
            tsd.Write(ssd.ToString());
            tsd.Flush();
            tsd.Close();
            fsd.Close();
        }

        public static void WriteMailData(string mail, string mail_passwd)
        {
            FileStream fmd = new("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tmd = new StreamWriter(fmd, Encoding.Default);
            StringBuilder smd = new();
            smd.AppendLine(mail + " " + mail_passwd);
            tmd.Write(smd.ToString());
            tmd.Flush();
            tmd.Close();
            fmd.Close();
        }
    }
}
