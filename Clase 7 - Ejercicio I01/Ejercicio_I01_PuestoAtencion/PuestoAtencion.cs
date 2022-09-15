using Entidades;

namespace Ejercicio_I01_PuestoAtencion
{
    public class PuestoAtencion
    {
        public enum Puesto
        {
            Caja1,
            Caja2
        }

        public static int NumeroActual
        {
            get
            {
                numeroActual++;
                return numeroActual;
            }
        }

        private static int numeroActual;
        private Puesto puesto;

        static PuestoAtencion()
        {
            numeroActual = 0;
        }

        public PuestoAtencion(Puesto puesto)
        {
            this.puesto = puesto;
        }

        public bool Atender(Cliente cli)
        {
            Thread.Sleep(3000);

            return true;
        }
    }
}