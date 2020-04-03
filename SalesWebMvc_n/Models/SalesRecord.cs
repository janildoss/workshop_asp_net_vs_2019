using SalesWebMvc_n.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc_n.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString ="{0:f2}")]
        public double Amount { get; set; }
        public SalesStatus SalesStatus { get; set; }
        public Seller Seller { get; set; }
        //construtores
        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus salesStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SalesStatus = salesStatus;
            Seller = seller;
        }
    }
}
