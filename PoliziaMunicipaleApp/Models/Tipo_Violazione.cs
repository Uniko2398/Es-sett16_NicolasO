using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class Tipo_Violazione
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Una breve descrizione è obbligatoria")]
        [StringLength(200, ErrorMessage ="Rimanere nel range di 200 caratteri")]
        public string Descrizione { get; set; }
    }
}
