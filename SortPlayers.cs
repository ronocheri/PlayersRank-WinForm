using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PlayersRank
{
    public partial class SortPlayers : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
 
        List<PlayerInGame> players = new List<PlayerInGame>();
        string str = "";

        public List<PlayerInGame> getListOfPlayersAtRank(int rank)
        {
            IEnumerable<PlayerInGame> RankQuery =
               (from player in players
                                     where player.Rank == rank
                select player);

            List<PlayerInGame> list = RankQuery.Cast<PlayerInGame>().ToList();
            return list;
        }

        public void addPlayersToTeams(List<PlayerInGame> pList, int numOfTeams)
        {
            List<int> teamsChoosen= new List<int>();

            Random rnd = new Random();
            foreach (PlayerInGame p in pList)
            {
                int rand = rnd.Next(1, numOfTeams+1); 
                while(teamsChoosen.Contains(rand))
                    rand = rnd.Next(1, numOfTeams + 1);
                teamsChoosen.Add(rand);
                p.TeamId = rand;
            }

            //return list;
        }


        public void printList(List<PlayerInGame> playerList)
        {
            string str = "";
            foreach (PlayerInGame p in playerList)
            {
                str += p.FirstName + " " + p.LastName + " " + p.Rank + " " + p.TeamId + System.Environment.NewLine;
            }
            MessageBox.Show("Players at rank " + playerList[0].Rank + ":" + System.Environment.NewLine + str);
        }
        public SortPlayers()
        {
            int c = 1;

            for (int i=1; i<4; i++)
            {
                for(int j=1;j<=5;j++)
                {                
                    PlayerInGame p = new PlayerInGame(c +"", c +"",j);
                    players.Add(p);
                   // str += p.FirstName + " " + p.LastName + " " + p.Rank + System.Environment.NewLine;
                    c++;
                }
            }


            InitializeComponent();
        }
        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<List<PlayerInGame>> allLists = new List<List<PlayerInGame>>();
            int numTeams = players.Count/5;

            for(int i=1;i<= 5;i++) //5 Ranks
            {
                allLists.Add(getListOfPlayersAtRank(i));  
            }



            //every ranked players list
            foreach (List<PlayerInGame> pList in allLists)
            {
                addPlayersToTeams(pList, numTeams); 
               
            }

            List<PlayerInGame> SortedRankPlatersInTeams = new List<PlayerInGame>();

                foreach (List<PlayerInGame> pList in allLists)
                {
                    foreach (PlayerInGame p in pList)
                    {
                    SortedRankPlatersInTeams.Add(p);
                    }

                }

            //SortedRankPlatersInTeams.OrderBy<TeamId>

            List<PlayerInGame> result1 = SortedRankPlatersInTeams.OrderBy(a => a.TeamId).ToList();

            //List<PlayerInGame> temp = result1;
            printList(result1);


        }
    }
}