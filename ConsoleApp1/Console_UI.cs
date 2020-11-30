using DevTeamsProject;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Console_UI
    {
        private DeveloperRepo_crud _developerRepo = new DeveloperRepo_crud();
        private DevTeam_Repo_crud _DevTeamRepo = new DevTeam_Repo_crud();

        // Method that runs/starts the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Developer\n" +
                    "2. Display Developer Directory\n" +
                    "3. Update Developer Information\n" +
                    "4. Delete Developer\n" +
                    "5. Create New Team\n" +
                    "6. Display List of Teams\n" +
                    "7. Add Team Members\n" +
                    "8. Delete Team Members\n" +
                    "9. Delete Teams\n" +
                    "0. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluation the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //Display Developer List
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //Update Developer Information
                        UpdateDeveloperInformation();
                        break;
                    case "4":
                        //Delete Developer
                        DeleteExistingDeveloper();
                        break;
                    case "5":
                        //Create New Team
                        CreateNewTeam();
                        break;
                    case "6":
                        //Display List of Teams
                        DisplayListofTeams();
                        break;
                    case "7":
                        //Add Team Members
                        AddTeamMembers();
                        break;
                    case "8":
                        //Delete Team Members
                        DeleteTeamMembers();
                        break;
                    case "9":
                        // Delete Teams
                        DeleteTeams();
                        break;
                    case "0":
                        //Exit
                        Console.WriteLine("Good Bye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //1. Create New Developer Information (from POCO/CRUD Repo)
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newContent = new Developer();

            //Name of Developer 
            Console.WriteLine("Enter the developer Name:");
            newContent.Name = Console.ReadLine();                                   //Name is crud variable

            //Identification of Developer
            Console.WriteLine("Enter the developer identification:");
            newContent.Identification = Convert.ToInt32(Console.ReadLine());        //parse string to int

            //Learning Tool Access
            Console.WriteLine("Does the developer have learning tool access? (y/n)");
            string toolaccess = Console.ReadLine().ToLower();

            if (toolaccess == "y")
            {
                newContent.ToolAccess = true;
            }
            else
            {
                newContent.ToolAccess = false;
            }

            _developerRepo.AddDeveloperToList(newContent);                             // Field --> class level variable
        }

        //2. Display Developer Directory
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listofdevelopers = _developerRepo.GetContentList();

            foreach (Developer content in listofdevelopers)
            {
                Console.WriteLine($"Developer: {content.Name}\n" +
                    $"Identification: {content.Identification}\n" +
                    $"Learning Tool Access: {content.ToolAccess}\n");
            }
        }

        //3. Update Developer Information
        private void UpdateDeveloperInformation()
        {
            // Display all developers
            DisplayAllDevelopers();

            // Ask for the developer identification to update
            Console.WriteLine("Enter the developer identification you would like to update:");

            // Get that name
            int oldDeveloper = Convert.ToInt32(Console.ReadLine());                      // parse string to int

            //GrabTheOldDeveloper
            //_developerRepo.GetDeveloperById(oldDeveloper);

            // We will build a new object
            Developer newContent = new Developer();

            //Name of Developer 
            Console.WriteLine("Enter the new developer name:");
            newContent.Name = Console.ReadLine();                                   // Name is crud variable

            //Identification of Developer
            Console.WriteLine("Enter the developer identification:");
            newContent.Identification = Convert.ToInt32(Console.ReadLine());        // parse string to int

            //Learning Tool Access
            Console.WriteLine("Does the developer have learning tool access? (y/n)");
            string toolaccess = Console.ReadLine().ToLower();

            if (toolaccess == "y")
            {
                newContent.ToolAccess = true;
            }
            else
            {
                newContent.ToolAccess = false;
            }

            //Verify the update worked
            bool wasUpdated = _developerRepo.UpdateExistingContent(oldDeveloper, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }
        }

        //4. Delete Developer
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();

            // Get the developer they want to remove
            Console.WriteLine("\nEnter the developer identification you would like to remove:");
            int input = Convert.ToInt32(Console.ReadLine());                          //parse string to int

            // Call the developer delete method
            bool wasDeleted = _developerRepo.RemoveContentFromList(input);

            // If the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            // Otherwise state it could not be deleted
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }

        //5. Create New Team
        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            //Add Team Name
                Console.WriteLine("Enter the team name:");
                newTeam.TeamName = Console.ReadLine();                                   //Name is crud variable

            //Add Team ID
                Console.WriteLine("Enter the team identification:");
                newTeam.TeamID = Convert.ToInt32(Console.ReadLine());

            _DevTeamRepo.AddTeamToList(newTeam);
        }

        //6. Display List (Directory) of Teams
        private void DisplayListofTeams()
        {
            Console.Clear();
            List<DevTeam> listofteams = _DevTeamRepo.GetTeamNameList();

            foreach (DevTeam info in listofteams)
            {
                Console.WriteLine($"\nTeam Name: {info.TeamName}     Team ID: {info.TeamID}");

                foreach (Developer info2 in info.TeamMembers)
                {
                    Console.WriteLine($"Team Member: {info2.Name}     Developer ID: {info2.Identification}");
                }

                Console.WriteLine("\n*********************************************");
            }
        }

        //7. Add Team Members to a Team List
        private void AddTeamMembers()
        {
            Console.Clear();

            // Display all Teams
            DisplayListofTeams();

            // Prompt the use to provide the team identification for update
            Console.WriteLine("Enter the team identification you would like to update:");

            //Find that team
            int newTeamID = Convert.ToInt32(Console.ReadLine());
            DevTeam Team = _DevTeamRepo.GetDevTeamById(newTeamID);

            //Build a new object

            //Display all developers
            DisplayAllDevelopers();

            //Get developer to add
            Console.WriteLine("Enter the developer identification you would like to add:");
            int newTeamMember = Convert.ToInt32(Console.ReadLine());
            Developer person = _developerRepo.GetDeveloperById(newTeamMember);
            Team.TeamMembers.Add(person);
        }

        //8. Delete Team Members from a Team List
        private void DeleteTeamMembers()
        {
            Console.Clear();

            // Display all Teams
            DisplayListofTeams();

            // Ask for the team identification to update
            Console.WriteLine("Enter the team identification you would like to update:");

            //Get that team
            int newTeamID = Convert.ToInt32(Console.ReadLine());
            DevTeam Team = _DevTeamRepo.GetDevTeamById(newTeamID);

            //Build a new object

            //Get developer to remove
            Console.WriteLine("Enter the developer identification you would like to remove:");
            int oldTeamMember = Convert.ToInt32(Console.ReadLine());
            Developer person = _developerRepo.GetDeveloperById(oldTeamMember);
            Team.TeamMembers.Remove(person);
        }

        //9. Delete Team
        private void DeleteTeams ()
        {
            DisplayListofTeams();
            // Get the team they want to remove
            Console.WriteLine("\nEnter the team identification you would like to remove:");

            int input = Convert.ToInt32(Console.ReadLine());

            // Call the delete method
            bool wasDeleted = _DevTeamRepo.RemoveTeamFromList(input);

            // If the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            // Otherwise state it could not be deleted
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }

        //make the seed method
        private void SeedContentList()
        {
            Developer bob = new Developer("Bob", 1, true);
            Developer joe = new Developer("Joe", 2, false);
            Developer fred = new Developer("Fred", 3, true);

            _developerRepo.AddDeveloperToList(bob);
            _developerRepo.AddDeveloperToList(joe);
            _developerRepo.AddDeveloperToList(fred);

            DevTeam blazers = new DevTeam("Blazers", 1, new List<Developer>() { bob, joe });
            DevTeam runners = new DevTeam("Runners", 2, new List<Developer>() { fred });

            _DevTeamRepo.AddTeamToList(blazers);
            _DevTeamRepo.AddTeamToList(runners);
        }
    }
}
