// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Numerics;

var devRepo = new DeveloperRepository();
var devTeamRepo = new DevTeamRepository();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("\t Komodo Developer Team Management Terminal");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("\tType \"help\" to see a list of avaliable commands.");
Console.WriteLine(" ");
Console.WriteLine(" ");
Console.WriteLine(" ");

input:
Console.WriteLine();
var userinput = Console.ReadLine();
Console.WriteLine();

switch(userinput)
{
    case "help":
        HelpMenu();
        break;
    
    case "devs":
        var devsList = devRepo.Read();
        if (devsList.Count == 0)
        {
            Console.WriteLine("There are currently no developers in the database.");
            break;
        }
        foreach (Developer person in devsList)
        {
            Console.WriteLine($"Developer ID : {person.Id} | {person.FullName}");
        }
        break;

    case "new dev":
        var developer = new Developer();
        Console.WriteLine("Enter the developer's first name.");
        firstname:
        var firstName = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(firstName))
        {
            Console.WriteLine("First name cannot be blank. Please try again.");
            goto firstname;
        }
        Console.WriteLine("Enter the developer's last name.");
        lastname:
        var lastName = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("Last name cannot be blank. Please try again.");
            goto lastname;
        }
        Console.WriteLine("Does this developer have a Pluralsight license? Enter \"y\" for yes or \"n\" for no.");
        pluralsightquestion:
        var userAnswer = Console.ReadLine();
        if (userAnswer == "y")
            developer.HasPluralsight = true;    
        else if (userAnswer == "n")
            developer.HasPluralsight = false;
        else
        {
            Console.WriteLine("Please enter \"y\" or \"n\"");
            goto pluralsightquestion;
        }


        developer.FirstName = firstName;
        developer.LastName = lastName;

        devRepo.Add(developer);

        Console.WriteLine("Developer " + developer.FullName + " has been created and added to developer database.");
        break ;

    case "pluralsight":
        var listOfDevs = devRepo.Read(); 
        if (listOfDevs.Count == 0)
        {
            Console.WriteLine("There are currently no developers requiring a Pluralsight license.");
            break;
        }
        Console.WriteLine("The following developers require a Pluralsight license:");
        foreach (Developer Dev in listOfDevs)
            if (Dev.HasPluralsight == false)
                Console.WriteLine($"Dev ID: {Dev.Id} | {Dev.FullName}");
        break;

    case "teams":
        var teamsList = devTeamRepo.Read();
        if (teamsList.Count == 0)
        {
            Console.WriteLine("There are currently no teams in the database.");
        }
        foreach (DevTeam devTeam in teamsList)
        {
            Console.WriteLine($"Team ID : {devTeam.Id} | {devTeam.Name}");
            var teamMems = devTeam.Read(); 
            if (teamMems.Count == 0)
            {
                Console.WriteLine("\tThere are currently no members in this team.");
            } 
            else
            {
                foreach (Developer member in teamMems)
                {
                    Console.WriteLine("\t" + "Dev ID: " + member.Id + " | " + member.FullName);
                }
                Console.WriteLine();
            }
        }
        break;

    case "new team":
        var developerTeam = new DevTeam();
        Console.WriteLine("Enter team name.");
        teamname:
        var teamName = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(teamName))
        {
            Console.WriteLine("Team name cannot be blank. Please try again.");
            goto teamname;
        }
        developerTeam.Name = teamName;
        devTeamRepo.Add(developerTeam);
        Console.WriteLine(developerTeam.Name + " has been added to the developer team database.");
        break;


    case "new member":
        Console.WriteLine("Enter team ID");
        var teamId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the ID of the developer you would like to add to this team.");
        var devId = Convert.ToInt32(Console.ReadLine());

        Developer dev = devRepo.Find(devId);
        if (dev == null)
        {
            Console.WriteLine("Your input does match any developer ID in the database. Please try again.");
            break;
        }
        bool success = devTeamRepo.Update(teamId, dev);

        if (success == true)
        {
            Console.WriteLine("The team has been successfully updated.");
            break;
        }
        else
        {
            Console.WriteLine("Your input does match any team ID in the database. Please try again.");
            break;
        }

    case "remove member":
        Console.WriteLine("Enter ID of team from which you would like to remove a member.");
        var teamID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter ID of developer you would like to remove.");
        var devID = Convert.ToInt32(Console.ReadLine());
        bool removalsuccess = devTeamRepo.DeleteMember(teamID, devID);
        if (removalsuccess == true)
        {
        Console.WriteLine("The developer has been removed from the team.");
        break;
        }
        else
        {
            Console.WriteLine("One or Both of your inputs did not match the database. Please check your inputs and try again.");
            break;
        }

    default:
        Console.WriteLine("\nInvalid command. Please enter a valid command. Type \"help\" for a list of valid commands.");
        break;

}

goto input;



static void HelpMenu()
{
    Console.WriteLine("\tdevs -- see a list of all developers");
    Console.WriteLine();
    Console.WriteLine("\tnew dev -- create a new developer");
    Console.WriteLine();
    Console.WriteLine("\tpluralsight -- see list of developers needing a Pluralsight license");
    Console.WriteLine();
    Console.WriteLine("\tteams -- see list of all teams");
    Console.WriteLine();
    Console.WriteLine("\tnew team -- create a developer team");
    Console.WriteLine();
    Console.WriteLine("\tnew member -- add a developer to a team");
    Console.WriteLine();
    Console.WriteLine("\tremove member -- remove a developer from a team");
    Console.WriteLine();
}




