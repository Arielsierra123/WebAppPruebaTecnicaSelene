using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppPruebaTecnica.Entities
{
    public class Sale
    {
        [Key] // Esta anotación indica que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Cantity { get; set; }  
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string TaxValue { get; set; }
        public DateTime DateSale { get; set; }

    }
}
