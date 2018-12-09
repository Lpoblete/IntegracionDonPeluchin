using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto
    {
        private int id;
        private string nombre;
        private int valor;
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private void Init(){
            id=0;
            nombre=string.Empty;
            valor=0;
            descripcion=string.Empty;
        }

        public Producto()
        {
            Init();
        }

        public Producto(int id, string nombre, int valor, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Valor = valor;
            Descripcion = descripcion;
        }
    }
}
