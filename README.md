Explicación de la Consulta:
JOIN Strategy: Utilice INNER JOINs para conectar las tres tablas
Venta → Producto (por CodigoProducto)
Producto → Categoria (por CodigoCategoria)

Ordenamiento:
ORDER BY v.Fecha DESC para obtener primero la venta más reciente
Limitación: TOP 1 para obtener únicamente el registro más reciente

Campos Seleccionados:
NombreCategoria (requerido)
FechaUltimaVenta (para verificación)
NombreProducto (contexto adicional)
CodigoVenta (identificador único)

Tecnologías Utilizadas
Framework: ASP.NET Core 8.0
Patrón: Razor Pages
ORM: Entity Framework Core 8.0
Base de Datos: SQL Server
Frontend: Bootstrap 5.3, Font Awesome 6.4
JavaScript: Vanilla JS para validación y UX
