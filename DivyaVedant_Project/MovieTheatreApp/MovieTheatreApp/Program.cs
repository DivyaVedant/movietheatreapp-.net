using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;

namespace MovieTheatreApp
{
    class Program
    {
        int attemptforlogin = 5;
        ConsoleKeyInfo cinfo;

        String[] age;
        String[] name;
        
        
        int noofmovie;
        public void user()
        {
            display();
        }

        public void admin()
        {
            String password;

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\n\tPlease Enter The Admin Password: ", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
                password = Console.ReadLine();

                if (password != "admin")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    attemptforlogin--;
                    Console.WriteLine("\n\tYou Have " + attemptforlogin + " more attempts to enter the correct password OR Press B to bo back to the previous screen", Console.ForegroundColor);

                    if (attemptforlogin == 0)
                    {
                        attemptforlogin = 5;
                        login();
                    }
                }
                else
                    break;
            }
            Console.Clear();
            insert();
        }

        public void menu2(int movie)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n\tPress M to Enter age again \n\tPress S to re-select movie: ", Console.ForegroundColor);

            while (true)
            {
                cinfo = Console.ReadKey();
                if (cinfo.Key == ConsoleKey.M)
                    ageVerification(movie);
                else if (cinfo.Key == ConsoleKey.S)
                    display();
                else
                    menu2(movie);
            }
        }

        public void display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int k = 0; k < noofmovie; k++)
            {
                Console.WriteLine("\n\t" + (k + 1) + ". {0} (age: {1})", name[k], age[k], Console.ForegroundColor);
            }

            if (name == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tThere are no movies available right now.", Console.ForegroundColor);
                menu();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tWhich movie would you like to watch: ", Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.Green;
            var m = Console.ReadLine();

            int movie;
            while (!int.TryParse(m, out movie) || movie > noofmovie )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tEnter valid choice!", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\tWhich movie would you like to watch: ", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.Green;
                m = Console.ReadLine();
            }
            ageVerification(movie);
        }

        public void ageVerification(int movie)
        {
            if (movie - 1 < name.Length)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\tPlease enter your age for verification: ",Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.Green;
                String agee = Console.ReadLine();

                int requiredAge;
                while (!int.TryParse(agee, out requiredAge) || (requiredAge < 0 || requiredAge > 100))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tPlease enter valid Age!", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n\tPlease enter your age for verification: ", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.Green;
                    agee = Console.ReadLine();
                }

                if (requiredAge >= getAge(age[movie - 1]))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\tEnjoy The Movie !", Console.ForegroundColor);
                    menu();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tYou are under Age for this movie, please book another movie", Console.ForegroundColor);
                    menu2(movie);
                }
            }
            else
                display();
        }

        public int getAge(String age )
        {
            int agee;
            if (int.TryParse(age, out agee))
            {
                return agee;
            }
            else
            {
                agee = getAgeFromRating(age);
            }
            return agee;
        }

        public int getAgeFromRating(String rating)
        {
            int age;
            
            switch (rating)
            {
                case "G" : age = 0;
                    break;
                case "PG" : age = 10;
                    break;
                case "PG-13" : age = 13;
                    break;
                case "R": age = 15;
                    break;
                case "NC-17" : age = 17;
                    break;
                default: age = -1;
                    break;
            }

            return age;
            
        }

        public void menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n\tPress M to go back to the Guest Main Menu \n\tPress S to go back to the Start Page\n ", Console.ForegroundColor);

            while (true)
            {
                cinfo = Console.ReadKey();
                if (cinfo.Key == ConsoleKey.M)
                    display();
                else if (cinfo.Key == ConsoleKey.S)
                    login();
                else
                    menu();
            }
        }

        public bool ValidateAgeOrRating(String rating)
        {
            String[] ratings = { "G", "PG", "PG-13", "R", "NC-17" };
            int age;

            if (int.TryParse(rating, out age))
            {
                if(age < 0 || age > 100)
                {
                    return false;
                }
                return true;
            }

            foreach(String item in ratings)
            {
                if(item.Equals(rating))
                {
                    return true;
                }
            }
            return false;
        }

        public void insert()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\tWelcome to the INOX. Feel the sound....\n\n",Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tHow Many Movies are playing today? ",Console.ForegroundColor);
            noofmovie = inputInt();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t /* G – General Audience, any age is good */", Console.ForegroundColor);
            Console.WriteLine("\t\t /* PG – We will take PG as 10 years or older */", Console.ForegroundColor);
            Console.WriteLine("\t\t /* PG-13 – We will take PG-13 as 13 years or older */", Console.ForegroundColor);
            Console.WriteLine("\t\t /* R – We will take R as 15 years or older. Don’t worry about accompany by parent case. */", Console.ForegroundColor);
            Console.WriteLine("\t\t /* NC-17 – We will take NC-17 as 17 years or older */", Console.ForegroundColor);

            
            if (noofmovie>10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tYou can Add Maximum 10 Movies", Console.ForegroundColor);
                Console.Clear();
                insert();
            }


            age = new String[noofmovie];
            name = new String[noofmovie];

            for (int j = 0; j < noofmovie; j++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\tPlease Enter the " + (j + 1) + " Movie's Name : ");
                Console.ForegroundColor = ConsoleColor.Green;
                name[j] = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tPlease Enter the Age Limit or rating for the " + (j + 1) + " Movie's : ");

                Console.ForegroundColor = ConsoleColor.Green;
                var agee = Console.ReadLine();

                while (!ValidateAgeOrRating(agee))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tEnter valid age or rating!", Console.ForegroundColor);
                    Console.Write("\n\tPlease Enter the Age Limit or rating for the " + (j + 1) + " Movie's : ");
                    agee = Console.ReadLine();
                }
                age[j] = agee;
            }

            for (int k = 0; k < noofmovie; k++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t" + (k+1) + ". {0} (age: {1})", name[k], age[k], Console.ForegroundColor);
            }
            Console.Clear();
            choice();
        }

        public int inputInt()
        {
            Console.Write("\n\tEnter Input: ");
            String input = Console.ReadLine();
            int option;
            while (!int.TryParse(input, out option))
            {
                Console.Write("\n\tPlease Enter Valid Input.");
                Console.Write("\n\n\tEnter Input: ");
                input = Console.ReadLine();
            }
            return option;
        }

        public void choice()
        {
            Console.Write("\n\tYour Movies Playing Today Are Listed Above. Are You Satisfied? (Y/N):  ");
            Console.ForegroundColor = ConsoleColor.Green;
            String choicee = Console.ReadLine();
            Console.Clear();

            switch (choicee.ToLower())
            {
                case "y":
                    login();
                    break;

                case "n":
                    insert();
                    break;

                default:
                    choice();
                    break;
            } 
        }
        public void login()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t*************************************", Console.ForegroundColor);
            Console.WriteLine("\t\t\t\t\t********** Welcome to INOX **********", Console.ForegroundColor);
            Console.WriteLine("\t\t\t\t\t*************************************", Console.ForegroundColor);
            Console.WriteLine("\t1: Login as an Administrator");
            Console.WriteLine("\t2: Login as a Guests\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tSelect option 1 or 2: ");
            Console.ForegroundColor = ConsoleColor.Green;
            String i = Console.ReadLine();
            Console.Clear();
            switch (i)
            {
                case "1":
                    admin();
                    break;

                case "2":
                    user();
                    break;

                default:
                    Console.WriteLine("\n\tPlease enter 1 for Admin and 2 for Guest. ");
                    login();
                    break;
            }    
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.login();
        }
    }
}
