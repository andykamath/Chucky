using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;

namespace Chucky
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Location.txt";
            if(!File.Exists(path))
            {
                Console.WriteLine("It looks like you need to set up Chucky");
                Console.WriteLine("Please enter your location");
                Console.Write(">>");
                string loc = Console.ReadLine();
                using(StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(loc);
                }
            }
            string read = System.IO.File.ReadAllText("Location.txt");
            Console.WriteLine("Your location is "+read);
            Random a = new Random();
            string[] welcomes = { "So glad to have you!", "I'm so glad you could make it", "It's great to be of a help!" };
            int rand = a.Next(welcomes.Length);
            Console.WriteLine("Welcome to Chucky, "+Environment.UserName+"! "+welcomes[rand]);
            Console.WriteLine("Please enter your commands below");
            Tasks();
        }

        static void Tasks()
        {
            Console.Write(">>");
            string todo = Console.ReadLine().ToLower();
            if(todo.Contains("google "))
            {
                todo = todo.Substring(7);
                System.Diagnostics.Process.Start("http://google.com/search?q=" + todo);
            }
            if(todo.Contains("who is"))
            {
                todo = todo.Substring(7);
                System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/" + todo);
            }
            if (todo.Contains("who was"))
            {
                todo = todo.Substring(8);
                System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/" + todo);
            }
            if (todo.Contains("what was"))
            {
                todo = todo.Substring(9);
                System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/" + todo);
            }
            if (todo.Contains("what is"))
            {
                todo = todo.Substring(8);
                System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/" + todo);
            }
            if (todo.Contains("weather"))
            {
                System.Diagnostics.Process.Start("http://google.com/search?q=weather in " + System.IO.File.ReadAllText("Location.txt"));
            }
            Tasks();
        }
    }
}
