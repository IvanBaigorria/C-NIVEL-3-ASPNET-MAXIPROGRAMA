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

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        
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