using System;
using System.Collections.Generic;
using System.Text;
using static eLedger.Account;
using static eLedger.FileManager;

namespace eLedger
{
    class Manager
    {
        private Account curAccount;
        private int numAccounts = 0;
        private string[] names = new string[20];
        private FileManager Accounts = new FileManager(@"D:\eLedger\accounts.txt");
        private AccountFileManager Entries;

        public Manager()
        {
            ReadAccounts();
        }

        public void ReadAccounts()
        {
            //load account info from file by mapping string to account
            //accounts file: lists the names of all the accounts
            //  A file named by each account: contains the account details, only load on selection

            names = Accounts.Read(names, ref numAccounts);
        }

        public void WriteAccounts()
        {
            Accounts.Write(names, numAccounts);
        }

        public int SetAccount(string name)
        {
            for (int i = 0; i < numAccounts; i++)
            {
                if (names[i] == name)
                {
                    ReadSingleAccount(name);
                    return i;
                }
            }
            return -1;
        }

        public void ReadSingleAccount(string name)
        {
            int count = 0;
            string[][] entry = new string[5][];
            String path = @"D:\eLedger\accounts\" + name + ".csv";
            Entries = new AccountFileManager(@"D:\eLedger\accounts\" + name + ".csv");
            curAccount = new Account(Entries.ReadBalance());
            entry = Entries.ReadEntries(ref count);

            for (int i = 0; i < count; i++)
            {
                curAccount.iniEntry(entry[i]);
            }
        }

        public double GetBalance()
        {
            return curAccount.bal;
        }

        public Account Order()
        {
            curAccount.orderEntries();
            return curAccount;
        }

        public void addEntry(int num, DateTime day, string info, bool credit, double amt)
        {
            curAccount.addEntry(num, day, info, credit, amt);
        }

        public void ValidateEntry(int i)
        {
            curAccount.ledger.Remove(curAccount.ledger[i]);
        }

        public void removeEntries(DateTime d)
        {
            curAccount.removeEntries(d);
        }

        public void WriteEntries()
        {
            Entries.Write(curAccount.bal, curAccount.ledger);
        }

        public void Delete(int i)
        {
            for (int j = i; j < numAccounts; j++)
            {
                names[j] = names[j + 1];
            }
            numAccounts--;
        }

        public void AddAccount(string name, double b)
        {
            names[numAccounts++] = name;
            string path = @"D:\eLedger\accounts\" + name + ".csv";
            Entries = new AccountFileManager(path);
            Entries.CreateNew(b);
        }

        public string[] getnames()
        {
            return names;
        }

        public int getLen()
        {
            return numAccounts;
        }

        //Probably broken because DateTime() most likely is not a null object
        public DateTime parseDate(string d)
        {
            DateTime day = new DateTime();
            try
            {
                day = DateTime.Parse(d);
            }
            catch (FormatException)
            {
            }
            return day;
        }

        //Amt -1: Couldn't parse
        //Amt -2: Negative, throw it away
        public double parseAmt(string a)
        {
            double amt;
            try
            {
                amt = double.Parse(a);
                if (amt < 0)
                    amt = -2;
            }
            catch (FormatException)
            {
                amt = -1;
            }
            return amt;
        }

        //num -1: Couldn't parse
        //num -2: Negative, throw it away
        public int parseCheck(string n)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(n);
                if (num < 0)
                    num = -2;
            }
            catch (FormatException)
            {
                num = -1;
            }
            return num;
        }

        //1 Credit
        //0 Debit
        //-1 Invalid/ Couldn't parse
        public int parseCredit(string c)
        {
            if (c == "+")
            {
                return 1;
            }
            else if (c == "-")
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
