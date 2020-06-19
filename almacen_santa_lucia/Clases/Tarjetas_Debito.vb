Public Class Tarjetas_Debito
    Private ID_Tarjeta_Debito As Integer
    Private Empresa As String
    Private Activo As String

    Public Sub SETIDTarjetaDebito(ByVal valor_id_tarjeta_Debito)
        ID_Tarjeta_Debito = valor_id_tarjeta_Debito
    End Sub

    Public Sub SETEmpresa(ByVal valor_Empresa)
        Empresa = valor_Empresa
    End Sub

    Public Sub SETActivo(ByVal valor_Activo)
        Activo = valor_Activo
    End Sub

    Public Function GETID_Tarjeta_Debito() As Integer
        Return ID_Tarjeta_Debito
    End Function

    'listado de todas las tarjetas de Debito
    Function Listado_Tarjetas_Debito(ByVal Condicion As String) As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT id_tarjeta_debito AS Codigo,Empresa,Activo FROM tarjetas_debito WHERE 1=1 " & Condicion
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'busco los datos de una tarjeta de Debito
    Function Buscar_Datos_Tarjeta_Debito() As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM tarjetas_debito WHERE id_tarjeta_debito=" & ID_Tarjeta_Debito
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    Public Sub Llenar_ComboBox(ByRef Combo As ComboBox)
        Dim BD As New Base_De_Datos
        Dim Consulta As String = "SELECT * FROM tarjetas_debito WHERE activo='S'"
        BD.Conectar()
        'BD.CrearComando(Consulta)
        Combo.DataSource = BD.Listar(Consulta)
        Combo.DisplayMember = "empresa"
        Combo.ValueMember = "id_tarjeta_debito"
        BD.Desconectar()
    End Sub

    'genero un nuevo id para el alta de una tarjeta de credito
    Function Generar_ID() As Integer
        Dim BD As New Base_De_Datos
        Dim ID As Integer
        ID = 1
        BD.Conectar()
        Dim Consulta As String = "SELECT MAX(id_tarjeta_debito) FROM tarjetas_debito"
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

    Public Function Agregar_Tarjeta_Debito() As String
        Dim Mensaje As String = ""
        Me.ID_Tarjeta_Debito = Generar_ID()
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        BD.Conectar()
        Consulta = "INSERT INTO tarjetas_debito(id_tarjeta_debito,empresa,activo) VALUES(@id_tarjeta_debito,@empresa,@activo)"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_tarjeta_debito", "int", Me.ID_Tarjeta_Debito)
        BD.AsignarParametro("@empresa", "string", Me.Empresa)
        BD.AsignarParametro("@activo", "string", Me.Activo)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Modificar_Tarjeta_Debito() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        BD.Conectar()
        Consulta = "UPDATE tarjetas_debito SET empresa=@empresa,activo=@activo WHERE id_tarjeta_debito=@id_tarjeta_debito"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_tarjeta_debito", "int", Me.ID_Tarjeta_Debito)
        BD.AsignarParametro("@empresa", "string", Me.Empresa)
        BD.AsignarParametro("@activo", "string", Me.Activo)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Eliminar_Tarjeta_Debito() As String
        Dim Mensaje As String = ""
        If Cantidad_Ventas_Tarjeta() = 0 Then
            Dim BD As New Base_De_Datos
            Dim Consulta As String = ""
            Dim Cant As Integer = 0
            BD.Conectar()
            Consulta = "DELETE FROM tarjetas_debito WHERE id_tarjeta_debito=@id_tarjeta_debito"
            BD.CrearComando(Consulta)

            BD.AsignarParametro("@id_tarjeta_Debito", "int", Me.ID_Tarjeta_Debito)
            Mensaje = BD.EjecutarConsulta()
            BD.Desconectar()
        Else
            Mensaje = "No se puede eliminar la tarjeta de debito ya se han realizado ventas con ella"
        End If
        Return Mensaje
    End Function

    Public Function Cantidad_Ventas_Tarjeta() As Integer
        Dim BD As New Base_De_Datos
        Dim Cant As Integer
        Cant = 0
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM ventas WHERE id_tarjeta_debito=" & Me.ID_Tarjeta_Debito
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows
            Cant = Cant + 1
        Next
        BD.Desconectar()
        Return Cant
    End Function
End Class
