using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ITipoOperacion<T,U,Z>
    {
        U ACliente { get; set; }

        void AgregarProducto(Z p, int cantidad);

        string Mostrar();

        void ConcretarOperacion();

        List<string> Movimientos();
        
    }
}
