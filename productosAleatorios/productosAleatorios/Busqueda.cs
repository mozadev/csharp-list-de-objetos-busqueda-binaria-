using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace productosPregunta
{
    public class Productos
    {
        public int numeroProducto;
        public int ensamblaje;
        public int pulido;
        public int pintura;
        public int empaque;
        public int prioridad;

        public Productos(int numeroProducto, int ensamblaje, int pulido, int pintura, int empaque, int prioridad)
        {
            this.numeroProducto = numeroProducto;
            this.ensamblaje = ensamblaje;
            this.pulido = pulido;
            this.pintura = pintura;
            this.empaque = empaque;
            this.prioridad = prioridad;

        }


        public void MostrarEstado()
        {
            Console.WriteLine("numeroProducto", numeroProducto);
            Console.WriteLine("ensamblaje", ensamblaje);
            Console.WriteLine("pulido", pulido);
            Console.WriteLine("pintura:", pintura);
            Console.WriteLine("empaque:", empaque);
            Console.WriteLine("prioridad:", prioridad);
        }

        public int tiempoSecuencia()
        {
            int tiempototal = ensamblaje + pulido + pintura + empaque;
            return tiempototal;
        }
       
    }
    



    public class clasePrincipal
    {

        public static void Main()
        {
            Productos p1 = new Productos(1, 15, 30, 10, 5, 2);
            Productos p2 = new Productos(2, 15, 30, 10, 5, 1);
            Productos p3 = new Productos(3, 0, 30, 10, 5, 4);
            Productos p4 = new Productos(4, 0, 0, 10, 5, 3);


            List<Productos> listaproductos = new List<Productos>();
            listaproductos.Add(p1);
            listaproductos.Add(p2);
            listaproductos.Add(p3);
            listaproductos.Add(p4);
          
            // ORDENANDO LA LISTA POR PRIORIDAD
            listaproductos.Sort(ordanmientosPorPrioridad);
            foreach (Productos prod in listaproductos)
            {
               Console.WriteLine(" num producto:  " + prod.numeroProducto + " ensamblaje:  " + prod.ensamblaje + 
                   " pulido: " +prod.pulido+" pintura: "+prod.pintura+" empaque: "+prod.empaque+" prioridad: "+prod.prioridad);
                Console.WriteLine(" ");
            }

            // SUMANDO LOS TIEMPOS DE TODOS
            int SUMATIEMPOTOTAL = 0;

            foreach (Productos produ in listaproductos)
            {
                SUMATIEMPOTOTAL = SUMATIEMPOTOTAL + produ.tiempoSecuencia();
            }
            Console.Write("\n\nTIEMPO 4 DIAS : "+ "2400");
            Console.Write("\n\nTIEMPO TOTAL : "+SUMATIEMPOTOTAL);

            // BUSCANDO EL PRODUCTO
            Console.Write("\n\nNumero de producto a buscar: ");
            int num = int.Parse(Console.ReadLine());
            
            
            busqueda(num, listaproductos);
        }
        
        // METODO ORDENAR POR PRIORIDAD
        public static int ordanmientosPorPrioridad(Productos name1, Productos name2)
        {

            return name1.prioridad.CompareTo(name2.prioridad);
        }

        // MEDOTO BUSQUEDA BINARIA
        public static void busqueda(int num, List<Productos> listaproductosx)
        {
            List<Productos> milista = new List<Productos>();
            milista = listaproductosx.OrderBy(o => o.numeroProducto).ToList();
            int l = 0, h = 3;
            int m = 0;
            bool found = false;

            while (l <= h && found == false)
            {
                m = (l + h) / 2;
                if (milista[m].numeroProducto==num)
                    found = true;
                if (milista[m].numeroProducto > num)
                    h = m - 1;
                else
                    l = m + 1;
            }
            if (found == false)
            { Console.Write("\nEl elemento {0} no esta en la lista", num); }
            else
            {
                Console.Write("\nProducto:   "+ milista[m].numeroProducto);
                Console.Write("\nPrioridad:   "+ milista[m].prioridad);
                Console.Write("\nEnsamblaje: "+ milista[m].ensamblaje);
                Console.Write("\nPulido:"+ milista[m].pulido);
                Console.Write("\nPintura:"+ milista[m].pintura);
                Console.Write("\nEmpaque:"+ milista[m].empaque);
                Console.Write("\nTiempo de secuencia: "+ milista[m].tiempoSecuencia());
                Console.WriteLine(" ");

                
            }


        }

    }
}

