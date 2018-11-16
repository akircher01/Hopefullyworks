using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeLouisvileOccupationdata
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(@"..\..\beer.json");
            var beers = DeserializeBeers(fileName);


            while (true)
            {
                var beerMenu = MainMenu();
                // I had this as a while loop but it would repeat the function conitnuosly so I change it to an if. 

                switch (beerMenu)
                {
                    case 1:
                        SearchBeers();
                        break;
                    case 2:
                        SeeAll(beers);
                        break;
                    case 3:
                        beers = DeserializeBeers(@"..\..\beer.json");
                        var topTwentyAbv = GetTopTwentyAbv(beers);
                        foreach (var beer in topTwentyAbv)
                        {
                            Console.WriteLine("Name: " + beer.BeerName + " Abv: " + beer.Abv);
                        }
                        Console.WriteLine("Press enter");
                        Console.ReadLine();
                        break;
                    case 4:
                        Ibu();
                        break;
                    case 5:
                        RateBeer();
                        break;
                    case 6:
                        CommentBeer();
                        break;
                    case 7:
                        AddBeer();
                        break;
                    case 8:
                        //Breaks the loop and exits the program
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("You chose an invalid option.");
                        Exit();
                        break;
                }
                // Console.Write("Bye");
                // Console.ReadLine();
                // break;

            }
        }
        // Prompt user to enter	a name.						
        static int MainMenu()
        {


            Console.WriteLine("Hello! Welcome to the Beer Database! What would you like to do?");
            Console.WriteLine("   +------------------------------------------------------+");
            Console.WriteLine("   |   Main Menu                                          |");
            Console.WriteLine("   |   1. Search for a Beer by name, try Devil's Cup      |");
            Console.WriteLine("   |   2. See all the of the Beers currently on the list  |");
            Console.WriteLine("   |   3. Top 20 Alcohol by Volume (abv)                  |");
            Console.WriteLine("   |   4. Search by International Bittering Units (ibu)   |");
            Console.WriteLine("   |   5. Rate a Beer                                     |");
            Console.WriteLine("   |   6. Comment on a Beer                               |");
            Console.WriteLine("   |   7. Add a Beer                                      |");
            Console.WriteLine("   |   8. Exit                                            |");
            Console.WriteLine("   +------------------------------------------------------+");
            Console.WriteLine();
            Console.Write("Enter an option: ");

            var selected = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(selected))
            {
                return 8;
            }

            return int.Parse(selected);
        }

        static void SearchBeers()
        {

        }

        static void SeeAll(List<Beer> beers)
        {

            foreach (var beer in beers)
            {
                //fill in 
            }

        }
        //This gets my top 20 beers it uses my AbvComparer to sort it the only adds the top 20
        public static List<Beer> GetTopTwentyAbv(List<Beer> beers)
        {
            var topTwentyAbv = new List<Beer>();
            beers.Sort(new AbvComparer());
            int counter = 0;
            foreach (var beer in beers)
            {
                topTwentyAbv.Add(beer);
                counter++;
                if (counter == 20)
                    break;
            }
            return topTwentyAbv;


        }
        static void Ibu()
        {
            Console.WriteLine("This function is a working progress come back later");
        }
        static void RateBeer()
        {
            Console.WriteLine("This function is a working progress come back later");
        }
        static void CommentBeer()
        {
            Console.WriteLine("This function is a working progress come back later");
        }
        static void AddBeer()
        {
            var beer1 = new Beer();
            Console.WriteLine("NAME THAT BEER!!!");
            var beer1name = Console.ReadLine();
            beer1.BeerName = beer1name;
            Console.WriteLine("What is the Alcohol By Volume (ABV) of your Beer!");
            var beer1Abv = Console.ReadLine();
            int m = 0;
            try
            {
                m = Convert.ToInt32(beer1Abv);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            beer1.Abv = m;
            Console.WriteLine("Name the style of your Beer!");
            var beer1style = Console.ReadLine();
            beer1.Style = beer1style;
            writeFile(beer1);
        }

        static void Exit()
        {
            Console.WriteLine("This function is a working progress come back later");
        }


        //The is deserilizing my beer list to make it readable 
        public static List<Beer> DeserializeBeers(string fileName)

        {
            var beers = new List<Beer>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                serializer.NullValueHandling = NullValueHandling.Ignore;
                beers = serializer.Deserialize<List<Beer>>(jsonReader); ;
            }

            return beers;

        }
        public static void writeFile(Beer beers)
        {
            var content = DeserializeBeers(@"..\..\Beer.json");
            content.Add(beers);
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(content);

            File.WriteAllText(@"..\..\beer.json", jsonString);
        }



    }
}
