using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Factura
    {
        private int no;
        private int total;
        private string cliente;
        private string observacion;
        private string entrega;
        private string fecha;

public string Fecha
{
  get { return fecha; }
  set { fecha = value; }
}


        public string Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public int No
        {
            get { return no; }
            set { no = value; }
        }

        private void Init()
        {
            no=0;
            total=0;
            cliente=string.Empty;
            observacion=string.Empty;
            entrega = string.Empty;
            fecha = string.Empty;
        }

        public Factura(){
            Init();
        }

        public Factura(int no, int total, string cliente, string observacion, string entrega,string fecha )
        {
            No = no;
            Total = total;
            Cliente = cliente;
            Observacion = observacion;
            Entrega = entrega;
            Fecha = fecha;
        }
    }
}
