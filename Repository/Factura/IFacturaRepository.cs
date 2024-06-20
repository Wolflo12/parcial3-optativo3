
using parcial3.Models.Factura;

namespace parcial3.Repository.IFactura
{
    public interface IFacturaRepository
    {
        bool add(FacturaModel facturaModel);
        bool update(FacturaModel facturaModel);
        bool DeleteByid(int id);
        IEnumerable<FacturaModel> GetAll();
    }
}
