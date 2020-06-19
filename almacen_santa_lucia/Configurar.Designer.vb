<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configurar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configurar))
        Me.txtRutaMYSQL = New System.Windows.Forms.TextBox()
        Me.lblRutaMYSQL = New System.Windows.Forms.Label()
        Me.txtCarpetaBackUp = New System.Windows.Forms.TextBox()
        Me.lblCarpetaBackUp = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnRutaMYSQL = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.fbdNavegador = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'txtRutaMYSQL
        '
        Me.txtRutaMYSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaMYSQL.Location = New System.Drawing.Point(140, 12)
        Me.txtRutaMYSQL.MaxLength = 50
        Me.txtRutaMYSQL.Name = "txtRutaMYSQL"
        Me.txtRutaMYSQL.Size = New System.Drawing.Size(327, 26)
        Me.txtRutaMYSQL.TabIndex = 0
        '
        'lblRutaMYSQL
        '
        Me.lblRutaMYSQL.AutoSize = True
        Me.lblRutaMYSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaMYSQL.Location = New System.Drawing.Point(32, 15)
        Me.lblRutaMYSQL.Name = "lblRutaMYSQL"
        Me.lblRutaMYSQL.Size = New System.Drawing.Size(108, 20)
        Me.lblRutaMYSQL.TabIndex = 6
        Me.lblRutaMYSQL.Text = "Ruta MYSQL:"
        '
        'txtCarpetaBackUp
        '
        Me.txtCarpetaBackUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarpetaBackUp.Location = New System.Drawing.Point(140, 44)
        Me.txtCarpetaBackUp.MaxLength = 50
        Me.txtCarpetaBackUp.Name = "txtCarpetaBackUp"
        Me.txtCarpetaBackUp.ReadOnly = True
        Me.txtCarpetaBackUp.Size = New System.Drawing.Size(327, 26)
        Me.txtCarpetaBackUp.TabIndex = 2
        '
        'lblCarpetaBackUp
        '
        Me.lblCarpetaBackUp.AutoSize = True
        Me.lblCarpetaBackUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarpetaBackUp.Location = New System.Drawing.Point(9, 47)
        Me.lblCarpetaBackUp.Name = "lblCarpetaBackUp"
        Me.lblCarpetaBackUp.Size = New System.Drawing.Size(131, 20)
        Me.lblCarpetaBackUp.TabIndex = 7
        Me.lblCarpetaBackUp.Text = "Carpeta BackUp:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.almacen_santa_lucia.My.Resources.Resources.X
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(305, 85)
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
        Me.btnAceptar.Location = New System.Drawing.Point(163, 85)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(135, 46)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnRutaMYSQL
        '
        Me.btnRutaMYSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRutaMYSQL.Location = New System.Drawing.Point(473, 12)
        Me.btnRutaMYSQL.Name = "btnRutaMYSQL"
        Me.btnRutaMYSQL.Size = New System.Drawing.Size(76, 22)
        Me.btnRutaMYSQL.TabIndex = 1
        Me.btnRutaMYSQL.Text = "Por Defecto"
        Me.btnRutaMYSQL.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.almacen_santa_lucia.My.Resources.Resources.buscar
        Me.btnBuscar.Location = New System.Drawing.Point(489, 40)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(38, 30)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Configurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(602, 154)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnRutaMYSQL)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtCarpetaBackUp)
        Me.Controls.Add(Me.lblCarpetaBackUp)
        Me.Controls.Add(Me.txtRutaMYSQL)
        Me.Controls.Add(Me.lblRutaMYSQL)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Configurar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configurar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRutaMYSQL As System.Windows.Forms.TextBox
    Friend WithEvents lblRutaMYSQL As System.Windows.Forms.Label
    Friend WithEvents txtCarpetaBackUp As System.Windows.Forms.TextBox
    Friend WithEvents lblCarpetaBackUp As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnRutaMYSQL As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents fbdNavegador As System.Windows.Forms.FolderBrowserDialog
End Class
