using Ejercicio_I01_PuestoAtencion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_I01_PuestoAtencion;

namespace Entidades
{
    public class Negocio
    {
        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;

        public Cliente Cliente
        {
            get
            {
                return clientes.Dequeue();
            }
            set
            {
                foreach (Cliente item in clientes)
                {
                    if (item == value)
                    {
                        break;
                    }

                    clientes.Enqueue(item);
                }
            }
        }

        public int ClientesPendientes
        {
            get
            {
                return this.clientes.Count;
            }
        }

        private Negocio()
        {
            this.caja = new PuestoAtencion(PuestoAtencion.Puesto.Caja1);
            this.clientes = new Queue<Cliente>();
        }

        public Negocio(string nombre)
            : this()
        {
            this.nombre = nombre;
        }

        public static bool operator +(Negocio n, Cliente c)
        {
            if (n is not null && c is not null)
            {
                if (n.clientes.Count == 0)
                {
                    n.clientes.Enqueue(c);
                    return true;
                }
                else
                {

                    foreach (Cliente item in n.clientes)
                    {
                        if (item == c)
                        {
                            return false;
                        }
                    }

                    n.clientes.Enqueue(c);
                    return true;
                }
            }

            return false;
        }

        public static bool operator ==(Negocio n, Cliente c)
        {
            if (n is not null && c is not null)
            {
                foreach (Cliente item in n.clientes)
                {
                    if (item == c)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }

        public static bool operator ~(Negocio n)
        {
            if (n is not null)
            {
                if (n.caja.Atender(n.Cliente))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
