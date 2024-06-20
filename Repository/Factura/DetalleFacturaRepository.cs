using parcial3.Bdd.ConnectionBD;
using System.Data;
using System.Linq;
using Dapper;
using parcial3.Bdd;
using parcial3.Repository.IDetalleFactura;
using parcial3.Models.DetalleFactura;


namespace parcial3.Repository.Factura.DetalleFactura
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        IDbConnection connection;

        public DetalleFacturaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(DetalleFacturaModel modelo)
        {
            try
            {
                connection.Execute("INSERT INTO DetalleFactura(id, id_factura, id_producto, cantidad_producto, subtotal) " +
                        " values(@id, @id_factura, @id_producto, @cantidad_producto, @subtotal)", modelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteByid(int id)
        {
            try
            {
                connection.Execute("delete from DetalleFactura where id = @id", id);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<DetalleFacturaModel> GetAll()
        {
            return connection.Query<DetalleFacturaModel>("SELECT * FROM DetalleFactura;");
        }


        public bool update(DetalleFacturaModel modelo)
        {
            try
            {
                connection.Execute("UPDATE DetalleFactura SET " +
                    " cantidad_producto = @cantidad_producto," +
                    " subtotal = @subtotal WHERE id = @id ", modelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}