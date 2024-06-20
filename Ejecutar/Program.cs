
using parcial3.Models.Cliente;
using parcial3.Models.Factura;
using parcial3.Models.Sucursal;
using parcial3.Services.Cliente;
using parcial3.Services.Factura;
using parcial3.Services.Sucursal;

string connectionString = "Host=localhost;Username=postgres;Password=bubuchona;Database=postgres;Port=5432";
ClienteService clienteService = new ClienteService(connectionString);
FacturaService facturaService = new FacturaService(connectionString);
SucursalService sucursalService = new SucursalService(connectionString);

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
}

if (opcion == "c")
{
    Console.WriteLine("Ingrese: \n 1 - para borrar cliente \n 2 - para borrar factura \n 3 - para borrar sucursal");
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
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

if (opcion == "d")
{
    Console.WriteLine("Ingrese: \n 1 - para actualizar cliente \n 2 - para actualizar factura \n 3 - para actualizar sucursal");
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
            break;
        case "3":
            Console.WriteLine("Ingrese el ID de la sucursal a actualizar:");
            int sucursalId = int.Parse(Console.ReadLine());
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

