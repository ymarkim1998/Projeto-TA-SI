using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class Excluir
    {
        Conexao conexao = new Conexao();
        SqlCommand sql = new SqlCommand();
        public String mensagem = "";

        public Excluir(String codigo)
        {
            sql.CommandText = "DELETE FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";

            sql.Parameters.AddWithValue("@IDCLIENTE", codigo);

            try
            {
                sql.Connection = conexao.conectar();
                sql.ExecuteNonQuery();
                this.mensagem = "Cliente Excluído com Sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao Excluir Cliente: " + e;
            }
        }
    }
}
