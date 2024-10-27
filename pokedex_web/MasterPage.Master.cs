﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace pokedex_web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error || Page is DetalleArticulos))
            {
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    if (user.Nombre == "")
                        lblUser.Text = user.Email;
                    
                    else lblUser.Text = user.Nombre;
                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.UrlImagenPerfil;
                }
            }
            if ((Page is Login || Page is Registro || Page is Default || Page is Error || Page is DetalleArticulos))
            {
                if (Seguridad.sesionActiva(Session["trainee"]))
                {
                    Trainee user = (Trainee)Session["trainee"];
                    if (user.Nombre == "")
                    {
                        lblUser.Text = user.Email;
                    }
                    else lblUser.Text = user.Nombre;
                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.UrlImagenPerfil;
                }
            }
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}