Public Class ABM_Ventas
    Dim Accion As Char
    Dim ID_Venta As Integer

    Private Sub Agregar_Capacitacion_Empleados_Empresa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ABM_Ventas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar_Click(sender, e)
        End If
    End Sub

    Private Sub ABM_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Accion = Accion_Usuario
        Dim fun As New Funciones
        ID_Venta = Pasa_ID_Venta
        Limpiar_Datos()
        Select Case Accion
            Case "A"
                btnAceptar.Text = "Agregar"
                Me.Text = "Agregar Venta"
                btnImprimir.Visible = False
                chkImprimir.Visible = True
            Case "B"
                btnAceptar.Text = "Eliminar"
                Me.Text = "Eliminar Venta"
                Buscar_Datos()
                fun.Bloquear_Controles_Formulario_Eliminacion(Me)
                btnImprimir.Visible = True
                chkImprimir.Visible = False
            Case "M"
                btnAceptar.Text = "Modificar"
                Me.Text = "Modificar Venta"
                Buscar_Datos()
                btnImprimir.Visible = True
                chkImprimir.Visible = False
        End Select
        chkImprimir.Checked = True
        'chkImprimir.Visible = True
        'btnEliminarDetalle.Location = New Point(692, 93)
    End Sub

    Protected Sub Limpiar_Datos()
        rptEfectivo.Checked = True
        Dim sender As System.Object
        Dim e As System.EventArgs
        rptEfectivo_CheckedChanged(sender, e)
        txtDNI.Text = ""
        txtNombre.Text = ""
        txtNumeroTarjeta.Text = ""
        txtCodBarras.Text = ""
        txtCantidadUnidades.Text = ""
        txtCantidad.Text = ""
        txtPrecio.Text = ""
        dgvProductos.DataSource = Nothing
        dgvProductos.Columns.Clear()

        dgvProductos.Rows.Clear()
        Dim dtbTabla As New System.Data.DataTable

        dtbTabla.Columns.Add("Codigo")
        dtbTabla.Columns.Add("Producto")
        dtbTabla.Columns.Add("Cantidad")
        dtbTabla.Columns.Add("SubTotal")

        dgvProductos.DataSource = dtbTabla
        dgvProductos.Columns(1).Width = 200
    End Sub

    Protected Sub Buscar_Datos()
        Dim Venta As New Ventas
        Venta.SETID_Venta(ID_Venta)
        Dim Datos = Venta.Buscar_Datos_Venta
        For Each row In Datos.Rows
            Dim sender As System.Object
            Dim e As System.EventArgs
            Select Case row("forma_pago")
                Case "e"
                    rptEfectivo.Checked = True
                    'rptEfectivo_CheckedChanged(sender, e)
                    'btnEliminarDetalle.Location = New Point(btnEliminarDetalle.Location.X, dgvProductos.Location.Y)
                Case "c"
                    rptCredito.Checked = True
                    'rptCredito_CheckedChanged(sender, e)
                    'btnEliminarDetalle.Location = New Point(btnEliminarDetalle.Location.X, dgvProductos.Location.Y)
                    cmbEmpresas.SelectedValue = row("id_tarjeta_credito")
                    If row("id_tarjeta_credito") IsNot DBNull.Value Then
                        cmbEmpresas.SelectedValue = row("id_tarjeta_credito")
                    End If
                    If row("dni") IsNot DBNull.Value Then
                        txtDNI.Text = row("dni")
                    End If
                    If row("nombre") IsNot DBNull.Value Then
                        txtNombre.Text = row("nombre")
                    End If
                    If row("numero_tarjeta") IsNot DBNull.Value Then
                        txtNumeroTarjeta.Text = row("numero_tarjeta")
                    End If
                Case "d"
                    rptDebito.Checked = True
                    'rptDebito_CheckedChanged(sender, e)
                    'btnEliminarDetalle.Location = New Point(btnEliminarDetalle.Location.X, dgvProductos.Location.Y)
                    If row("id_tarjeta_debito") IsNot DBNull.Value Then
                        cmbEmpresas.SelectedValue = row("id_tarjeta_debito")
                    End If
                    If row("dni") IsNot DBNull.Value Then
                        txtDNI.Text = row("dni")
                    End If
                    If row("nombre") IsNot DBNull.Value Then
                        txtNombre.Text = row("nombre")
                    End If
                    If row("numero_tarjeta") IsNot DBNull.Value Then
                        txtNumeroTarjeta.Text = row("numero_tarjeta")
                    End If
            End Select
            'Busco Detalles
            Dim Venta_Dettale As New Ventas_Detalles
            Venta_Dettale.SETID_Venta(ID_Venta)
            dgvProductos.DataSource = Venta_Dettale.Listado_Ventas_Detalles
            lblTotal.Text = row("precio")
            'For Each Fila As DataRow In Venta_Dettale.Listado_Ventas_Detalles.Rows
            '    Dim dt2 As New System.Data.DataTable
            '    dt2 = dgvProductos.DataSource

            '    Dim dtrFila As DataRow
            '    dtrFila = dt2.NewRow()
            '    dtrFila("Codigo") = row("id_producto")
            '    dtrFila("Producto") = row("descripcion")
            '    dtrFila("Cantidad") = Fila("cantidad")
            '    dtrFila("SubTotal") = row("subtotal")
            '    dt2.Rows.Add(dtrFila)
            'Next
        Next
    End Sub

    Protected Function Validar_Datos_Venta() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorCantidadUnidades.Clear()
        If txtCantidadUnidades.Text <> Nothing Then
            Dim fun As New Funciones
            If fun.Valida_Entero(txtCantidadUnidades.Text, True) = False Then
                Cant_Errores = Cant_Errores + 1
                ErrorCantidadUnidades.SetError(txtCantidadUnidades, "Valor incorrecto")
            End If
            'Else
            'Cant_Errores = Cant_Errores + 1
            'ErrorCantidadUnidades.SetError(txtCantidadUnidades, "Debe ingresar un valor")
        End If
        Return Cant_Errores
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If txtCodBarras.Text <> Nothing And Validar_Datos_Venta() = 0 Then
            Dim Producto As New Productos
            Producto.SETCodigo_Barras(txtCodBarras.Text)
            Dim Leer = Producto.Buscar_Datos_Producto("AND codigo_barras='" & txtCodBarras.Text & "' AND activo='S'")
            Dim ExisteProducto As Boolean = False
            For Each Row In Leer.Rows
                ExisteProducto = True
                Dim Articulo_Encontrado_Grilla As Boolean = False
                For i = 0 To dgvProductos.RowCount - 1
                    If Row("id_producto") = dgvProductos.Rows(i).Cells(0).Value Then
                        Articulo_Encontrado_Grilla = True
                    End If
                Next

                If Articulo_Encontrado_Grilla = True Then
                    'MessageBox.Show("El producto ya esta cargado modifique la cantidad si quiere ingresar mas unidades", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    'Busco el producto en la grilla y sumo la cantidad de unidades
                    For i = 0 To dgvProductos.RowCount - 1
                        If Row("id_producto") = dgvProductos.Rows(i).Cells(0).Value Then
                            
                            Dim Cant_Unidades As Integer = dgvProductos.Rows(i).Cells(2).Value


                            If txtCantidadUnidades.Text = "" Then
                                Cant_Unidades = Cant_Unidades + 1
                            Else
                                Cant_Unidades = Cant_Unidades + txtCantidadUnidades.Text
                            End If
                            dgvProductos.Rows(i).Cells(2).Value = Cant_Unidades
                            dgvProductos.Rows(i).Cells(3).Value = Row("precio") * Cant_Unidades
                            txtCantidadUnidades.Text = ""
                            Calcular_Total()
                        End If
                    Next
                Else
                    Dim dt2 As New System.Data.DataTable
                    dt2 = dgvProductos.DataSource

                    Dim dtrFila As DataRow
                    dtrFila = dt2.NewRow()
                    dtrFila("Codigo") = Row("id_producto")
                    dtrFila("Producto") = Row("descripcion")
                    Dim Cant_Unidades As Integer = 1
                    If txtCantidadUnidades.Text = "" Then
                        Cant_Unidades = 1
                    Else
                        Cant_Unidades = txtCantidadUnidades.Text
                    End If
                    dtrFila("Cantidad") = Cant_Unidades
                    dtrFila("SubTotal") = Row("precio") * Cant_Unidades
                    txtCantidadUnidades.Text = ""
                    dt2.Rows.Add(dtrFila)
                    Calcular_Total()
                End If
            Next
            If ExisteProducto = False Then
                MessageBox.Show("El producto no existe o no esta activo", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
            txtCodBarras.Text = ""
            'txtCantidadUnidades.Text = "1"
            txtCodBarras.Focus()
        Else
            MessageBox.Show("Debe ingresar un codigo de barras", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Protected Sub Calcular_Total()
        Try
            Dim Total As Decimal = 0
            For i = 0 To dgvProductos.Rows.Count - 1
                Total = Total + CDec(dgvProductos.Rows(i).Cells(3).Value)
            Next
            If rptCredito.Checked = True Or rptDebito.Checked = True Then
                If rptCredito.Checked = True Then
                    If cmbEmpresas.SelectedValue <> Nothing Then
                        Dim Tarjeta_Credito As New Tarjetas_Credito
                        Tarjeta_Credito.SETIDTarjetaCredito(cmbEmpresas.SelectedValue)
                        Dim Leer = Tarjeta_Credito.Buscar_Datos_Tarjeta_Credito
                        Dim Porcentaje As Decimal = 0
                        For Each Row In Leer.Rows
                            Porcentaje = Row("recargo")
                        Next
                        Dim Porcentaje_Calculado As Decimal
                        Porcentaje_Calculado = (Total * Porcentaje) / 100
                        Total = Total + Porcentaje_Calculado
                    End If
                End If
                If rptDebito.Checked = True Then
                    If cmbEmpresas.SelectedValue <> Nothing Then
                        'Dim Tarjeta_Debito As New Tarjetas_Debito
                        'Tarjeta_Debito.SETIDTarjetaDebito(cmbEmpresas.SelectedValue)
                        'Dim Leer = Tarjeta_Debito.Buscar_Datos_Tarjeta_Debito
                        'Dim Porcentaje As Decimal = 0
                        'For Each Row In Leer.Rows
                        '    Porcentaje = Row("recargo")
                        'Next
                        'Dim Porcentaje_Calculado As Decimal
                        'Porcentaje_Calculado = (Total * Porcentaje) / 100
                        'Total = Total + Porcentaje_Calculado
                    End If
                End If
            End If
            Dim fun As New Funciones
            lblTotal.Text = "$ " & fun.Formatear_Decimales(Total)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptEfectivo.CheckedChanged
        If rptEfectivo.Checked = True Then
            cmbEmpresas.DataSource = Nothing
            Calcular_Total()
            lblEmpresa.Visible = False
            cmbEmpresas.Visible = False
            grpDatosCliente.Visible = False
            dgvProductos.Location = New Point(14, 93)
            'btnEliminarDetalle.Location = New Point(692, 93)
            'dgvProductos.Height = 317
            dgvProductos.Height = 397
            btnEliminarDetalle.Location = New Point(btnEliminarDetalle.Location.X, dgvProductos.Location.Y)
        End If
    End Sub

    Private Sub rptCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptCredito.CheckedChanged
        If rptCredito.Checked = True Then
            lblEmpresa.Visible = True
            cmbEmpresas.Visible = True
            cmbEmpresas.DataSource = Nothing
            Dim Tarjeta_Credito As New Tarjetas_Credito
            Tarjeta_Credito.Llenar_ComboBox(cmbEmpresas)
            Calcular_Total()
            grpDatosCliente.Visible = True
            dgvProductos.Height = 317
            dgvProductos.Location = New Point(14, 173)
            'btnEliminarDetalle.Location = New Point(692, 173)
            btnEliminarDetalle.Location = New Point(btnEliminarDetalle.Location.X, dgvProductos.Location.Y)
            Ajustar_Localizacion_Componentes()
        End If
    End Sub

    Private Sub rptDebito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptDebito.CheckedChanged
        If rptDebito.Checked = True Then
            lblEmpresa.Visible = True
            cmbEmpresas.Visible = True
            cmbEmpresas.DataSource = Nothing
            Dim Tarjeta_Debito As New Tarjetas_Debito
            Tarjeta_Debito.Llenar_ComboBox(cmbEmpresas)
            Calcular_Total()
            grpDatosCliente.Visible = True
            dgvProductos.Height = 317
            dgvProductos.Location = New Point(14, 173)
            btnEliminarDetalle.Location = New Point(692, 173)
            Ajustar_Localizacion_Componentes()
            '692, 173
        End If
    End Sub

    Protected Sub Ajustar_Localizacion_Componentes()
        Label1.Location = New Point(Label1.Location.X, btnEliminarDetalle.Location.Y + btnEliminarDetalle.Height + 10)
        lblTotal.Location = New Point(lblTotal.Location.X, Label1.Location.Y)
        lblCantidad.Location = New Point(lblCantidad.Location.X, lblTotal.Location.Y + lblTotal.Height + 10)
        txtCantidad.Location = New Point(txtCantidad.Location.X, lblCantidad.Location.Y + lblCantidad.Height + 10)
        lblPrecio.Location = New Point(lblPrecio.Location.X, txtCantidad.Location.Y + txtCantidad.Height + 10)
        txtPrecio.Location = New Point(txtPrecio.Location.X, lblPrecio.Location.Y + lblPrecio.Height + 10)
        btnModificarCantidadPrecio.Location = New Point(btnModificarCantidadPrecio.Location.X, txtPrecio.Location.Y + txtPrecio.Height + 10)
    End Sub

    Private Sub btnEliminarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDetalle.Click
        If dgvProductos.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar el producto " & dgvProductos.CurrentRow.Cells(1).Value & " de la venta?", Nombre_Proyecto, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                dgvProductos.Rows.Remove(dgvProductos.CurrentRow)
                Calcular_Total()
            End If
        End If
    End Sub

    Protected Function Validar_DatosModificarDetalles() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorCantidad.Clear()
        ErrorPrecio.Clear()
        If txtCantidad.Text <> Nothing Then
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtCantidad.Text, True) = False Then
                Cant_Errores = Cant_Errores + 1
                ErrorCantidad.SetError(txtCantidad, "Valor incorrecto")
            End If
        Else
            Cant_Errores = Cant_Errores + 1
            ErrorCantidad.SetError(txtCantidad, "Debe ingresar un valor")
        End If
        If txtPrecio.Text <> Nothing Then
            Dim fun As New Funciones
            If fun.Valida_Decimal(txtPrecio.Text, True) = False Then
                Cant_Errores = Cant_Errores + 1
                ErrorCantidad.SetError(txtPrecio, "Valor incorrecto")
            End If
        Else
            Cant_Errores = Cant_Errores + 1
            ErrorCantidad.SetError(txtPrecio, "Debe ingresar un valor")
        End If
        Return Cant_Errores
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarCantidadPrecio.Click
        If dgvProductos.Rows.Count > 0 Then
            If Validar_DatosModificarDetalles() = 0 Then
                dgvProductos.CurrentRow.Cells(2).Value = txtCantidad.Text
                dgvProductos.CurrentRow.Cells(3).Value = txtPrecio.Text
                Calcular_Total()
            End If
        End If
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

    Protected Function Validar_Datos() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorEmpresa.Clear()
        ErrorDNI.Clear()
        ErrorNombre.Clear()
        ErrorNumeroTarjeta.Clear()
        ErrorGrilla.Clear()
        If rptCredito.Checked = True Or rptDebito.Checked = True Then
            If cmbEmpresas.Text = Nothing Then
                Cant_Errores = Cant_Errores + 1
                ErrorEmpresa.SetError(cmbEmpresas, "Debe seleccionar una opcion")
            Else
                Dim fun As New Funciones
                If fun.Chequear_Existencia_Elemento_En_Combo_Box_Data_Source(cmbEmpresas) = False Then
                    Cant_Errores = Cant_Errores + 1
                    ErrorEmpresa.SetError(cmbEmpresas, "Elemento no valido")
                End If
            End If
            If txtDNI.Text <> Nothing Then
                Dim fun As New Funciones
                If fun.Valida_Entero(txtDNI.Text) = False Then
                    Cant_Errores = Cant_Errores + 1
                    ErrorDNI.SetError(txtDNI, "Debe ingresar un valor numerico")
                End If
            Else
                Cant_Errores = Cant_Errores + 1
                ErrorDNI.SetError(txtDNI, "Debe ingresar un dni")
            End If
            If txtNombre.Text = Nothing Then
                Cant_Errores = Cant_Errores + 1
                ErrorNombre.SetError(txtNombre, "Debe ingresar un nombre")
            End If
            If txtNumeroTarjeta.Text = Nothing Then
                Cant_Errores = Cant_Errores + 1
                ErrorNumeroTarjeta.SetError(txtNumeroTarjeta, "Debe ingresar un numero de tarjeta")
            End If
        End If
        If dgvProductos.Rows.Count = 0 Then
            Cant_Errores = Cant_Errores + 1
            ErrorGrilla.SetError(dgvProductos, "No hay productos agregados")
        End If
        Return Cant_Errores
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar_Datos() = 0 Then
            Accion = Accion_Usuario
            Dim fun As New Funciones
            ID_Venta = Pasa_ID_Venta
            Dim Venta As New Ventas
            Dim Mensaje As String = ""
            Venta.SETFecha(Now.Date)
            Venta.SETPrecio(lblTotal.Text)
            If rptEfectivo.Checked = True Then
                Venta.SETForma_Pago("e")
                Venta.SETID_TarjetaCredito(0)
                Venta.SETID_TarjetaDebito(0)
            End If
            If rptCredito.Checked = True Then
                Venta.SETForma_Pago("c")
                Venta.SETID_TarjetaCredito(cmbEmpresas.SelectedValue)
                Venta.SETID_TarjetaDebito(0)
                Venta.SET_DNI(txtDNI.Text)
                Venta.SETNombre(txtNombre.Text)
                Venta.SETNumeroTarjeta(txtNumeroTarjeta.Text)
            End If
            If rptDebito.Checked = True Then
                Venta.SETForma_Pago("d")
                Venta.SETID_TarjetaCredito(0)
                Venta.SETID_TarjetaDebito(cmbEmpresas.SelectedValue)
                Venta.SET_DNI(txtDNI.Text)
                Venta.SETNombre(txtNombre.Text)
                Venta.SETNumeroTarjeta(txtNumeroTarjeta.Text)
            End If
            Select Case Accion
                Case "A"
                    Mensaje = Venta.Agregar_Venta
                    ID_Venta = Venta.GETID_Venta
                    For i = 0 To dgvProductos.Rows.Count - 1
                        Dim Venta_Detalle As New Ventas_Detalles
                        Venta_Detalle.SETID_Venta(ID_Venta)
                        Venta_Detalle.SETID_Producto(dgvProductos.Rows(i).Cells(0).Value)
                        Venta_Detalle.SETCantidad(dgvProductos.Rows(i).Cells(2).Value)
                        Venta_Detalle.SETSubTotal(dgvProductos.Rows(i).Cells(3).Value)
                        Mensaje = Mensaje & Venta_Detalle.Agregar_Venta_Detalle
                    Next
                    If Mensaje = "" Then
                        MessageBox.Show("Venta agregada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        If chkImprimir.Checked = True Then
                            Imprimir()
                        End If
                    End If
                Case "B"
                    Venta.SETID_Venta(ID_Venta)
                    If MessageBox.Show("¿Está seguro eliminar la venta?", Nombre_Proyecto, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        Mensaje = Venta.Eliminar_Venta
                        If Mensaje = "" Then
                            MessageBox.Show("Venta eliminada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                Case "M"
                    Venta.SETID_Venta(ID_Venta)
                    Mensaje = Venta.Modificar_Venta
                    Dim Venta_Detalle As New Ventas_Detalles
                    Venta_Detalle.SETID_Venta(ID_Venta)
                    Mensaje = Mensaje & Venta_Detalle.Eliminar_Ventas_Detalles
                    For i = 0 To dgvProductos.Rows.Count - 1
                        Venta_Detalle.SETID_Venta(ID_Venta)
                        Venta_Detalle.SETID_Producto(dgvProductos.Rows(i).Cells(0).Value)
                        Venta_Detalle.SETCantidad(dgvProductos.Rows(i).Cells(2).Value)
                        Venta_Detalle.SETSubTotal(dgvProductos.Rows(i).Cells(3).Value)
                        Mensaje = Mensaje & Venta_Detalle.Agregar_Venta_Detalle
                    Next
                    If Mensaje = "" Then
                        MessageBox.Show("Venta modificada", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
            End Select

            If Mensaje <> "" Then
                fun.Grabo_Archivo_Log(Mensaje, "Letra accion " & Accion)
                MessageBox.Show(Mensaje, Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                If Accion = "A" Then
                    Limpiar_Datos()
                Else
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub cmbEmpresas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresas.SelectedIndexChanged
        Calcular_Total()
    End Sub

    Private Sub cmbEmpresas_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresas.SelectedValueChanged
        Calcular_Total()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub ABM_Ventas_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvProductos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        btnEliminarDetalle.Location = New Point(dgvProductos.Location.X + dgvProductos.Width + 10, dgvProductos.Location.Y)

        Label1.Location = New Point(dgvProductos.Location.X + dgvProductos.Width + 10, btnEliminarDetalle.Location.Y + btnEliminarDetalle.Height + 10)
        lblTotal.Location = New Point(Label1.Location.X + Label1.Width + 10, Label1.Location.Y)

        lblCantidad.Location = New Point(Label1.Location.X, Label1.Location.Y + Label1.Height + 10)
        txtCantidad.Location = New Point(lblCantidad.Location.X, lblCantidad.Location.Y + lblCantidad.Height + 10)

        lblPrecio.Location = New Point(txtCantidad.Location.X, txtCantidad.Location.Y + txtCantidad.Height + 10)
        txtPrecio.Location = New Point(lblPrecio.Location.X, lblPrecio.Location.Y + lblPrecio.Height + 10)

        btnModificarCantidadPrecio.Location = New Point(txtPrecio.Location.X, txtPrecio.Location.Y + txtPrecio.Height + 10)

        btnAceptar.Location = New Point(btnAceptar.Location.X, dgvProductos.Location.Y + dgvProductos.Height + 10)
        btnCancelar.Location = New Point(btnCancelar.Location.X, dgvProductos.Location.Y + dgvProductos.Height + 10)
    End Sub

    Protected Sub Imprimir()
        Chr(10) '& " " & Me.fechasalida.Text
        Try
            Dim PrintDialog1 As New PrintDialog
            PrintDialog1.Document = PrintDocument1
            'PrintDialog1.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"
            Dim Parametro As New Parametros
            Dim NombreImpresora As String = ""
            Parametro.SETIDParametro("nombre_impresora")
            NombreImpresora = Parametro.GETValor_Parametro
            PrintDialog1.PrinterSettings.PrinterName = NombreImpresora
            If PrintDocument1.PrinterSettings.IsValid Then
                PrintDocument1.Print() 'Imprime texto 
            Else
                MessageBox.Show("La impresora no es valida")
            End If
            '--------------------------------------------------- 
        Catch ex As Exception
            MessageBox.Show("Hay un problema de impresión", ex.ToString())
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'e.Graphics.DrawString(Nombre_Proyecto & " Federico Dieterle 2715", New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        e.Graphics.DrawString(Nombre_Proyecto & " ", New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        e.Graphics.DrawString("Fecha:" & Now.Date & " Hora: " & Now.Hour & ":" & Now.Minute, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 30)
        e.Graphics.DrawString("ARTICULOS", New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 42)
        Dim ValorY As Integer = 52
        For i = 0 To dgvProductos.Rows.Count - 1
            Dim Ariculo As String = ""
            'ValorY = 58 * (i + 1)
            'ValorY = ValorY + 40
            If i = 0 Then
            Else
                ValorY = ValorY + 40
            End If
            Dim Cantidad As String
            Dim fun As New Funciones
            If fun.Valida_Entero(4) = True Then
                Cantidad = CInt(dgvProductos.Rows(i).Cells(2).Value)
            Else
                Cantidad = dgvProductos.Rows(i).Cells(2).Value
            End If
            Ariculo = dgvProductos.Rows(i).Cells(1).Value '& " X" & Cantidad & " " & dgvProductos.Rows(i).Cells(3).Value
            e.Graphics.DrawString(Ariculo, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 10, ValorY)
            ValorY = ValorY + 40
            e.Graphics.DrawString("X " & Cantidad & "-" & dgvProductos.Rows(i).Cells(3).Value, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 10, ValorY)
        Next
        e.Graphics.DrawString("---------------------------------------------------------", New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 10, ValorY + 40)
        e.Graphics.DrawString("TOTAL: " & lblTotal.Text, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, ValorY + 80)
        Dim Pago As String = ""
        If rptEfectivo.Checked = True Then
            Pago = "Efectivo"
        End If
        If rptCredito.Checked = True Then
            Pago = "Credito-" & cmbEmpresas.Text
        End If
        If rptDebito.Checked = True Then
            Pago = "Debito-" & cmbEmpresas.Text
        End If
        'e.Graphics.DrawString("PAGO: $" & lblTotal.Text, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, ValorY + 120)
        e.Graphics.DrawString(Pago, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, ValorY + 120)
        e.Graphics.DrawString("GRACIAS POR SU COMPRA", New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, ValorY + 160)
        e.Graphics.DrawString("no valido como factura", New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, ValorY + 200)
        'no valido como factura
        'e.Graphics.DrawString("", New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Validar_Datos() = 0 Then
            Imprimir()
        End If
    End Sub
End Class