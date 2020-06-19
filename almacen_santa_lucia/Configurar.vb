Imports System
Imports System.IO
Imports System.Collections

Public Class Configurar

    Private Sub Configurar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Configurar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub Configurar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Parametro As New Parametros
        Parametro.SETIDParametro("ruta_mysql")
        txtRutaMYSQL.Text = Parametro.GETValor_Parametro
        Parametro.SETIDParametro("carpeta_backup_mysql")
        txtCarpetaBackUp.Text = Parametro.GETValor_Parametro
    End Sub

    Private Sub btnRutaMYSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRutaMYSQL.Click
        txtRutaMYSQL.Text = "C:\wamp\bin\mysql\mysql5.5.24\bin\"
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            ' Configuración del FolderBrowserDialog  
            With fbdNavegador
                .Reset() ' resetea  
                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  
                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  
                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then
                    txtCarpetaBackUp.Text = fbdNavegador.SelectedPath
                    'Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)
                    'nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)
                    'MsgBox("Total de archivos: " & CStr(nFiles.Count), _
                    '                        MsgBoxStyle.Information)
                End If
                .Dispose()
            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Parametro As New Parametros
        Dim Mensaje As String = ""
        Parametro.SETIDParametro("ruta_mysql")
        Parametro.SETValorParametro(txtRutaMYSQL.Text)
        Mensaje = Parametro.Actualizar_Valor_Parametro

        Parametro.SETIDParametro("carpeta_backup_mysql")
        Parametro.SETValorParametro(txtCarpetaBackUp.Text)
        Mensaje = Mensaje & Parametro.Actualizar_Valor_Parametro
        If Mensaje = "" Then
            MessageBox.Show("Parametros actualizados", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim Fun As New Funciones
            Fun.Grabo_Archivo_Log(Mensaje, "")
            MessageBox.Show(Mensaje, Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class