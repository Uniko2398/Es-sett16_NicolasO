using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class Anagrafica
    {
        [Key]
        public int anagrafica_id { get; set; }
        [Required (ErrorMessage = "il cognome è obbligatorio")]
        [StringLength(100, ErrorMessage ="Scrivere un cognome entro i 100 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(100, ErrorMessage = "Scrivere un nome entro i 100 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Scrivere un indirizzo entro i 100 caratteri")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "la città è obbligatorio")]
        [StringLength(100, ErrorMessage = "Scrivere una città entro i 100 caratteri")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Il CAP è obbligatorio")]
        [StringLength(5, ErrorMessage = "Scrivere un CAP entro i 5 caratteri")]
        public string CAP { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [StringLength(16, ErrorMessage = "Scrivere un nome entro i 100 caratteri")]
        public string Cod_Fisc { get; set; }
    }
}
