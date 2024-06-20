
using parcial3.Models.Sucursal;


namespace parcial3.Repository.ISucursal
{
    public interface ISucursalRepository
    {
        bool add(SucursalModel sucursalModel);
        bool update(SucursalModel sucursalModel);
        bool DeleteByid(int id);
        IEnumerable<SucursalModel> GetAll();
    }
}
