using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola_Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Usuario { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoCargo ID_Cargo { get; set; }
        public string Nome_Usuario { get; set; }
        public string Email { get; set; }
        [Column("Senha")]
        public string SenhaUsuario { get; set; }
        public DateTime DataAdmissao { get; set; }

    }
    public enum TipoCargo
    {
        Coordenador = 1,
        Professor = 2,
        Aluno = 3
    }
}
