using parcial3.Models.Producto;

namespace parcial3.Repository.IProducto
{
    public interface IProductoRepository
    {
        bool add(ProductoModel modelo);
        bool update(ProductoModel modelo);
        bool delete(int id);
        ProductoModel getById(int id);
        IEnumerable<ProductoModel> getAll();
    }
}