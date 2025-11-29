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

        /*"server=localhost;user id=root;password=; database=cadastro_livros");*/

        /*"Server=mysql-3ea635ce-gustavomartinsdilima-c233.k.aivencloud.com;Port=18263;Database=defaultdb;Uid=avnadmin;Pwd=AVNS_P3XmOYbnN74aPM22Ece; SslMode=Required;"*/

        /*String nuvem "Server=mysql-3c994b13-gustavomartinslim06-ced0.j.aivencloud.com;Port=19122;Database=defaultdb;Uid=avnadmin;Pwd=AVNS_Be2RLD9TBg9YpFRXS2s;SslMode=Required;"**/
        MySqlConnection conexao = new MySqlConnection();
        public string mensagem="sucesso";

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

        }//fim do insereLivro


        public DataTable listaGeneros()
        {
            // comentario
            MySqlCommand cmd = new MySqlCommand("sp_listaGeneros", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_generos

        // Metodo no conecta Banco

        public DataTable listaLivros()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaLivros", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_bandas


    }//fim da classe
}
