using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{

    //Plain Old C# Object -- POCO
    //Content Object
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> TeamMembers { get; set; } = new List<Developer>();
        public DevTeam() { }
        public DevTeam(string teamname, int teamid, List<Developer> teammembers)
        {
            //Set Property Title same as Parameter Title
            TeamName = teamname;
            TeamID = teamid;
            TeamMembers = teammembers;
        }
    }
}
