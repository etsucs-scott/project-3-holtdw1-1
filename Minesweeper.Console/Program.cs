using Minesweeper.Core;
bool main = true;
string action;
string row;
string column;//have to initialize here for scoping
while (main == true)
{
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

                bool state = true; //it's really hard to quit out of all these loops
                while (state == true) //this just keeps the loop going to recollect inputs
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
                        //-------This section is the logic for each map----------------
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
                            bool gameState = true;
                            while (gameState == true)
                            {
                                board.ShowBoard();//show the updated board on each loop

                                //-------This section validates user input for changing tile states-----------------
                                Console.WriteLine("Input the action for the tile - flag (f), reveal (r) or q to quit: ");
                                action = Console.ReadLine().ToLower();
                                while (true)
                                {
                                    while (action.ToLower() != "f" && action.ToLower() != "r" && action.ToLower() != "q")
                                    {
                                        Console.WriteLine("Invalid input! Please input just 'f' or 'r' (or 'q' to quit)");
                                        action = Console.ReadLine().ToLower();
                                    }
                                    if (action.ToLower() == "q")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Returning to main menu...\n\n");
                                        Thread.Sleep(500);
                                        gameState = false;
                                        state = false;
                                        running = false; //basically goes back to main menu
                                        break;
                                    }
                                    break;
                                }

                                if (action.ToLower() == "q") //these hold to break at any point in the program in case the user changes their mind
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Input the row to interact with (1 - {(int)board.Size}) or q to quit:");
                                    row = Console.ReadLine().ToLower();
                                    while (true)
                                    {
                                        if (row.ToLower() == "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Returning to main menu...\n\n");
                                            Thread.Sleep(500);
                                            gameState = false;
                                            state = false;
                                            running = false; //basically goes back to main menu
                                            break;
                                        }
                                        while (int.TryParse(row, out int y) == false || y < 1 || y > (int)board.Size)//false means the parsing didn't work
                                        {
                                            Console.WriteLine("Input was out of bounds, or was not a number. Please try again");
                                            row = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                if (action.ToLower() == "q" || row.ToLower() == "q")//check to make sure quit wasn't selected
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Input the column to interact with (1 - {(int)board.Size}) or q to quit:");
                                    column = Console.ReadLine().ToLower();
                                    while (true)
                                    {
                                        if (column.ToLower() == "q" || row.ToLower() == "q" || action.ToLower() == "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Returning to main menu...\n\n");
                                            Thread.Sleep(500);
                                            gameState = false;
                                            state = false;
                                            running = false; //basically goes back to main menu
                                            break;
                                        }
                                        while (int.TryParse(column, out int y) == false || y < 1 || y > (int)board.Size)//false means the parsing didn't work
                                        {
                                            Console.WriteLine("Input was out of bounds, or was not a number. Please try again");
                                            column = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                //-------This section handles the actual game logic for changing tile states--------------
                                if (action.ToLower() != "q" && row.ToLower() != "q" && column.ToLower() != "q")
                                {
                                    if (action.ToLower() == "f")//if you chose to flag
                                    {
                                        if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged == true)
                                        {
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = false;
                                            Console.Clear();
                                            Console.WriteLine("Flag removed");
                                            board.Moves++;
                                            //if it's flagged, remove the flag
                                        }
                                        else
                                        {
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = true;//-1 is because the user inputs 1-8, but the array is 0-7
                                            Console.Clear();
                                            Console.WriteLine("Flag placed");//it it's not, flag it
                                            board.Moves++;
                                        }
                                    }
                                    else if (action.ToLower() == "r")//reveal the cell
                                    {
                                        if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed == true)
                                        {
                                            Console.WriteLine("You've already revealed that one\n");
                                            //if it's already revealed, do nothing
                                        }
                                        else if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isMine == true)
                                        {
                                            //if you hit a bomb, end the game
                                            Console.Clear();
                                            Console.WriteLine("You hit a mine! Game over!\n\n");
                                            board.Moves++;
                                            state = false;
                                            running = false;
                                            gameState = false; //breaks the game loop, but not the main menu loop
                                        }
                                        else
                                        {
                                            //if all goes well, reveal the cell
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed = true;//reveals the cell. The -1 is because the user inputs 1-8, but the array is 0-7
                                            board.Search(board, int.Parse(column), int.Parse(row));
                                            Console.Clear();
                                            board.Moves++;
                                        }
                                        //I tried string.Split, but I couldn't really figure it out. Hope this works!
                                    }
                                }
                            }
                        }
                        if (choice2 == 2)
                        {
                            Console.WriteLine("Please input the map seed here, or leave blank for a random one: ");
                            string? input3 = Console.ReadLine();//same scoping issue
                            if (int.TryParse(input3, out int seed) == false)//false means the parsing didn't work
                            {
                                Console.WriteLine("Input was not a number, or was left blank. Generating random seed...");
                                board = new Board(Size.Medium, null);
                                Thread.Sleep(500);//pauses for half a second to pretend we're doing something
                                                  //slight issue: the user only gets one shot here
                            }
                            else//meaning if the parsing works
                            {
                                Console.WriteLine($"Generating board with seed: {seed}\n");
                                board = new Board(Size.Medium, seed);
                            }
                            board.GenerateBoard(Size.Medium);//makes the grid
                            board.PlaceMines((int)Size.Medium, board.Seed);//handles if the seed is null by itself
                                                                           //that little (int) means to treat the size as an int, not as an enum. This works
                                                                           //because each size has a number tied to it. Size.Small is just easier to read
                            bool gameState = true;
                            while (gameState == true)
                            {
                                board.ShowBoard();//show the updated board on each loop

                                //-------This section validates user input for changing tile states-----------------
                                Console.WriteLine("Input the action for the tile - flag (f), reveal (r) or q to quit: ");
                                action = Console.ReadLine().ToLower();
                                while (true)
                                {
                                    while (action.ToLower() != "f" && action.ToLower() != "r" && action.ToLower() != "q")
                                    {
                                        Console.WriteLine("Invalid input! Please input just 'f' or 'r' (or 'q' to quit)");
                                        action = Console.ReadLine().ToLower();
                                    }
                                    if (action.ToLower() == "q")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Returning to main menu...\n\n");
                                        Thread.Sleep(500);
                                        gameState = false;
                                        state = false;
                                        running = false; //basically goes back to main menu
                                        break;
                                    }
                                    break;
                                }

                                if (action.ToLower() == "q") //these hold to break at any point in the program in case the user changes their mind
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Input the row to interact with (1 - {(int)board.Size}) or q to quit:");
                                    row = Console.ReadLine().ToLower();
                                    while (true)
                                    {
                                        if (row.ToLower() == "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Returning to main menu...\n\n");
                                            Thread.Sleep(500);
                                            gameState = false;
                                            state = false;
                                            running = false; //basically goes back to main menu
                                            break;
                                        }
                                        while (int.TryParse(row, out int y) == false || y < 1 || y > (int)board.Size)//false means the parsing didn't work
                                        {
                                            Console.WriteLine("Input was out of bounds, or was not a number. Please try again");
                                            row = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                if (action.ToLower() == "q" || row.ToLower() == "q")//check to make sure quit wasn't selected
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Input the column to interact with (1 - {(int)board.Size}) or q to quit:");
                                    column = Console.ReadLine().ToLower();
                                    while (true)
                                    {
                                        if (column.ToLower() == "q" || row.ToLower() == "q" || action.ToLower() == "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Returning to main menu...\n\n");
                                            Thread.Sleep(500);
                                            gameState = false;
                                            state = false;
                                            running = false; //basically goes back to main menu
                                            break;
                                        }
                                        while (int.TryParse(column, out int y) == false || y < 1 || y > (int)board.Size)//false means the parsing didn't work
                                        {
                                            Console.WriteLine("Input was out of bounds, or was not a number. Please try again");
                                            column = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                //-------This section handles the actual game logic for changing tile states--------------
                                if (action.ToLower() != "q" && row.ToLower() != "q" && column.ToLower() != "q")
                                {
                                    if (action.ToLower() == "f")//if you chose to flag
                                    {
                                        if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged == true)
                                        {
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = false;
                                            Console.Clear();
                                            Console.WriteLine("Flag removed");
                                            board.Moves++;
                                            //if it's flagged, remove the flag
                                        }
                                        else
                                        {
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = true;//-1 is because the user inputs 1-8, but the array is 0-7
                                            Console.Clear();
                                            Console.WriteLine("Flag placed");//it it's not, flag it
                                            board.Moves++;
                                        }
                                    }
                                    else if (action.ToLower() == "r")//reveal the cell
                                    {
                                        if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed == true)
                                        {
                                            Console.WriteLine("You've already revealed that one\n");
                                            //if it's already revealed, do nothing
                                        }
                                        else if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isMine == true)
                                        {
                                            //if you hit a bomb, end the game
                                            Console.Clear();
                                            Console.WriteLine("You hit a mine! Game over!\n\n");
                                            board.Moves++;
                                            state = false;
                                            running = false;
                                            gameState = false; //breaks the game loop, but not the main menu loop
                                        }
                                        else
                                        {
                                            //if all goes well, reveal the cell
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed = true;//reveals the cell. The -1 is because the user inputs 1-8, but the array is 0-7
                                            board.Search(board, int.Parse(column), int.Parse(row));
                                            Console.Clear();
                                            board.Moves++;
                                        }
                                        //I tried string.Split, but I couldn't really figure it out. Hope this works!
                                    }
                                }
                            }
                        }//the medium map
                        if (choice2 == 3)
                        {
                            Console.WriteLine("Please input the map seed here, or leave blank for a random one: ");
                            string? input3 = Console.ReadLine();//same scoping issue
                            if (int.TryParse(input3, out int seed) == false)//false means the parsing didn't work
                            {
                                Console.WriteLine("Input was not a number, or was left blank. Generating random seed...");
                                board = new Board(Size.Large, null);
                                Thread.Sleep(500);//pauses for half a second to pretend we're doing something
                                                  //slight issue: the user only gets one shot here
                            }
                            else//meaning if the parsing works
                            {
                                Console.WriteLine($"Generating board with seed: {seed}\n");
                                board = new Board(Size.Large, seed);
                            }
                            board.GenerateBoard(Size.Large);//makes the grid
                            board.PlaceMines((int)Size.Large, board.Seed);//handles if the seed is null by itself
                                                                          //that little (int) means to treat the size as an int, not as an enum. This works
                                                                          //because each size has a number tied to it. Size.Small is just easier to read
                            bool gameState = true;
                            while (gameState == true)
                            {
                                board.ShowBoard();//show the updated board on each loop

                                //-------This section validates user input for changing tile states-----------------
                                Console.WriteLine("Input the action for the tile - flag (f), reveal (r) or q to quit: ");
                                action = Console.ReadLine().ToLower();
                                while (true)
                                {
                                    while (action.ToLower() != "f" && action.ToLower() != "r" && action.ToLower() != "q")
                                    {
                                        Console.WriteLine("Invalid input! Please input just 'f' or 'r' (or 'q' to quit)");
                                        action = Console.ReadLine().ToLower();
                                    }
                                    if (action.ToLower() == "q")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Returning to main menu...\n\n");
                                        Thread.Sleep(500);
                                        gameState = false;
                                        state = false;
                                        running = false; //basically goes back to main menu
                                        break;
                                    }
                                    break;
                                }

                                if (action.ToLower() == "q") //these hold to break at any point in the program in case the user changes their mind
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Input the row to interact with (1 - {(int)board.Size}) or q to quit:");
                                    row = Console.ReadLine().ToLower();
                                    while (true)
                                    {
                                        if (row.ToLower() == "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Returning to main menu...\n\n");
                                            Thread.Sleep(500);
                                            gameState = false;
                                            state = false;
                                            running = false; //basically goes back to main menu
                                            break;
                                        }
                                        while (int.TryParse(row, out int y) == false || y < 1 || y > (int)board.Size)//false means the parsing didn't work
                                        {
                                            Console.WriteLine("Input was out of bounds, or was not a number. Please try again");
                                            row = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                if (action.ToLower() == "q" || row.ToLower() == "q")//check to make sure quit wasn't selected
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Input the column to interact with (1 - {(int)board.Size}) or q to quit:");
                                    column = Console.ReadLine().ToLower();
                                    while (true)
                                    {
                                        if (column.ToLower() == "q" || row.ToLower() == "q" || action.ToLower() == "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Returning to main menu...\n\n");
                                            Thread.Sleep(500);
                                            gameState = false;
                                            state = false;
                                            running = false; //basically goes back to main menu
                                            break;
                                        }
                                        while (int.TryParse(column, out int y) == false || y < 1 || y > (int)board.Size)//false means the parsing didn't work
                                        {
                                            Console.WriteLine("Input was out of bounds, or was not a number. Please try again");
                                            column = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                //-------This section handles the actual game logic for changing tile states--------------
                                if (action.ToLower() != "q" && row.ToLower() != "q" && column.ToLower() != "q")
                                {
                                    if (action.ToLower() == "f")//if you chose to flag
                                    {
                                        if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged == true)
                                        {
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = false;
                                            Console.Clear();
                                            Console.WriteLine("Flag removed");
                                            board.Moves++;
                                            //if it's flagged, remove the flag
                                        }
                                        else
                                        {
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = true;//-1 is because the user inputs 1-8, but the array is 0-7
                                            Console.Clear();
                                            Console.WriteLine("Flag placed");//it it's not, flag it
                                            board.Moves++;
                                        }
                                    }
                                    else if (action.ToLower() == "r")//reveal the cell
                                    {
                                        if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed == true)
                                        {
                                            Console.WriteLine("You've already revealed that one\n");
                                            //if it's already revealed, do nothing
                                        }
                                        else if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isMine == true)
                                        {
                                            //if you hit a bomb, end the game
                                            Console.Clear();
                                            Console.WriteLine("You hit a mine! Game over!\n\n");
                                            board.Moves++;
                                            state = false;
                                            running = false;
                                            gameState = false; //breaks the game loop, but not the main menu loop
                                        }
                                        else
                                        {
                                            //if all goes well, reveal the cell
                                            board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed = true;//reveals the cell. The -1 is because the user inputs 1-8, but the array is 0-7
                                            board.Search(board, int.Parse(column), int.Parse(row));
                                            Console.Clear();
                                            board.Moves++;
                                        }
                                        //I tried string.Split, but I couldn't really figure it out. Hope this works!
                                    }
                                }
                            }
                        }//the large map
                        if (choice2 == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Returning to main menu...\n\n");
                            Thread.Sleep(500);
                            state = false;
                            running = false;
                            break;
                        }//back
                    }
                }
            }//play the game
            if (choice == 2)
            {
                Console.WriteLine("High Scores coming soon!\n");
                Thread.Sleep(1000);
                break;
            }//view saved high scores
            if (choice == 3)
            {
                Console.WriteLine("Exiting game...");
                Thread.Sleep(1000);
                main = false; //breaks the main menu loop, ending the program
                break;
            }//exit game
        }
    }
}