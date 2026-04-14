using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Escola_Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Usuario { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoCargo ID_Cargo { get; set; }
        public string Nome_Usuario { get; set; }
        public string Email { get; set; }

    }
    public enum TipoCargo
    {
        Coordenador = 1,
        Professor = 2,
        Aluno = 3
    }
}
