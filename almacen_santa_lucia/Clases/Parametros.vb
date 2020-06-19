Public Class Parametros
    Private ID_Parametro As String
    Private Valor_Parametro As String

    Public Sub SETIDParametro(ByVal valor_id_parametro)
        ID_Parametro = valor_id_parametro
    End Sub

    Public Sub SETValorParametro(ByVal valor_dato_parametro)
        Valor_Parametro = valor_dato_parametro
    End Sub

    Public Function GETValor_Parametro() As String
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Dim Consulta As String = "SELECT valor FROM parametros WHERE id_parametro='" & ID_Parametro & "' "
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows()
            Valor_Parametro = row("valor")
        Next
        BD.Desconectar()
        Return Valor_Parametro
    End Function

    Public Function Actualizar_Valor_Parametro() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Dim Consulta As String = ""

        Consulta = "UPDATE parametros SET valor@valor WHERE id_parametro=@id_parametro"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@valor", "string", Me.ID_Parametro)
        BD.AsignarParametro("@id_parametro", "string", Me.Valor_Parametro)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function
End Class
