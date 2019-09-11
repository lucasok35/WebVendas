<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Material.aspx.cs" Inherits="WebVendas.Material" %>
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
                    <h2><a href="#">Cadastro de Material</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="descricao">Descrição:</label>
            <asp:TextBox class="form-control" name="txtDescricao" ID="txtDescricao"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">Fornecedor:</label>
            <asp:DropDownList class="form-control" name="DDLForn" ID="DDLForn"
                runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="Data">Tipo:</label>
            <asp:DropDownList class="form-control" name="DDLTipo" ID="DDLTipo"
                runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="Data">Data de Entrada:</label>
            <asp:TextBox class="form-control" name="txtDataEntrada" ID="txtDataEntrada"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">Valor:</label>
            <asp:TextBox class="form-control" name="txtValor" ID="txtValor"
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
