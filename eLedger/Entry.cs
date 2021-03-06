using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace eLedger
{
    public class Entry
    {
        public int checkNo;
        public DateTime date;
        public string note;
        public bool isCredit; //True if credit, else debit and false
        public double amount;

        public Entry(int num, DateTime day, string info, bool credit, double amt)
        {
            checkNo = num;
            date = day;
            note = info;
            isCredit = credit;
            amount = amt;
        }

        public Entry(string num, string day, string info, string credit, string amount)
        {

        }
        public Entry()
        {

        }

        public string toString()
        {
            string cred;
            string check = "     ";
            if (isCredit)
                cred = "+";
            else
                cred = "-";
            if (checkNo != 0)
                check = checkNo.ToString();
            return date.Month.ToString("00") + "/" + date.Day.ToString("00") + " // " + cred + " // " + amount.ToString("F2",CultureInfo.InvariantCulture)
                + " // " + checkNo.ToString("0000") + " // " + note;
        }
    }
}