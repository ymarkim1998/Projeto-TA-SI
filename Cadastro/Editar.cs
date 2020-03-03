using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class Editar
    {
        Conexao conexao = new Conexao();
        SqlCommand sql = new SqlCommand();
        public String mensagem;

        public Editar(String codigo, String nome, String nascimento, String cpf, String sexo)
        {
            sql.CommandText = "UPDATE CLIENTE SET NOME = @NOME, NASCIMENTO = @NASCIMENTO, CPF = @CPF, SEXO = @SEXO WHERE IDCLIENTE = @CODIGO";

            sql.Parameters.AddWithValue("@NOME", nome);
            sql.Parameters.AddWithValue("@NASCIMENTO", nascimento);
            sql.Parameters.AddWithValue("@CPF", cpf);
            sql.Parameters.AddWithValue("@SEXO", sexo);
            sql.Parameters.AddWithValue("@CODIGO", codigo);

            try
            {
                sql.Connection = conexao.conectar();
                sql.ExecuteNonQuery();
                this.mensagem = "Cliente Editado com Sucesso!!";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao Editar Cliente: " + e;  
            }
        }
    }
}
