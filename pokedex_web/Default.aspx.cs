using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;


namespace pokedex_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listar();

            Trainee user = (Trainee)Session["trainee"];

            string id = Request.QueryString["id"];


                if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
                
            }

            ddlCriterio.Visible = false;
   

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            ddlCriterio.Visible = true;
            if (ddlCampo.SelectedItem.ToString() != "Marca" && ddlCampo.SelectedItem.ToString() != "Categoria")
            {
                Response.Redirect("Default.aspx", false);
            }


                if (ddlCampo.SelectedItem.ToString() == "Marca")
            {
                MarcaNegocio negocioMarca = new MarcaNegocio();
                List<Marca> listaMarca = negocioMarca.listar();

                ddlCriterio.DataSource = listaMarca;
                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataTextField = "Descripcion";
                ddlCriterio.DataBind();

                

                /*List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dgvPokemons.DataSource = listaFiltrada;
                dgvPokemons.DataBind();*/

            }

            else
            {

                CategoriaNegocio negociocat = new CategoriaNegocio();
                List<Categoria> listaCategoria = negociocat.listar();
                ddlCriterio.DataSource = listaCategoria;
                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataTextField = "Descripcion";
                ddlCriterio.DataBind();

            }
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                repRepetidor.DataSource = negocio.filtrarInicio(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString());
                repRepetidor.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }
        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                repRepetidor.DataSource = negocio.filtrarInicio(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString());
                repRepetidor.DataBind();
                btnVolver.Visible=true;
                ddlCampo.Visible = false;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
        /*protected void dgvArticulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             dgvArticulo.PageIndex = e.NewPageIndex;
             dgvArticulo.DataBind();
         }*/

        /*protected void dgvArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulo.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleArticulos.aspx?id=" + id);
        }*/
        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }

        
    }
}