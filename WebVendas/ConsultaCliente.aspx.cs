using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVendas
{
    public partial class ConsultaCliente : System.Web.UI.Page
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
            tb_cliente cliente = new tb_cliente();
            VendasDBEntities1 context = new VendasDBEntities1();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                cliente = context.tb_cliente.First(c => c.id == idItem);
                txtNomeCliente.Text = cliente.cli_nome;
                txtFoneCliente.Text = cliente.cli_fone;
                txtCidadeCliente.Text = cliente.cli_cidade;
                txtEnderecoCliente.Text = cliente.cli_endereco;
                txtCpf.Text = Convert.ToString(cliente.cli_cpf);
            }
        }

        private void LoadGrid()
        {
            VendasDBEntities1 context = new VendasDBEntities1();
            List<tb_cliente> lstcliente = context.tb_cliente.ToList<tb_cliente>();
            int cont = 0;
            do
            {
                foreach (var item in lstcliente)
                {
                    string cpf = Convert.ToString(item.cli_cpf.ToString());
                    string digito = IsCpf(cpf);

                    item.cli_cpf = Convert.ToInt64(cpf + digito);
                }
                cont++;
            } while (cont <= (lstcliente.Count) + 1);


            GVCliente.DataSource = lstcliente;
            GVCliente.DataBind();
        }

        public static string IsCpf(String cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return digito;
        }
    }
}