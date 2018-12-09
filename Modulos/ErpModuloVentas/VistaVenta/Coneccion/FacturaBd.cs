using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Coneccion
{
    public class FacturaBd
    {
        public List<Factura> Mostrar()
        {
            ConBDTableAdapters.FacturaTableAdapter fat = new ConBDTableAdapters.FacturaTableAdapter();
            List<Factura> fats = new List<Factura>();
            foreach (var item in fat.Mostrar().ToList())
            {
                fats.Add(new Modelo.Factura(int.Parse(item.NoFactura.ToString()), int.Parse(item.Total.ToString()), item.Cliente, item.Observacion, item.Entrega, item.fecha.ToString()));
            }
            return fats;
        }

        public Factura buscar(int id)
        {
            foreach (var item in Mostrar())
            {
                if (item.No == id)
                {
                    return item;
                }
            }
            return null;
        }

        public int Agregar(Factura fat)
        {
            if (fat != null)
            {
                if (buscar(fat.No) == null)
                {
                    ConBDTableAdapters.FacturaTableAdapter fatC = new ConBDTableAdapters.FacturaTableAdapter();
                    fatC.Agregar(fat.No, fat.Total, fat.Cliente, fat.Observacion, fat.Entrega, fat.Fecha);

                    return 1;
                }
                return 2;
            }
            return 0;
        }

        public int Modificar(Factura fat)
        {
            if (fat != null)
            {
                ConBDTableAdapters.FacturaTableAdapter fatC = new ConBDTableAdapters.FacturaTableAdapter();
                fatC.Actualizar(fat.Total, fat.Cliente, fat.Observacion, fat.Entrega, fat.Fecha, fat.No);
                return 1;
            }
            return 0;
        }

    }
}
