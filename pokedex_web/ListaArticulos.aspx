<%@ Page Title="Lista" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Catalogo_Web.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="contenido">
    <h1>Lista de articulos </h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label" runat="server">Filtrar</label>
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
    </div>

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text="Filtro Avanzado" runat="server"
                CssClass="" ID="chkAvanzado"
                AutoPostBack="true"
                OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>

    <%if (FiltroAvanzado)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Tipo" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
    


    <div class="col-3">
        <div class="mb-3">
            <asp:Label Text="Criterio" ID="lblCriterio" runat="server" />
            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="col-3">
        <div class="mb-3">
            <asp:Label Text="Filtro" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
        </div>
    </div>


    <div class="col-3">
        <div class="mb-3">
            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar"  OnClick="btnBuscar_Click" />
            <asp:Label Text="Ingrese los datos adecuados!" runat="server" CssClass="--bs-danger-text-emphasis" id="verificador" Visible="false" />
        </div>
    </div>
    <%} %>
    </div>



    <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id"
        CssClass="table table-dark table-hover" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging"
        AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion"  />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="True" SelectText="Modificar" />
           
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
        </div>
        
</asp:Content>
