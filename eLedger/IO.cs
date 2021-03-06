using System;
using System.Collections.Generic;
using System.Text;
using static eLedger.Account;
using static eLedger.Manager;
using System.IO;
using System.Globalization;

namespace eLedger
{
    class IO
    {
        private static string welcomePrompt = "What action would you like to perform?\n(S)elect Account\n(A)dd Account\n" +
            "(R)emove Account\n(L)ist Accounts\nE(x)it";
        private static string invalid = "Not a valid command. Please enter a valid command from above.";
        
        private string command;
        private List<string> exit = new List<string> {"exit", "x" };
        private List<string> add = new List<string> { "add", "a" };
        private List<string> select = new List<string> {"select", "s" };
        private List<string> remove = new List<string> { "remove", "r" };
        private List<string> list = new List<string> { "list", "l" };
        private List<string> balance = new List<string> { "balace", "b" };
        private List<string> ledger = new List<string> { "ledger", "l" };
        private List<string> strike = new List<string> { "strike", "s" };
        private List<string> validate = new List<string> { "validate", "v" };
        private List<string> byDate = new List<string> { "date", "d" };
        private List<string> yes = new List<string> { "yes", "y" };
        private List<string> no = new List<string> { "no", "n" };

        Manager man = new Manager(); // Read in Files
        

        public void run()
        {
            Console.WriteLine(welcomePrompt);
            command = Console.ReadLine();
            command = command.ToLower();
            while(!exit.Contains(command))
            {
                if (select.Contains(command))
                {
                    selectAccount();
                }
                else if (add.Contains(command))
                {
                    addAccount();
                }
                else if (remove.Contains(command))
                {
                    removeAccount();
                }
                else if(list.Contains(command))
                {
                    List();
                }
                else
                    Console.WriteLine(invalid);
                //read a new command
                Console.WriteLine(welcomePrompt);
                command = Console.ReadLine();
                command = command.ToLower();
            }
            //save account info to file on exit
            man.WriteAccounts();
        }

        public void selectAccount()
        {
            string name;
            string command;
            int index;

            //Console.WriteLine("Choose from this list of accounts:");
            List();
            name = Console.ReadLine();
            index = man.SetAccount(name);
            
            if (index != -1)
            {
                Console.WriteLine("What would you like to do with that account\nSee (B)alance\nSee (L)edger\n(A)dd Entry\n(V)alidate An Entry\nValidate Entries by (D)ate\nE(x)it");
                command = Console.ReadLine();
                command = command.ToLower();
                while (!exit.Contains(command))
                {
                    if (balance.Contains(command))
                    {
                        double bal = man.GetBalance();
                        Console.WriteLine(man.GetBalance().ToString("F2", CultureInfo.InvariantCulture));
                    }
                    else if (ledger.Contains(command))
                    {
                        Account curAccount = man.Order();
                        Console.Out.WriteLine("Date // +/- // Amount // Check No // Notes // ID");
                        int i = 0;
                        foreach (Entry e in curAccount.ledger)
                        {
                            Console.Out.WriteLine(e.toString() + " // " + i++);
                        }
                    }
                    else if (add.Contains(command))
                    {
                        string info;
                        string cred;
                        string a;
                        string n;
                        string d;
                        DateTime day = new DateTime();
                        bool credit;
                        int c;
                        double amt;
                        int num;

                        Console.WriteLine("Date? Format dd/mm");
                        d = Console.ReadLine();
                        d += "/2000 00:00:00";
                        day = man.parseDate(d);

                        Console.WriteLine("Credit (+) or Debit (-)?");
                        cred = Console.ReadLine();
                        c = man.parseCredit(cred);
                        if (c == 1)
                        {
                            credit = true;
                        }
                        else if (c == 0)
                        {
                            credit = false;
                        }
                        else //-1
                        {
                            Console.WriteLine("Invalid Format.");
                            goto Loop;
                        }

                        Console.WriteLine("Amount?");
                        a = Console.ReadLine();
                        amt = man.parseAmt(a);
                        if (amt == -1)
                        {
                            Console.WriteLine("Invalid Format.");
                            goto Loop;
                        }
                        if (amt == -2)
                        {
                            Console.WriteLine("Amount can't be negative.");
                            goto Loop;
                        }

                        Console.WriteLine("Check Number?");
                        n = Console.ReadLine();
                        num = man.parseCheck(n);
                        if (num == -1)
                        {
                            Console.WriteLine("Invalid Format.");
                            goto Loop;
                        }
                        else if (num == -2)
                        {
                            Console.WriteLine("Negative numbers are not allowed.");
                            goto Loop;
                        }

                        if (d == null)
                        {
                            Console.WriteLine("Invalid Format.");
                            goto Loop;
                        }

                        Console.WriteLine("Any Notes?");
                        info = Console.ReadLine();

                        man.addEntry(num, day, info, credit, amt);
                    }
                    else if (strike.Contains(command))
                        ;//future use
                    else if (validate.Contains(command))
                    {
                        int vIndex = -1;
                        Account curAccount = man.Order();
                        Console.Out.WriteLine("Date // +/- // Amount // Check No // Notes // ID");
                        int i = 0;
                        foreach (Entry e in curAccount.ledger)
                        {
                            Console.Out.WriteLine(e.toString() + " // " + i++);
                        }

                        Console.WriteLine("Entry ID to Delete:");
                        vIndex = Int32.Parse(Console.ReadLine());
                        if (vIndex != -1)
                            man.ValidateEntry(vIndex);
                    }
                    else if (byDate.Contains(command))
                    {
                        string d;
                        DateTime day = new DateTime();
                        DateTime test = new DateTime();
                        Console.WriteLine("Date? Format dd/mm");
                        d = Console.ReadLine();
                        d += "/2000 00:00:00";
                        day = man.parseDate(d);
                        if (day == test)
                        {
                            Console.WriteLine("Invalid Format");
                            goto Loop;
                        }
                        man.removeEntries(day);
                    }
                    else
                        Console.WriteLine(invalid);
                Loop:
                    Console.WriteLine("What would you like to do with that account\nSee (B)alance\nSee (L)edger\n(A)dd Entry\n(V)alidate Entry\nValidate Entry by (D)ate\nE(x)it");
                    command = Console.ReadLine();
                    command = command.ToLower();
                }
                //Save updated values and close the file
                man.WriteEntries();
                
            }
            else
                Console.WriteLine("You don't have an account with that name.");
        }

