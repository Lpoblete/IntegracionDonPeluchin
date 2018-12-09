using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Coneccion
{
    public class CLienteBD
    {
        public List<Cliente> Mostrar()
        {
            ConBDTableAdapters.ClienteTableAdapter cli = new ConBDTableAdapters.ClienteTableAdapter();
            List<Cliente> clis = new List<Cliente>();
            foreach (var item in cli.Mostrar().ToList())
            {
                clis.Add(new Modelo.Cliente(item.Rut_Cliente,item.Nombre_Cliente,item.Direccion_Cliente,int.Parse(item.Telefono_Cliente)));
            }
            return clis;
        }

        public Cliente buscar(string rut)
        {
            foreach (var item in Mostrar())
            {
                if (item.Rut.Trim().Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
