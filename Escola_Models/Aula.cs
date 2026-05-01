using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_Models
{
    public class Aula
    {
        [Key]//define como pk
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//define que o banco de dados adiciona o número, ou seja, lá no bd é auto_increment
        public int Id { get; set; }
        public string Responsavel {  get; set; }
        public string Materia { get; set; }
        public int Sala {  get; set; }
        public TimeSpan Horario { get; set; }

    }
}
