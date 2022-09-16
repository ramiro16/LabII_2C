using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ParaisoFiscal
    {
        private List<CuentaOffShore> _listadoCuentas;
        private eParaisosFiscales _lugar;
        public static int cantidadCuentas;
        public static DateTime fechaInicioActividades;

        static ParaisoFiscal()
        {
            cantidadCuentas = 0;
            fechaInicioActividades = DateTime.Now;
        }

        private ParaisoFiscal()
        {
            this._listadoCuentas = new List<CuentaOffShore>();
        }

        private ParaisoFiscal(eParaisosFiscales lugar)
            : this()
        {
            this._lugar = lugar;
        }

        public void MostrarParaiso()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Fecha de Inicio{fechaInicioActividades}");
            sb.AppendLine($"Lugar {this._lugar}");
            sb.AppendLine($"Cantidad de cuentas{cantidadCuentas}");
            sb.AppendLine($"Listado de cuentas: \n");

            foreach (CuentaOffShore cuenta in this._listadoCuentas)
            {
                Cliente auxCliente = cuenta.Duenio;

                sb.AppendLine(Cliente.RetornarDatos(auxCliente));
            }

            Console.WriteLine(sb.ToString());
        }

        public static implicit operator ParaisoFiscal(eParaisosFiscales epf)
        {
            return new ParaisoFiscal(epf);
        }

        public static bool operator ==(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf is not null && cos is not null)
            {
                foreach (CuentaOffShore item in pf._listadoCuentas)
                {
                    if (item == cos)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        public static bool operator !=(ParaisoFiscal pf, CuentaOffShore cos)
        {
            return !(pf == cos);
        }

        public static ParaisoFiscal operator +(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf is not null && cos is not null)
            {
                foreach (CuentaOffShore item in pf._listadoCuentas)
                {
                    if (pf == cos)
                    {
                        item.Saldo += cos.Saldo;
                        return pf;
                    }
                }

                pf._listadoCuentas.Add(cos);
                cantidadCuentas++;

                return pf;
            }

            return pf;
        }

        public static ParaisoFiscal operator -(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf is not null && cos is not null)
            {
                foreach (CuentaOffShore item in pf._listadoCuentas)
                {
                    if (pf == cos)
                    {
                        pf._listadoCuentas.Remove(cos);
                        cantidadCuentas--;

                        Console.WriteLine("Se quito la cuenta del paraiso...");
                        return pf;
                    }
                }
            }

            return pf;
        }

    }
}
