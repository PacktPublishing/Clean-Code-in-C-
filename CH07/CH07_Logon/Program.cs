using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CH07_Logon
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            DoLogin("Welcome to the test platform");
        }

        private static void DoLogin(string message)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(message);
            Console.WriteLine("----------------------------");
            Console.Write("Enter your username: ");
            var usr = Console.ReadLine();
            Console.Write("Enter your password: ");
            var pwd = ReadPassword();
            ValidateUser(usr, pwd);
        }

        private static void ValidateUser(string usr, string pwd)
        {
            if (usr.Equals("admin") && pwd.Equals("letmein"))
            {
                var process = new Process();
                process.StartInfo.FileName = @"..\..\..\CH07_Admin\bin\Debug\CH07_Admin.exe";
                process.StartInfo.Arguments = "admin";
                process.Start();
            }
            else if (usr.Equals("student") && pwd.Equals("letmein"))
            {
                var process = new Process();
                process.StartInfo.FileName = @"..\..\..\CH07_Test\bin\Debug\CH07_Test.exe";
                process.StartInfo.Arguments = "test";
                process.Start();
            }
            else
            {
                Console.Clear();
                DoLogin("Invalid username or password");
            }
        }

        public static string ReadPassword()
        {
            return ReadPassword('*');
        }

        public static string ReadPassword(char mask)
        {
            const int enter = 13, backspace = 8, controlBackspace = 127;
            int[] filtered = { 0, 27, 9, 10, 32 };
            
            var pass = new Stack<char>();
            char chr = (char)0;

            while ((chr = Console.ReadKey(true).KeyChar) != enter)
            {
                if (chr == backspace)
                {
                    if (pass.Count > 0)
                    {
                        Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (chr == controlBackspace)
                {
                    while (pass.Count > 0)
                    {
                        Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (filtered.Count(x => chr == x) <= 0)
                {
                    pass.Push((char)chr);
                    Console.Write(mask);
                }
            }

            Console.WriteLine();

            return new string(pass.Reverse().ToArray());
        }
    }
}
