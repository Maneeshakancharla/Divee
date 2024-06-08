using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Health { get; set; }

        public Pet(string name, string type)
        {
            Name = name;
            Type = type;
            Hunger = 4;
            Happiness = 4;
            Health = 6;
        }

        public void Feed()
        {
            Hunger -= 3;
            if (Hunger < 0) Hunger = 0;
            Health += 1;
            if (Health > 10) Health = 10;
            Console.WriteLine($"{Name} has been fed. Hunger decreased to 3, health increased to 1.");
        }

        public void Play()
        {
            Happiness += 3;
            if (Happiness > 10) Happiness = 10;
            Hunger += 1;
            if (Hunger > 10) Hunger = 10;
            Console.WriteLine($"{Name} has played. Happiness increased by 3, hunger increased by 1.");
        }

        public void Rest()
        {
            Health += 2;
            if (Health > 10) Health = 10;
            Happiness -= 1;
            if (Happiness < 0) Happiness = 0;
            Console.WriteLine($"{Name} has rested. Health increased by 2, happiness decreased by 1.");
        }

        public void Status()
        {
            Console.WriteLine($"Name: {Name}, Type: {Type}, Hunger: {Hunger}, Happiness: {Happiness}, Health: {Health}");
        }
    }

    class petsimulator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Pet Simulator!");
            Console.Write("Enter your pet's name: ");
            string petname = Console.ReadLine();

            Console.WriteLine("Choose your pet type:");
            Console.WriteLine("1. Cat");
            Console.WriteLine("2. Dog");
            Console.WriteLine("3. Rabbit");
            Console.WriteLine("4.Other");
            Console.Write("Enter your choice: ");
            int petChoice = Convert.ToInt32(Console.ReadLine());

            string petType;
            switch (petChoice)
            {
                case 1:
                    petType = "Cat";
                    break;
                case 2:
                    petType = "Dog";
                    break;
                case 3:
                    petType = "Rabbit";
                    break;
                default:
                    petType = "Other";
                    break;
            }

            Pet pet = new Pet(petname, petType);

            Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Check status");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Rest();
                        break;
                    case "4":
                        pet.Status();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }

                pet.Hunger += 1;
                pet.Happiness -= 1;

         //check critical status
                if (pet.Hunger >= 8)
                {
                    Console.WriteLine($"{pet.Name} is Hungry! Please feed pet.");
                }
                if (pet.Happiness <= 2)
                {
                    Console.WriteLine($"{pet.Name} is very unhappy! Spend some time playing with your pet.");
                }
                if (pet.Health <= 2)
                {
                    Console.WriteLine($"{pet.Name} is sick! Take your pet to the doctor.");
                }
               
            }
            Console.WriteLine("Thank you for playing the virtual play simulator");
        }
    }

}
