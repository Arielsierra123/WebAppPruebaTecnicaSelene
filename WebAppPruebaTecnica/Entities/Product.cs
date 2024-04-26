using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppPruebaTecnica.Entities
{
    public class Product
    {
        [Key] // Esta anotación indica que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public string Picture {  get; set; }
        public int ProviderId { get; set; }
        public ICollection<Sale> sales {  get; set; } 
    }
}
