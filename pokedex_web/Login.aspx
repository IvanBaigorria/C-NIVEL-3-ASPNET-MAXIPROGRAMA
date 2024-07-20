<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row">
            
            <div class="col-4">
                <h2>Login</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" cssclass="form-control" REQUIRED="true" ID="txtEmail"/>
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" TextMode="Password"/>
                </div>
                <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                <a href="/" Class="btn btn-danger" >Cancelar</a>

            </div>
        </div>
        </div>
      
    
        
</asp:Content>