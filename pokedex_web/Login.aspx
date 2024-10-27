<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido"  style="text-align: center;">
        <h2 css="align-center" id="titulo" onmouseover="agrandarTexto(this)" onmouseout="restaurarTexto(this)">Login</h2>
        <p></p>
        <div class="d-flex justify-content-center">
            
            <div class="col-3">
                
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" cssclass="form-control" REQUIRED="true" ID="txtEmail"/>
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" TextMode="Password"/>
                </div>
                <asp:Button Text="Ingresar" cssclass="btn btn-dark" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                
                <a href="/" Class="btn btn-primary" >Home</a>
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