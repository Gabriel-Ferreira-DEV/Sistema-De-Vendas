using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); // salesrecord contra as vendas dos funcionarios

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) // adiciona uma venda
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr) // remove uma venda
        {
            Sales.Remove(sr);
        }

        public double ToTalSales(DateTime initial,DateTime Final) // calcula o total de vendas em um periodo de tempo
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= Final).Sum(sr => sr.Amount);
        }
    }
}
