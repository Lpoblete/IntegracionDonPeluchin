using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Coneccion
{
    public class ProductoBd
    {
           public List<Producto> Mostrar()
        {
            ConBDTableAdapters.ProductoTableAdapter pro = new ConBDTableAdapters.ProductoTableAdapter();
            List<Producto> pros = new List<Producto>();
            foreach (var item in pro.Mostrar().ToList())
            {
                pros.Add(new Modelo.Producto(int.Parse(item.ID_producto.ToString()),item.Nombre_producto ,int.Parse(item.Valor.ToString()),item.Descripcion));
            }
            return pros;
        }
           public Producto buscar(int id)
           {
               foreach (var item in Mostrar())
               {
                   if (item.Id.Equals(id))
                   {
                       return item;
                   }
               }
               return null;
           }
    }
}
