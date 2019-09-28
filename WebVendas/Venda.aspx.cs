using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVendas
{
    public partial class Venda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        LoadGrid();
            if (!IsPostBack)
            {
                CarregarDadosPagina();
                LoadDDLCliente();
                LoadDDLFornecedor();
                LoadDDLMaterial();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            int fornecedor = int.Parse(ddlFornecedor.SelectedValue.ToString());
            int cliente = int.Parse(ddlCliente.SelectedValue.ToString());
            int material = int.Parse(ddlMaterial.SelectedValue.ToString());
            DateTime datavenda = Convert.ToDateTime(txtdatavenda.Text);
            tb_venda ven = new tb_venda() { id_fornec = fornecedor, id_cli = cliente, id_mat = material, venda_data = datavenda };
            VendasDBEntities1 context = new VendasDBEntities1();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                context.tb_venda.Add(ven);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(valor);
                tb_venda venda = context.tb_venda.First(c => c.id == id);
                venda.id_cli = ven.id_cli;
                venda.id_fornec = ven.id_fornec;
                venda.id_mat = ven.id_mat;
                venda.venda_data = ven.venda_data;
                lblmsg.Text = "Registro Alterado!";
            };
            context.SaveChanges();
            LoadGrid();
        }

        private void LoadDDLFornecedor()
        {
            ddlFornecedor.DataSource = new VendasDBEntities1().tb_fornecedor.ToList<tb_fornecedor>();
            ddlFornecedor.DataTextField = "Nome";
            ddlFornecedor.DataValueField = "Id";
            ddlFornecedor.DataBind();
        }

        private void LoadDDLMaterial()
        {
            ddlMaterial.DataSource = new VendasDBEntities1().tb_material.ToList<tb_material>();
            ddlMaterial.DataTextField = "Descricao";
            ddlMaterial.DataValueField = "Id";
            ddlMaterial.DataBind();
        }

        private void LoadDDLCliente()
        {
            ddlCliente.DataSource = new VendasDBEntities1().tb_cliente.ToList<tb_cliente>();
            ddlCliente.DataTextField = "Nome";
            ddlCliente.DataValueField = "Id";
            ddlCliente.DataBind();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            tb_venda venda = new tb_venda();
            VendasDBEntities1 context = new VendasDBEntities1();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                venda = context.tb_venda.First(c => c.id == idItem);
                ddlCliente.Equals(venda.id_cli);
                ddlFornecedor.Equals(venda.id_fornec);
                ddlMaterial.Equals(venda.id_mat);
                txtdatavenda.Text = venda.venda_data.ToString();
            }
        }

        private void LoadGrid()
        {
            VendasDBEntities1 context = new VendasDBEntities1();

            var dados = (
                         from venda in context.tb_venda
                         from m in context.tb_material.Where(x => x.id == venda.id_mat)
                         from f in context.tb_fornecedor.Where(x => x.id == venda.id_fornec)
                         from cliente in context.tb_cliente.Where(x => x.id == venda.id_cli)
                         select new
                         {
                             Id = venda.id,
                             Id_fornecedor = f.forn_nome,
                             Id_cliente = cliente.cli_nome,
                             Id_material = m.mat_desc,
                             Datavenda = venda.venda_data,
                         }).ToList();

            GVVendas.DataSource = dados;
            GVVendas.DataBind();
        }
    }
}