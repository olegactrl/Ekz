using System;
using System.Collections.Generic;
using System.Threading;

namespace TennisCourtVisualization
{
    public class TennisCourt
    {
        public int CourtNumber { get; }

        public TennisCourt(int courtNumber)
        {
            CourtNumber = courtNumber;
        }

        public void PlayMatch(Player player1, Player player2)
        {
            Console.WriteLine($"{player1.Name} against {player2.Name} - on court {CourtNumber}");

        }
    }

    public class Player
    {
        public string Name { get; }
        public PlayerType Type { get; }

        public Player(string name, PlayerType type)
        {
            Name = name;
            Type = type;
        }
    }

    public enum PlayerType
    {
        Beginner,
        Professional
    }

    class Program
    {
        static void Main()
        {
            TennisCourt court1 = new TennisCourt(1);
            TennisCourt court2 = new TennisCourt(2);

            List<Player> players = new List<Player>();
            for (int i = 0; i < 14; i++)
            {
                if (i < 7)
                    players.Add(new Player($"Beginner {i + 1}", PlayerType.Beginner));
                else
                    players.Add(new Player($"Professional {i - 6}", PlayerType.Professional));
            }

            for (int i = 0; i < 14; i++)
            {
                Player player1 = players[i];
                for (int j = i + 1; j < 14; j++)
                {
                    Player player2 = players[j];
                    Thread matchThread = new Thread(() => court1.PlayMatch(player1, player2));
                    matchThread.Start();
                }
            }

            Console.ReadLine();
        }
    }
}