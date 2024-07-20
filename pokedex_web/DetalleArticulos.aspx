<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="pokedex_web.DetalleArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <h1 class="text-center">Detalle de articulo</h1>
    <div class="contenido">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:Label runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Precio $</label>
                <asp:Label runat="server" ID="txtNumero" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"  Enabled="false"/>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" Enabled="false"/>
            </div>

            <div class="mb-3">
                
                <a href="/" class="btn btn-primary">Volver</a>
                
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:Label runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control"/>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" Visible="false"/>
                    </div>
                    <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" runat="server" id="imgPokemon" width="260" height="270"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
        </div>
    </div>
       

</asp:Content>
