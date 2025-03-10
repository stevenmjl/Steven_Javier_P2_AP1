using System.ComponentModel.DataAnnotations;

namespace Steven_Javier_P2_AP1.Models
{
    public class Encuesta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo no debe quedar vacío.")]
        [MaxLength(60, ErrorMessage = "No mayor de 60 letras")]
        public string? Asignatura { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Debe haber un monto")]
        [Range(1,200000, ErrorMessage = "Desde 1 hasta 200,000")]
        public double Monto { get; set; }
    }
}
