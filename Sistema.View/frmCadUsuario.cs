using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;

namespace Sistema.View
{
    public partial class frmCadUsuario : Form
    {
        public frmCadUsuario()
        {
            InitializeComponent();
        }

        UsuariosEnt objetoTabela = new UsuariosEnt();



        private void btnNovo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            inicarOpc();
        }

        private void inicarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        objetoTabela.Nome = txtNome.Text;
                        objetoTabela.Usuario = txtUsuario.Text;
                        objetoTabela.Senha = txtSenha.Text;

                        int x = UsuarioModel.Inserir(objetoTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0} foi inserido", txtNome.Text));
                        }
                        else    
                        {
                            MessageBox.Show("Não inserido!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar: " + ex.Message);
                        //throw;
                    }
                    
                    break;

                case "Excluir":
                   
                    break;

                case "Editar":
                    
                    break;
            }
        }


        private string opc = "";


        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtSenha.Enabled = true;
            txtUsuario.Enabled = true;

        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtSenha.Enabled = false;
            txtUsuario.Enabled = false;

        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            inicarOpc();
            ListarGird();
            DesabilitarCampos();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            opc = "Excluir";
            inicarOpc();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            opc = "Editar";
            inicarOpc();
        }


        private void ListarGird()
        {
            try
            {
                List<UsuariosEnt> lista = new List<UsuariosEnt>();
                lista = new UsuarioModel().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar dados: " + ex.Message);
            }
        }

        private void ListarGrid()
        {
            try
            {
                //o objeto do tipo list funciona como se fosse um array, carrega dados
                List<UsuariosEnt> lista = new List<UsuariosEnt>();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar dados " + ex.Message);
            }
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            ListarGird();

        }
    }
}
