Public Class Ventas_Detalles
    Private ID_Venta As Integer
    Private ID_Producto As Integer
    Private Cantidad As Decimal
    Private SubTotal As Decimal

    Public Sub SETID_Venta(ByVal valor_id_venta)
        ID_Venta = valor_id_venta
    End Sub

    Public Sub SETID_Producto(ByVal valor_id_producto)
        ID_Producto = valor_id_producto
    End Sub

    Public Sub SETCantidad(ByVal valor_cantidad)
        Cantidad = valor_cantidad
    End Sub

    Public Sub SETSubTotal(ByVal valor_subtotal)
        SubTotal = valor_subtotal
    End Sub

    'listado de todos los detalles
    Function Listado_Ventas_Detalles() As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT ventas_detalles.id_producto AS Codigo,productos.descripcion AS Producto,ventas_detalles.cantidad AS Cantidad,ventas_detalles.subtotal AS SubTotal FROM ventas_detalles INNER JOIN productos ON ventas_detalles.id_producto=productos.id_producto WHERE id_venta=" & ID_Venta
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'agrego una nueva venta la base de datos
    Function Agregar_Venta_Detalle() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        Consulta = "INSERT INTO ventas_detalles(id_venta,id_producto,cantidad,subtotal) VALUES(@id_venta,@id_producto,@cantidad,@subtotal)"
        BD.Conectar()
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_venta", "int", Me.ID_Venta)
        BD.AsignarParametro("@id_producto", "int", Me.ID_Producto)
        BD.AsignarParametro("@cantidad", "decimal", Me.Cantidad)
        BD.AsignarParametro("@subtotal", "decimal", Me.SubTotal)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    'Elimino los detalles de la venta la base de datos
    Function Eliminar_Ventas_Detalles() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        Consulta = "DELETE FROM ventas_detalles WHERE id_venta=@id_venta"
        BD.Conectar()
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_venta", "int", Me.ID_Venta)

        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function
End Class
