using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc_n.Models
{
    public class Seller
    {
        public int Id { get; set; }       
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Tamanho permitido entre {2} e {1} caracteres")]
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]                   //anotation
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }
       
        [Display(Name = "Base Salary")]                     //anotation
        [DisplayFormat(DataFormatString = "{0:F2}")]        //anotation
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        
        [Display(Name="Birt Date")]                         //anotation
        [DataType(DataType.Date)]                           //anotation
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//anotation
        public DateTime BirthDate { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        //construtor
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
        public void AddSales(SalesRecord sr) 
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) {
            //Expressao lambda do link
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
