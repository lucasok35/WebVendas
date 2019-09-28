using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVendas
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "" || txtCidadeCliente.Text == "" || txtCpf.Text == "" || txtEnderecoCliente.Text == "" || txtFoneCliente.Text == "")
            {
                lblmsg.Text = "Preencha todos os campos!";
            }
            else
            {

                string nome = txtNomeCliente.Text;
                string telefone = txtFoneCliente.Text;
                string cidade = txtCidadeCliente.Text;
                string endereco = txtEnderecoCliente.Text;
                long cpf = Convert.ToInt64(txtCpf.Text.ToString().Substring(0, 9));
                tb_cliente cli = new tb_cliente() { cli_nome = nome, cli_fone = telefone, cli_cidade = cidade, cli_endereco = endereco, cli_cpf = cpf };
                VendasDBEntities1 context = new VendasDBEntities1();

                string valor = Request.QueryString["idItem"];

                if (String.IsNullOrEmpty(valor))
                {
                    context.tb_cliente.Add(cli);
                    lblmsg.Text = "Registro Inserido!";
                }
                else
                {
                    int id = Convert.ToInt32(valor);
                    tb_cliente cliente = context.tb_cliente.First(c => c.id == id);
                    cliente.id = cli.id;
                    cliente.cli_nome = cli.cli_nome;
                    cliente.cli_fone = cli.cli_fone;
                    cliente.cli_endereco = cli.cli_endereco;
                    cliente.cli_cidade = cli.cli_cidade;
                    cliente.cli_cpf = cli.cli_cpf;
                    lblmsg.Text = "Registro Alterado!";
                };
                context.SaveChanges();
            }
        }

      
    }
}