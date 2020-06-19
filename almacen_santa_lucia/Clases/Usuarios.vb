Public Class Usuarios
    Private Usuario As String
    Private Clave As String
    Private Tipo As String

    Public Sub SETUsuario(ByVal valor_Usuario)
        Usuario = valor_Usuario
    End Sub

    Public Sub SETClave(ByVal valor_Clave)
        Clave = valor_Clave
    End Sub

    Public Sub SETTipo(ByVal valor_tipo)
        Tipo = valor_tipo
    End Sub

    Public Function Validar_Usuario() As Boolean
        Dim Valido As Boolean = False
        Dim Consulta As String = ""
        Consulta = "SELECT * FROM usuarios WHERE usuario=@usuario AND clave=@clave"
        Dim BD As New Base_De_Datos
        BD.Conectar()
        BD.CrearComando(Consulta)
        BD.AsignarParametro("@usuario", "string", Me.Usuario)
        BD.AsignarParametro("@clave", "string", Me.Clave)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows
            Valido = True
        Next
        BD.Desconectar()
        Return Valido
    End Function

    Public Function Modificar_Clave() As String
        Dim Mensaje As String = ""
        Dim Consulta As String = ""
        Consulta = "UPDATE usuarios SET clave=@clave WHERE usuario=@usuario"
        Dim BD As New Base_De_Datos
        BD.Conectar()
        BD.CrearComando(Consulta)
        BD.AsignarParametro("@usuario", "string", Me.Usuario)
        BD.AsignarParametro("@clave", "string", Me.Clave)

        Mensaje = BD.EjecutarConsulta
        BD.Desconectar()
        Return Mensaje
    End Function
End Class