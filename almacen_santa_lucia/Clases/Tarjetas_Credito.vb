Public Class Tarjetas_Credito
    Private ID_Tarjeta_Credito As Integer
    Private Empresa As String
    Private Recargo As Decimal
    Private Activo As String

    Public Sub SETIDTarjetaCredito(ByVal valor_id_tarjeta_credito)
        ID_Tarjeta_Credito = valor_id_tarjeta_credito
    End Sub

    Public Sub SETEmpresa(ByVal valor_Empresa)
        Empresa = valor_Empresa
    End Sub

    Public Sub SETRecargo(ByVal valor_Recargo)
        Recargo = valor_Recargo
    End Sub

    Public Sub SETActivo(ByVal valor_Activo)
        Activo = valor_Activo
    End Sub

    Public Function GETID_Tarjeta_Credito() As Integer
        Return ID_Tarjeta_Credito
    End Function

    'listado de todas las tarjetas de credito
    Function Listado_Tarjetas_Credito(ByVal Condicion As String) As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT id_tarjeta_credito AS Codigo,Empresa,Recargo,Activo FROM tarjetas_credito WHERE 1=1 " & Condicion
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'busco los datos de una tarjeta de credito
    Function Buscar_Datos_Tarjeta_Credito() As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM tarjetas_credito WHERE id_tarjeta_credito=" & ID_Tarjeta_Credito
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    Public Sub Llenar_ComboBox(ByRef Combo As ComboBox)
        Dim BD As New Base_De_Datos
        Dim Consulta As String = "SELECT * FROM tarjetas_credito WHERE activo='S'"
        BD.Conectar()
        'BD.CrearComando(Consulta)
        Combo.DataSource = BD.Listar(Consulta)
        Combo.DisplayMember = "empresa"
        Combo.ValueMember = "id_tarjeta_credito"
        BD.Desconectar()
    End Sub

    'genero un nuevo id para el alta de una tarjeta de credito
    Function Generar_ID() As Integer
        Dim BD As New Base_De_Datos
        Dim ID As Integer
        ID = 1
        BD.Conectar()
        Dim Consulta As String = "SELECT MAX(id_tarjeta_credito) FROM tarjetas_credito"
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

    Public Function Agregar_Tarjeta_Credito() As String
        Dim Mensaje As String = ""
        Me.ID_Tarjeta_Credito = Generar_ID()
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        BD.Conectar()
        Consulta = "INSERT INTO tarjetas_credito(id_tarjeta_credito,empresa,recargo,activo) VALUES(@id_tarjeta_credito,@empresa,@recargo,@activo)"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_tarjeta_credito", "int", Me.ID_Tarjeta_Credito)
        BD.AsignarParametro("@empresa", "string", Me.Empresa)
        BD.AsignarParametro("@recargo", "decimal", Me.Recargo)
        BD.AsignarParametro("@activo", "string", Me.Activo)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Modificar_Tarjeta_Credito() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        BD.Conectar()
        Consulta = "UPDATE tarjetas_credito SET empresa=@empresa,recargo=@recargo,activo=@activo WHERE id_tarjeta_credito=@id_tarjeta_credito"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_tarjeta_credito", "int", Me.ID_Tarjeta_Credito)
        BD.AsignarParametro("@empresa", "string", Me.Empresa)
        BD.AsignarParametro("@recargo", "decimal", Me.Recargo)
        BD.AsignarParametro("@activo", "string", Me.Activo)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Eliminar_Tarjeta_Credito() As String
        Dim Mensaje As String = ""
        If Cantidad_Ventas_Tarjeta() = 0 Then
            Dim BD As New Base_De_Datos
            Dim Consulta As String = ""
            Dim Cant As Integer = 0
            BD.Conectar()
            Consulta = "DELETE FROM tarjetas_credito WHERE id_tarjeta_credito=@id_tarjeta_credito"
            BD.CrearComando(Consulta)

            BD.AsignarParametro("@id_tarjeta_credito", "int", Me.ID_Tarjeta_Credito)
            Mensaje = BD.EjecutarConsulta()
            BD.Desconectar()
        Else
            Mensaje = "No se puede eliminar la tarjeta de credito ya se han realizado ventas con ella"
        End If
        Return Mensaje
    End Function

    Public Function Cantidad_Ventas_Tarjeta() As Integer
        Dim BD As New Base_De_Datos
        Dim Cant As Integer
        Cant = 0
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM ventas WHERE id_tarjeta_credito=" & Me.ID_Tarjeta_Credito
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
