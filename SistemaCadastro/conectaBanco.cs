using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace SistemaCadastro
{
    internal class conectaBanco
    {


        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root; password=thiago260507.;database=bancocadastro");
        public string mensagem;
        public bool insereBanda(Banda novaBanda)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereBanda", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nome", novaBanda.Nome);
                cmd.Parameters.AddWithValue("p_integrantes", novaBanda.Integrantes);
                cmd.Parameters.AddWithValue("p_ranking", novaBanda.Ranking);
                cmd.Parameters.AddWithValue("p_genero", novaBanda.Genero);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
        }

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

    }


}
