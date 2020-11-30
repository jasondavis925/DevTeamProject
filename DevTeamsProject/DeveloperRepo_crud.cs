using System;
using System.Collections.Generic;
using System.Linq;
namespace DevTeamsProject
{
using System.Text;
using System.Threading.Tasks;

    public class DeveloperRepo_crud
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer content)
        {
            _developerDirectory.Add(content);
        }

        //Developer Read
        public List<Developer> GetContentList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingContent(int originalIdentification, Developer newContent)
        {
            // Find the content
            Developer oldContent = GetDeveloperById(originalIdentification);       //Call Helper Method

            //Update the content
            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.Identification = newContent.Identification;
                oldContent.ToolAccess = newContent.ToolAccess;
                //oldContent.TeamID = newContent.TeamID;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool RemoveContentFromList(int identification)
        {
            Developer content = GetDeveloperById(identification);               //Call Helper Method

            if (content == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(content);

            if (initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int identification)
        {
            foreach (Developer content in _developerDirectory)
            {
                if (content.Identification == identification)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