        public void addAccount()
        {
            string addName;
            string addBal;
            double parsed;
            /*string response;    //for future use of adding ledger
            int loop = 0; // 0 continue looping, else break
            int num;
            string day;
            string info;
            bool credit;
            int amt;*/
            Console.WriteLine("What would you like to name the account?");
            addName = Console.ReadLine();
            if(man.SetAccount(addName) != -1)
                Console.WriteLine("The account already exists.");
            else
            {
                Console.WriteLine("What is the starting Balance?");
                addBal = Console.ReadLine();
                parsed = man.parseAmt(addBal);
                if (parsed == -1)
                    Console.WriteLine("Invalid Format.");
                else if (parsed == -2)
                    Console.WriteLine("Balance Can't be negative.");
                else
                    man.AddAccount(addName, parsed);
            }

            /* Add a ledger, for future use
            Console.WriteLine("Would you like to import a ledger? Y\n");
            response = Console.ReadLine();
            response = response.toLower();
            while (loop == 0)
            {
                if (yes.Contains(response))
                {
                    //add entry -- Future use
                    while(not eof)
                        get all entry details
                        create into Entry object
                        add to ledger
                }
                else if (no.Contains(response))
                {
                    loop = 1;
                }
                else
                    Console.WriteLine(invalid);
                Console.WriteLine("Add another entry?")

            }*/
        }

        void removeAccount()
        {
            string name;
            int loop = 0;
            Console.WriteLine("What is the name of the account you would like to remove? (Type exit to go back)");
            name = Console.ReadLine();
            while(loop != 1 && !exit.Contains(name))
            {
                int index = man.SetAccount(name);

                if (index != -1)
                {
                    man.Delete(index);
                    loop = 1;
                        
                }
                else
                    Console.WriteLine("That is not a valid account.");
                if (loop != 1)
                {
                    Console.WriteLine("What is the name of the account you would like to remove? (Type exit to go back)");
                    name = Console.ReadLine();
                }
            }
        }

        void List()
        {
            string[] names;
            int num;
            names = man.getnames();
            num = man.getLen();
            Console.WriteLine("You have the following accounts:");
            for (int i = 0; i < num; i++)
                Console.WriteLine(names[i]);
        }
    }
}
