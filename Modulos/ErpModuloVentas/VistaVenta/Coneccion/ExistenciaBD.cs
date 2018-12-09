using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Coneccion
{
    public class ExistenciaBD
    {
        public List<Existencia> Mostrar()
        {
            ConBDTableAdapters.ExistenciaTableAdapter exi = new ConBDTableAdapters.ExistenciaTableAdapter();
            List<Existencia> exis = new List<Existencia>();
            foreach (var item in exi.Mostrar().ToList())
            {
                exis.Add(new Modelo.Existencia(int.Parse(item.Codigo_existencia.ToString()), item.Codigo_bodega.ToString() , int.Parse(item.Codigo_producto.ToString()), int.Parse(item.Cantidad.ToString()), item.Fecha_Ingreso.ToString()));
            }
            return exis;
        }

        public Existencia buscar(int id)
        {
            foreach (var item in Mostrar())
            {
                if (item.Id==id)
                {
                    return item;
                }
            }
            return null;
        }

        public Existencia buscarPro(int prod, string bog)
        {
            foreach (var item in Mostrar())
            {
                if (item.IdBog.Equals(bog) && item.IdPro==prod)
                {
                    return item;
                }
            }
            return null;
        }

        public int Modificar(Existencia fat)
        {
            if (fat != null)
            {
                    ConBDTableAdapters.ExistenciaTableAdapter fatC = new ConBDTableAdapters.ExistenciaTableAdapter();
                    fatC.Modificar(fat.IdBog, fat.IdPro, fat.Cantidad, fat.Fecha, fat.Id);
                    return 1;
                }
                return 2;            
        }
    }
}
