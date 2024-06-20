using parcial3.Bdd.ConnectionBD;
using parcial3.Models.Producto;
using System.Data;
using System.Linq;
using Dapper;
using parcial3.Bdd;
using parcial3.Repository.IProducto;

namespace Repository.Producto.ProductoRepository
{
    public class ProductoRepository : IProductoRepository
    {
        IDbConnection connection;

        public ProductoRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        bool IProductoRepository.add(ProductoModel modelo)
        {
            try
            {
                connection.Execute("INSERT INTO Producto(descripcion, cantidad_minima, cantidad_stock, precio_compra, precio_venta, categoria, marca, estado) " +
                        " values(@descripcion, @cantidad_minima, @cantidad_stock, @precio_compra, @precio_venta, @categoria, @marca @estado)", modelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool IProductoRepository.delete(int id)
        {
            try
            {
                connection.Execute("delete from Producto where id = @id", id);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        IEnumerable<ProductoModel> IProductoRepository.getAll()
        {
            return connection.Query<ProductoModel>("SELECT * FROM Producto;");
        }

        ProductoModel IProductoRepository.getById(int id)
        {
            try
            {
                return connection.QuerySingle<ProductoModel>("SELECT * FROM Productos where id = @id", id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        bool IProductoRepository.update(ProductoModel modelo)
        {
            try
            {
                connection.Execute("UPDATE Producto SET " +
                    " descripcion = @descripcion," +
                    " cantidad_minima = @cantidad_minima, " +
                    " cantidad_stock = @cantidad_stock, " +
                    " precio_compra = @precio_compra," +
                    " precio_venta = @precio_venta," +
                    " categoria = @categoria," +
                    " marca = @marca," +
                    " estado = @estado WHERE id = @id ", modelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}