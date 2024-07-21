using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestingQuest_18jule
{
    public class EmployeeManager
    {
        public LinkedList<Employee> employeesList;

        public EmployeeManager()
        {
            employeesList = new LinkedList<Employee>();
            LoadEmployeesFromFile();
        }

        private void LoadEmployeesFromFile()
        {
            string filePath = @"JsonDB\EmployeeDataBase.json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var employees = JsonConvert.DeserializeObject<LinkedList<Employee>>(jsonString);
                if (employees != null)
                {
                    employeesList = employees;
                }
            }
        }

        private void SaveEmployeesToFile()
        {
            string filePath = @"JsonDB\EmployeeDataBase.json";
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string jsonString = JsonConvert.SerializeObject(employeesList);
            File.WriteAllText(filePath, jsonString);
        }

        public void AddEmployee(Employee employee)
        {
            employeesList.AddLast(employee);
            SaveEmployeesToFile();
            Console.WriteLine($"Сотрудник {employee.FirstName} {employee.LastName} добавлен.");
        }

        public void RemoveEmployee(int id)
        {
            Employee employeeToRemove = null;
            foreach (Employee emp in employeesList)
            {
                if (emp.Id == id)
                {
                    employeeToRemove = emp;
                    break;
                }
            }

            if (employeeToRemove != null)
            {
                employeesList.Remove(employeeToRemove);
                SaveEmployeesToFile();
                Console.WriteLine($"Сотрудник с ID - {id} успешно удалён!");
            }
            else
            {
                Console.WriteLine($"Сотрудник с ID - {id} не найден.");
            }
        }

        public Employee GetEmployee(int id)
        {
            foreach (Employee emp in employeesList)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }

        public void UpdateEmployee(int id, string field, string newValue)
        {
            Employee employeeToUpdate = GetEmployee(id);
            if (employeeToUpdate != null)
            {
                switch (field.ToLower())
                {
                    case "firstname":
                        employeeToUpdate.FirstName = newValue;
                        break;
                    case "lastname":
                        employeeToUpdate.LastName = newValue;
                        break;
                    case "salary":
                        if (decimal.TryParse(newValue, out decimal newSalary))
                        {
                            employeeToUpdate.Salary = newSalary;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение для зарплаты.");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Некорректное поле для обновления.");
                        return;
                }
                SaveEmployeesToFile();
                Console.WriteLine($"Сотрудник с ID - {id} успешно обновлён.");
            }
            else
            {
                Console.WriteLine($"Сотрудник с ID - {id} не найден.");
            }
        }

        public void ShowAllEmployees()
        {
            Console.WriteLine("Список всех сотрудников:");
            foreach (Employee emp in employeesList)
            {
                Console.WriteLine($"ID: {emp.Id}, Имя: {emp.FirstName}, Фамилия: {emp.LastName}, Зарплата: {emp.Salary}");
            }
        }

        public int GetNextFreeId()
        {
            int id = 1;
            HashSet<int> usedIds = new HashSet<int>();
            foreach (Employee emp in employeesList)
            {
                usedIds.Add(emp.Id);
            }
            while (usedIds.Contains(id))
            {
                id++;
            }
            return id;
        }
    }
}
