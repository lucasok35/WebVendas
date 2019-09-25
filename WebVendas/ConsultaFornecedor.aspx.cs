using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVendas
{
    public partial class ConsultaFornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }
        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            tb_fornecedor fornecedor = new tb_fornecedor();
            VendasDBEntities1 context = new VendasDBEntities1();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                fornecedor = context.tb_fornecedor.First(c => c.id == idItem);
                txtNome.Text = fornecedor.forn_nome;
                txtFone.Text = fornecedor.forn_fone;
                txtCidade.Text = fornecedor.forn_cidade;
                txtEndereco.Text = fornecedor.forn_endereco;
                txtCnpj.Text = Convert.ToString(fornecedor.forn_cnpj);
            }
        }

        private void LoadGrid()
        {
            VendasDBEntities1 context = new VendasDBEntities1();
            List<tb_fornecedor> lstforn = context.tb_fornecedor.ToList<tb_fornecedor>();
            int cont = 0;
            do
            {
                foreach (var item in lstforn)
                {
                    string cnpj = Convert.ToString(item.forn_cnpj.ToString());
                    string digito = IsCnpj(cnpj);

                    item.forn_cnpj = Convert.ToInt64(cnpj + digito);
                }
                cont++;
            } while (cont <= (lstforn.Count) + 1);


            GVFornecedor.DataSource = lstforn;
            GVFornecedor.DataBind();
        }

        public static string IsCnpj(String cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return digito;
        }

    }
}