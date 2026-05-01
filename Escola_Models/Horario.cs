using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_Models
{
    public enum StatusHorario
    {
        Livre,
        Ocupado
    }

    public class Horario
    {
        

        public int Id { get; set; }

        public string HorarioTexto { get; set; }

        public StatusHorario Status { get; set; }

        public string Professor { get; set; }

        public string Disciplina { get; set; }

        public string Sala { get; set; }

        public string DiaSemana { get; set; }
    }
}
