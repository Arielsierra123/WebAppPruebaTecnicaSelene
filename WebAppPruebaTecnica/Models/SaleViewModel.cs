using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using WebAppPruebaTecnica.Entities;

namespace WebAppPruebaTecnica.Models
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        [ValidateNever]
        public List<Product> Products { get; set; }
        public int ProductId { get; set; }
        public int Cantity { get; set; }
        public int UserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalAmount { get; set; }
        public string TaxValue { get; set; }
        public DateTime DateSale { get; set; }
    }
}
