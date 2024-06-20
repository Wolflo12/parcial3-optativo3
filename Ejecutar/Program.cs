using parcial3.Models.Cliente;
using parcial3.Models.Factura;
using parcial3.Models.Sucursal;
using parcial3.Models.DetalleFactura;
using parcial3.Models.Producto;
using parcial3.Services.Cliente;
using parcial3.Services.Factura;
using parcial3.Services.Sucursal;
using parcial3.Services.DetalleFactura;
using parcial3.Services.Producto;
using System.Text.RegularExpressions;

string connectionString = "Host=localhost;Username=postgres;Password=bubuchona;Database=postgres;Port=5432";
ClienteService clienteService = new ClienteService(connectionString);
FacturaService facturaService = new FacturaService(connectionString);
SucursalService sucursalService = new SucursalService(connectionString);
DetalleFacturaService detallefacturaService = new DetalleFacturaService(connectionString);
ProductoService productoService = new ProductoService(connectionString);

Console.WriteLine("Ingrese: \n a - para insertar \n b - para listar \n c - para borrar \n d - para actualizar");
string opcion = Console.ReadLine();

if (opcion == "a")
{
    clienteService.add(new ClienteModel
    {
        Nombre = "Octavio",
        Apellido = "Fernandez",
        Documento = "456783",
        Direccion = "su casa",
        Mail = "abcd@gmail.com",
        Celular = "123456789",
        Estado = "Activo"
    });

    facturaService.add(new FacturaModel
    {
        Nro_factura = "Nro° 12345678",
        Fecha_hora = new DateTime(2024, 05, 22),
        Total = new decimal(12),
        Total_iva5 = new decimal(22),
        Total_iva10 = new decimal(32),
        Total_iva = new decimal(42),
        Total_letras = "No se contar",
        Sucursal = "Tacumbu",
    });

    sucursalService.add(new SucursalModel
    {
        Direccion = "ni idea",
        Telefono = "82234689",
        Whatsapp = "92348905",
        Mail = "sucursal@gmail.com",
        Estado = "Activo"
    });

    detallefacturaService.add(new DetalleFacturaModel
    {
        cantidad_producto = "20",
        subtotal = "82234689",
    });

    productoService.add(new ProductoModel
    {
        descripcion = "ni idea",
        cantidad_minima = "82234689",
        cantidad_stock = "92348905",
        precio_compra = "9394",
        precio_venta = "9823498",
        categoria = "2",
        marca = "no se",
        estado = "bien",
    });
}

if (opcion == "b")
{
    clienteService.GetAll().ToList().ForEach(cliente =>
    Console.WriteLine(
        $"Nombre: {cliente.Nombre} \n " +
        $"Apellido: {cliente.Apellido} \n " +
        $"Documento: {cliente.Documento} \n " +
        $"Direccion {cliente.Direccion} \n " +
        $"Mail: {cliente.Mail} \n " +
        $"Celular: {cliente.Celular} \n " +
        $"Estado: {cliente.Estado} \n "
        )
    );

    facturaService.GetAll().ToList().ForEach(factura =>
    Console.WriteLine(
        $"Nombre: {factura.Nro_factura} \n " +
        $"Apellido: {factura.Fecha_hora} \n " +
        $"Documento: {factura.Total} \n " +
        $"Direccion {factura.Total_iva5} \n " +
        $"Mail: {factura.Total_iva10} \n " +
        $"Celular: {factura.Total_iva} \n " +
        $"Estado: {factura.Total_letras} \n " +
        $"Estado: {factura.Sucursal} \n "
        )
    );

    sucursalService.GetAll().ToList().ForEach(sucursal =>
    Console.WriteLine(
        $"Nombre: {sucursal.Direccion} \n " +
        $"Apellido: {sucursal.Telefono} \n " +
        $"Documento: {sucursal.Whatsapp} \n " +
        $"Estado: {sucursal.Estado} \n "
        )
    );

    detallefacturaService.GetAll().ToList().ForEach(DetalleFactura =>
    Console.WriteLine(
        $"cantidad_producto: {DetalleFactura.cantidad_producto} \n " +
        $"subtotal: { DetalleFactura.subtotal} \n " 
        )
    );

    productoService.GetAll().ToList().ForEach(Producto =>
    Console.WriteLine(
        $"descripcion: { Producto.descripcion} \n " +
        $"cantidad_minima: { Producto.cantidad_minima} \n " +
        $"cantidad_stock: { Producto.cantidad_stock} \n " +
        $"precio_compra: { Producto.precio_compra} \n " +
        $"precio_venta: { Producto.precio_venta} \n " +
        $"categoria: { Producto.categoria} \n " +
        $"marca: { Producto.marca} \n " +
        $"estado: { Producto.estado} \n "
        )
    );
}

