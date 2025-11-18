using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ReverseText();
                        break;
                    case '5':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

       

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            /* List<string> använder en underliggande array som växer dynamisk
             * Capacity visar hur mycket plats som är allokerad, medan Count visar hur många  element faktiskt finns
             * - När ökar listans kapacitet? När vi lägger fler element än vad listan har plats för. När vi lägger första element får vi capacity 4,  
             * när vi lägger femte element blir capacity 8.
             * - Med hur mycket ökar kapaciteten? Den fördubblas. T ex (4, 8, 16 osv)
             * - Varför ökar inte listans kapacitet i samma takt som element läggs till? För att det är snabbare, det skulle bli långsammare om 
             * listan ändrade storlek varje gång.
             * - Minskar kapaciteten när element tas bort ur listan? Nej, capacity minskar inte, den stannar kvar även om listan blir tom
             * -  När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
             * När man vet exakt hur många element vi behöver. Då sparar vi minne och det går lite snabbare. Det märks mest när vi jobbar med stora datamängder. 
             */

            List<string> theList = new List<string>();
            
            while(true)
            {
                Console.WriteLine("\nEnter +\"Something\" to add or -\"Something\" to remove. Type \"Q\" to return to main menu.");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                    break;

                if (input.Length < 2)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);


                switch (nav) {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added \"{value}\" to the list.");
                        break;
                    case '-':
                        if (theList.Remove(value) == false)
                            Console.WriteLine($"\"{value}\" not found in the list.");
                        else
                            Console.WriteLine($" Removed \"{value}\" from the list.");
                        break;
                    default:
                        Console.WriteLine("Please use \"+\" to add or \"-\" to remove.");
                        break;
                }
                Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nEnter +\"Name\" to add someone to the queue or \"-\" to remove the first person. Type \"Q\" to return to main menu.");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                    break;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";

               
                if (nav == '+' && string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("You must enter a name after '+'.");
                    continue;
                }


                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        Console.WriteLine($" \"{value}\" added  to the queue.");
                        break;
                    case '-':
                        if (queue.Count > 0)
                        {
                            string removed = queue.Dequeue();
                            Console.WriteLine($"\"{removed}\" removed  from the queue.");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty. No one to remove.");
                        }
                        break;

                    default:
                        Console.WriteLine("Please use \"+\" to add or \"-\" to remove.");
                        break;
                }
                Console.WriteLine("Current queue: " + string.Join(", ", queue));
                Console.WriteLine($"Count: {queue.Count}");
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

           Stack<string> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("\nEnter +\"Name\" to add someone to the stack or \"-\" to remove the last person. Type \"Q\" to return to main menu.");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                    break;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";


                if (nav == '+' && string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("You must enter a name after '+'.");
                    continue;
                }


                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        Console.WriteLine($" \"{value}\" added  to the stack.");
                        break;
                    case '-':
                        if (stack.Count > 0)
                        {
                            string removed = stack.Pop();
                            Console.WriteLine($"\"{removed}\" removed  from the stack.");
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty. No one to remove.");
                        }
                        break;

                    default:
                        Console.WriteLine("Please use \"+\" to add or \"-\" to remove.");
                        break;
                }
                Console.WriteLine("Current stack: " + string.Join(", ", stack));
                Console.WriteLine($"Count: {stack.Count}");
            }
        }

        static void ReverseText()
        {
            while (true)
            {
                Console.WriteLine("\nEnter a text to reverse (or type Q to return to the main menu):");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("You must enter some text.");
                    continue;
                }

                if (input.ToLower() == "q")
                    break;
                Stack<char> charStack = new Stack<char>();

                foreach (char c in input)
                {
                    charStack.Push(c);
                }
                string reversed = "";
                while (reversed.Length > 0) 
                {
                    reversed += charStack.Pop();
                }
                Console.WriteLine("Reversed text: " + reversed);

            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

