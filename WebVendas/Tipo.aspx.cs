using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVendas
{
    public partial class Tipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescTipo.Text;
            tb_tipo tip = new tb_tipo() { descricao = descricao };
            VendasDBEntities1 context = new VendasDBEntities1();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                context.tb_tipo.Add(tip);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(valor);
                tb_tipo tipo = context.tb_tipo.First(c => c.id == id);
                tipo.id = tip.id;
                tipo.descricao = tip.descricao;
                lblmsg.Text = "Registro Alterado!";
            };

            context.SaveChanges();
            LoadGrid();

        }


        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            tb_tipo tipo = new tb_tipo();
            VendasDBEntities1 contextTipo = new VendasDBEntities1();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                tipo = contextTipo.tb_tipo.First(c => c.id == idItem);
                txtDescTipo.Text = tipo.descricao;
            }
        }

        private void LoadGrid()
        {
            VendasDBEntities1 context = new VendasDBEntities1();
            List<tb_tipo> lsttipo = context.tb_tipo.ToList<tb_tipo>();

            GVTipo.DataSource = lsttipo;
            GVTipo.DataBind();
        }

    }
}