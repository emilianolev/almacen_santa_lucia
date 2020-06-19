Public Class ABM_Tarjetas_Debito
    Dim Accion As Char
    Dim ID_Tarjeta_Debito As Integer

    Private Sub ABM_Tarjetas_Debito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ABM_Tarjetas_Debito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub ABM_Tarjetas_Debito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Accion = Accion_Usuario
        Dim fun As New Funciones
        ID_Tarjeta_Debito = Pasa_ID_Tarjeta_Debito
        Select Case Accion
            Case "A"
                btnAceptar.Text = "Agregar"
                Me.Text = "Agregar Tarjeta Debito"
                chkActivo.Visible = False
            Case "B"
                btnAceptar.Text = "Eliminar"
                Me.Text = "Eliminar Tarjeta Debito"
                fun.Bloquear_Controles_Formulario_Eliminacion(Me)
                chkActivo.Visible = True
                Buscar_Datos()
            Case "M"
                btnAceptar.Text = "Modificar"
                Me.Text = "Modificar Tarjeta Debito"
                chkActivo.Visible = True
                Buscar_Datos()
        End Select
    End Sub

    Protected Sub Limpiar_Datos()
        txtEmpresa.Text = ""
    End Sub

    Protected Sub Buscar_Datos()
        Dim Tarjeta_Debito As New Tarjetas_Debito
        Tarjeta_Debito.SETIDTarjetaDebito(ID_Tarjeta_Debito)
        Dim Datos = Tarjeta_Debito.Buscar_Datos_Tarjeta_Debito
        For Each row In Datos.Rows
            txtEmpresa.Text = row("empresa")
            If row("activo") = "S" Then
                chkActivo.Checked = True
            Else
                chkActivo.Checked = False
            End If
        Next
    End Sub

    Protected Function Validar_Datos() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorEmpresa.Clear()
        If txtEmpresa.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorEmpresa.SetError(txtEmpresa, "Debe ingresar un nombre")
        End If
        Return Cant_Errores
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar_Datos() = 0 Then
            Dim Tarjeta_Debito As New Tarjetas_Debito
            Tarjeta_Debito.SETEmpresa(txtEmpresa.Text)
            If Accion = "A" Then
                Tarjeta_Debito.SETActivo("S")
            Else
                If chkActivo.Checked = True Then
                    Tarjeta_Debito.SETActivo("S")
                Else
                    Tarjeta_Debito.SETActivo("N")
                End If
            End If
            Dim Mensaje As String = ""
            Select Case Accion
                Case "A"
                    Mensaje = Tarjeta_Debito.Agregar_Tarjeta_Debito
                    Pasa_ID_Producto = Tarjeta_Debito.GETID_Tarjeta_Debito
                    If Mensaje = "" Then
                        MessageBox.Show("Tarjeta de debito agregada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Limpiar_Datos()
                    End If
                Case "B"
                    Tarjeta_Debito.SETIDTarjetaDebito(ID_Tarjeta_Debito)
                    If MessageBox.Show("¿Está seguro eliminar la tarjeta de debito " & txtEmpresa.Text & "?", Nombre_Proyecto, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        Mensaje = Tarjeta_Debito.Eliminar_Tarjeta_Debito()
                        If Mensaje = "" Then
                            MessageBox.Show("Tarjeta de debito eliminada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                Case "M"
                    Tarjeta_Debito.SETIDTarjetaDebito(ID_Tarjeta_Debito)
                    Mensaje = Tarjeta_Debito.Modificar_Tarjeta_Debito()
                    If Mensaje = "" Then
                        MessageBox.Show("Tarjeta de debito modificada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
            End Select
            If Mensaje <> "" Then
                Dim Fun As New Funciones
                Fun.Grabo_Archivo_Log(Mensaje, "Letra Accion " & Accion)
                MessageBox.Show(Mensaje, Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                If Accion <> "A" Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class