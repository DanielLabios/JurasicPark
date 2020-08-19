using System;
using System.Collections.Generic;
using System.Linq;

namespace JurasicPark
{
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
            // Starting The Program
            // ||||||||||||||||||||
            // ||||||||||||||||||||

            Console.Clear();

            Console.WriteLine("Hello, welcome to Caveman's High Tech Dinosaur Tracker!");
            Console.WriteLine("Modern Solutions for Prehistoric Problems");

            var runTime = true;
            var zooDinosaurs = new List<Dinosaur>();

            // Adding Dummy Data
            // |||||||||||||||||

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
                name = "Veloceraptor",
                dietType = "Carnivorous",
                whenAcquired = DateTime.Now.AddMonths(-2),
                weight = 34,
                enclosureNumber = 1,
                iD = 002,
            });
            zooDinosaurs.Add(new Dinosaur()
            {
                name = "Brontosaurus",
                dietType = "Herbivorous",
                whenAcquired = DateTime.Now.AddMonths(-6),
                weight = 36000,
                enclosureNumber = 5,
                iD = 003,
            });
            zooDinosaurs.Add(new Dinosaur()
            {
                name = "Stegosaurus",
                dietType = "Herbivorous",
                whenAcquired = DateTime.Now.AddMonths(-3),
                weight = 6800,
                enclosureNumber = 5,
                iD = 004,
            });

            // --------Menu----------
            // ||||||||||||||||||||||

            while (runTime == true)
            {
                Console.WriteLine("--View-- Show all the Dinosaurs currently in Zoo and their current state.");
                Console.WriteLine("--ADD-- Add a new Dinosaur brought into the Zoo into the CHTDT Management System");
                Console.WriteLine("--Transfer-- Change a Dinosaur's listed Enclosure");
                Console.WriteLine("--Remove-- Remove a Dinosaur from the CHTDT Management System  ");
                Console.WriteLine("--Summary-- Shows the current number of Carnivores & Herbivores at the Zoo");
                Console.WriteLine("--Quit-- Exit out of the CHTDT Management System");

                string choice = Console.ReadLine().ToUpper();
                Console.Clear();
                if (choice != "VIEW" && choice != "ADD" && choice != "REMOVE" && choice != "TRANSFER" && choice != "SUMMARY" && choice != "QUIT")
                {
                    choice = "FALSE";
                }

                switch (choice)
                {

                    // ----View Option----
                    // |||||||||||||||||||

                    case "VIEW":
                        var dinosInOrder = zooDinosaurs.OrderBy(Dinosaurs => Dinosaurs.whenAcquired);
                        foreach (Dinosaur Dino in dinosInOrder)
                        {
                            Dino.PrintDescription();
                            Console.WriteLine("\r\n");
                        }
                        break;

                    // ----Add Option----
                    // ||||||||||||||||||

                    case "ADD":
                        int tempiD = zooDinosaurs.Max(Dinosaurs => Dinosaurs.iD) + 1;
                        Console.WriteLine($"Adding new Dinosaur. His Unique ID will be {tempiD}.");
                        Console.WriteLine("Please give the Dinosaurs Species' name?");
                        string tempName = Console.ReadLine();
                        var inputSwitch = false;
                        string tempdietType = "unknown";

                        // While loop below checks to see if input was correct before going further

                        while (inputSwitch == false)
                        {
                            Console.WriteLine("Please give the Dinosaur's diet type?\r\nCarnivorous/Herbivorous or c/h");
                            tempdietType = Console.ReadLine().ToUpper();
                            if (tempdietType != "C" && tempdietType != "H" && tempdietType != "CARNIVOROUS" && tempdietType != "HERBIVOROUS")
                            {
                                Console.WriteLine("User Input was not recognized. Please Try Again.");
                                inputSwitch = false;
                            }
                            else if (tempdietType == "C" || tempdietType == "CARNIVOROUS")
                            {
                                tempdietType = "Carnivorous";
                                inputSwitch = true;
                            }
                            else if (tempdietType == "H" || tempdietType == "HERBIVOROUS")
                            {
                                tempdietType = "Herbivorous";
                                inputSwitch = true;
                            }
                        }
                        Console.WriteLine("Please give the Dinosaur's weight in pounds? ");
                        var tempweight = double.Parse(Console.ReadLine());
                        Console.WriteLine("Please give the EnclosureNumber the Dinosaur will be housed?");
                        var tempEnclosureNumber = int.Parse(Console.ReadLine());
                        DateTime tempDateTime = DateTime.Now;

                        // Data has been gathered, time to create and add new Dinosaur

                        Console.WriteLine($"{tempName} ID: {tempiD} has been successfully created!");
                        zooDinosaurs.Add(new Dinosaur()
                        {
                            name = tempName,
                            dietType = tempdietType,
                            whenAcquired = DateTime.Now,
                            weight = tempweight,
                            enclosureNumber = tempEnclosureNumber,
                            iD = tempiD,
                        });
                        break;

                    // ----Remove Option----
                    // |||||||||||||||||||||

                    case "REMOVE":
                        Console.WriteLine("Which Dinosaur do you want removed");
                        var nameGiven = Console.ReadLine();
                        var nameThatWasSearched = new List<Dinosaur>();
                        nameThatWasSearched.AddRange(zooDinosaurs.Where(Dinosaur => Dinosaur.name == nameGiven));

                        // Adventure Mode Implemented; if more than one name is returned, we prompt for specification before we remove correct Dinosaur using their ID property

                        if (nameThatWasSearched.Count() == 0)
                        {
                            Console.WriteLine($"The Listed Dinosaur {nameGiven} was not found.");
                        }
                        else if (nameThatWasSearched.Count() == 1)
                        {
                            zooDinosaurs.RemoveAt(zooDinosaurs.FindIndex(Dinosaur => Dinosaur.name.Contains(nameGiven)));
                        }
                        else if (nameThatWasSearched.Count() > 1)
                        {

                            // Gives Option to specify which Dino if more than one Dino Found

                            Console.WriteLine($"There was more than one Dinosaurs named {nameGiven}. Which one are you looking for?");
                            int counter = 1;
                            var listOfChoices = new List<int>();
                            foreach (Dinosaur dinosaur in nameThatWasSearched)
                            {
                                Console.WriteLine("{" + $"{counter}" + "}" + $"-----------ID: {dinosaur.iD}-----------Name: {dinosaur.name}---------");
                                dinosaur.PrintDescription();
                                Console.WriteLine();
                                listOfChoices.Add(counter);
                                counter++;
                            }
                            Console.Write("Choose Options:");
                            foreach (int options in listOfChoices)
                            {
                                Console.Write($"     " + "{" + $"{options}" + "}");
                            }
                            var optionChosen = int.Parse(Console.ReadLine());

                            // Space for "if input was wrong input, loop back"

                            zooDinosaurs.RemoveAt(zooDinosaurs.FindIndex(Dinosaur => Dinosaur.iD == nameThatWasSearched[optionChosen - 1].iD));
                        }
                        break;

                    // ----Transfer Option (similar to Remove Option----
                    // |||||||||||||||||||||||||||||||||||||||||||||||||

                    case "TRANSFER":
                        Console.WriteLine("Which Dinosaur do you want to Transfer?");
                        var nameGiven2 = Console.ReadLine();
                        var nameThatWasSearched2 = new List<Dinosaur>();
                        nameThatWasSearched2.AddRange(zooDinosaurs.Where(Dinosaur => Dinosaur.name == nameGiven2));

                        int iDOfNameGiven = 0;

                        if (nameThatWasSearched2.Count() == 0)
                        {
                            Console.WriteLine($"The Listed Dinosaur {nameGiven2} was not found.");
                        }
                        else if (nameThatWasSearched2.Count() == 1)
                        {
                            iDOfNameGiven = zooDinosaurs.First(Dinosaur => Dinosaur.name == nameGiven2).iD;
                        }
                        else if (nameThatWasSearched2.Count() > 1)
                        {
                            Console.WriteLine($"There was more than one Dinosaurs named {nameGiven2}. Which one are you looking for?");
                            int counter = 1;
                            var listOfChoices = new List<int>();
                            foreach (Dinosaur dinosaur in nameThatWasSearched2)
                            {
                                Console.WriteLine("{" + $"{counter}" + "}" + $"-----------ID: {dinosaur.iD}-----------Name: {dinosaur.name}---------");
                                dinosaur.PrintDescription();
                                Console.WriteLine();
                                listOfChoices.Add(counter);
                                counter++;
                            }
                            Console.Write("Choose Options:");
                            foreach (int options in listOfChoices)
                            {
                                Console.Write($"     " + "{" + $"{options}" + "}");
                            }
                            var optionChosen2 = int.Parse(Console.ReadLine());
                            iDOfNameGiven = zooDinosaurs.First(Dinosaur => Dinosaur.iD == nameThatWasSearched2[optionChosen2 - 1].iD).iD;
                        }
                        if (nameThatWasSearched2.Count() != 0)
                        {
                            Console.WriteLine("Which Enclosure are you transfering the Dinosaur into?");
                            var enclosureTransfer = int.Parse(Console.ReadLine());
                            zooDinosaurs.First(Dinosaur => Dinosaur.iD == iDOfNameGiven).enclosureNumber = enclosureTransfer;
                        }
                        break;

                    // ----Summary Option----
                    // ||||||||||||||||||||||

                    case "SUMMARY":
                        int herbDinos = zooDinosaurs.Where(Dinosaurs => Dinosaurs.dietType == "Herbivorous").Count();
                        int carnDinos = zooDinosaurs.Where(zooDinosaurs => zooDinosaurs.dietType == "Carnivorous").Count();
                        Console.WriteLine($"Currently, there are {herbDinos} Herbivores at the Zoo.");
                        Console.WriteLine($"Also, There are {carnDinos} Carnivores at the Zoo.");

                        break;

                    // ----Quit Option----
                    // |||||||||||||||||||

                    case "QUIT":
                        runTime = false;
                        break;

                    // ----Wrong Input Option----
                    // ||||||||||||||||||||||||||

                    case "FALSE":
                        Console.WriteLine("User Input was not recognized. Please Try Again.");
                        break;
                }
            }
        }
    }
}