if (opcion == "c")
{
    Console.WriteLine("Ingrese: \n 1 - para borrar cliente \n 2 - para borrar factura \n 3 - para borrar sucursal \n 4 - para borrar detalle \n 5 - para borrar producto");
    string subopcion = Console.ReadLine();

    switch (subopcion)
    {
        case "1":
            Console.WriteLine("Ingrese el ID del cliente a borrar:");
            int clienteId = int.Parse(Console.ReadLine());
            clienteService.DeleteByid(clienteId);
            break;
        case "2":
            Console.WriteLine("Ingrese el ID de la factura a borrar:");
            int facturaId = int.Parse(Console.ReadLine());
            facturaService.DeleteByid(facturaId);
            break;
        case "3":
            Console.WriteLine("Ingrese el ID de la sucursal a borrar:");
            int sucursalId = int.Parse(Console.ReadLine());
            sucursalService.DeleteByid(sucursalId);
            break;
        case "4":
            Console.WriteLine("Ingrese el ID del detalle a borrar:");
            int detallefacturaId = int.Parse(Console.ReadLine());
            detallefacturaService.DeleteByid(detallefacturaId);
            break;
        case "5":
            Console.WriteLine("Ingrese el ID del producto a borrar:");
            int productoId = int.Parse(Console.ReadLine());
            productoService.DeleteByid(productoId);
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

if (opcion == "d")
{
    Console.WriteLine("Ingrese: \n 1 - para actualizar cliente \n 2 - para actualizar factura \n 3 - para actualizar sucursal \n 4 - para actualizar detalle \n 5 - para actualizar producto");
    string subopcion = Console.ReadLine();

    switch (subopcion)
    {
        case "1":
            Console.WriteLine("Ingrese el ID del cliente a actualizar:");
            int clienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del cliente:");
            string nuevoNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo apellido del cliente:");
            string nuevoApellido = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo documento del cliente:");
            string nuevoDocumento = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva dirección del cliente:");
            string nuevaDireccion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo mail del cliente:");
            string nuevoMail = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo celular del cliente:");
            string nuevoCelular = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo estado del cliente:");
            string nuevoEstado = Console.ReadLine();

            ClienteModel clienteActualizado = new ClienteModel
            {
                Id = clienteId, 
                Nombre = nuevoNombre,
                Apellido = nuevoApellido,
                Documento = nuevoDocumento,
                Direccion = nuevaDireccion,
                Mail = nuevoMail,
                Celular = nuevoCelular,
                Estado = nuevoEstado
            };

            clienteService.update(clienteActualizado);
            break;
        case "2":
            Console.WriteLine("Ingrese el ID de la factura a actualizar:");
            int facturaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo nrofactura:");
            string nuevonrofactura = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo fechahora:");
            string nuevofechahora = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo total:");
            string nuevototal = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva total_iva5:");
            string nuevatotal_iva5 = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo total_iva10:");
            string nuevototal_iva10 = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo total_iva:");
            string nuevototal_iva = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo total_letras:");
            string nuevototal_letras = Console.ReadLine();

            FacturaModel facturaActualizado = new FacturaModel
            {
                Nro_factura = nuevonrofactura,
                Fecha_hora = nuevofechahora,
                Total = nuevototal,
                Total_iva5 = nuevatotal_iva5,
                Total_iva10 = nuevototal_iva10,
                Total_iva = nuevototal_iva,
                Total_letras = nuevototal_letras,
            };

            clienteService.update(facturaActualizado);
            break;
        case "3":
            Console.WriteLine("Ingrese el ID de la sucursal a actualizar:");
            int sucursalId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo descripcion:");
            string nuevodescripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo direccion:");
            string nuevodireccion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo telefono:");
            string nuevotelefono = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva whatsapp:");
            string nuevowhatsapp = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo mail:");
            string nuevomail = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo estado:");
            string nuevoestado = Console.ReadLine();

            SucursalModel sucursalActualizado = new SucursalModel
            {
                Direccion = nuevodireccion,
                Telefono = nuevotelefono,
                Whatsapp = nuevowhatsapp,
                Mail = nuevomail,
                Estado = nuevoestado
            };

            sucursalService.update(sucursalActualizado);
            break;
        case "4":
            Console.WriteLine("Ingrese el ID del detalle:");
            int detalleId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo cantidad_producto:");
            string nuevocantidad = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo subtotal:");
            string nuevosubtotal = Console.ReadLine();

            DetalleFacturaModel detallefacturaActualizado = new DetalleFacturaModel
            {
                cantidad_producto = nuevocantidad,
                subtotal = nuevosubtotal,
            };

            detallefacturaService.update(detallefacturaActualizado);
            break;
        case "5":
            Console.WriteLine("Ingrese el ID del producto:");
            int productoId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo descripcion:");
            string nuevodescripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo cantidad_minima:");
            string nuevocantidadm = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo cantidad_stock:");
            string nuevocantidads = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva compra:");
            string nuevacompra = Console.ReadLine();

            Console.WriteLine("Ingrese el nueva venta:");
            string nuevaventa = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo categoria:");
            string nuevocategoria = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo marca:");
            string nuevomarca = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo estado:");
            string nuevoestado = Console.ReadLine();

            ProductoModel productoActualizado = new ProductoModel
            {
                descripcion = nuevodescripcion,
                cantidad_minima = nuevocantidadm,
                cantidad_stock = nuevocantidads,
                precio_compra = nuevacompra,
                precio_venta = nuevaventa,
                categoria = nuevoCelular,
                marca = nuevomarca,
                estado = nuevoestado,
            };

            productoService.update(productoActualizado);
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}
