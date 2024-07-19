

static void Main(string[] args)
{
    string UserInput = args[0].ToLower();
    Console.WriteLine("Добро пожаловать в программу по управлению сотрудниками");

    Console.WriteLine("" +
        "Доступны следующие команды:\n" +
        " 1) -add First Name Last Name Salary\n" +
        " 2) -update ID (First Name/Last Name/Salary)\n" +
        " 3) -delete ID \n" +
        " 4) -get ID" +
        " 5) -getall");
    UserInput = Console.ReadLine();
    switch (UserInput)
        {
        case "-add"
    }
}