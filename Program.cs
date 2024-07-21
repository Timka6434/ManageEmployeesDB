using System;

namespace TestingQuest_18jule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();

            Console.WriteLine("Добро пожаловать в программу по управлению сотрудниками");

            string userInput;
            do
            {
                Console.WriteLine("\nДоступны следующие команды:\n" +
                    " 1) -add FirstName LastName Salary\n" +
                    " 2) -update ID FirstName LastName Salary\n" +
                    " 3) -delete ID\n" +
                    " 4) -get ID\n" +
                    " 5) -getall\n" +
                    " 6) -exit\n");
                userInput = Console.ReadLine().ToLower();

                string[] inputParts = userInput.Split(' ');

                switch (inputParts[0])
                {
                    case "-add":
                        if (inputParts.Length == 4 && decimal.TryParse(inputParts[3], out decimal salary))
                        {
                            int newId = manager.GetNextFreeId();
                            manager.AddEmployee(new Employee(newId, inputParts[1], inputParts[2], salary));
                        }
                        else
                        {
                            Console.WriteLine("Неправильный формат команды. Используйте: -add FirstName LastName Salary");
                        }
                        break;

                    case "-update":
                        if (inputParts.Length == 4 && int.TryParse(inputParts[1], out int updateId))
                        {
                            manager.UpdateEmployee(updateId, inputParts[2], inputParts[3]);
                        }
                        else
                        {
                            Console.WriteLine("Неправильный формат команды. Используйте: -update ID Field NewValue");
                        }
                        break;

                    case "-delete":
                        if (inputParts.Length == 2 && int.TryParse(inputParts[1], out int deleteId))
                        {
                            manager.RemoveEmployee(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Неправильный формат команды. Используйте: -delete ID");
                        }
                        break;

                    case "-get":
                        if (inputParts.Length == 2 && int.TryParse(inputParts[1], out int getId))
                        {
                            Employee emp = manager.GetEmployee(getId);
                            if (emp != null)
                            {
                                Console.WriteLine($"ID: {emp.Id}, Имя: {emp.FirstName}, Фамилия: {emp.LastName}, Зарплата: {emp.Salary}");
                            }
                            else
                            {
                                Console.WriteLine($"Сотрудник с ID - {getId} не найден.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неправильный формат команды. Используйте: -get ID");
                        }
                        break;

                    case "-getall":
                        manager.ShowAllEmployees();
                        break;

                    case "-exit":
                        Console.WriteLine("Выход из программы...");
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда. Пожалуйста, попробуйте снова.");
                        break;
                }
            } while (userInput != "-exit");
        }
    }
}
