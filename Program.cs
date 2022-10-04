using System;
using System.Reflection;

namespace ShoppingListJT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool start = true;
            while (start == true)
            {
                Console.WriteLine("Welcome to the shop. Here's what we have for sale:");
                Console.WriteLine();

                Dictionary<string, double> shoppingList = new Dictionary<string,double>(); //display 8 items w/ price.
                List<int> cart = new List<int>();

                shoppingList.Add("Apple", 2.00);
                shoppingList.Add("Pears", 2.50);
                shoppingList.Add("Beef", 5.75);
                shoppingList.Add("Dried Seaweed", 1.50);
                shoppingList.Add("Dehydrated Water", 70.25);
                shoppingList.Add("Purple Yams", 1.15);
                shoppingList.Add("Dried Plums", 4.25);
                shoppingList.Add("Canned Asparagus", 3.25);

                Console.WriteLine("Available Products");
                Console.WriteLine("------------------------");

                int i = 1;
                foreach (KeyValuePair<string, double> kvp in shoppingList) //foreach loop to display dictionary objects 
                    {
                        Console.WriteLine($"{i}) " + kvp.Key + " " + "$" + kvp.Value); //interpolation,{i}, and i++ values to create number list for dictionary. 
                    i++;
                    }

                Console.WriteLine("------------------------");
                Console.WriteLine();

                bool qLoop = true; //question loop for adding items to cart
                while (true)
                {
                    Console.WriteLine("Please enter the number of the item you would like to add to your cart 1-8. Or, if you are done shopping enter '0''.");  //allow user to add to orders
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();


                    if (userInput < 0 || userInput > 8) //filter user input for items outside of the range.
                    {
                        Console.WriteLine("Error, the choice you have selected does not exist. Please try again."); //return to question
                        Console.WriteLine();
                    }
                    else if (userInput == 0)
                    {
                        Console.WriteLine("Beginning checkout:");
                        Console.WriteLine();
                        break; // exits loop
                    }
                    else
                    {
                        cart.Add(userInput); //adds most recent line of user input to 'cart' list.
               
                        Console.WriteLine("In shopping cart:");
                        foreach (int carts in cart) //loop to display current items in cart. (currently displays integers related to list, not keys related to dictonary)
                        {
                            Console.Write($"{carts}, ");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine("The items in your cart are:");
             
                
                foreach (int carts in cart)    //display all ordered items w/ prices (displaying 
                {
                    Console.Write($"{shoppingList.ElementAt(carts).Key}, "); //translates 'cart' list to keys/names from 'shoppingList' dictonary 
                    Console.Write($"{shoppingList.ElementAt(carts).Value}, "); // translates 'cart' list to values/prices from 'shoppingList' dictonary

                    //.ElementAt is used to return the value at a specific index, specificly the indexes from the list)

                    Console.WriteLine();
                }        

                double sum = 0; //declaring double before foreachloop.
                foreach (int carts in cart) //sum of values from the dictionary
                {
                    sum += shoppingList.ElementAt(carts).Value;
                }
                Console.WriteLine("Your total bill is ${0}", sum); //sum of all items

                start = restart(); //prompt to restart or quit
                Console.WriteLine();
            }
        }
        public static bool restart()
        {
            Console.WriteLine("Do you want to restart? Y/N");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;

            }
            else if (input == "n")
            {
                return false;
            }
            else //if user input is not "y" or "n"
            {
                Console.WriteLine("I'm sorry, I'm afraid I can't do that, invalid input. Please try again.");
                return restart();
            }
        }
    }
}