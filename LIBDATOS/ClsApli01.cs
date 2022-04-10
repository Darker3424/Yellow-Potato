using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDATOS
{
    public class ClsApli01
    {
        static VentasIDATEntities db = new VentasIDATEntities();
        public static Array ListarPedidos()
        {       
            var query = from p in db.Pedidos select p;
            return query.ToArray();//ToArray un tipo arreglo
        }
        public static Array PedidosporRangoFechas(DateTime FechaInicio,DateTime FechaFinal)
        {
            var query=from p in db.Pedidos join e in db.Empleados on
            p.IdEmpleado equals e.IdEmpleado join d in db.Detalles_de_pedidos on
            p.IdPedido equals d.IdPedido
            where p.FechaPedido >= FechaInicio && p.FechaPedido <= FechaFinal
            group new {p,e,d}
            by new {p.IdPedido,e.IdEmpleado,p.FechaPedido,e.Nombre,e.Apellidos} into GD
            select new
            {
                IdPedido = GD.Key.IdPedido, IdEmpleado= GD.Key.IdEmpleado,
                Fecha_Pedido= GD.Key.FechaPedido,
                Empleado= GD.Key.Apellidos+"  "+ GD.Key.Nombre,
                Venta= Math.Round(GD.Sum(g =>
                (double)g.d.PrecioUnidad*g.d.Cantidad*(1-g.d.Descuento)))                
            };
            return query.ToArray();
        }
    }
}
