
using parcial3.Models.Sucursal;
using parcial3.Repository.Sucursal;
using parcial3.Repository.ISucursal;
using System.Text.RegularExpressions;

namespace parcial3.Services.Sucursal
{
    public class SucursalService : ISucursalRepository
    {
        private SucursalRepository sucursalRepository;
        public SucursalService(string connectionString)
        {
            sucursalRepository = new SucursalRepository(connectionString);
        }

        public bool add(SucursalModel sucursal)
        {
            return validarDatos(sucursal) ? sucursalRepository.add(sucursal) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            return sucursalRepository.GetAll();
        }

        public bool DeleteByid(int id)
        {
            return id > 0 ? sucursalRepository.DeleteByid(id) : false;
        }


        public bool update(SucursalModel sucursalModel)
        {
            return validarDatos(sucursalModel) ? sucursalRepository.update(sucursalModel) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool validarDatos(SucursalModel sucursal)
        {
            if (sucursal == null)
                return false;
            if (string.IsNullOrEmpty(sucursal.Direccion) && sucursal.Direccion.Length < 10)
                return false;
            if (string.IsNullOrEmpty(sucursal.Telefono))
                return false;
            if (string.IsNullOrEmpty(sucursal.Whatsapp))
                return false;
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(sucursal.Mail, patronEmail))
                return false;
            if (string.IsNullOrEmpty(sucursal.Estado))
                return false;

            return true;
        }
    }
}
