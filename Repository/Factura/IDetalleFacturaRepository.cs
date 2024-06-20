using parcial3.Models.DetalleFactura;

namespace parcial3.Repository.IDetalleFactura
{
    public interface IDetalleFacturaRepository
    {
        bool add(DetalleFacturaModel detallefacturaModel);
        bool update(DetalleFacturaModel detallefacturaModel);
        bool DeleteByid(int id);
        IEnumerable<DetalleFacturaModel> GetAll();
    }
}
