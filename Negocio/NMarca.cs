using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class NMarca
    {
        public List<Marca> GetAll()
        {
			var list = new List<Marca>();
			var conection = new Conection();
			try
			{
				conection.SetQuery("SELECT Id, Descripcion FROM MARCAS");
				conection.ExecuteQuery();
				while(conection.Reader.Read())
				{
                    var marca = new Marca
                    {
						Id = (int)conection.Reader["Id"],
						Descripcion = (string)conection.Reader["Descripcion"]
                    };
					list.Add(marca);
                }
				return list;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conection.CloseConnection();
			}
        }
    }
}
