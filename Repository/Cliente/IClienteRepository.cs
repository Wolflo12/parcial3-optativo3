
using parcial3.Models.Cliente;

namespace parcial3.Repository.ICliente
{
    public interface IClienteRepository
    {
        bool add(ClienteModel clienteModelo);
        bool update(ClienteModel clienteModelo);
        bool DeleteByid(int id);
        IEnumerable<ClienteModel> GetAll();
    }
}
