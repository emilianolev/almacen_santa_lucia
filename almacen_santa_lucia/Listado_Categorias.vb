Public Class Listado_Categorias

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
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            dgvCategorias.Focus()
        End If
    End Sub

    Private Sub Listado_Categorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Focus()
        Busqueda_Capacitaciones()
    End Sub

    Private Sub Busqueda_Capacitaciones()
        Dim Condicion As String = ""
        If txtDescripcion.Text <> Nothing Then
            Condicion = " AND descripcion LIKE '%" & txtDescripcion.Text & "%' "
        End If
        Dim Categoria As New Categorias
        dgvCategorias.DataSource = Categoria.Listado_Categorias(Condicion)
        dgvCategorias.Columns(0).Width = 50
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Accion_Usuario = "A"
        ABM_Categorias.ShowDialog()
        Busqueda_Capacitaciones()
        Dim fun As New Funciones
        fun.Seleccionar_Dato_Grilla(dgvCategorias, Pasa_ID_Categoria, 0)
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If dgvCategorias.RowCount > 0 Then
            Pasa_ID_Categoria = dgvCategorias.CurrentRow.Cells(0).Value
            Accion_Usuario = "M"
            ABM_Categorias.ShowDialog()
            Busqueda_Capacitaciones()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvCategorias, Pasa_ID_Categoria, 0)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If dgvCategorias.RowCount > 0 Then
            Pasa_ID_Categoria = dgvCategorias.CurrentRow.Cells(0).Value
            Accion_Usuario = "B"
            ABM_Categorias.ShowDialog()
            Busqueda_Capacitaciones()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvCategorias, Pasa_ID_Categoria, 0)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        Busqueda_Capacitaciones()
    End Sub

    Private Sub Listado_Categorias_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvCategorias.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        lblDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        txtDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        lblDescripcion.Location = New Point(dgvCategorias.Location.X, dgvCategorias.Location.Y + dgvCategorias.Height + 10)
        txtDescripcion.Location = New Point(lblDescripcion.Location.X + lblDescripcion.Width, lblDescripcion.Location.Y)

        lblDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        txtDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        btnAgregar.Location = New Point(dgvCategorias.Location.X + dgvCategorias.Width + 5, btnAgregar.Location.Y)
        btnModificar.Location = New Point(dgvCategorias.Location.X + dgvCategorias.Width + 5, btnModificar.Location.Y)
        btnEliminar.Location = New Point(dgvCategorias.Location.X + dgvCategorias.Width + 5, btnEliminar.Location.Y)
        btnSalir.Location = New Point(dgvCategorias.Location.X + dgvCategorias.Width + 5, dgvCategorias.Location.Y + dgvCategorias.Height - btnSalir.Height)
    End Sub
End Class