using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP.Models
{
    public class Gastos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0.01, int.MaxValue, ErrorMessage ="El monto ingresado debe ser mayor a 0")] 
        public decimal Monto {  get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage="La descripción debe contener entre 3 a 250 caracteres")]
        public string Descripcion { get; set; }
        [Required]
        public DateOnly Fecha { get; set; } 
        [Required]
        [StringLength(250, ErrorMessage = "El nombre del comercio no debe contener más de 250 caracteres")]
        public string NombreComercio { get; set; }

    }
}
