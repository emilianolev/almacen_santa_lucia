Public Class Listado_Productos

    Private Sub Listado_Categorias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Listado_Categorias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Insert Then
            btnAgregar_Click(sender, e)
        End If
        If e.KeyCode = Keys.F5 Then
            btnModificar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Delete Then
            btnEliminar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If cmbEstado.Focused = False And cmbCategorias.Focused = False Then
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                dgvProductos.Focus()
            End If
        End If
    End Sub

    Protected Function Validar_Datos() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorCategoria.Clear()
        If chkCategorias.Checked = True Then
            If cmbCategorias.Text <> Nothing Then
                Dim fun As New Funciones
                If fun.Chequear_Existencia_Elemento_En_Combo_Box_Data_Source(cmbCategorias) = False Then
                    Cant_Errores = Cant_Errores + 1
                    ErrorCategoria.SetError(cmbCategorias, "Elemento no valido")
                End If
            Else
                Cant_Errores = Cant_Errores + 1
                ErrorCategoria.SetError(cmbCategorias, "Debe seleccionar una categoria")
            End If
        End If
        Return Cant_Errores
    End Function

    Private Sub Listado_Categorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEstado.SelectedIndex = 0
        txtDescripcion.Focus()
        cmbCategorias.SelectedValue = 0
        Mostrar_Categorias()
        Busqueda_Productos()
    End Sub

    Private Sub Busqueda_Productos()
        If Validar_Datos() = 0 Then
            Dim Condicion As String = ""
            If txtDescripcion.Text <> Nothing Then
                Condicion = " AND productos.descripcion LIKE '%" & txtDescripcion.Text & "%' "
            End If
            If chkCategorias.Checked = True Then
                If cmbCategorias.SelectedValue <> Nothing Then
                    Condicion = Condicion & " AND productos.id_categoria=" & cmbCategorias.SelectedValue
                End If
            End If
            Select Case cmbEstado.Text
                Case "Activo"
                    Condicion = Condicion & " and productos.activo='S'"
                Case "No activo"
                    Condicion = Condicion & " and productos.activo='N'"
            End Select
            Dim Producto As New Productos
            dgvProductos.DataSource = Producto.Listado_Productos(Condicion)
            If dgvProductos.Rows.Count > 0 Then
                dgvProductos.Columns(0).Width = 50
            End If
        End If
    End Sub

    Private Sub Mostrar_Categorias()
        Dim Categoria As New Categorias
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Categoria.Llenar_ComboBox(cmbCategorias)
        BD.Desconectar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Accion_Usuario = "A"
        ABM_Productos.ShowDialog()
        Busqueda_Productos()
        Dim fun As New Funciones
        fun.Seleccionar_Dato_Grilla(dgvProductos, Pasa_ID_Producto, 0)
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If dgvProductos.RowCount > 0 Then
            Pasa_ID_Producto = dgvProductos.CurrentRow.Cells(0).Value
            Accion_Usuario = "M"
            ABM_Productos.ShowDialog()
            Busqueda_Productos()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvProductos, Pasa_ID_Producto, 0)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If dgvProductos.RowCount > 0 Then
            Pasa_ID_Producto = dgvProductos.CurrentRow.Cells(0).Value
            Accion_Usuario = "B"
            ABM_Productos.ShowDialog()
            Busqueda_Productos()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvProductos, Pasa_ID_Producto, 0)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub Listado_Productos_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvProductos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        lblDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        txtDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        lblDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        txtDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        chkCategorias.Location = New Point(lblDescripcion.Location.X, lblDescripcion.Location.Y + lblDescripcion.Height + 10)
        cmbCategorias.Location = New Point(chkCategorias.Location.X + chkCategorias.Width + 10, txtDescripcion.Location.Y + txtDescripcion.Height + 10)

        lblEstado.Location = New Point(cmbCategorias.Location.X + cmbCategorias.Width + 10, cmbCategorias.Location.Y)
        cmbEstado.Location = New Point(lblEstado.Location.X + lblEstado.Width + 10, lblEstado.Location.Y)

        chkCategorias.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        cmbCategorias.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        btnAgregar.Location = New Point(dgvProductos.Location.X + dgvProductos.Width + 5, btnAgregar.Location.Y)
        btnModificar.Location = New Point(dgvProductos.Location.X + dgvProductos.Width + 5, btnModificar.Location.Y)
        btnEliminar.Location = New Point(dgvProductos.Location.X + dgvProductos.Width + 5, btnEliminar.Location.Y)
        btnSalir.Location = New Point(dgvProductos.Location.X + dgvProductos.Width + 5, dgvProductos.Location.Y + dgvProductos.Height - btnSalir.Height)

        btnBuscar.Location = New Point(cmbEstado.Location.X + cmbEstado.Width + 10, cmbEstado.Location.Y)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Busqueda_Productos()
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        Busqueda_Productos()
    End Sub

    Private Sub chkCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCategorias.CheckedChanged
        If chkCategorias.Checked = True Then
            cmbCategorias.Enabled = True
        Else
            cmbCategorias.Enabled = False
        End If
    End Sub
End Class