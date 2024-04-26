using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebAppPruebaTecnica.Entities;

namespace WebAppPruebaTecnica.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int ProviderId { get; set; }
        public int Code { get; set; }
        [ValidateNever]
        public List<Provider> Providers { get; set; }
    }
}
