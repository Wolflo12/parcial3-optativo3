
using parcial3.Models.Producto;
using parcial3.Repository.IProducto;
using Repository.Producto.ProductoRepository;
using System;

namespace parcial3.Services.Producto
{
    public class ProductoService : IProductoRepository
    {
        private ProductoRepository productoRepository;

        public ProductoService(string connectionString)
        {
            productoRepository = new ProductoRepository(connectionString);
        }

        bool IProductoRepository.add(ProductoModel producto)
        {
            return ValidarDatos(producto) ? productoRepository.add(producto) : throw new Exception("Error en la validación de datos, corroborar");
        }

        IEnumerable<ProductoModel> IProductoRepository.getAll()
        {
            return productoRepository.getAll();
        }

        bool IProductoRepository.delete(int id)
        {
            return id > 0 ? productoRepository.delete(int id) : false; 
        }

        public bool update(ProductoModel producto)
        {
            return ValidarDatos(producto) ? productoRepository. .update(producto) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool ValidarDatos(ProductoModel producto)
        {
            if (producto == null)
                return false;

            if (string.IsNullOrEmpty(producto.descripcion))
                return false;

            if (string.IsNullOrEmpty(producto.cantidad_minima))
                return false;
            if (string.IsNullOrEmpty(producto.cantidad_stock))
                return false;
            if (string.IsNullOrEmpty(producto.precio_compra))
                return false;
            if (string.IsNullOrEmpty(producto.precio_venta))
                return false;
            if (string.IsNullOrEmpty(producto.categoria))
                return false;
            if (string.IsNullOrEmpty(producto.marca))
                return false;
            if (string.IsNullOrEmpty(producto.estado))
                return false;

       
            if (!int.TryParse(producto.cantidad_minima, out int cantidadMinima) || cantidadMinima <= 1)
                return false;

            
            if (!int.TryParse(producto.precio_compra, out int precioCompra) || precioCompra < 0)
                return false;

            
            if (!int.TryParse(producto.precio_venta, out int precioVenta) || precioVenta < 0)
                return false;

            return true;
        }

    }
}
