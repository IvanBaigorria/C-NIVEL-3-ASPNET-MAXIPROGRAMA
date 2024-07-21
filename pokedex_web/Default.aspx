<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"  background-color= dimgrey >     
    
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="contenido">
    <h1>Hola. Llegaste al CatalogoWeb, tu lugar de productos de tecnologia</h1>
    <p>Nuestro catalogo!</p>
        <div class="col">
            <div class="mb-1">
            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="btn btn-secondary dropdown-toggle" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                <asp:ListItem Text="Marca" />
                <asp:ListItem Text="Categoria" />
            </asp:DropDownList>


            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCriterio" CssClass="btn btn-secondary dropdown-toggle" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged"></asp:DropDownList>
                
                <asp:Button Text="x" runat="server" ID="btnVolver" class="btn btn-dark" Visible="false" OnClick="volver_Click" />
            

                </div>
            
        </div>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%--        <%  
            foreach (dominio.Pokemon poke in ListaPokemon)
            {                                                                               OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" al lado de dll campo!!!!!
        %>
                                                                                                <label for="ddlMarca" class="form-label">Marca</label>
                                                                                        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="btn btn-secondary dropdown-toggle" />
                                                                                        </div>
                                                                                        <div class="mb-1">
                                                                                            <label for="ddlCategoria" class="form-label">Categoria</label>
                                                                                            <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="btn btn-secondary dropdown-toggle" />
                                                                                        </div>
                <div class="col">
                    <div class="card">
                        <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%:poke.Nombre %></h5>
                            <p class="card-text"><%: poke.Descripcion %></p>
                            <a href="DetallePokemon.aspx?id=<%: poke.Id %>">Ver detalle</a>
                        </div>
                    </div>
                </div>
          <% } %>--%>

        <asp:Repeater runat="server" ID="repRepetidor" >
            <ItemTemplate>
                <div class="card border-dark mb-3" style="max-width: 18rem; background-color: white" >
                <div class="col">
                    <div>
                        <img src="<%#Eval("ImagenUrl") %>" class="rounded" width="260" height="270" alt="...">
                        <div class="card-body" >
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>            
                            <p class="card-text">$<%#Eval("Precio") %></p>   
                            <a href="DetalleArticulos.aspx?id=<%#Eval("Id") %>" class="btn btn-dark">Ver detalle</a>
                            <a href="Favoritos.aspx?id=<%#Eval("Id") %>" class="btn btn-warning">Fav</a>
                          
                            <%-- <asp:Button Text="Ejemplo" cssclas="btn btn-primary" runat="server" id="btnEjemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click"/> --%>
                        </div>
                    </div>
                </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>


    </div>
        </div>
</asp:Content>
