using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class NArticulo
    {
		private Conection conection;
		public NArticulo() 
		{ 
			conection = new Conection();
		}
        public List<Articulo> GetAll()
        {
			var list = new List<Articulo>();
			//var conection = new Conection();
			try
			{
				conection.SetQuery("SELECT A.Id AId,A.Codigo ACod,A.Nombre ANom,A.Descripcion ADes,A.IdMarca AIdMarca,M.Descripcion MDes,A.IdCategoria AIdCat,C.Descripcion as CDes,A.ImagenUrl AImgUrl,A.Precio APrecio FROM ARTICULOS as A INNER JOIN CATEGORIAS as C ON A.IdCategoria = C.Id INNER JOIN MARCAS as M ON A.IdMarca = M.Id");
				conection.ExecuteQuery();
				while(conection.Reader.Read()) 
				{
					var articulo = new Articulo();
					articulo.Id = (int)conection.Reader["AId"];
					articulo.Codigo = (string)conection.Reader["ACod"];
					articulo.Nombre = (string)conection.Reader["ANom"];
					articulo.Descripcion = (string)conection.Reader["ADes"];
					articulo.Marca = new Marca();
					articulo.Marca.Id = (int)conection.Reader["AIdMarca"];
					articulo.Marca.Descripcion = (string)conection.Reader["MDes"];
					articulo.Categoria = new Categoria();
					articulo.Categoria.Id = (int)conection.Reader["AIdCat"];
					articulo.Categoria.Descripcion = (string)conection.Reader["CDes"];
					articulo.ImagenUrl = (string)conection.Reader["AImgUrl"];
					articulo.Precio = (Decimal)conection.Reader["APrecio"];
					list.Add(articulo);
				}
				return list;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				throw ex;
			}
			finally
			{
				conection.CloseConnection();
			}
        }
		public bool Insert(Articulo nuevo)
		{
            //var conection = new Conection();
            try
            {
				conection.SetQuery("INSERT INTO ARTICULOS VALUES(@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)");
				conection.SetParameter("@Codigo",nuevo.Codigo);
				conection.SetParameter("@Nombre",nuevo.Nombre);
				conection.SetParameter("@Descripcion",nuevo.Descripcion);
				conection.SetParameter("@IdMarca",nuevo.Marca.Id);
				conection.SetParameter("@IdCategoria",nuevo.Categoria.Id);
				conection.SetParameter("@ImagenUrl",nuevo.ImagenUrl);
				conection.SetParameter("@Precio",nuevo.Precio);
				return conection.ExecuteAction();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conection.CloseConnection();
			}
		}

		public bool Modify(Articulo articulo)
		{
            //var conection = new Conection();
            try
            {
				conection.SetQuery("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio WHERE Id = @Id");
				conection.SetParameter("@Codigo", articulo.Codigo);
				conection.SetParameter("@Nombre", articulo.Nombre);
				conection.SetParameter("@Descripcion", articulo.Descripcion);
				conection.SetParameter("@IdMarca", articulo.Marca.Id);
				conection.SetParameter("@IdCategoria", articulo.Categoria.Id);
				conection.SetParameter("@ImagenUrl", articulo.ImagenUrl);
				conection.SetParameter("@Precio", articulo.Precio);
				conection.SetParameter("@Id", articulo.Id);
				return conection.ExecuteAction();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conection.CloseConnection();
			}
        }

		public bool Delete(Articulo articulo)
		{
			try
			{
				conection.SetQuery("DELETE FROM ARTICULOS WHERE Id = @Id");
				conection.SetParameter("@Id", articulo.Id);
				return conection.ExecuteAction();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conection.CloseConnection();
			}
        }
    }
}
