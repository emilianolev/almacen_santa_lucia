Public Class Funciones

    Public Function Valida_Entero(ByVal NumInt As String, Optional ByVal Mayor_0 As Boolean = False) As Boolean
        Dim Valida As Boolean
        Try
            Dim Num As Integer = CDec(NumInt)
            Valida = True
            If Mayor_0 = True Then
                If Num <= 0 Then
                    Valida = False
                End If
            End If
        Catch ex As Exception
            Valida = False
        End Try
        Return Valida
    End Function

    Public Function Valida_Decimal(ByVal NumDecimal As String, Optional ByVal Mayor_0 As Boolean = False) As Boolean
        Dim Valida As Boolean
        Try
            Dim Num As Decimal = CDec(NumDecimal)
            Valida = True
            If Mayor_0 = True Then
                If Num < 0 Then
                    Valida = False
                End If
            End If
        Catch ex As Exception
            Valida = False
        End Try
        Return Valida
    End Function

    'Obtengo un numero decimal y lo formateo con dos decimales
    Public Function Formatear_Decimales(ByVal NumDecimal As String, Optional ByVal Porcentaje As Boolean = False) As String
        Dim Numero_Decimal As String = ""
        Numero_Decimal = Format(CDbl(NumDecimal), "F")
        Return Numero_Decimal
    End Function

    'funcion para encriptar la clave de usuario
    Function MD5Encrypt(ByVal EncString As String) As String
        'Variable Declarations
        Dim MD5String As String
        Dim EncStringBytes() As Byte
        Dim Encoder As New System.Text.UTF8Encoding
        Dim MD5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider

        'Converts the String to bytes
        EncStringBytes = Encoder.GetBytes(EncString)

        'Generates the MD5 Byte Array
        EncStringBytes = MD5Hasher.ComputeHash(EncStringBytes)

        'Create MD5 hash
        MD5String = BitConverter.ToString(EncStringBytes)
        MD5String = MD5String.Replace("-", "")

        'Returns the MD5 encrypted string to the calling object
        Return MD5String
    End Function

    Public Sub Seleccionar_Dato_Grilla(ByVal Grilla As DataGridView, ByVal Id_Seleccionar As String, ByVal Numero_Columna_Seleccionar As Integer)
        For i = 0 To Grilla.RowCount - 1
            If Id_Seleccionar = Grilla.Rows(i).Cells(0).Value Then
                Grilla.CurrentCell = Grilla(Numero_Columna_Seleccionar, i)
                Exit Sub
            End If
        Next
    End Sub

    Public Sub Bloquear_Controles_Formulario_Eliminacion(ByVal Formulario As Form)
        For Each ctl As Control In Formulario.Controls
            If ctl.Name <> "btnAceptar" And ctl.Name <> "btnCancelar" Then
                ctl.Enabled = False
            End If
        Next
    End Sub

    'Procedimiento para el control de errores, grabo todo en un log
    Public Sub Grabo_Archivo_Log(ByVal Mensaje_Error As String, ByVal Origen_Error As String)
        Try
            Dim Fecha As String = Now.Date.ToString
            Dim Hora As String = Now.TimeOfDay.ToString
            Dim Linea_Log As String = "ERROR= " & Mensaje_Error & " - ORIGEN= " & Origen_Error & " -FECHA Y HORA = " & Fecha & " " & Hora
            Dim Carpeta As String = My.Computer.FileSystem.CurrentDirectory
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Carpeta & "\Errores.log", True)
            file.WriteLine(Linea_Log)
            file.Close()
        Catch ex As Exception
            MessageBox.Show("No se puede acceder al archivo log, verifique permisos en la carpeta", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Reviso al salir del combo box que exista lo que el usuario escribio
    'debido al evento keyup que no funciona bien cuando se introduce solo un caracter
    Public Function Chequear_Existencia_Elemento_En_Combo_Box_Data_Source(ByRef ComboBox As ComboBox) As Boolean
        Dim Existe_Elemento As Boolean
        Existe_Elemento = False
        For Each item As System.Data.DataRowView In ComboBox.Items
            If item.Row.ItemArray(1) = ComboBox.Text Then
                Existe_Elemento = True
            End If
        Next
        Chequear_Existencia_Elemento_En_Combo_Box_Data_Source = Existe_Elemento
        'Public Function ExisteEnCombobox(ByVal cmb As ComboBox) As Boolean
        '    Dim resultado As Boolean = False
        '    For Each x As DictionaryEntry In cmb.Items
        '        If x.Value = cmb.Text Then
        '            resultado = True
        '        End If
        '    Next
        '    Return resultado
        'End Function
    End Function

    Public Function Formatear_Fecha(ByVal Fecha As Date) As String
        Dim Fecha_Formateada As String
        Fecha_Formateada = Fecha.Day & "/" & Fecha.Month & "/" & Fecha.Year
        Return Fecha_Formateada
    End Function

    'Funcion para saber si el programa esta registro(licencia) o no en la maquina que se utiliza
    Public Function Validar_Programa_Activado() As Boolean
        Dim Valida As Boolean = False
        Dim regVersion As Microsoft.Win32.RegistryKey
        Dim keyValue As String
        keyValue = "Software\\Microsoft\\Ntsc"
        regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyValue, False)
        Dim intVersion As String = ""
        If (Not regVersion Is Nothing) Then
            intVersion = regVersion.GetValue("Commands32Bit", 0)
            regVersion.Close()
        End If
        If intVersion = "m42bnk86cxkaa8bbc432c03njp4xn" Then
            Valida = True
        Else
            Valida = False
        End If
        Return Valida
    End Function
End Class
