<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABM_Ventas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABM_Ventas))
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
        Me.lblCodBarras = New System.Windows.Forms.Label()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.rptEfectivo = New System.Windows.Forms.RadioButton()
        Me.rptCredito = New System.Windows.Forms.RadioButton()
        Me.rptDebito = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.cmbEmpresas = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.grpDatosCliente = New System.Windows.Forms.GroupBox()
        Me.txtNumeroTarjeta = New System.Windows.Forms.TextBox()
        Me.lbnNumeroTarjeta = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.lblDNI = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidadUnidades = New System.Windows.Forms.TextBox()
        Me.ErrorCantidadUnidades = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorCantidad = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorPrecio = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorEmpresa = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorDNI = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorNombre = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorNumeroTarjeta = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorGrilla = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkImprimir = New System.Windows.Forms.CheckBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnModificarCantidadPrecio = New System.Windows.Forms.Button()
        Me.btnEliminarDetalle = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosCliente.SuspendLayout()
        CType(Me.ErrorCantidadUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorDNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorNumeroTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorGrilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(146, 12)
        Me.txtCodBarras.MaxLength = 60
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(281, 26)
        Me.txtCodBarras.TabIndex = 0
        '
        'lblCodBarras
        '
        Me.lblCodBarras.AutoSize = True
        Me.lblCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodBarras.Location = New System.Drawing.Point(11, 15)
        Me.lblCodBarras.Name = "lblCodBarras"
        Me.lblCodBarras.Size = New System.Drawing.Size(136, 20)
        Me.lblCodBarras.TabIndex = 8
        Me.lblCodBarras.Text = "Codigo de Barras:"
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.BackgroundColor = System.Drawing.Color.White
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(14, 173)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProductos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductos.Size = New System.Drawing.Size(672, 321)
        Me.dgvProductos.TabIndex = 9
        '
        'rptEfectivo
        '
        Me.rptEfectivo.AutoSize = True
        Me.rptEfectivo.Checked = True
        Me.rptEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rptEfectivo.Location = New System.Drawing.Point(12, 48)
        Me.rptEfectivo.Name = "rptEfectivo"
        Me.rptEfectivo.Size = New System.Drawing.Size(84, 24)
        Me.rptEfectivo.TabIndex = 4
        Me.rptEfectivo.TabStop = True
        Me.rptEfectivo.Text = "Efectivo"
        Me.rptEfectivo.UseVisualStyleBackColor = True
        '
        'rptCredito
        '
        Me.rptCredito.AutoSize = True
        Me.rptCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rptCredito.Location = New System.Drawing.Point(96, 48)
        Me.rptCredito.Name = "rptCredito"
        Me.rptCredito.Size = New System.Drawing.Size(78, 24)
        Me.rptCredito.TabIndex = 5
        Me.rptCredito.Text = "Credito"
        Me.rptCredito.UseVisualStyleBackColor = True
        '
        'rptDebito
        '
        Me.rptDebito.AutoSize = True
        Me.rptDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rptDebito.Location = New System.Drawing.Point(175, 48)
        Me.rptDebito.Name = "rptDebito"
        Me.rptDebito.Size = New System.Drawing.Size(74, 24)
        Me.rptDebito.TabIndex = 6
        Me.rptDebito.Text = "Debito"
        Me.rptDebito.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(692, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 24)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "TOTAL $"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Green
        Me.lblTotal.Location = New System.Drawing.Point(785, 225)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(45, 24)
        Me.lblTotal.TabIndex = 35
        Me.lblTotal.Text = "0,00"
        '
        'cmbEmpresas
        '
        Me.cmbEmpresas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmpresas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmpresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpresas.FormattingEnabled = True
        Me.cmbEmpresas.Location = New System.Drawing.Point(327, 47)
        Me.cmbEmpresas.Name = "cmbEmpresas"
        Me.cmbEmpresas.Size = New System.Drawing.Size(327, 28)
        Me.cmbEmpresas.TabIndex = 8
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(250, 48)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(77, 20)
        Me.lblEmpresa.TabIndex = 7
        Me.lblEmpresa.Text = "Empresa:"
        '
        'grpDatosCliente
        '
        Me.grpDatosCliente.Controls.Add(Me.txtNumeroTarjeta)
        Me.grpDatosCliente.Controls.Add(Me.lbnNumeroTarjeta)
        Me.grpDatosCliente.Controls.Add(Me.txtNombre)
        Me.grpDatosCliente.Controls.Add(Me.lblNombre)
        Me.grpDatosCliente.Controls.Add(Me.txtDNI)
        Me.grpDatosCliente.Controls.Add(Me.lblDNI)
        Me.grpDatosCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosCliente.Location = New System.Drawing.Point(14, 77)
        Me.grpDatosCliente.Name = "grpDatosCliente"
        Me.grpDatosCliente.Size = New System.Drawing.Size(560, 90)
        Me.grpDatosCliente.TabIndex = 4
        Me.grpDatosCliente.TabStop = False
        Me.grpDatosCliente.Text = "Datos del Cliente"
        Me.grpDatosCliente.Visible = False
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(143, 50)
        Me.txtNumeroTarjeta.MaxLength = 20
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(338, 26)
        Me.txtNumeroTarjeta.TabIndex = 2
        '
        'lbnNumeroTarjeta
        '
        Me.lbnNumeroTarjeta.AutoSize = True
        Me.lbnNumeroTarjeta.Location = New System.Drawing.Point(6, 55)
        Me.lbnNumeroTarjeta.Name = "lbnNumeroTarjeta"
        Me.lbnNumeroTarjeta.Size = New System.Drawing.Size(136, 20)
        Me.lbnNumeroTarjeta.TabIndex = 4
        Me.lbnNumeroTarjeta.Text = "Numero de tarjeta"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(274, 22)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(273, 26)
        Me.txtNombre.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(211, 22)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(65, 20)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(42, 22)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(167, 26)
        Me.txtDNI.TabIndex = 0
        '
        'lblDNI
        '
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Location = New System.Drawing.Point(6, 25)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(37, 20)
        Me.lblDNI.TabIndex = 0
        Me.lblDNI.Text = "DNI"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(693, 270)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(73, 20)
        Me.lblCantidad.TabIndex = 61
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(696, 293)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 26)
        Me.txtCantidad.TabIndex = 11
        '
        'txtPrecio
        '
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(696, 344)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 26)
        Me.txtPrecio.TabIndex = 12
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(693, 323)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(53, 20)
        Me.lblPrecio.TabIndex = 63
        Me.lblPrecio.Text = "Precio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(477, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cantidad De Unidades"
        '
        'txtCantidadUnidades
        '
        Me.txtCantidadUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadUnidades.Location = New System.Drawing.Point(649, 12)
        Me.txtCantidadUnidades.Name = "txtCantidadUnidades"
        Me.txtCantidadUnidades.Size = New System.Drawing.Size(39, 26)
        Me.txtCantidadUnidades.TabIndex = 3
        Me.txtCantidadUnidades.Text = "1"
        '
        'ErrorCantidadUnidades
        '
        Me.ErrorCantidadUnidades.ContainerControl = Me
        '
        'ErrorCantidad
        '
        Me.ErrorCantidad.ContainerControl = Me
        '
        'ErrorPrecio
        '
        Me.ErrorPrecio.ContainerControl = Me
        '
        'ErrorEmpresa
        '
        Me.ErrorEmpresa.ContainerControl = Me
        '
        'ErrorDNI
        '
        Me.ErrorDNI.ContainerControl = Me
        '
        'ErrorNombre
        '
        Me.ErrorNombre.ContainerControl = Me
        '
        'ErrorNumeroTarjeta
        '
        Me.ErrorNumeroTarjeta.ContainerControl = Me
        '
        'ErrorGrilla
        '
        Me.ErrorGrilla.ContainerControl = Me
        '
        'chkImprimir
        '
        Me.chkImprimir.AutoSize = True
        Me.chkImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimir.Location = New System.Drawing.Point(697, 9)
        Me.chkImprimir.Name = "chkImprimir"
        Me.chkImprimir.Size = New System.Drawing.Size(84, 24)
        Me.chkImprimir.TabIndex = 14
        Me.chkImprimir.Text = "Imprimir"
        Me.chkImprimir.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.almacen_santa_lucia.My.Resources.Resources.imprimir_icono_5248_482
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(697, 440)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(100, 51)
        Me.btnImprimir.TabIndex = 15
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        Me.btnImprimir.Visible = False
        '
        'btnModificarCantidadPrecio
        '
        Me.btnModificarCantidadPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificarCantidadPrecio.Image = Global.almacen_santa_lucia.My.Resources.Resources.Checkmark
        Me.btnModificarCantidadPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarCantidadPrecio.Location = New System.Drawing.Point(696, 372)
        Me.btnModificarCantidadPrecio.Name = "btnModificarCantidadPrecio"
        Me.btnModificarCantidadPrecio.Size = New System.Drawing.Size(100, 51)
        Me.btnModificarCantidadPrecio.TabIndex = 13
        Me.btnModificarCantidadPrecio.Text = "Modificar"
        Me.btnModificarCantidadPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificarCantidadPrecio.UseVisualStyleBackColor = True
        '
        'btnEliminarDetalle
        '
        Me.btnEliminarDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarDetalle.Image = Global.almacen_santa_lucia.My.Resources.Resources.elimina
        Me.btnEliminarDetalle.Location = New System.Drawing.Point(692, 173)
        Me.btnEliminarDetalle.Name = "btnEliminarDetalle"
        Me.btnEliminarDetalle.Size = New System.Drawing.Size(45, 40)
        Me.btnEliminarDetalle.TabIndex = 10
        Me.btnEliminarDetalle.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.almacen_santa_lucia.My.Resources.Resources.X
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(355, 500)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 46)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.almacen_santa_lucia.My.Resources.Resources.Checkmark
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(213, 500)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(135, 46)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.almacen_santa_lucia.My.Resources.Resources.buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(433, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(38, 25)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'ABM_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(881, 557)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.chkImprimir)
        Me.Controls.Add(Me.txtCantidadUnidades)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnModificarCantidadPrecio)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.grpDatosCliente)
        Me.Controls.Add(Me.btnEliminarDetalle)
        Me.Controls.Add(Me.cmbEmpresas)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rptDebito)
        Me.Controls.Add(Me.rptCredito)
        Me.Controls.Add(Me.rptEfectivo)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtCodBarras)
        Me.Controls.Add(Me.lblCodBarras)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(891, 589)
        Me.Name = "ABM_Ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM_Ventas"
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosCliente.ResumeLayout(False)
        Me.grpDatosCliente.PerformLayout()
        CType(Me.ErrorCantidadUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorDNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorNumeroTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorGrilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents lblCodBarras As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents rptEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents rptCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rptDebito As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents btnEliminarDetalle As System.Windows.Forms.Button
    Friend WithEvents grpDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblDNI As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtDNI As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents lbnNumeroTarjeta As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents btnModificarCantidadPrecio As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadUnidades As System.Windows.Forms.TextBox
    Friend WithEvents ErrorCantidadUnidades As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorCantidad As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorPrecio As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorEmpresa As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorDNI As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorNombre As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorNumeroTarjeta As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorGrilla As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
