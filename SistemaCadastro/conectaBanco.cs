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



    }
}
