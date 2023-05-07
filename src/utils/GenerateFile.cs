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
            File.Create(path).Close();
        }
        public static bool DataAlreadyExists()
        {
            int linesCount = 0;
            StreamReader sr = new("config.conf");
            while (sr.ReadLine() != null)
            {
                linesCount++;
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
            FileStream fs = new("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new();
            sb.AppendLine(seats);
            tw.Write(sb.ToString());
            tw.Flush();
            tw.Close();
            fs.Close();
        }

        public static void WriteMailData(string mail, string mail_passwd)
        {
            FileStream fs = new("config.conf", FileMode.Append, FileAccess.Write);
            TextWriter tw = new StreamWriter(fs, Encoding.Default);
            StringBuilder sb = new();
            sb.AppendLine(mail + " " + mail_passwd);
            tw.Write(sb.ToString());
            tw.Flush();
            tw.Close();
            fs.Close();
        }
    }
}
