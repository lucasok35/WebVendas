<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Venda.aspx.cs" Inherits="WebVendas.Venda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Cadastro de Transação</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
         <div class="form-group">
            <label for="fornecedor">Fornecedor:</label>
            <asp:DropDownList ID="ddlFornecedor" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="cliente">Cliente:</label>
            <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="material">Material:</label>
            <asp:DropDownList ID="ddlMaterial" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="dtvenda">Data Venda:</label>
 
            <asp:TextBox class="form-control" name="txtdatavenda" ID="txtdatavenda" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" ID="btnCadastrar" runat="server" Text="Salvar" OnClick="btnCadastrar_Click" />
        <br />
        <br />
        <br />
    <asp:GridView runat="server" CssClass="table table-hover" ID="GVVendas" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Id_fornecedor" HeaderText="Fornecedor" />
            <asp:BoundField DataField="Id_cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="Id_material" HeaderText="Material" />
            <asp:BoundField DataField="Datavenda" HeaderText="Data Venda" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:Localize ID="LocCliente" runat="server"></asp:Localize>
        <asp:Button class="btn btn-primary" ID="btnSalvar" runat="server" Text="Salvar"/>
    </form>
    <br />
    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>
</asp:Content>
