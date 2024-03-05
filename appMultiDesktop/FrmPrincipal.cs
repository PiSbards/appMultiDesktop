using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMultiDesktop
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pessoas = pessoa.listaPessoa();
            dgvPessoa.DataSource = pessoas;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            this.txtId.Focus();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                if (pessoa.RegistroRepetido(txtNome.Text,txtIdade.Text,txtCidade.Text) == true)
                {
                    MessageBox.Show("Pessoa já existe em nossa base de dados!!", "Registro Repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Text = "";
                    txtNome.Text = "";
                    txtIdade.Text = "";
                    txtCidade.Text = "";
                    this.txtNome.Focus();
                    return;
                }
                else
                {
                    pessoa.Inserir(txtNome.Text,txtIdade.Text,txtCidade.Text);
                    MessageBox.Show("Pessoa inserida com sucesso!", "Registro Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<Pessoa> pessoas = pessoa.listaPessoa();
                    dgvPessoa.DataSource = pessoas;
                    txtId.Text = "";
                    txtNome.Text = "";
                    txtIdade.Text = "";
                    txtCidade.Text = "";
                    this.txtNome.Focus();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
