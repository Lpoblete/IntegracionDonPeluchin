using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Coneccion
{
    public class DetalleBD
    {
        public List<Detalle> Mostrar()
        {
            ConBDTableAdapters.DetalleVentaTableAdapter det = new ConBDTableAdapters.DetalleVentaTableAdapter();
            List<Detalle> dets = new List<Detalle>();
            foreach (var item in det.Mostrar().ToList())
            {
                dets.Add(new Modelo.Detalle(int.Parse(item.NoDetalle.ToString()),int.Parse(item.Linea.ToString()),int.Parse(item.NoFactura.ToString()),int.Parse(item.Producto.ToString()),int.Parse(item.Cantidad.ToString()),int.Parse(item.Existencia.ToString()), int.Parse(item.subtotal.ToString())));
            }
            return dets;
        }

        public Detalle buscarprod(int idproducto,int factura)
        {
            foreach (var item in Mostrar())
            {
                if (item.Producto.Equals(idproducto) && item.Factura==factura)
                {
                    return item;
                }
            }
            return null;
        }

        public int Agregar(Detalle Det)
        {
            if (Det != null)
            {                  
                    ConBDTableAdapters.DetalleVentaTableAdapter detC = new ConBDTableAdapters.DetalleVentaTableAdapter();
                    detC.Agregar(Det.Id,Det.Linea,Det.Factura,Det.Producto,Det.Cantidad,Det.Existencia,Det.Subtotal);

                     return 1;
                }
                   return 2;
            }
               
            }
        }
