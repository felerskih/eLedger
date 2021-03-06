using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace eLedger
{
    class AccountFileManager 
    {

        private string path;
        private StreamReader sr;
        private StreamWriter sw;


        public AccountFileManager(string p)
        {
           path = p;
        }

        //Opens the Account ledger and returns the balance
        public double ReadBalance()
        {
            double bal;
            sr = File.OpenText(path);
            bal = double.Parse(sr.ReadLine());
            sr.Close();

            return bal;
        }

        //Read in the Entries and close the ledger/reader
        public string[][] ReadEntries(ref int count)
        {
            string s = "";
            string[][] entry = new string[5][];
            sr = File.OpenText(path);
            sr.ReadLine(); //Read Bal
            while ((s = sr.ReadLine()) != null)
            {
                entry[count++] = s.Split(",");
            }
            sr.Close();
            return entry;
        }

        public void Write(double bal, List<Entry> entry)
        {
            sw = new StreamWriter(path);
            sw.WriteLine(bal);
            foreach (Entry e in entry)
            {
                sw.WriteLine(e.checkNo + "," + e.date + "," + e.note + "," + e.isCredit + "," + e.amount);
            }
            sw.Close();
        }

        public bool CreateNew(double bal)
        {
            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
                sw.WriteLine(bal);
                sw.Close();
                return true;
            }
            return false;
        }

        public void Delete()
        {
            File.Delete(path);
        }
    }
}