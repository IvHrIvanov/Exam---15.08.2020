using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pianist> pianist = new List<Pianist>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                Pianist newPianist = new Pianist(piece, composer, key);
                pianist.Add(newPianist);

            }

            string[] commandsArg = Console.ReadLine().Split("|");

            while (commandsArg[0] != "Stop")
            {
                StringBuilder sb = new StringBuilder();
                string command = commandsArg[0];
                string piece = commandsArg[1];
                int index = pianist.FindIndex(x => x.Piece == piece);
                var contains = pianist.Find(x => x.Piece.Contains(piece));
                if (command == "Add")
                {
                    if (contains == null)
                    {
                        string composer = commandsArg[2];
                        string key = commandsArg[3];
                        Pianist newPianist = new Pianist(piece, composer, key);
                        pianist.Add(newPianist);
                        sb.Append($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        sb.Append($"{piece} is already in the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (contains != null)
                    {
                        pianist.RemoveAt(index);
                        sb.Append($"Successfully removed {piece}!");
                    }
                    else
                    {
                        sb.Append($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    if (contains != null)
                    {
                        string key = commandsArg[2];
                        pianist[index].Key = key;
                        sb.Append($"Changed the key of {piece} to {key}!");
                    }
                    else
                    {
                        sb.Append($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                Console.WriteLine(sb);
                commandsArg = Console.ReadLine().Split("|");
            }

            foreach (var item in pianist.OrderBy(x=>x.Piece))
            {
                Console.WriteLine($"{item.Piece} -> Composer: {item.Composer}, Key: {item.Key}");
            }

        }
    }
    class Pianist
    {
        public Pianist(string piece, string composer, string key)
        {
            Piece = piece;
            Composer = composer;
            Key = key;
        }

        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}