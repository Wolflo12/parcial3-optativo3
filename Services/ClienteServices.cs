
using parcial3.Models.Cliente;
using parcial3.Repository.ICliente;
using parcial3.Repository.Cliente;

namespace parcial3.Services.Cliente
{
    public class ClienteService : IClienteRepository
    {
        private ClienteRepository clienteRepository;
        public ClienteService(string connectionString)
        {
            clienteRepository = new ClienteRepository(connectionString);
        }

        public bool add(ClienteModel cliente)
        {
            return validarDatos(cliente) ? clienteRepository.add(cliente) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return clienteRepository.GetAll();
        }

        public bool DeleteByid(int id)
        {
            return id > 0 ? clienteRepository.DeleteByid(id) : false;
        }


        public bool update(ClienteModel clienteModel)
        {
            return validarDatos(clienteModel) ? clienteRepository.update(clienteModel) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool validarDatos(ClienteModel cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.Nombre) && cliente.Nombre.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido) && cliente.Apellido.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Documento) && cliente.Documento.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Direccion))
                return false;
            if (string.IsNullOrEmpty(cliente.Mail))
                return false;
            if (string.IsNullOrEmpty(cliente.Celular) && cliente.Celular.Length != 10 && !long.TryParse(cliente.Celular, out _))
                return false;
            if (string.IsNullOrEmpty(cliente.Estado))
                return false;

            return true;
        }
    }
}
