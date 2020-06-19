Public Class Ventas
    Private ID_Venta As Integer
    Private Fecha As String
    Private Precio As Decimal
    Private Forma_Pago As String
    Private ID_Tarjeta_Credito As Integer = 0
    Private ID_Tarjeta_Debito As Integer = 0
    Private DNI As Integer = 0
    Private Nombre As String = ""
    Private Numero_Tarjeta As String = ""

    Public Sub SETID_Venta(ByVal valor_idventa)
        ID_Venta = valor_idventa
    End Sub

    Public Sub SETFecha(ByVal valor_fecha)
        Fecha = valor_fecha
    End Sub

    Public Sub SETPrecio(ByVal valor_precio)
        Precio = valor_precio
    End Sub

    Public Sub SETForma_Pago(ByVal valor_forma_pago)
        Forma_Pago = valor_forma_pago
    End Sub

    Public Sub SET_DNI(ByVal valor_dni)
        DNI = valor_dni
    End Sub

    Public Sub SETNombre(ByVal Valor_Nombre As String)
        Nombre = Valor_Nombre
    End Sub

    Public Sub SETNumeroTarjeta(ByVal valor_numero_tarjeta)
        Numero_Tarjeta = valor_numero_tarjeta
    End Sub

    Function GETID_Venta() As Integer
        Return ID_Venta
    End Function

    Public Sub SETID_TarjetaCredito(ByVal valor_id_tarjeta_credito)
        ID_Tarjeta_Credito = valor_id_tarjeta_credito
    End Sub

    Public Sub SETID_TarjetaDebito(ByVal valor_id_tarjeta_debito)
        ID_Tarjeta_Debito = valor_id_tarjeta_debito
    End Sub

    'listado de todas las ventas
    Function Listado_Ventas(ByVal Condicion As String) As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT ventas.id_venta AS Codigo,DATE_FORMAT(ventas.fecha,'%d/%m/%Y') AS Fecha," & _
            "CASE WHEN ventas.forma_pago='e' THEN 'Efectivo' WHEN ventas.forma_pago='c' THEN 'Credito' " & _
            "WHEN ventas.forma_pago='d' THEN 'Debito' END AS 'Forma Pago',Precio,tarjetas_credito.empresa AS 'Tarjeta de Credito'," & _
            "tarjetas_debito.empresa AS 'Tarjeta de Debito',ventas.dni AS DNI,ventas.nombre AS Nombre," & _
            "ventas.numero_tarjeta AS 'Numero de Tarjeta' FROM ventas LEFT JOIN tarjetas_credito " & _
            "ON ventas.id_tarjeta_credito=tarjetas_credito.id_tarjeta_credito " & _
            "LEFT JOIN tarjetas_debito ON ventas.id_tarjeta_debito=tarjetas_debito.id_tarjeta_debito WHERE 1=1 " & Condicion & " ORDER BY ventas.id_venta DESC"
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'busco los datos de una venta
    Function Buscar_Datos_Venta() As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM ventas WHERE id_venta=" & ID_Venta
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'genero un nuevo id para el alta de una nueva venta
    Function Generar_ID() As Integer
        Dim BD As New Base_De_Datos
        Dim ID As Integer
        ID = 1
        BD.Conectar()
        Dim Consulta As String = "SELECT MAX(id_venta) FROM ventas"
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows
            If row(0) IsNot DBNull.Value Then
                ID = row(0)
                ID = ID + 1
            End If
        Next
        BD.Desconectar()
        Return ID
    End Function

    'agrego una nueva venta la base de datos
    Function Agregar_Venta() As String
        Dim Mensaje As String = ""
        Me.ID_Venta = Generar_ID()
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        Consulta = "INSERT INTO ventas(id_venta,fecha,precio,forma_pago,id_tarjeta_credito,id_tarjeta_debito,dni,nombre,numero_tarjeta) VALUES(@id_venta,@fecha,@precio,@forma_pago,@id_tarjeta_credito,@id_tarjeta_debito,@dni,@nombre,@numero_tarjeta)"
        BD.Conectar()
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_venta", "int", Me.ID_Venta)
        BD.AsignarParametro("@fecha", "date", CDate(Me.Fecha))
        BD.AsignarParametro("@precio", "decimal", Me.Precio)
        BD.AsignarParametro("@forma_pago", "string", Me.Forma_Pago)
        Select Case Forma_Pago
            Case "e"
                BD.AsignarParametro("@id_tarjeta_credito", "int", DBNull.Value)
                BD.AsignarParametro("@id_tarjeta_debito", "int", DBNull.Value)
                BD.AsignarParametro("@dni", "int", DBNull.Value)
                BD.AsignarParametro("@nombre", "string", DBNull.Value)
                BD.AsignarParametro("@numero_tarjeta", "string", DBNull.Value)
            Case "c"
                BD.AsignarParametro("@id_tarjeta_credito", "int", Me.ID_Tarjeta_Credito)
                BD.AsignarParametro("@id_tarjeta_debito", "int", DBNull.Value)
                BD.AsignarParametro("@dni", "int", Me.DNI)
                BD.AsignarParametro("@nombre", "string", Me.Nombre)
                BD.AsignarParametro("@numero_tarjeta", "string", Me.Numero_Tarjeta)
            Case "d"
                BD.AsignarParametro("@id_tarjeta_credito", "int", DBNull.Value)
                BD.AsignarParametro("@id_tarjeta_debito", "int", Me.ID_Tarjeta_Debito)
                BD.AsignarParametro("@dni", "int", Me.DNI)
                BD.AsignarParametro("@nombre", "string", Me.Nombre)
                BD.AsignarParametro("@numero_tarjeta", "string", Me.Numero_Tarjeta)
        End Select
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    'Modifico una venta de la base de datos
    Function Modificar_Venta() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        Consulta = "UPDATE ventas SET precio=@precio,forma_pago=@forma_pago,id_tarjeta_credito=@id_tarjeta_credito,id_tarjeta_debito=@id_tarjeta_debito,dni=@dni,nombre=@nombre,numero_tarjeta=@numero_tarjeta WHERE id_venta=@id_venta"
        BD.Conectar()
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_venta", "int", Me.ID_Venta)
        BD.AsignarParametro("@precio", "decimal", Me.Precio)
        BD.AsignarParametro("@forma_pago", "string", Forma_Pago)
        Select Case Forma_Pago
            Case "e"
                BD.AsignarParametro("@id_tarjeta_credito", "int", DBNull.Value)
                BD.AsignarParametro("@id_tarjeta_debito", "int", DBNull.Value)
                BD.AsignarParametro("@dni", "int", DBNull.Value)
                BD.AsignarParametro("@nombre", "string", DBNull.Value)
                BD.AsignarParametro("@numero_tarjeta", "string", DBNull.Value)
            Case "c"
                BD.AsignarParametro("@id_tarjeta_credito", "int", Me.ID_Tarjeta_Credito)
                BD.AsignarParametro("@id_tarjeta_debito", "int", DBNull.Value)
                BD.AsignarParametro("@dni", "int", Me.DNI)
                BD.AsignarParametro("@nombre", "string", Me.Nombre)
                BD.AsignarParametro("@numero_tarjeta", "string", Me.Numero_Tarjeta)
            Case "d"
                BD.AsignarParametro("@id_tarjeta_credito", "int", DBNull.Value)
                BD.AsignarParametro("@id_tarjeta_debito", "int", Me.ID_Tarjeta_Debito)
                BD.AsignarParametro("@dni", "int", Me.DNI)
                BD.AsignarParametro("@nombre", "string", Me.Nombre)
                BD.AsignarParametro("@numero_tarjeta", "string", Me.Numero_Tarjeta)
        End Select

        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    'Elimino una venta la base de datos
    Function Eliminar_Venta() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        Consulta = "DELETE FROM ventas WHERE id_venta=@id_venta"
        BD.Conectar()
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_venta", "int", Me.ID_Venta)

        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function
End Class
