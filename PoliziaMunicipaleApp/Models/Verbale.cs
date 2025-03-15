using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliziaMunicipale.Models
{
    public class Verbale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataViolazione { get; set; }

        [Required]
        public string IndirizzoViolazione { get; set; }

        [Required]
        public string Nominativo_Agente { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [Required]
        public decimal Importo { get; set; }

        [Required]
        public int DecurtamentoPunti { get; set; }

        [ForeignKey("anagrafica_id")]
        public int anagrafica_id { get; set; }

        public virtual Anagrafica? Anagrafica { get; set; }

        [ForeignKey("violazione_id")]
        public int violazione_id { get; set; }

        public virtual Tipo_Violazione? Violazione { get; set; }
    }
}
