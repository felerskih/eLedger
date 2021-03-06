using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace eLedger
{
    class FileManager
    {
        private string path;
        private StreamReader sr;
        private StreamWriter sw;


        public FileManager(string p)
        {
            path = p;
            sr = File.OpenText(path);
        }

        public string[] Read(string[] names, ref int num)
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                names[num++] = s;
            }
            sr.Close();
            return names;
        }

        public void Write(string[] names, int num)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < num; i++)
            {
                sw.WriteLine(names[i]);
            }
            sw.Close();
        }
    }
}