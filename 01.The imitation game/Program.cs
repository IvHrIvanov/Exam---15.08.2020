using System;
using System.Linq;

namespace _01.The_imitation_game
{
    class Program
    {
        static void Main(string[] args)
        {

            string message = Console.ReadLine();

            string[] command = Console.ReadLine().Split("|");

            while (command[0] != "Decode")
            {

                string operation = command[0];

                switch (operation)
                {
                    case "Move":
                        int n = int.Parse(command[1]);
                        message = MovetoLast(message, n);
                        break;
                    case "Insert":
                        int index = int.Parse(command[1]);
                        string value = command[2];
                        message = InsertValue(message, index, value);
                        break;
                    case "ChangeAll":
                        string sub = command[1];
                        string replace = command[2];
                        message = ChangeAll(message, sub, replace);
                        break;

                }
                command = Console.ReadLine().Split("|");

            }
            Console.WriteLine($"The decrypted message is: {message}");

        }

        private static string ChangeAll(string message, string sub, string replace)
        {

            message = message.Replace(sub,replace);

            return message;
        }

        private static string InsertValue(string message, int index, string value)
        {
            message = message.Insert(index, value);
            return message;
        }

        private static string MovetoLast(string message, int n)
        {

            string forMove = message.Substring(0, n);
            message = message.Remove(0,n);
            message = message.Insert(message.Length,forMove);
           
            return message;
        }
    }
}
