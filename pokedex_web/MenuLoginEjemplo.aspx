<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuLoginEjemplo.aspx.cs" Inherits="pokedex_web.MenuLoginEjemplo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-12">
            <h3>Te logueaste correctamente, bienvenido</h3>
        </div>
        <div class="col-4">
            <asp:Button Text="Pagina 1" runat="server" ID="btnPagina1" OnClick="btnPagina1_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-4">
            <!--if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN ){ -->
            
            <asp:Button Text="Pagina 2" runat="server" ID="btnPagina2" OnClick="btnPagina2_Click" CssClass="btn btn-primary" />
            
            <p>Configuración ADMIN.</p>
            
            
        </div>
    </div>

</asp:Content>
