using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Web.WebPages;

namespace Catalogo_Web
{
    public partial class ListaArticulos : System.Web.UI.Page
    {

        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere permisos de admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx");
            }


            FiltroAvanzado = chkAvanzado.Checked;
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add(("listaArticulos"), negocio.lista());
            dgvPokemons.DataSource = Session["listaArticulos"];
            dgvPokemons.DataBind();
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
            verificador.Visible = false;
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
            verificador.Visible = false;
        }

      
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                txtFiltroAvanzado.Text = null;
                verificador.Visible = false;

            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.Text = null;
                verificador.Visible = false;
            }
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsDigit(caracter) || !char.IsWhiteSpace(caracter))
                {
                    return true;
                }
            }
            return false;
        }


        private bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return false;
                
            }
            return true;
        }
        bool pasar = true;

        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pasar = true;
            verificador.Visible = false;
            try
            {
                

                bool validar = (!validaTextoVacio(txtFiltroAvanzado.Text));
                if (ddlCampo.SelectedItem.ToString() == "Precio" && !soloNumeros(txtFiltroAvanzado.Text))
                {
                    txtFiltroAvanzado.Text = null;
                    verificador.Visible = true;
                    pasar = false;
                }
                else
                {
                    pasar = true; verificador.Visible = false;
                }
                

                if (ddlCampo.SelectedItem != null && ddlCriterio.SelectedItem != null && txtFiltroAvanzado.Text != null && pasar==true) { 
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvPokemons.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                dgvPokemons.DataBind();
                    verificador.Visible = false;
                }

                else
                {
                    verificador.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}