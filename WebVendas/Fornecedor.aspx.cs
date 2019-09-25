using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVendas
{
    public partial class Fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNomeFornecedor.Text == "" || txtCidadeFornecedor.Text == "" || txtEnderecoFornecedor.Text == "" || txtFoneFornecedor.Text == "" || txtCnpj.Text == "") 
            {
                lblmsg.Text = "Preencha todos os campos!";
            }
            else
            {

                string nome = txtNomeFornecedor.Text;
                string telefone = txtFoneFornecedor.Text;
                string cidade = txtCidadeFornecedor.Text;
                string endereco = txtEnderecoFornecedor.Text;
                long cnpj = Convert.ToInt64(txtCnpj.Text.ToString().Substring(0, 9));
                tb_fornecedor forn = new tb_fornecedor() { forn_nome = nome, forn_fone = telefone, forn_cidade = cidade, forn_endereco = endereco, forn_cnpj = cnpj };
                VendasDBEntities1 context = new VendasDBEntities1();

                string valor = Request.QueryString["idItem"];

                if (String.IsNullOrEmpty(valor))
                {
                    context.tb_fornecedor.Add(forn);
                    lblmsg.Text = "Registro Inserido!";
                }
                else
                {
                    int id = Convert.ToInt32(valor);
                    tb_fornecedor fornecedor = context.tb_fornecedor.First(c => c.id == id);
                    fornecedor.id = forn.id;
                    fornecedor.forn_nome = forn.forn_nome;
                    fornecedor.forn_fone = forn.forn_fone;
                    fornecedor.forn_endereco = forn.forn_endereco;
                    fornecedor.forn_cidade = forn.forn_cidade;
                    fornecedor.forn_cnpj = forn.forn_cnpj;
                    lblmsg.Text = "Registro Alterado!";
                };
                context.SaveChanges();
            }
        }
    }
}