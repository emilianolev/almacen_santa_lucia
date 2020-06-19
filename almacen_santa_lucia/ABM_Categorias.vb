Public Class ABM_Categorias
    Dim Accion As Char
    Dim ID_Categoria As Integer

    Private Sub ABM_Categorias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ABM_Categorias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub ABM_Categorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Accion = Accion_Usuario
        Dim fun As New Funciones
        ID_Categoria = Pasa_ID_Categoria
        cmbSigno.SelectedIndex = 0
        Select Case Accion
            Case "A"
                btnAceptar.Text = "Agregar"
                Me.Text = "Agregar Categoria"
            Case "B"
                btnAceptar.Text = "Eliminar"
                Me.Text = "Eliminar Categoria"
                Buscar_Datos()
                fun.Bloquear_Controles_Formulario_Eliminacion(Me)
                chkModificarPreciosProductos.Visible = True
                cmbSigno.Visible = True
                txtPorntajece.Visible = True
                Label1.Visible = True
            Case "M"
                btnAceptar.Text = "Modificar"
                Me.Text = "Modificar Categoria"
                Buscar_Datos()
                chkModificarPreciosProductos.Visible = True
                cmbSigno.Visible = True
                txtPorntajece.Visible = True
                Label1.Visible = True
        End Select
    End Sub

    Protected Sub Buscar_Datos()
        Dim Categoria As New Categorias
        Categoria.SETID_Categoria(ID_Categoria)
        Dim Datos = Categoria.Buscar_Datos_Categoria
        For Each row In Datos.Rows
            txtDescripcion.Text = row("descripcion")
        Next
    End Sub

    Protected Sub Limpiar_Datos()
        txtDescripcion.Text = ""
    End Sub

    Protected Function Validar_Datos() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorDescripcion.Clear()
        ErrorPorcentaje.Clear()
        If txtDescripcion.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorDescripcion.SetError(txtDescripcion, "Debe ingresar una descripcion")
        End If
        If Accion <> "A" Then
            If chkModificarPreciosProductos.Checked = True Then
                If txtPorntajece.Text = Nothing Then
                    Cant_Errores = Cant_Errores + 1
                    ErrorPorcentaje.SetError(txtPorntajece, "Debe ingresar un valor de porcentaje")
                Else
                    Dim fun As New Funciones
                    If fun.Valida_Decimal(txtPorntajece.Text) = False Then
                        Cant_Errores = Cant_Errores + 1
                        ErrorPorcentaje.SetError(txtPorntajece, "Debe ingresar un valor numerico")
                    End If
                End If
            End If
        End If
        Return Cant_Errores
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar_Datos() = 0 Then
            Dim Categoria As New Categorias
            Categoria.SETdescripcion(txtDescripcion.Text)
            Dim Mensaje As String = ""
            Select Case Accion
                Case "A"
                    Mensaje = Categoria.Agregar_Categoria()
                    Pasa_ID_Categoria = Categoria.GETID_Categoria
                    If Mensaje = "" Then
                        MessageBox.Show("Categoria agregada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Limpiar_Datos()
                    End If
                Case "B"
                    Categoria.SETID_Categoria(ID_Categoria)
                    If MessageBox.Show("¿Está seguro eliminar la categoria " & txtDescripcion.Text & "?", Nombre_Proyecto, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        Mensaje = Categoria.Eliminar_Categoria()
                        If Mensaje = "" Then
                            MessageBox.Show("Categoria eliminada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                Case "M"
                        Categoria.SETID_Categoria(ID_Categoria)
                        Mensaje = Categoria.Modificar_Categoria()
                        If chkModificarPreciosProductos.Checked = True Then
                            If cmbSigno.Text = "+" Then
                            Mensaje = Mensaje & Categoria.Modificar_Precios_productos_Categorias(txtPorntajece.Text, True)
                            If Mensaje = "" Then
                                MessageBox.Show("Categoria modificada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        Else
                            Mensaje = Mensaje & Categoria.Modificar_Precios_productos_Categorias(txtPorntajece.Text, False)
                            If Mensaje = "" Then
                                MessageBox.Show("Categoria modificada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
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

    Private Sub txtPorntajece_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorntajece.Leave
        ErrorPorcentaje.Clear()
        If txtPorntajece.Text <> Nothing Then
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtPorntajece.Text) = False Then
                ErrorPorcentaje.SetError(txtPorntajece, "Debe ingresar un valor numerico")
                txtPorntajece.Focus()
            Else
                txtPorntajece.Text = fun.Formatear_Decimales(txtPorntajece.Text)
            End If
        End If
    End Sub

    Private Sub chkModificarPreciosProductos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModificarPreciosProductos.CheckedChanged
        If chkModificarPreciosProductos.Checked = True Then
            cmbSigno.Enabled = True
            txtPorntajece.Enabled = True
        Else
            cmbSigno.Enabled = False
            txtPorntajece.Enabled = False
        End If
    End Sub
End Class