<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="pokedex_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="contenido" style="text-align: center;">
        <h1 css="align-center" id="titulo" onmouseover="agrandarTexto(this)" onmouseout="restaurarTexto(this)">Creá tu cuenta Tecno</h1>
        <h3>Y empeza a comprar!</h3>
        <p></p>
    <div class="d-flex justify-content-center">
        <div class="col-3" >
            
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/" class="btn btn-dark">Volver</a>
            <p></p>

        </div>
    </div>
        </div>

    <script>
    
    
    function agrandarTexto(elemento) {
        elemento.style.transform = "scale(1.2)";
        elemento.style.transition = "transform 0.5s ease";
    }

    function restaurarTexto(elemento) {
        elemento.style.transform = "scale(1)";
        elemento.style.transition = "transform 0.5s ease";
    }

    </script>
</asp:Content>
