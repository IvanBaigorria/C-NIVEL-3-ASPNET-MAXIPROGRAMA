<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="pokedex_web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="contenido">

        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo</label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNumero" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
                </div>
                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
                </div>

                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-dark" OnClick="btnCancelar_Click" runat="server" />
                    

                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                            <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                                AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                        </div>
                        <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" runat="server" ID="imgPokemon" width="260" height="270" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">

                <div class="col-6">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                            </div>

                            <%if (ConfirmaEliminacion)
                                { %>
                            <div class="mb-3">
                                <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                                <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="ConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                            </div>
                            <%} %>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
