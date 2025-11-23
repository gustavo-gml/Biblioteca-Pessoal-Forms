using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    internal class Livro
    {
        string titulo;
        string autor;
        int genero;
        int anoPublicacao;

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int Genero { get => genero; set => genero = value; }
        public int AnoPublicacao { get => anoPublicacao; set => anoPublicacao = value; }
    }
}
