using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppPruebaTecnica.Entities
{
    public class Provider
    {
        [Key] // Esta anotación indica que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }
        public long Phone { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
