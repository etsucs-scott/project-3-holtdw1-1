Console.WriteLine("--------------------Minesweeper Clone V0.01 - Alpha Build--------------");
Console.WriteLine("|-------------------Main Menu-----------------------------------------|");
Console.WriteLine("|1. New Game                                                          |");
Console.WriteLine("|2. High Scores                                                       |");
Console.WriteLine("|3. Exit                                                              |");
Console.WriteLine("-----------------------------------------------------------------------");
Console.Write("Input a number, and press enter to continue: ");
string? input = Console.ReadLine();

while (int.TryParse(input, out int choice) == true)
{
    if (input == null || (choice != 1 && choice != 2 && choice != 3))
    {
        Console.WriteLine("Invalid input! Please try again.");
        input = Console.ReadLine();
        choice = 0;
        int.TryParse(input, out choice);
    }
    else
    {
        //logic
    }
}