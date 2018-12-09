using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Existencia
    {
        private int id;
        private string idBog;
        private int idPro;
        private int cantidad;
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int IdPro
        {
            get { return idPro; }
            set { idPro = value; }
        }

        public string IdBog
        {
            get { return idBog; }
            set { idBog = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private void Init()
        {
            id=0;
            idBog=string.Empty;
            idPro=0;
            cantidad=0;
            fecha=string.Empty;
        }

        public Existencia()
        {
            Init();
        }

        public Existencia(int id, string idBog, int idPro, int cantidad, string fecha)
        {
            Id = id;
            IdBog = idBog;
            IdPro = idPro;
            Cantidad = cantidad;
            Fecha = fecha;
        }
    }
}
