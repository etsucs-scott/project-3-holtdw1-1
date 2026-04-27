using Minesweeper.Core;

//I think this little menu is cute
Console.WriteLine("--------------------Minesweeper Clone V0.01 - Alpha Build--------------");
Console.WriteLine("|-------------------Main Menu-----------------------------------------|");
Console.WriteLine("|1. New Game                                                          |");
Console.WriteLine("|2. High Scores                                                       |");
Console.WriteLine("|3. Exit                                                              |");
Console.WriteLine("-----------------------------------------------------------------------");
Console.Write("Input a number, and press enter to continue: ");

bool running = true;
Board board;//was having scoping issues, so I'm defining it here, initializing later
while (running == true) //set to false to break the entire loop
{
    string? input = Console.ReadLine();
    Console.WriteLine(); //formatting

    if (int.TryParse(input, out int choice) == false) //with tryparse, it takes in the input. If it screws up
    {//, it returns a false bool. If it works, it returns true and assigns "choice" as a local int for use
        Console.WriteLine("Invalid input! You need a number. Please try again.");
    }
    else if ((choice != 1 && choice != 2 && choice != 3))//if choice doesn't do anything, try again
    {
        Console.WriteLine("Invalid input! Please try again.");
    }
    else
    {
        if (choice == 1)//new game, display menu for size choice
        {
            Console.Clear(); //empties the main menu that we're not using anymore
            Console.WriteLine("--------------------Choose the board size------------------------------");
            Console.WriteLine("|1. Small board - 8x8 with 10 mines                                   |");
            Console.WriteLine("|2. Medium board - 12x12 with 25 mines                                |");
            Console.WriteLine("|3. Large board - 16x16 with 40 mines                                 |");
            Console.WriteLine("|4. Back                                                              |");
            Console.WriteLine("-----------------------------------------------------------------------\n");
            Console.Write("Input a number, and press enter to continue: ");

            while (true) //this just keeps the loop going to recollect inputs
            {
                string? input2 = Console.ReadLine(); //input is technically in the same scope, so I made a new one
                Console.WriteLine();//formatting

                if (int.TryParse(input2, out int choice2) == false)//same with choice
                {
                    Console.WriteLine("Invalid input! You need a number. Please try again.");
                }
                else if ((choice2 != 1 && choice2 != 2 && choice2 != 3 && choice2 != 4))
                {
                    Console.WriteLine("Invalid input! Please try again.");
                }
                else
                {
                    //-------This section is the logic for small maps----------------
                    if (choice2 == 1)
                    {
                        Console.WriteLine("Please input the map seed here, or leave blank for a random one: ");
                        string? input3 = Console.ReadLine();//same scoping issue
                        if (int.TryParse(input3, out int seed) == false)//false means the parsing didn't work
                        {
                            Console.WriteLine("Input was not a number, or was left blank. Generating random seed...");
                            board = new Board(Size.Small, null);
                            Thread.Sleep(500);//pauses for half a second to pretend we're doing something
                            //slight issue: the user only gets one shot here
                        }
                        else//meaning if the parsing works
                        {
                            Console.WriteLine($"Generating board with seed: {seed}\n");
                            board = new Board(Size.Small, seed);
                        }
                        board.GenerateBoard(Size.Small);//makes the grid
                        board.PlaceMines((int)Size.Small, board.Seed);//handles if the seed is null by itself
                        //that little (int) means to treat the size as an int, not as an enum. This works
                        //because each size has a number tied to it. Size.Small is just easier to read
                        board.ShowBoard();
                    }
                }
            }
        }
    }
}