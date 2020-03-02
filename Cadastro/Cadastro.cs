using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class Cadastro
    {
        Conexao conexao = new Conexao();
        SqlCommand sql = new SqlCommand();
        public String mensagem = "";

        public Cadastro(String nome, String nascimento, String cpf, String sexo)
        {
            sql.CommandText = "INSERT INTO CLIENTE(NOME,NASCIMENTO,CPF,SEXO) VALUES (@nome, @nascimento, @cpf, @sexo)";

            sql.Parameters.AddWithValue("@nome", nome);
            sql.Parameters.AddWithValue("@nascimento", nascimento);
            sql.Parameters.AddWithValue("@cpf", cpf);
            sql.Parameters.AddWithValue("@sexo", sexo);

            try
            {
                sql.Connection = conexao.Conectar();
                sql.ExecuteNonQuery();
                conexao.Desconectar();
                this.mensagem = "Cliente Cadastrado com Sucesso!!";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao conectar com o Banco de Dados: \n " + e;
            }
        }
    }
}
