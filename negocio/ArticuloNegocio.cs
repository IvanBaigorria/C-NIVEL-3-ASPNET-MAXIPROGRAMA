using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "") //(bool inactivos = false)
        {
            List<Articulo> lista = new List<Articulo>();
            //AccesoDatos datos = new AccesoDatos();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, A.ImagenUrl, A.Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca And C.Id = A.IdCategoria";
                /* if (inactivos)
                     datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, A.ImagenUrl, A.Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca And C.Id = A.IdCategoria and A.Precio<0");
                 else*/
               // datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, A.ImagenUrl, A.Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca And C.Id = A.IdCategoria");
                if (id != "")
                    comando.CommandText += " and A.Id = " + id;
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

                    if (!(lector.IsDBNull(lector.GetOrdinal("ImagenUrl"))))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];

                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];

                    aux.Precio = Math.Round((decimal)lector["Precio"], 0);

                    if (aux.Precio < 0)
                        aux.Precio = -aux.Precio;


                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        public List<Articulo> lista() //(bool inactivos = false)
        {
            List<Articulo> lista = new List<Articulo>();
            //AccesoDatos datos = new AccesoDatos();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, A.ImagenUrl, A.Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca And C.Id = A.IdCategoria";
                
                
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.Precio = Math.Round((decimal)lector["Precio"], 0);



                    lista.Add(aux);

                }

                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl,Precio)values('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', @idMarca, @idCategoria, @ImagenUrl," + nuevo.Precio + ")");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);
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

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update articulos set codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, ImagenUrl = @img, IdMarca = @idMarca, IdCategoria = @idCategoria, precio = @precio where id = @id");
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@img", art.ImagenUrl);
                datos.setearParametro("@IdMarca", art.Marca.Id);
                datos.setearParametro("idCategoria", art.Categoria.Id);
                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@precio", art.Precio);

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



        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("Id", @id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void activarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update ARTICULOS set Activo = 1 where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update ARTICULOS set Activo = 0 where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, A.ImagenUrl, A.Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca And C.Id = A.IdCategoria and A.Precio>0 and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Menor a":
                            consulta += "Nombre like '%" + filtro + "'";

                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%' ";
                            break;
                    }
                }

                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Menor a":
                            consulta += "M.Descripcion like '%" + filtro + "'";

                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%' ";
                            break;
                    }

                }


                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Menor a":
                            consulta += "C.Descripcion like '%" + filtro + "'";

                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%' ";
                            break;
                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                SqlDataReader lector = datos.Lector;


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 0);
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenURl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria ();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    listaFiltrada.Add(aux);

                }

                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Articulo> listado(List<int> idFavoritos)
        {
            List<Articulo> listador = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A JOIN CATEGORIAS C ON C.Id = A.IdCategoria JOIN MARCAS M ON M.Id = A.IdMarca WHERE A.Id ";
                comando.CommandText += "IN ( " + string.Join(", ", idFavoritos) + " )";
                
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.Precio = Math.Round((decimal)lector["Precio"], 0);
                    if (!(lector.IsDBNull(lector.GetOrdinal("ImagenUrl"))))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];

                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];

                   

                    listador.Add(aux);

                }

                conexion.Close();
                return listador;

            }   
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
