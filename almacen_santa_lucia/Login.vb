Public Class Login

    Private Sub Login_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If clsInstanciaPrevia.InstanciaPrevia(clsInstanciaPrevia.eTipo.POR_SESION) Then
            Me.Close()
        End If
        Dim fun As New Funciones
        If fun.Validar_Programa_Activado = False Then
            MessageBox.Show("El producto no esta activado", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End
        End If
        Dim BD As New Base_De_Datos
        If BD.Validar_Coneccion = False Then
            MessageBox.Show("Por algun problema no se puede realizar la coneccion a la base de datos, verifique que el servicio MySQL este activo", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End
        End If
        txtUsuario.Focus()
        'txtUsuario.Text = "administrador"
        'txtClave.Text = "12345678"
    End Sub

    Function Validar_Datos() As Integer
        Dim Cant As Integer = 0
        ErrorUsuario.Clear()
        ErrorClave.Clear()
        If txtUsuario.Text = Nothing Then
            Cant = Cant + 1
            ErrorUsuario.SetError(txtUsuario, "Debe ingresar un usuario")
        End If
        If txtClave.Text = Nothing Then
            Cant = Cant + 1
            ErrorClave.SetError(txtClave, "Debe ingresar una clave")
        End If
        Return Cant
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar_Datos() = 0 Then
            Dim Usuario As New Usuarios
            Dim fun As New Funciones
            Usuario.SETUsuario(txtUsuario.Text)
            Nombre_Usuario = txtUsuario.Text
            Usuario.SETClave(fun.MD5Encrypt(txtClave.Text))
            If Usuario.Validar_Usuario = True Then
                Me.Visible = False
                Frm_Pantalla_Inicial.ShowDialog()
            Else
                MessageBox.Show("Datos incorrectos", Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        End
    End Sub
End Class