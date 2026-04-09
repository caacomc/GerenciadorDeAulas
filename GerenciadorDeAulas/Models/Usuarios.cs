using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeAulas.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome_Usuario { get; set; }
        public string Email {  get; set; }
        public string senhaHash { get; set; }
        public perfilUsuario Perfil { get; set; }
    }
    public enum perfilUsuario
    {
        Professor,
        Coordenador
    }
}
