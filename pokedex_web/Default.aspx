    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >     
    
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .titulo {
                 flex-shrink: 0;
                 /*/background-color: #f1f1f1;*/
                 padding: 10px;
                 text-align: center;
                 position: relative;
                 width: 100%;
                 bottom: 0;
                 margin-top: 0cm; /* Mueve el contenido 2 cm hacia abajo */
                 margin-left: -2cm;
                 
                 
            }

    </style>
    <div class="contenido">
        <div class="titulo">
            <div>
                <h1 id="titulo" onmouseover="agrandarTexto(this)" onmouseout="restaurarTexto(this)">TecnoCatalogo, tu lugar de productos de tecnologia</h1>
                <p id="parrafo" onmouseover="cambiarColor(this)" onmouseout="restaurarColor(this)">Nuestros productos para vos!</p>
            </div>
         </div>

        <div class="col">
            <div class="mb-1">

            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="btn btn-secondary dropdown-toggle" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                <asp:ListItem Text="Filtro" />
                <asp:ListItem Text="Marca" />
                <asp:ListItem Text="Categoria" />
            </asp:DropDownList>


            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCriterio" CssClass="btn btn-secondary dropdown-toggle" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged">
                
            </asp:DropDownList>
                
                <asp:Button Text="x" runat="server" ID="btnVolver" class="btn btn-dark" Visible="false" OnClick="volver_Click" />
                       
                </div>
            
        </div>
        
        <hr style="background-color: #C0C0C0" />
        
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
        <div class="card border-dark mb-3 d-flex justify-content-center" style="max-width: 18rem; background-color: #f1f1f1" >
            <div class="col">
                <hr />
                <div>
                    <img src='<%# Eval("ImagenUrl") %>' class="rounded" width="260" height="270" alt="..."
                         onmouseover="agrandarImagen(this)" onmouseout="restaurarImagen(this)">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <p class="card-text">$<%# Eval("Precio") %></p>
                        <a href="DetalleArticulos.aspx?id=<%# Eval("Id") %>" class="btn btn-dark">Ver detalle</a>
                       
                        <a href="Favoritos.aspx?id=<%# Eval("Id") %>" visible=false class="btn btn-warning" ID="btnFavorito" >✰</a>
                    </div>
                </div>
                <hr />
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>



    </div>
        </div>

    <script>
        function agrandarImagen(img) {
            img.style.transform = "scale(1.2)"; // Agranda la imagen un 30%
            img.style.transition = "transform 0.5s ease"; // Añade una transición suave
        }

        function restaurarImagen(img) {
            img.style.transform = "scale(1)";
            img.style.transition = "transform 0.5s ease";
        }
        function agrandarTexto(elemento) {
            elemento.style.transform = "scale(1.2)";
            elemento.style.transition = "transform 0.5s ease";
        }

        function restaurarTexto(elemento) {
            elemento.style.transform = "scale(1)";
            elemento.style.transition = "transform 0.5s ease";
        }

        function cambiarColor(elemento) {
            elemento.style.color = "gray"; // Cambiado a verde
            elemento.style.transition = "color 0.2s ease";
        }

        function restaurarColor(elemento) {
            elemento.style.color = "black";
            elemento.style.transition = "color 0.5s ease";
        }
    </script>

</asp:Content>


