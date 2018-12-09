using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        private string rut;
        private string nombre;
        private string direccion;
        private int fono;

        public int Fono
        {
            get { return fono; }
            set { fono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        private void Init()
        {
            rut = string.Empty;
            nombre=string.Empty;
            direccion = string.Empty;
            fono=0;
        }
        public Cliente()
        {
            Init();
        }
        public Cliente( string rut, string nombre, string direccion, int fono)
        {
            Rut = rut;
            Nombre = nombre;
            Direccion = direccion;
            Fono = fono;
        }
    }
}
