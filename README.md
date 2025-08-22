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
