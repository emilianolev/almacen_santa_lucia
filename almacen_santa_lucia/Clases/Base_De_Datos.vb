Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlDataAdapter
Imports System.Data

Public Class Base_De_Datos

    Dim connection As MySqlConnection
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public ds As New DataSet
    Public cb As MySqlCommandBuilder
    Public odatarow As DataRow

    'Al abrir el programa verifico que se pueda acceder al phpMyAdmin
    Public Function Validar_Coneccion() As Boolean
        Dim Valida As Boolean = False
        Dim Conector As New MySqlConnection
        Conector.ConnectionString = Cadena_Coneccion
        Try
            Conector.Open()
            Conector.Close()
            Valida = True
        Catch ex As Exception
            Valida = False
        End Try
        Return Valida
    End Function

    Public Sub Conectar()
        connection = New MySqlConnection
        connection.ConnectionString = Cadena_Coneccion '"server=localhost;user=root;password=;database=almacen_santa_lucia;PORT=3306"
        connection.Open()
    End Sub

    Public Sub Desconectar()
        connection.Close()
    End Sub

    Public Sub CrearComando(ByVal consulta As String)
        cmd = New MySqlCommand(consulta, connection)
    End Sub

    Public Sub AsignarParametro(ByVal param As String, ByVal tipoDato As String, ByVal valor As Object)
        'MySqlDbType
        Dim tipo As MySqlDbType
        Select Case tipoDato
            Case "string"
                tipo = MySqlDbType.VarChar
            Case "int"
                tipo = MySqlDbType.Int32
            Case "decimal"
                tipo = MySqlDbType.Decimal
            Case "date"
                tipo = MySqlDbType.Date
            Case "time"
                tipo = MySqlDbType.Time
            Case "longtext"
                tipo = MySqlDbType.LongText
        End Select

        cmd.Parameters.Add(param, tipo).Value = valor
    End Sub

    Public Function EjecutarConsulta() As String
        Dim Mensaje As String = ""
        Try
            cmd.ExecuteNonQuery()
            Mensaje = ""
        Catch ex As Exception
            Mensaje = ex.Message
        End Try
        Return Mensaje
    End Function

    Public Function EjecutarReader() As MySqlDataReader
        Return cmd.ExecuteReader()
    End Function

    Public Function EjecutarDataTable() As DataTable
        dt = New DataTable()
        da = New MySqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt
    End Function

    'funcion para rellenar combo box
    Public Function Listar(ByVal Consulta As String) As DataTable
        Dim dt = New DataTable
        Dim da = New MySqlDataAdapter(consulta, connection)
        da.Fill(dt)
        Listar = dt
        Return Listar
    End Function
End Class
