using System;
using System.Collections.Generic;
using System.Linq;
//       PEDAC for Dinosaur Zoo Management App

// Problem - Create a simple Dinosaur Management System in Console that does the following:

namespace JurasicPark
{
    //  - Create Class (Dinosaur) with following properties
    //    - Name in string {get; set}
    //    - DietType, either carnivore or herbivore {get; set;}
    //    - whenAcquired, stores date in (vartype????, will be printed out to console later)
    //      at time when a new Dinosaur is created.  use => datetime.now public DateTime Now {get;}
    //    - weight in double {get; set;}
    //    - Enclosure Number - Int
    //    - Public ID Int - {get; Set;}

    //  - Class (Dinosuar) has following method
    //    - input(no)
    //    - Prints a discription of the Dinosaur that includes all properties
    //    - output string
    class Dinosaur
    {
        public string name { get; set; }
        public string dietType { get; set; }
        public DateTime whenAcquired = new DateTime();
        public double weight { get; set; }
        public int enclosureNumber { get; set; }
        public int iD { get; set; }

        public void PrintDescription()
        {
            Console.WriteLine($"Dino {iD} is a {dietType} {name} who is housed in Enclosure {enclosureNumber}. Dino {iD} weighs {weight} Pounds and was brought into the zoo at {whenAcquired}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, welcome to Caveman's High Tech Dinosaur Tracker!");
            Console.WriteLine("Modern Solutions for Prehistoric Problems");

            var runTime = true;
            var zooDinosaurs = new List<Dinosaur>();

            zooDinosaurs.Add(new Dinosaur()
            {
                name = "Veloceraptor",
                dietType = "Carnivorous",
                whenAcquired = DateTime.Now.AddMonths(-1),
                weight = 33,
                enclosureNumber = 1,
                iD = 001,
            });
            zooDinosaurs.Add(new Dinosaur()
            {
                name = "Brontosaurus",
                dietType = "Herbivorous",
                whenAcquired = DateTime.Now.AddMonths(-6),
                weight = 36000,
                enclosureNumber = 5,
                iD = 002,
            });
            zooDinosaurs.Add(new Dinosaur()
            {
                name = "Stegosaurus",
                dietType = "Herbivorous",
                whenAcquired = DateTime.Now.AddMonths(-3),
                weight = 6800,
                enclosureNumber = 5,
                iD = 003,
            });


            while (runTime == true)
            {
                Console.WriteLine("--View-- Show all the Dinosaurs currently in Zoo and their current state.");
                Console.WriteLine("--ADD-- Add a new Dinosaur brought into the Zoo into the CHTDT Management System");
                Console.WriteLine("--Transfer-- Change a Dinosaur's listed Enclosure");
                Console.WriteLine("--Remove-- Remove a Dinosaur from the CHTDT Management System  ");
                Console.WriteLine("--Summary-- Shows the current number of Carnivores & Herbivores at the Zoo");
                Console.WriteLine("--Quit-- Exit out of the CHTDT Management System");

                string choice = Console.ReadLine().ToUpper();
                if (choice != "VIEW" && choice != "ADD" && choice != "REMOVE" && choice != "TRANSFER" && choice != "SUMMARY" && choice != "QUIT")
                {
                    choice = "FALSE";
                }

                switch (choice)
                {
                    case "VIEW":
                        var dinosInOrder = zooDinosaurs.OrderBy(Dinosaurs => Dinosaurs.whenAcquired);
                        foreach (Dinosaur Dino in dinosInOrder)
                        {
                            Dino.PrintDescription();
                        }
                        break;

                    case "QUIT":
                        runTime = false;
                        break;

                    case "FALSE":
                        Console.WriteLine("User Input was not recognized. Please Try Again.");
                        break;
                }


                //  - When the Console application runs, the options can be executed by the user

                //    - VIEW - this command will show all the dinosaurs in a list<Dinosaur> (ZooDinosaurs) ordered by WhenAcquired
                //       - 
                //       - Use Linq Expression .orderby or similar to store ZooDinosaurs in varDinosaursAcquiredInOrder
                //       - for each Dinosaur in DAIO Print Discription

                //    - ADD - this command will create a new Dinosaur class and let the user type in the name diet type weight and enclosure number
                //          - Autogenerate a ID number for the Dinosaur to avoid duplicate name issues down the road
                // 	 - it would be nice if after adding the Dinosaur, the console prints out confirmation and unique ID of Dinosaur
                //          - print autogenerated Id and store it in temp var 
                //          - ask for name of dinosaur and store it in temp var
                //          - ask for carnivore or herbivore, if != c or h, printtypoacknowledgement() and loop back; store in temp var
                //          - ask for weight, convert to double (USE TRYPARSE), if null, printtypoacknowledgement() and loop back, store in temp var
                //          - ask for enclosure, convert to int, if null, printtypoacknowledgement() and loop back, store in temp var
                //          - create new dinosaur using all tempvars
                //          - print (success!!)

                //    - Remove - This command will prompt the user for a Dinosuar name, then find and delete the dinosaur name
                //       - ask for name of Dinosaur
                //       - look for name of Dinosuar in ZooDinosaurs and store it in list
                //       - if no name found (null) or Count ==0 (print not found and get out of remove)
                // 	(candidate for static method linq called DinoInQuestion etc)inputnamestring output list process .where
                //       - if multiple names found print all descriptions and ask for index number input
                //       - else, indextoremove == 0
                //       - remove index number based on index input


                //    - Transfer - This command will prompt the user for a dinosuar name (DinoInQuestion) and a new Enclosure Number and update that dino's information
                // 	- dinoInQuestion
                //         - ask for Enclosure Number
                //         - update enclosure number (method within class Dinosaur)

                //    - Summary - This Command will display the number of carnivores and the number of herbivores
                //        - where carnivores are listed in ZooDinosuar, store it in a list called carnivores
                //        - where herbivores are listed in ZooDinosuar, store it in a list called herbivores
                //        - print out carnivores and herbivores
                //    - Quit - This will stop the program
                //    - set while to checker to false
                //    - print goodbye outside of while loop

                //    - If typo, printtypoacknowledgement()


            }
        }
    }
}
