using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Form1 : Form
    {
        Conexao conexao = new Conexao();
        SqlDataAdapter adapter;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            preencherTabela();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            DialogResult dialogResult = MessageBox.Show("Deseja criar um novo resgistro" + "?", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        public void limparCampos()
        {
            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtSexo.Text = "";
            dataGridView.Rows.Clear();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja gravar o Cliente com o CPF: " + txtCPF.Text + "?", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Cadastro cadastro = new Cadastro(txtNome.Text, txtNascimento.Text, txtCPF.Text, txtSexo.Text);

                MessageBox.Show(cadastro.mensagem);

                limparCampos();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir o Cliente com o CPF: " + txtCPF.Text + "?", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void preencherTabela()
        {
            adapter = new SqlDataAdapter("SELECT * FROM CLIENTE", conexao.Conectar());

            dt = new DataTable();

            adapter.Fill(dt);

            dataGridView.DataSource = dt;

            dataGridView.Columns[0].HeaderText = "Código";
            dataGridView.Columns[1].HeaderText = "Nome";
            dataGridView.Columns[2].HeaderText = "Nascimento";
            dataGridView.Columns[3].HeaderText = "CPF";
            dataGridView.Columns[4].HeaderText = "Sexo";
            dataGridView.Columns[0].Width = 78;
            dataGridView.Columns[1].Width = 175;
            dataGridView.Columns[2].Width = 90;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
        }
    }
}
