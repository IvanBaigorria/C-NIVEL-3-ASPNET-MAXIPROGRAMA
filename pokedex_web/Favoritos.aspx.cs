using Catalogo_Web;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace pokedex_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> listaFav { get; set; }
        public List<Articulo> listaEliminar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Trainee user = (Trainee)Session["trainee"];

            string id = Request.QueryString["id"];
            if (id != null && !IsPostBack)
            {
                
                Favorito fav = new Favorito();
                FavoritosNegocio nuevo = new FavoritosNegocio();

                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    fav.IdUser = user.Id;
                    fav.IdArticulo = int.Parse(id);
                    nuevo.agregar(fav);
                }
                

                //Session.Add(("negociofavoritos"), negocfavoritos.listar());
                //dgvFavoritos.DataSource = Session["negociofavoritos"];
                //dgvFavoritos.DataBind();
                /*if (!IsPostBack)
                {
                    repRepetidor.DataSource = listaFav;
                    repRepetidor.DataBind();
                }*/
            }
            

            if (user != null)
                {
                    FavoritosNegocio negocioart = new FavoritosNegocio();
                    List<int> idFavoritos = negocioart.listar(user.Id);
                    if (idFavoritos.Count > 0)
                    {
                        ArticuloNegocio art = new ArticuloNegocio();
                        listaFav = new List<Articulo>();
                        listaFav = art.listado(idFavoritos);
                        repRepetidor.DataSource = listaFav;
                        repRepetidor.DataBind();
                    }
                    if(!(idFavoritos.Count > 0 ))
                    {
                    Session.Add("error","Todavia no hay ningun producto guardado en favoritos.");
                    Response.Redirect("Error.aspx", false);
                }

                }
            }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            Trainee user = (Trainee)Session["trainee"];

            Favorito fav = new Favorito();
            FavoritosNegocio negocioart = new FavoritosNegocio();

            fav.IdUser = user.Id;
            fav.IdArticulo = int.Parse(((Button)sender).CommandArgument);
            negocioart.eliminarFav(fav.IdArticulo, fav.IdUser);


            

            //Page_Load(sender, e);

            Response.Redirect("Favoritos.aspx", false);


        }

        




    }


    }

