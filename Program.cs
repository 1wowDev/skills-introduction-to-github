// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
namespace taskmanager
{
    public class Info
    {
        public DateTime creationDate;
        public DateTime doDate = DateTime.MaxValue;
        public int Priority = 10;
        public string  message = "message is empty";
        public string title = "title is empty";
        public string stats = "pending";
        public Info(string? t, string? m, string? stat, int p, DateTime d)
        {

            if (p > 0 && p < 10)
                this.Priority = p;

            this.creationDate = DateTime.Now;

            if (m.Length < 1024 && m.Length > 0)
                this.message = m;
            else
                Console.WriteLine("message is TLDR");

            if (t.Length < 64 && t.Length>0)
                this.title = t;
            else
                Console.WriteLine("boring title");

            if (d < DateTime.Now)
                Console.WriteLine("invalid time");
            else
                this.doDate = d;
            if (stat.Length !=0)
            this.stats = stat;

        }


    }
    public static class Taskm
    {
        private static int NumOfTask;
        private static readonly List<Info> taskList = new();


        public static void Welcom()
        {
            Console.WriteLine("options..");
            Console.WriteLine("1: add task");
            Console.WriteLine("2:edit a task ");
            Console.WriteLine("3:view a task ");
            Console.WriteLine("4:view all tasks");
            Console.WriteLine("5:save data");
            Console.WriteLine("6:remove a task");
            Console.WriteLine("7:remove on condtion");
            Console.WriteLine("9:close program");
        }


        public static void View()
        {
            Console.WriteLine("view all task");
            Console.WriteLine("1:priority");
            Console.WriteLine("2: date of creation");
            Console.WriteLine("3:do date");
            Console.WriteLine("4:abc");
            Console.WriteLine("5:stats");
            string? option = Console.ReadLine();
            
            if (int.TryParse(option, out int Op))
            {
                Display(Op);
            }



        }


        public static void AddTaskHelper()
        {
            Console.WriteLine("write title");
            string? t = Console.ReadLine();
            Console.WriteLine("write message");
            string? m = Console.ReadLine();
            Console.WriteLine("choose stats");
            string? s = Console.ReadLine();
            Console.WriteLine("choose priority (from 1 to 9 or with out priority)");
            String? ofp = Console.ReadLine();
            if (!int.TryParse(ofp, out int p))
                p = 10;

            Console.WriteLine("choose doDate");
            Console.WriteLine("year");

            string? time = Console.ReadLine();

            if (!int.TryParse(time, out int year))
                year = 9999;


            Console.WriteLine("month");
            time = Console.ReadLine();
           
            if (!int.TryParse(time, out int month))
               month = 12;


            Console.WriteLine("day");
            time = Console.ReadLine();
            if (!int.TryParse(time, out int day))
                day = 28;

            DateTime d = new(year, month, day);
            AddTask(t, m, s, p, d);

        }
        public static void Stop()
        {
            Console.Write("enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void ToRemoveCondtion()
        {
            Console.WriteLine("remove on condition of");
            Console.WriteLine("1:title length");
            Console.WriteLine("2:message length");
            Console.WriteLine("3:stats length");
            Console.WriteLine("4: priority");
            Console.WriteLine("5:message");
            Console.WriteLine("6:stats");
            Console.WriteLine("7:title");
            Console.WriteLine("8:doDate");
            string? ofa = Console.ReadLine();
            if (!int.TryParse(ofa, out int a))
            {
                Console.WriteLine("out of range");
                Stop();
                return;
            }
            else if (!(a >= 1 && a <= 8))
            {
                Console.WriteLine("out of range");
                Stop();
                return;
            }

            Console.WriteLine("choose oportor");
            Console.WriteLine("1:more then");
            Console.WriteLine("2:less then");
            Console.WriteLine("3:equals to");
            string? ofb = Console.ReadLine();
            if (!int.TryParse(ofb, out int b))
            {
                Console.WriteLine("out of range");
                Stop();
                return;
            }
            else if (!(b >= 1 && b <= 3))
            {
                Console.WriteLine("out of range");
                Stop();
                return;
            }

            /*if(a>=5 && a<=7)
			removalstring(a,b);
			if(a>=1 &&a<=4)
			removalint(a,b)
			if(a==8)
			removaldate(b)*/
            Stop();


        }

        public static void Cmd()
        {
            Console.WriteLine("welcom to task manager");
            Welcom();
            string? option = Console.ReadLine();       
            if (!int.TryParse(option, out int op))
                op = 9;
            Console.Clear();
            switch (op)
            {
                case 1:
                    AddTaskHelper();// work in progress
                    break;
                case 2: //Edit(); pending
                    break;
                case 3: //ViewHelper(); pending
                    break;
                case 4:
                    View(); //working i think
                    break;
                case 5:// AppendData(); pending
                    break;
                case 6:
                    ToRemove(); //working i think
                    break;
                case 7:
                    ToRemoveCondtion();// work in progress
                    break;
                case 9://empty 
                    break;
                default:
                    Console.WriteLine("invalid code");
                    break;
            }
            if (op != 9)
                Cmd();

        }


        public static void AddTask(string? t, string? m, string? s, int p, DateTime d)
        {
            NumOfTask++;

            taskList.Add(new Info(t, m, s, p, d));
            Stop();
        }


        public static void Display(int num)
        {
            switch (num)
            {
                case 1:
                    taskList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                    break;
                case 2:
                    taskList.Sort((x, y) => x.creationDate.Ticks.CompareTo(y.creationDate.Ticks));
                    break;
                case 3:
                    taskList.Sort((x, y) => x.doDate.Ticks.CompareTo(y.doDate.Ticks));
                    break;
                case 4:
                    taskList.Sort((x, y) => String.Compare(x.title, y.title));
                    break;
            }
            if (num > 0 && num < 5)
                foreach (Info z in taskList)
                {
                    Console.WriteLine(z.title);
                    Console.WriteLine(z.message);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            if (num == 5)
            {
                Console.WriteLine("what stats");
                string? temp = Console.ReadLine();
                foreach (Info z in taskList)
                {
                    if (z.stats.Equals(temp))
                    {
                        Console.WriteLine(z.title);
                        Console.WriteLine(z.message);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("number of task:"+NumOfTask);
            Stop();

        }
        public static void ToRemove()
        {
            Console.WriteLine("remove with title");
            string? t = Console.ReadLine();
            foreach (Info z in taskList)
            {
                if (z.title.Equals(t))
                {
                    taskList.Remove(z);
                    Stop();
                    NumOfTask--;
                    return;
                }

            }
            Stop();
        }
    }
    public class ProgramTaskManager
    {
        public static void Main()
        {
            Taskm.Cmd();
            Console.WriteLine("bye");
            Console.ReadLine();
        }
    }
}
/* 
need to implment cmd case 2,3,5 and continue implmenting
case 7 RemovalString() RemovalInt() RemovalDate()
*/
