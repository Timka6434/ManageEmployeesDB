using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestingQuest_18jule
{
    internal class EmployeeManager
    {
        public LinkedList<Employee> employeesList;

        EmployeeManager()
        {
            employeesList = new LinkedList<Employee>();
            //ExistJsonDb();
        }


        /*private void ExistJsonDb()
        {
            string filePath = @"\JsonDB\EmployeeDataBase.json";
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? string.Empty);
                File.Create(filePath).Close();
            }
            string jsonString = JsonConvert.SerializeObject(employeesList);
        }*/

        private void SaveEmployeesToFile()
        {
            string filePath = @"JsonDB\EmployeeDataBase.json";
            string jsonString = JsonConvert.SerializeObject(employeesList);
            File.WriteAllText(filePath, jsonString);
        }

        public void AddEmployee(Employee employee)
        {
            employeesList.AddLast(employee);
            SaveEmployeesToFile();
        }

        public void RemoveEmployee(int id)
        {
            foreach (Employee emp in employeesList)
            {
                if(emp.Id == id)
                {
                    employeesList.Remove(emp);
                    Console.WriteLine($"Пользователь с ID - {id} успешно удалён!");
                }
                else
                {
                    Console.WriteLine($"Пользователя с ID - {id} не существует");
                }
            }
            SaveEmployeesToFile();
        }

        public void GetEmployee(int id)
        {

        }

        public void UpdateEpmloyee(int id)
        {

        }

        public void ShowAllEmployees()
        {

        }
    }
}
