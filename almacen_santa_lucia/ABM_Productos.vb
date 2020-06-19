Public Class ABM_Productos
    Dim Accion As Char
    Dim ID_Producto As Integer

    Private Sub ABM_Productos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ABM_Productos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub ABM_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Accion = Accion_Usuario
        Dim fun As New Funciones
        ID_Producto = Pasa_ID_Producto
        Mostrar_Categorias()
        Select Case Accion
            Case "A"
                btnAceptar.Text = "Agregar"
                Me.Text = "Agregar Producto"
                chkActivo.Visible = False
            Case "B"
                btnAceptar.Text = "Eliminar"
                Me.Text = "Eliminar Producto"
                fun.Bloquear_Controles_Formulario_Eliminacion(Me)
                chkActivo.Visible = True
                Buscar_Datos()
            Case "M"
                btnAceptar.Text = "Modificar"
                Me.Text = "Modificar Producto"
                chkActivo.Visible = True
                Buscar_Datos()
        End Select
    End Sub

    Protected Sub Limpiar_Datos()
        txtDescripcion.Text = ""
        txtCodBarras.Text = ""
        txtPrecio.Text = ""
    End Sub

    Private Sub Mostrar_Categorias()
        Dim Categoria As New Categorias
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Categoria.Llenar_ComboBox(cmbCategorias)
        BD.Desconectar()
    End Sub

    Protected Sub Buscar_Datos()
        Dim Producto As New Productos
        Producto.SETID_Producto(ID_Producto)
        Dim Datos = Producto.Buscar_Datos_Producto
        For Each row In Datos.Rows
            txtDescripcion.Text = row("descripcion")
            txtCodBarras.Text = row("codigo_barras")
            cmbCategorias.SelectedValue = row("id_categoria")
            txtPrecio.Text = row("precio")
            If row("activo") = "S" Then
                chkActivo.Checked = True
            Else
                chkActivo.Checked = False
            End If
        Next
    End Sub

    Protected Function Validar_Datos() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorDescripcion.Clear()
        ErrorCodigoBarras.Clear()
        ErrorCategoria.Clear()
        ErrorPrecio.Clear()
        If txtDescripcion.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorDescripcion.SetError(txtDescripcion, "Debe ingresar una descripcion")
        End If
        If txtCodBarras.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorCodigoBarras.SetError(txtCodBarras, "Debe ingresar un codigo de barras")
        End If
        If cmbCategorias.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorCategoria.SetError(cmbCategorias, "Debe seleccionar una categoria")
        Else
            Dim fun As New Funciones
            If fun.Chequear_Existencia_Elemento_En_Combo_Box_Data_Source(cmbCategorias) = False Then
                Cant_Errores = Cant_Errores + 1
                ErrorCategoria.SetError(cmbCategorias, "Elemento no valido")
            End If
        End If
        If txtPrecio.Text = Nothing Then
            Cant_Errores = Cant_Errores + 1
            ErrorPrecio.SetError(txtPrecio, "Debe ingresar un valor de precio")
        Else
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtPrecio.Text) = False Then
                Cant_Errores = Cant_Errores + 1
                ErrorPrecio.SetError(txtPrecio, "Debe ingresar un valor numerico")
            End If
        End If
        Return Cant_Errores
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar_Datos() = 0 Then
            Dim Producto As New Productos
            Producto.SETDescripcion(txtDescripcion.Text)
            Producto.SETCodigo_Barras(txtCodBarras.Text)
            Producto.SETID_Categoria(cmbCategorias.SelectedValue)
            Producto.SETPrecio(txtPrecio.Text)
            If Accion = "A" Then
                Producto.SETActivo("S")
            Else
                If chkActivo.Checked = True Then
                    Producto.SETActivo("S")
                Else
                    Producto.SETActivo("N")
                End If
            End If
            Dim Mensaje As String = ""
            Select Case Accion
                Case "A"
                    Mensaje = Producto.Agregar_Producto()
                    Pasa_ID_Producto = Producto.GETID_Producto
                    If Mensaje = "" Then
                        MessageBox.Show("Producto agregado", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Limpiar_Datos()
                    End If
                Case "B"
                    Producto.SETID_Producto(ID_Producto)
                    If MessageBox.Show("¿Está seguro eliminar el producto " & txtDescripcion.Text & "?", Nombre_Proyecto, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        Mensaje = Producto.Eliminar_Producto()
                        If Mensaje = "" Then
                            MessageBox.Show("Producto eliinado", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                Case "M"
                    Producto.SETID_Producto(ID_Producto)
                    Mensaje = Producto.Modificar_Producto()
                    If Mensaje = "" Then
                        MessageBox.Show("Producto modificado", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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

    Private Sub txtPrecio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecio.Leave
        ErrorPrecio.Clear()
        If txtPrecio.Text <> Nothing Then
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtPrecio.Text) = False Then
                ErrorPrecio.SetError(txtPrecio, "Debe ingresar un valor numerico")
                txtPrecio.Focus()
            Else
                txtPrecio.Text = fun.Formatear_Decimales(txtPrecio.Text)
            End If
        End If
    End Sub
End Class