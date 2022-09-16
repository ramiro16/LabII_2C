using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaOffShore
    {
        private Cliente _duenio;
        private int _numeroCuenta;
        private double _saldo;

        public Cliente Duenio
        {
            get
            {
                return this._duenio;
            }
        }

        public double Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            {
                this._saldo = value;
            }
        }

        public CuentaOffShore(Cliente duenio, int numero, double saldoInicial)
        {
            this._duenio = duenio;
            this._numeroCuenta = numero;
            this._saldo = saldoInicial;
        }

        public CuentaOffShore(string nombre, eTipoCliente tipo, int numero, double saldoInicial)
            : this(new Cliente(tipo, nombre), numero, saldoInicial)
        {

        }

        public static bool operator ==(CuentaOffShore cos1, CuentaOffShore cos2)
        {
            if (cos1 is not null && cos2 is not null)
            {
                if((cos1._numeroCuenta == cos2._numeroCuenta) && (cos1.Duenio.GetAlias() == cos2.Duenio.GetAlias()))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public static bool operator !=(CuentaOffShore cos1, CuentaOffShore cos2)
        {
            return !(cos1 == cos2);
        }

        public static explicit operator int(CuentaOffShore cos)
        {
            return cos._numeroCuenta;
        }
    }
}
