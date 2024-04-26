using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppPruebaTecnica.Entities
{
    public class User
    {
        [Key] // Esta anotación indica que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public ICollection<Sale> sales { get; set; }
    }
}
