using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Detalle
    {
        private int id;
        private int linea;
        private int factura;
        private int producto;
        private int cantidad;
        private int existencia;
        private int subtotal;

        public int Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public int Factura
        {
            get { return factura; }
            set { factura = value; }
        }

        public int Linea
        {
            get { return linea; }
            set { linea = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public void Init()
        {
            id=0;
            linea=0;
            factura=0;
            producto=0;
            cantidad=0;
            existencia=0;
            subtotal = 0;
        }
        public Detalle()
        {
            Init();
        }

        public Detalle( int id, int linea,int factura, int producto, int cantidad, int existencia, int subtotal)
        {
            Id = id;
            Linea = linea;
            Factura = factura;
            Producto = producto;
            Cantidad = cantidad;
            Existencia = existencia;
            Subtotal=subtotal;

        }
    }
}
