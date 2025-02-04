﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingQuest_18jule
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary {  get; set; } 

        public Employee(int id, string firstName, string lastName, decimal salary) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
    }
}
