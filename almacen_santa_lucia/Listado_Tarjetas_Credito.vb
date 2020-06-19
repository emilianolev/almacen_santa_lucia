Public Class Listado_Tarjetas_Credito

    Private Sub Listado_Tarjetas_Credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Listado_Tarjetas_Credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            dgvTarjetas.Focus()
        End If
    End Sub

    Private Sub Listado_Tarjetas_Credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Focus()
        Busqueda_Tarjetas()
    End Sub

    Private Sub Busqueda_Tarjetas()
        Dim Condicion As String = ""
        If txtDescripcion.Text <> Nothing Then
            Condicion = " AND empresa LIKE '%" & txtDescripcion.Text & "%' "
        End If
        Dim Tarjetas As New Tarjetas_Credito
        dgvTarjetas.DataSource = Tarjetas.Listado_Tarjetas_Credito(Condicion)
        dgvTarjetas.Columns(0).Width = 50
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Accion_Usuario = "A"
        ABM_Tarjetas_Credito.ShowDialog()
        Busqueda_Tarjetas()
        Dim fun As New Funciones
        fun.Seleccionar_Dato_Grilla(dgvTarjetas, Pasa_ID_Tarjeta_Credito, 0)
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If dgvTarjetas.RowCount > 0 Then
            Pasa_ID_Tarjeta_Credito = dgvTarjetas.CurrentRow.Cells(0).Value
            Accion_Usuario = "M"
            ABM_Tarjetas_Credito.ShowDialog()
            Busqueda_Tarjetas()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvTarjetas, Pasa_ID_Tarjeta_Credito, 0)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If dgvTarjetas.RowCount > 0 Then
            Pasa_ID_Tarjeta_Credito = dgvTarjetas.CurrentRow.Cells(0).Value
            Accion_Usuario = "B"
            ABM_Tarjetas_Credito.ShowDialog()
            Busqueda_Tarjetas()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvTarjetas, Pasa_ID_Tarjeta_Credito, 0)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub Listado_Tarjetas_Credito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvTarjetas.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        lblDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        txtDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        lblDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        txtDescripcion.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

        btnAgregar.Location = New Point(dgvTarjetas.Location.X + dgvTarjetas.Width + 5, btnAgregar.Location.Y)
        btnModificar.Location = New Point(dgvTarjetas.Location.X + dgvTarjetas.Width + 5, btnModificar.Location.Y)
        btnEliminar.Location = New Point(dgvTarjetas.Location.X + dgvTarjetas.Width + 5, btnEliminar.Location.Y)
        btnSalir.Location = New Point(dgvTarjetas.Location.X + dgvTarjetas.Width + 5, dgvTarjetas.Location.Y + dgvTarjetas.Height - btnSalir.Height)
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        Busqueda_Tarjetas()
    End Sub
End Class