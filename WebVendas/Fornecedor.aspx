<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Fornecedor.aspx.cs" Inherits="WebVendas.Fornecedor" %>
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
                    <h2><a href="#">Cadastro de Fornecedor</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="descricao">Nome:</label>
            <asp:TextBox class="form-control" name="txtNomeFornecedor" ID="txtNomeFornecedor"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">Telefone:</label>
            <asp:TextBox class="form-control" name="txtFoneFornecedor" ID="txtFoneFornecedor"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">Cidade:</label>
            <asp:TextBox class="form-control" name="txtCidadeFornecedor" ID="txtCidadeFornecedor"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">Endereço:</label>
            <asp:TextBox class="form-control" name="txtEnderecoFornecedor" ID="txtEnderecoFornecedor"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">CNPJ:</label>
            <asp:TextBox class="form-control" name="txtCnpj" ID="txtCnpj"
                runat="server"></asp:TextBox>
        </div>
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
