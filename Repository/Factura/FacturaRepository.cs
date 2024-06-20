using parcial3.Bdd.ConnectionBD;
using parcial3.Models.Factura;
using Dapper;
using System.Data;
using parcial3.Repository.IFactura;
using Npgsql;
using parcial3.Models.DetalleFactura;

namespace parcial3.Repository.Factura.FacturaRepository
{
    public class FacturaRepository : IFacturaRepository
    {
        IDbConnection connection;
        public FacturaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(FacturaModel factura)
        {
            try
            {
                var queryFactura = @"INSERT INTO Factura(Nro_factura, Fecha_hora, Total, Total_iva5, Total_iva10, Total_iva, Total_letras)
                                   values(@nro_factura, @fecha_hora, @total, @total_iva5, @total_iva10, @total_iva, @total_letras); 

                                    SELECT CAST(SCOPE_IDENTITY() as int); ";

                connection.Execute(queryFactura, factura);

                var idFactura = connection.QuerySingle<int>(queryFactura, new
                {
                    factura.Nro_factura,
                    factura.Fecha_hora,
                    factura.Total,
                    factura.Total_iva5,
                    factura.Total_iva10,
                    factura.Total_iva,
                    factura.Total_letras,
                });

                foreach (var producto in factura.detallefactura)
                {
                    connection.Execute("INSERT INTO detalle_factura(id_factura, id_producto, cantidad_producto, subtotal)" +
                        $" values({idFactura}, @id_producto, @cantidad_producto, subtotal)", producto);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool update(FacturaModel factura)
        {
            try
            {
                var queryFactura = @"UPDATE Factura SET
                                    nro_factura=@nro_factura,
                                    fecha_hora=@fecha_hora,
                                    total=@total,
                                    total_iva5=@total_iva5,
                                    total_iva10=@total_iva10,
                                    total_iva=@total_iva,
                                    total_letras=@total_letras
                                    WHERE  id = @id;";

                var queryDetalleFactura = @"UPDATE detalle_factura SET
                                          id_producto=@id_producto,
                                          cantidad_producto=@cantidad_producto,
                                          subtotal=@subtotal
                                          WHERE id = @id;";

                connection.Execute(queryFactura, factura);

                foreach (var producto in factura.detallefactura)
                {
                    connection.Execute(queryDetalleFactura, producto);
                }

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
                connection.Execute("DELETE FROM detalle_factura WHERE id_factura = @id", id);
                connection.Execute("DELETE FROM Factura WHERE id = @id", id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            try
            {
                var facturaDictonary = new Dictionary<int, FacturaModel>();
                var query = @" SELECT
                               pc.id, pc.Nro_factura, pc.Fecha_hora, pc.Total, pc.Total_iva5, pc.Total_iva10, pc.Total_iva, pc.Total_letras
                               pd.id, pd.id_factura, pd.id_producto, pd.cantidad_producto, pd.subtotal
                               FROM Factura pc
                               LEFT JOIN detalle_factura pd on pc.id = pd.id_factura 
                              ";

                var factura = connection.Query<FacturaModel, DetalleFacturaModel, FacturaModel>(query, (factura, detalle_factura) =>
                {
                    if (!facturaDictonary.TryGetValue(factura.Id, out var facturaActual))
                    {
                        facturaActual = factura;
                        facturaActual.detallefactura = new List<DetalleFacturaModel>();
                        facturaDictonary.Add(facturaActual.Id, facturaActual);

                        if (detalle_factura != null)
                        {
                            facturaActual.detallefactura.Add(detalle_factura);
                        }

                        return facturaActual;
                    }
                }
                 );
                return factura;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FacturaModel getById(int id)
        {
            throw new NotImplementedException();
        }


    }
}