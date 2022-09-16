using System.Text;

namespace Entidades
{
    public class Cliente
    {
        private string _aliasParaIncognito;
        private string _nombre;
        private eTipoCliente _tipoDeCliente;

        private Cliente()
        {
            this._nombre = "NN";
            this._aliasParaIncognito = "Sin alias";
            this._tipoDeCliente = eTipoCliente.SinTipo;
        }

        public Cliente(eTipoCliente tipoDeCliente)
        {
            this._tipoDeCliente = tipoDeCliente;
        }
        
        public Cliente(eTipoCliente tipoDeCliente, string nombre)
            : this(tipoDeCliente)
        {
            this._nombre = nombre;
        }

        private void CrearAlias()
        {
            Random rng = new Random();

            this._aliasParaIncognito = $"{rng.Next(1000, 9999).ToString()}{this._tipoDeCliente}";
        }

        public string GetAlias()
        {
            if(this._aliasParaIncognito == "Sin alias")
            {
                CrearAlias();
                return this._aliasParaIncognito;
            }
            else
            {
                return this._aliasParaIncognito;
            }
        }

        private string RetornarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this._nombre}");
            sb.AppendLine($"Alias: {this._aliasParaIncognito}");
            sb.AppendLine($"Tipo Cliente: {this._tipoDeCliente}");

            return sb.ToString();
        }

        public static string RetornarDatos(Cliente unCliente)
        {
            return unCliente.RetornarDatos();
        }
    }
}