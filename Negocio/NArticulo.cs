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
        public List<Articulo> GetAll()
        {
			var list = new List<Articulo>();
			var conection = new Conection();
			try
			{
				conection.SetQuery("SELECT Id,Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio FROM ARTICULOS");
				conection.ExecuteQuery();
				while(conection.Reader.Read()) 
				{
					var articulo = new Articulo();
					articulo.Id = (int)conection.Reader["id"];
					articulo.Codigo = (string)conection.Reader["Codigo"];
					articulo.Nombre = (string)conection.Reader["Nombre"];
					articulo.Descripcion = (string)conection.Reader["descripcion"];
					articulo.IdMarca = (int)conection.Reader["IdMarca"];
					articulo.IdCategoria = (int)conection.Reader["IdCategoria"];
					articulo.ImagenUrl = (string)conection.Reader["ImagenUrl"];
					articulo.Precio = (Decimal)conection.Reader["Precio"];
					list.Add(articulo);
				}
				return list;
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
