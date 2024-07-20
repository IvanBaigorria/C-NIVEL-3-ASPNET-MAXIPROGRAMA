using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritosNegocio
    {
        public List<int> listar(int idUser)
        {
            List<int> listaFav = new List<int>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select IdArticulo From FAVORITOS where IdUser = @idUser");
                datos.setearParametro("@IdUser", idUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int aux = (int)datos.Lector["idArticulo"];

                    listaFav.Add(aux);
                }

                return listaFav;
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

        public void agregar(Favorito nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into FAVORITOS (IdUser, IdArticulo)values(@idUser, @idArticulo)");
                datos.setearParametro("@idUser", nuevo.IdUser);
                datos.setearParametro("@idArticulo", nuevo.IdArticulo);


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

        public void eliminar(Favorito eliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("  ");
                datos.setearParametro("@idUser", eliminar.IdUser);
                datos.setearParametro("@idArticulo", eliminar.IdArticulo);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarFav(int idArticulo, int idUser)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE (IdUser=@idUser AND IdArticulo=@idArticulo)");
                datos.setearParametro("@idArticulo", @idArticulo);
                datos.setearParametro("@idUser", @idUser);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {       

                throw ex;
            }
        }
    }
}