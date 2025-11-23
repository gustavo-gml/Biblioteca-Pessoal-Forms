using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaCadastro
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=1234; database=cadastro_livros");
        public string mensagem;

        public bool insereLivro(Livro novoLivro)
        {
            try
            {
                conexao.Open();
                using (var cmd = new MySqlCommand("sp_insereLivro", conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("titulo", novoLivro.Titulo);
                    cmd.Parameters.AddWithValue("autor", novoLivro.Autor);
                    cmd.Parameters.AddWithValue("genero", novoLivro.Genero);
                    cmd.Parameters.AddWithValue("anoPublicacao", novoLivro.AnoPublicacao); // nome corrigido
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception erro) // capturar Exception ou adicionar ArgumentException
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open) conexao.Close();
            }
        }
    }
}
