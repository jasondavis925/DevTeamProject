using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam_Repo_crud
    {
        private readonly DeveloperRepo_crud _developerRepo = new DeveloperRepo_crud();
        private readonly List<DevTeam> _DevTeam = new List<DevTeam>();
        private readonly List<Developer> _TeamMember = new List<Developer>();

        //DevTeam Create
        public void AddTeamToList(DevTeam teamname)
        {
            _DevTeam.Add(teamname);
        }

        //DevTeam Read
        public List<DevTeam> GetTeamNameList()
        {
            return _DevTeam;
        }

        //DevTeam Update
        public bool UpdateExistingContent(int originalIdentification, DevTeam newInfo)
        {
            // Find the content
            DevTeam oldInfo = GetDevTeamById(originalIdentification);                            //Call Helper Method

            //Update the content
            if (oldInfo != null)
            {
                oldInfo.TeamName = newInfo.TeamName;
                oldInfo.TeamID = newInfo.TeamID;
                oldInfo.TeamMembers = newInfo.TeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveTeamFromList(int identification)
        {
            DevTeam info = GetDevTeamById(identification);               //Call Helper Method

            if (info == null)
            {
                return false;
            }

            int initialCount = _DevTeam.Count;
            _DevTeam.Remove(info);

            if (initialCount > _DevTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamById(int identification)
        {
            foreach (DevTeam info in _DevTeam)
            {
                if (info.TeamID == identification)
                {
                    return info;
                }
            }

            return null;
        }
    }
}
