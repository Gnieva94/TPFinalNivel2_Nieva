using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class NCategoria
    {
        public List<Categoria> GetAll()
        {
            var list = new List<Categoria>();
            var conection = new Conection();
            try
            {
                conection.SetQuery("SELECT Id, Descripcion FROM CATEGORIAS");
                conection.ExecuteQuery();
                while (conection.Reader.Read())
                {
                    var categoria = new Categoria 
                    { 
                        Id = (int)conection.Reader["ID"],
                        Descripcion = (string)conection.Reader["Descripcion"]
                    };
                    list.Add(categoria);
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
