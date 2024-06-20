using parcial3.Models.Factura;
using parcial3.Repository.IFactura;
using parcial3.Repository.Factura.FacturaRepository;
using System.Text.RegularExpressions;
using parcial3.Repository.Factura.DetalleFactura;

namespace parcial3.Services.Factura
{
    public class FacturaService : IFacturaRepository
    {
        private FacturaRepository facturaRepository;
        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }

        public bool add(FacturaModel factura)
        {
            return validarDatos(factura) ? facturaRepository.add(factura) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            return facturaRepository.GetAll();
        }

        public bool DeleteByid(int id)
        {
            return id > 0 ? facturaRepository.DeleteByid(id) : false;
        }


        public bool update(FacturaModel facturaModel)
        {
            return validarDatos(facturaModel) ? facturaRepository.update(facturaModel) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool validarDatos(FacturaModel factura)
        {
            if (factura == null)
                return false;

            string patron = @"^\d{3}-\d{3}-\d{6}$";
            if (!Regex.IsMatch(factura.Nro_factura, patron))
                return false;

            if (factura.Fecha_hora == DateTime.MinValue)
                return false;

            if (factura.Total <= 0 || factura.Total_iva5 <= 0 || factura.Total_iva10 <= 0 || factura.Total_iva <= 0)
                return false;

            if (string.IsNullOrEmpty(factura.Total_letras) || factura.Total_letras.Length < 6)
                return false;

            if (string.IsNullOrEmpty(factura.Sucursal))
                return false;

            return true;
        }
        public IEnumerable<FacturaModel> GetAllWithDetalle()
        {
            return facturaRepository.GetAll().ToList();
        }
    }
}
