using System;
using System.Collections.Generic;
using System.Text;
using static eLedger.Entry;

namespace eLedger
{
    public class Account
    {
        public double bal;
        public List<Entry> ledger = new List<Entry>();

        public Account(double b)
        {
            bal = b;
        }

        public Account(double b, List<Entry> l)
        {
            bal = b;
            ledger = l;
        }

        //Assumes proper format since coming from a file
        //0-checkno 1-date 2-note 3-isCredit 4-amount
        public void iniEntry(string[] e)
        {
            ledger.Add(new Entry(int.Parse(e[0]), DateTime.Parse(e[1]), e[2], bool.Parse(e[3]), double.Parse(e[4])));
        }
 
        public void addEntry(int num, DateTime day, string info, bool credit, double amt)
        {
            Entry temp = new Entry(num, day, info, credit, amt);
            ledger.Add(temp);

            if (credit)
                bal += amt;
            else
                bal -= amt;
        }

        public void removeEntries(DateTime date)
        {
            bool through = false;
            while (!through)
            {
                foreach (Entry e in ledger)
                {
                    if (e.date <= date)
                    {
                        ledger.Remove(e);
                        break;
                    }
                    if (e == ledger[ledger.Count - 1])
                        through = true;
                }
            }
        }

        public void orderEntries()
        {
            Entry temp = new Entry();
            Entry cur = new Entry();
            if (ledger.Count > 1)
            {
                for (int i = 0; i < ledger.Count; i++)
                {
                    for (int j = i; j < ledger.Count; j++)
                    {
                        if (ledger[i].date > ledger[j].date)
                        {
                            temp = ledger[i];
                            ledger[i] = ledger[j];
                            ledger[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
