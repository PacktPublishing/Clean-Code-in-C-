using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4
{
    public class Player
    {
        public string PlayerName { get; }
        public long HighScore { get; }
        public Player(string playerName, long highScore)
        {
            PlayerName = playerName;
            HighScore = highScore;
        }
        public Player UpdateHighScore(long highScore)
        {
            return new Player(PlayerName, highScore);
        }
    }
}
