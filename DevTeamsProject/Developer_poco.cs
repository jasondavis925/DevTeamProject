using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    //Plain Old C# Object -- POCO
    //Content Object
    public class Developer
    {
        public string Name { get; set; }
        public int Identification { get; set; }
        public bool ToolAccess { get; set; }
        //public int TeamID { get; set; }
 
        public Developer() { }
        public Developer(string name, int identification, bool toolaccess)//, int teamid
        {
            //Set Property Title same as Parameter Title
            Name = name;
            Identification = identification;
            ToolAccess = toolaccess;
            //TeamID = teamid;
        }
    }
}
