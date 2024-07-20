using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace pokedex_web
{
    public partial class DetalleArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MarcaNegocio negocio = new MarcaNegocio();
            List<Marca> listaMarca = negocio.listar();

            ddlMarca.DataSource = listaMarca;
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataBind();

            CategoriaNegocio negociocat = new CategoriaNegocio();
            List<Categoria> listaCategoria = negociocat.listar();
            ddlCategoria.DataSource = listaCategoria;
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataBind();

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            ArticuloNegocio negocioa = new ArticuloNegocio();
            
            Articulo seleccionado = (negocioa.listar(id))[0];

            Session.Add("articuloSeleccionado", seleccionado);
            //txtId.Text = id;
            txtNombre.Text = seleccionado.Nombre;
            txtDescripcion.Text = seleccionado.Descripcion;


            txtImagenUrl.Text = seleccionado.ImagenUrl;
            txtNumero.Text = seleccionado.Precio.ToString();
            txtImagenUrl_TextChanged(sender, e);

            ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
            ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

            
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }
    }
}