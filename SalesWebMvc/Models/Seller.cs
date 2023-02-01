﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }

        private ICollection<SalesRecord> _sales = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sales)
        {
            _sales.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            _sales.Remove(sales);
        }

        public double TotalSales(DateTime dateInitial, DateTime dateFinal)
        {
            return _sales.Where(sales => sales.Date >= dateFinal && sales.Date <= dateFinal).Sum(sales => sales.Amount);
        }
    }
}
