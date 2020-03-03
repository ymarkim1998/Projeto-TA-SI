using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class frmClientes : Form
    {
        Conexao conexao = new Conexao();
        SqlDataAdapter adapter;
        DataTable dt;
        public frmClientes()
        {
            InitializeComponent();
            preencherTabela("SELECT * FROM CLIENTE");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pesquisar(txtPesquisar.Text);
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
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtSexo.Text = "";
        }



        private void btGravar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja gravar o Cliente com o CPF: " + txtCPF.Text + "?", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Cadastrar cadastro = new Cadastrar(txtNome.Text, txtNascimento.Text, txtCPF.Text, txtSexo.Text);

                MessageBox.Show(cadastro.mensagem);

                limparCampos();

                preencherTabela("SELECT * FROM CLIENTE");


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
                Excluir excluir = new Excluir(txtCodigo.Text);

                MessageBox.Show(excluir.mensagem);

                limparCampos();

                preencherTabela("SELECT * FROM CLIENTE");

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice == -1)
            {
                return;
            }

            DataGridViewRow dataGrid = dataGridView.Rows[indice];

            txtCodigo.Text = dataGrid.Cells[0].Value.ToString();
            txtNome.Text = dataGrid.Cells[1].Value.ToString();
            txtNascimento.Text = dataGrid.Cells[2].Value.ToString();
            txtCPF.Text = dataGrid.Cells[3].Value.ToString();
            txtSexo.Text = dataGrid.Cells[4].Value.ToString();
        }

        public void preencherTabela(String sql)
        {
            adapter = new SqlDataAdapter(sql, conexao.conectar());

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

        public void Pesquisar(String pesquisa) {
            preencherTabela("SELECT * FROM CLIENTE WHERE NOME like '%" + pesquisa + "%'");
            
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja editar o Cliente com o CPF: " + txtCPF.Text + "?", "Confirmação", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Editar editar = new Editar(txtCodigo.Text, txtNome.Text, txtNascimento.Text, txtCPF.Text, txtSexo.Text);

                MessageBox.Show(editar.mensagem);

                limparCampos();

                preencherTabela("SELECT * FROM CLIENTE");
            }
            else if (dialogResult == DialogResult.No)
            {
                limparCampos();
            }
        }
    }
}
