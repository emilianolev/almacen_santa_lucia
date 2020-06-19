Public Class ABM_Tarjetas_Credito
    Dim Accion As Char
    Dim ID_Tarjeta_Credito As Integer

    Private Sub ABM_Tarjetas_Credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ABM_Tarjetas_Credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub ABM_Tarjetas_Credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Accion = Accion_Usuario
        Dim fun As New Funciones
        ID_Tarjeta_Credito = Pasa_ID_Tarjeta_Credito
        Select Case Accion
            Case "A"
                btnAceptar.Text = "Agregar"
                Me.Text = "Agregar Tarjeta Credito"
                chkActivo.Visible = False
            Case "B"
                btnAceptar.Text = "Eliminar"
                Me.Text = "Eliminar Tarjeta Credito"
                fun.Bloquear_Controles_Formulario_Eliminacion(Me)
                chkActivo.Visible = True
                Buscar_Datos()
            Case "M"
                btnAceptar.Text = "Modificar"
                Me.Text = "Modificar Tarjeta Credito"
                chkActivo.Visible = True
                Buscar_Datos()
        End Select
    End Sub

    Protected Sub Limpiar_Datos()
        txtEmpresa.Text = ""
        txtRecargo.Text = "0"
    End Sub

    Protected Sub Buscar_Datos()
        Dim Tarjeta_Credito As New Tarjetas_Credito
        Tarjeta_Credito.SETIDTarjetaCredito(ID_Tarjeta_Credito)
        Dim Datos = Tarjeta_Credito.Buscar_Datos_Tarjeta_Credito
        For Each row In Datos.Rows
            txtEmpresa.Text = row("empresa")
            txtRecargo.Text = row("recargo")
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
        ErrorRecargo.Clear()
        If txtEmpresa.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorEmpresa.SetError(txtEmpresa, "Debe ingresar un nombre")
        End If
        If txtRecargo.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorRecargo.SetError(txtRecargo, "Debe ingresar un valor de precio")
        Else
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtRecargo.Text, True) = False Then
                Cant_Errores = Cant_Errores + 1
                ErrorRecargo.SetError(txtRecargo, "Debe ingresar un valor numerico o mayor a 0")
            End If
        End If
        Return Cant_Errores
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar_Datos() = 0 Then
            Dim Tarjeta_Credito As New Tarjetas_Credito
            Tarjeta_Credito.SETEmpresa(txtEmpresa.Text)
            Tarjeta_Credito.SETRecargo(txtRecargo.Text)
            If Accion = "A" Then
                Tarjeta_Credito.SETActivo("S")
            Else
                If chkActivo.Checked = True Then
                    Tarjeta_Credito.SETActivo("S")
                Else
                    Tarjeta_Credito.SETActivo("N")
                End If
            End If
            Dim Mensaje As String = ""
            Select Case Accion
                Case "A"
                    Mensaje = Tarjeta_Credito.Agregar_Tarjeta_Credito
                    Pasa_ID_Producto = Tarjeta_Credito.GETID_Tarjeta_Credito
                    If Mensaje = "" Then
                        MessageBox.Show("Tarjeta de credito agregada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Limpiar_Datos()
                    End If
                Case "B"
                    Tarjeta_Credito.SETIDTarjetaCredito(ID_Tarjeta_Credito)
                    If MessageBox.Show("¿Está seguro eliminar la tarjeta de credito " & txtEmpresa.Text & "?", Nombre_Proyecto, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        Mensaje = Tarjeta_Credito.Eliminar_Tarjeta_Credito()
                        If Mensaje = "" Then
                            MessageBox.Show("Tarjeta de credito eliminada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                Case "M"
                    Tarjeta_Credito.SETIDTarjetaCredito(ID_Tarjeta_Credito)
                    Mensaje = Tarjeta_Credito.Modificar_Tarjeta_Credito()
                    If Mensaje = "" Then
                        MessageBox.Show("Tarjeta de credito modificada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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

    Private Sub txtRecargo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecargo.Leave
        ErrorRecargo.Clear()
        If txtRecargo.Text <> Nothing Then
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtRecargo.Text, True) = False Then
                ErrorRecargo.SetError(txtRecargo, "Debe ingresar un valor numerico o mayor a 0")
                txtRecargo.Focus()
            Else
                txtRecargo.Text = fun.Formatear_Decimales(txtRecargo.Text)
            End If
        End If
    End Sub
End Class