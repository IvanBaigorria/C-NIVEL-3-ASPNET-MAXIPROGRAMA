<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="pokedex_web.Favoritos" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
<h1>FAVORITOS!</h1>


    <div class="row row-cols-1 row-cols-md-3 g-4">
      <asp:Repeater runat="server" ID="repRepetidor" >
    <ItemTemplate>
        <div class="card border-dark mb-3" style="max-width: 18rem;" >
        <div class="col">
            <div>
                <img src="<%#Eval("ImagenUrl") %>" class="rounded" width="260" height="270" alt="...">
                <div class="card-body">
                     <h5 class="card-title"><%#Eval("Nombre") %></h5>
                      <p class="card-text"><%#Eval("Descripcion") %></p>
                    
                    <a href="DetalleArticulos.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a> 
                    <a class="btn btn-danger">Eliminar Fav</a>
                    
                    <asp:Button Text="x" class="btn btn-danger" runat="server" id="btnEliminarClick" CommandArgument='<%#Eval("Id") %>' CommandName="FavoritosId" OnClick="btnEliminar_Click"/>
                </div>
            </div>
        </div>
            </div>
    </ItemTemplate>

</asp:Repeater>
        </div>
</asp:Content>
    