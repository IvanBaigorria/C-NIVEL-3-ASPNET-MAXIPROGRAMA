using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using static negocio.AccesoDatos;

namespace negocio
{
    public class TraineeNegocio
    {
        //id
        //email
        //pass
        //admin false

        //nombre, apellido, fecha, imagen

        public void insertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into users (Email, Pass)values('" + nuevo.Email + "', '" + nuevo.Pass + "')");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set UrlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido Where Id = @id");
                //datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);, fechaNacimiento = @fecha (no tiene fecha de nacimiento)
                datos.setearParametro("@imagen", (object)user.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                //datos.setearParametro("@fecha", user.FechaNacimiento);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, UrlImagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
                //, fechaNacimiento
                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@pass", trainee.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["UrlImagenPerfil"] is DBNull))
                        trainee.UrlImagenPerfil = (string)datos.Lector["UrlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Lector["apellido"];
                    //if (!(datos.Lector["fechaNacimiento"] is DBNull))
                      //  trainee.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }


}