Imports System
Imports System.IO
Imports System.Collections

Public Class Exportar_Base_Datos

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
                    txtCarpeta.Text = fbdNavegador.SelectedPath
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

    Private Sub Exportar_Base_Datos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Exportar_Base_Datos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub Exportar_Base_Datos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Parametro As New Parametros
        Parametro.SETIDParametro("carpeta_backup_mysql")
        txtCarpeta.Text = Parametro.GETValor_Parametro
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ErrorCarpeta.Clear()
        If txtCarpeta.Text = "" Then
            ErrorCarpeta.SetError(txtCarpeta, "Debe seleccionar una carpeta")
        Else
            If Directory.Exists(txtCarpeta.Text) Then
                Crear_BackUp()
            Else
                MessageBox.Show("El directorio seleccionado no existe", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Protected Sub Crear_BackUp()
        Try
            Dim Carpeta As String = ""
            Dim Archivo As String = "BackUp_BDO_" & Now.Date.Year.ToString & "_" & Now.Date.Month.ToString & "_" & Now.Date.Day.ToString & "_" & Now.TimeOfDay.Hours.ToString & "_" & Now.TimeOfDay.Minutes.ToString & "_" & Now.TimeOfDay.Seconds.ToString & ".sql"
            Carpeta = txtCarpeta.Text & "\" & Archivo
            Dim Ruta_MYSQL As String = ""
            Dim Parametro As New Parametros
            Parametro.SETIDParametro("ruta_mysql")
            Ruta_MYSQL = Parametro.GETValor_Parametro
            Process.Start(Ruta_MYSQL & "mysqldump.exe", " --host=localhost --user='root'   --password=   almacen_santa_lucia  -r " & Carpeta)
        Catch ex As Exception
            Dim fun As New Funciones
            fun.Grabo_Archivo_Log(ex.Message, "procedimiento Crear_BackUp en BDO_Exportar")
            MessageBox.Show(ex.Message, Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class