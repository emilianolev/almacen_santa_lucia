<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABM_Categorias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABM_Categorias))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.chkModificarPreciosProductos = New System.Windows.Forms.CheckBox()
        Me.cmbSigno = New System.Windows.Forms.ComboBox()
        Me.txtPorntajece = New System.Windows.Forms.TextBox()
        Me.ErrorDescripcion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorPorcentaje = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ErrorDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorPorcentaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.almacen_santa_lucia.My.Resources.Resources.X
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(225, 98)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 46)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.almacen_santa_lucia.My.Resources.Resources.Checkmark
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(83, 98)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(135, 46)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(104, 12)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(327, 26)
        Me.txtDescripcion.TabIndex = 0
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(5, 15)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(96, 20)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripcion:"
        '
        'chkModificarPreciosProductos
        '
        Me.chkModificarPreciosProductos.AutoSize = True
        Me.chkModificarPreciosProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkModificarPreciosProductos.Location = New System.Drawing.Point(83, 55)
        Me.chkModificarPreciosProductos.Name = "chkModificarPreciosProductos"
        Me.chkModificarPreciosProductos.Size = New System.Drawing.Size(224, 24)
        Me.chkModificarPreciosProductos.TabIndex = 1
        Me.chkModificarPreciosProductos.Text = "Modificar Precios Productos"
        Me.chkModificarPreciosProductos.UseVisualStyleBackColor = True
        Me.chkModificarPreciosProductos.Visible = False
        '
        'cmbSigno
        '
        Me.cmbSigno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSigno.Enabled = False
        Me.cmbSigno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSigno.FormattingEnabled = True
        Me.cmbSigno.Items.AddRange(New Object() {"+", "-"})
        Me.cmbSigno.Location = New System.Drawing.Point(307, 53)
        Me.cmbSigno.Name = "cmbSigno"
        Me.cmbSigno.Size = New System.Drawing.Size(31, 28)
        Me.cmbSigno.TabIndex = 2
        Me.cmbSigno.Visible = False
        '
        'txtPorntajece
        '
        Me.txtPorntajece.Enabled = False
        Me.txtPorntajece.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorntajece.Location = New System.Drawing.Point(359, 54)
        Me.txtPorntajece.MaxLength = 50
        Me.txtPorntajece.Name = "txtPorntajece"
        Me.txtPorntajece.Size = New System.Drawing.Size(57, 26)
        Me.txtPorntajece.TabIndex = 3
        Me.txtPorntajece.Visible = False
        '
        'ErrorDescripcion
        '
        Me.ErrorDescripcion.ContainerControl = Me
        '
        'ErrorPorcentaje
        '
        Me.ErrorPorcentaje.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(339, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "%:"
        Me.Label1.Visible = False
        '
        'ABM_Categorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(466, 155)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPorntajece)
        Me.Controls.Add(Me.cmbSigno)
        Me.Controls.Add(Me.chkModificarPreciosProductos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ABM_Categorias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ABM_Categorias"
        CType(Me.ErrorDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorPorcentaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents chkModificarPreciosProductos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSigno As System.Windows.Forms.ComboBox
    Friend WithEvents txtPorntajece As System.Windows.Forms.TextBox
    Friend WithEvents ErrorDescripcion As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorPorcentaje As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
