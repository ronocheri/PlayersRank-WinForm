using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersRank
{
    public class PlayerInGame : Player
    {
        int rank;
        int teamId;

        public PlayerInGame(string firstName, string lastName, int rank, int teamId=0) : base(firstName, lastName)
        {
            this.Rank = rank;
            this.TeamId = teamId;
        }

        public int Rank { get => rank; set => rank = value; }
        public int TeamId { get => teamId; set => teamId = value; }
    }
}
