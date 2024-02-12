using Championship.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using System.Security;

namespace Championship
{
    public class Program
    {

        static public TeamContext con = new TeamContext();

        static public List<Team> teams = con.Teams.ToList();

        static public List<Matches> matches = con.Matches.ToList();


        static void Main(string[] args)
        {
            bool ProgramWorking = true;
            while (ProgramWorking)
            {
                Console.WriteLine("0.Вихід");
                Console.WriteLine("1.Додати команду");
                Console.WriteLine("2.Видалення команди");
                Console.WriteLine("3.Інформація про існуючі команди");
                Console.WriteLine("4.Інформація Про матчі");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        ProgramWorking = false;
                        break;
                    case 1:
                        AddTeam();
                        break;
                    case 2:
                        DeleteTeam(TeamByNameAndTown(false));
                        break;
                    case 3:
                        InfoAboutTeams();
                        break;
                    case 4:
                        MatchesInfo();
                        break;
                    default:
                        break;
                }

            }
        }

        private static void MatchesInfo()
        {
            bool IsMatchWorking = true;
            while (IsMatchWorking)
            {
                Console.Clear();
                Console.WriteLine("0.Вихід");
                Console.WriteLine("1.Різниця забитих та пропущених голів для кожної команди");
                Console.WriteLine("2.Повна інформація про матч");
                Console.WriteLine("3.Інформація про матч у конкренту дату");
                Console.WriteLine("4.Усі матчі конкретної команди");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        IsMatchWorking = false;
                        break; 
                    case 1:
                        DifferenceOfGoals(InfoAboutMatchByDate(false));
                        break;
                    case 2:
                        InfoAboutMatch(InfoAboutMatchByDate(false));
                        break; 
                    case 3:
                        InfoAboutMatchByDate(true);
                        break;
                    case 4:
                        AllMatchesByTeam();
                        break;
                    default:
                        break;
                }
            }
            Console.Clear();
        }

        private static void AllMatchesByTeam()
        {
            Console.Clear();
            Console.WriteLine("Введіть назву каманди");
            string name = Console.ReadLine();
            foreach (var item in matches)
            {
                if(name == item.Team1.Name || name == item.Team2.Name)
                {
                    InfoAboutMatch(item);
                }
            }
        }

        private static Matches InfoAboutMatchByDate(bool isInfo)
        {
            Console.Clear();
            Console.WriteLine("Введіть дату");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            foreach (var item in matches)
            {
                if (item.Date == date && isInfo == false)
                {
                    return item;
                }
                else if (item.Date == date && isInfo == true)
                {
                    Console.Clear();
                    Console.WriteLine($"Team1: {item.Team1}");
                    Console.WriteLine($"Team2: {item.Team2}");
                    Console.WriteLine($"Goals scored be team 1: {item.GoalsScoredByTeam1}");
                    Console.WriteLine($"Goals scored be team 2: {item.GoalsScoredByTeam2}");
                    Console.WriteLine($"Date: {item.Date}");
                }
            }
            EndFunc();
            return null;
        }

        private static void InfoAboutMatch(Matches matches)
        {
            Console.Clear();
            Console.WriteLine($"Team1: {matches.Team1}");
            Console.WriteLine($"Team2: {matches.Team2}");
            Console.WriteLine($"Goals scored be team 1: {matches.GoalsScoredByTeam1}");
            Console.WriteLine($"Goals scored be team 2: {matches.GoalsScoredByTeam2}");
            Console.WriteLine($"Date: {matches.Date}");
            EndFunc();
        }

        private static void DifferenceOfGoals(Matches matches)
        {
            Console.Clear();
            Console.WriteLine($"Team1: {matches.GoalsScoredByTeam1 -  matches.Team1.GoalsConceded}");
            Console.WriteLine($"Team2: {matches.GoalsScoredByTeam2 -  matches.Team2.GoalsConceded}");
            EndFunc();
        }

        private static void DeleteTeam(Team team)
        {
            con.Teams.Remove(team);
            con.SaveChanges();
        }

        private static void AddTeam()
        {
            Console.Clear();
            Console.WriteLine("Назва команди:");
            string? Name = Console.ReadLine();
            Console.WriteLine("З якого міста команда?:");
            string? Town = Console.ReadLine();
            Console.WriteLine("Кількість перемог:");
            int Wins = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кількість програшів:");
            int Defeats = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кількість ігр, зіграних в нічию:");
            int Draws = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кількість забитих голів:");
            int GoalsScored = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кількість пропущених голів:");
            int GoalsConceded = Convert.ToInt32(Console.ReadLine());
            Team team = new Team()
            {
                Name = Name,
                Town = Town,
                Wins = Wins,
                Defeats = Defeats,
                Draws = Draws,
                GoalsScored = GoalsScored,
                GoalsConceded = GoalsConceded
            };
            con.Teams.Add(team);
            con.SaveChanges();

            EndFunc();
        }

        private static void InfoAboutTeams()
        {
            Console.Clear();
            bool IsWorking = true;
            while (IsWorking)
            {
                Console.WriteLine("0.Вихід.");
                Console.WriteLine("1.Пошук інформації про команду за назвою.");
                Console.WriteLine("2.Пошук команд за назвою міста.");
                Console.WriteLine("3.Пошук інформації за назвою команди і міста.");
                Console.WriteLine("4.Відображення команди з найбільшою кількістю перемог.");
                Console.WriteLine("5.Відображення команди з найбільшою кількістю поразок.");
                Console.WriteLine("6.Відображення команди з найбільшою кількістю ігор у нічию.");
                Console.WriteLine("7.Відображення команди з найбільшою кількістю забитих голів.");
                Console.WriteLine("8.Відображення команди з найбільшою кількістю пропущених голів.");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        IsWorking = false;
                        break;
                    case 1:
                        TeamByName();
                        break;
                    case 2:
                        TeamByTownName();
                        break;
                    case 3:
                        TeamByNameAndTown(false);
                        break;
                    case 4:
                        BestTeam();
                        break;
                    case 5:
                        WorstTeam();
                        break;
                    case 6:
                        TeamWithMostDraws();
                        break;
                    case 7:
                        BeastTeamByGoals();
                        break;
                    case 8:
                        WorstTeamByLoosingGoals();
                        break;
                }
            }
        }

        private static void WorstTeamByLoosingGoals()
        {
            Console.Clear();
            int max = 0;
            foreach (var item in teams)
            {
                if (item.GoalsConceded > max)
                {
                    max = item.Wins;
                }
            }
            foreach (var item in teams)
            {
                if (item.GoalsConceded == max)
                {
                    TeamByName(item.Name);
                    break;
                }
            }
        }

        private static void BeastTeamByGoals()
        {
            Console.Clear();
            int max = 0;
            foreach (var item in teams)
            {
                if (item.GoalsScored > max)
                {
                    max = item.Wins;
                }
            }
            foreach (var item in teams)
            {
                if (item.GoalsScored == max)
                {
                    TeamByName(item.Name);
                    break;
                }
            }
        }

        private static void TeamWithMostDraws()
        {
            Console.Clear();
            int max = 0;
            foreach (var item in teams)
            {
                if (item.Draws > max)
                {
                    max = item.Wins;
                }
            }
            foreach (var item in teams)
            {
                if (item.Draws == max)
                {
                    TeamByName(item.Name);
                    break;
                }
            }
        }

        private static void WorstTeam()
        {
            Console.Clear();
            int max = 0;
            foreach (var item in teams)
            {
                if (item.Defeats > max)
                {
                    max = item.Wins;
                }
            }
            foreach (var item in teams)
            {
                if (item.Defeats == max)
                {
                    TeamByName(item.Name);
                    break;
                }
            }
        }

        private static void BestTeam()
        {
            Console.Clear();
            int max = 0;
            foreach (var item in teams)
            {
                if (item.Wins > max)
                {
                    max = item.Wins;
                }
            }
            foreach (var item in teams)
            {
                if (item.Wins == max)
                {
                    TeamByName(item.Name);
                    break;
                }
            }
        }

        private static Team TeamByNameAndTown(bool IsInfo)
        {
            Console.Clear();
            Team team1;
            Console.WriteLine("Введіть назву міста");
            string? TownName = Console.ReadLine();
            Console.WriteLine("Введіть назву команди");
            string? TeamName = Console.ReadLine();
            Console.Clear();
            foreach (var team in teams)
            {
                if (team.Town == TownName && team.Name == TeamName && IsInfo == true)
                {
                    Console.WriteLine($"Name: {team.Name}");
                    Console.WriteLine($"Town: {team.Town}");
                    Console.WriteLine($"Wins: {team.Wins}");
                    Console.WriteLine($"Defeats: {team.Defeats}");
                    Console.WriteLine($"Draws: {team.Draws}");
                    Console.WriteLine($"GoalsScored: {team.GoalsScored}");
                    Console.WriteLine($"GoalsConceded: {team.GoalsConceded}");
                    break;
                }
                else if(team.Town == TownName && team.Name == TeamName && IsInfo == false)
                {
                    team1 = team;
                    EndFunc();
                    return team1;
                }
            }
            EndFunc();
            return new Team();
        }

        private static void TeamByTownName()
        {
            Console.Clear();
            Console.WriteLine("Введіть назву міста");
            string? name = Console.ReadLine();
            Console.Clear();
            foreach (var team in teams)
            {
                if (team.Town == name)
                {
                    Console.WriteLine($"Name: {team.Name}");
                    Console.WriteLine($"Town: {team.Town}");
                    Console.WriteLine($"Wins: {team.Wins}");
                    Console.WriteLine($"Defeats: {team.Defeats}");
                    Console.WriteLine($"Draws: {team.Draws}");
                    Console.WriteLine($"GoalsScored: {team.GoalsScored}");
                    Console.WriteLine($"GoalsConceded: {team.GoalsConceded}");
                }
            }
            EndFunc();
        }

        private static void TeamByName()
        {
            Console.Clear();
            using (var con = new TeamContext())
            {
                Console.WriteLine("Введіть назву команди");
                string? name = Console.ReadLine();
                Console.Clear();
                foreach (var team in teams)
                {
                    if (team.Name == name)
                    {
                        Console.WriteLine($"Name: {team.Name}");
                        Console.WriteLine($"Town: {team.Town}");
                        Console.WriteLine($"Wins: {team.Wins}");
                        Console.WriteLine($"Defeats: {team.Defeats}");
                        Console.WriteLine($"Draws: {team.Draws}");
                        Console.WriteLine($"GoalsScored: {team.GoalsScored}");
                        Console.WriteLine($"GoalsConceded: {team.GoalsConceded}");
                    }
                }
            }
            EndFunc();
        }

        private static void TeamByName(string? name)
        {
            Console.Clear();
            Console.Clear();
            foreach (var team in teams)
            {
                if (team.Name == name)
                {
                    Console.WriteLine($"Name: {team.Name}");
                    Console.WriteLine($"Town: {team.Town}");
                    Console.WriteLine($"Wins: {team.Wins}");
                    Console.WriteLine($"Defeats: {team.Defeats}");
                    Console.WriteLine($"Draws: {team.Draws}");
                    Console.WriteLine($"GoalsScored: {team.GoalsScored}");
                    Console.WriteLine($"GoalsConceded: {team.GoalsConceded}");
                }
            }
            EndFunc();
        }

        static private void EndFunc()
        {
            Console.WriteLine("Для прожовження натисніть ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}