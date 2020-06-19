Public Class Modificar_Clave

    Private Sub Modificar_Clave_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Modificar_Clave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub Modificar_Clave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtClave.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text <> Nothing Then
            ErrorClave.Clear()
            Dim Mensaje As String = ""
            Dim Usuario As New Usuarios
            Usuario.SETUsuario(Nombre_Usuario)
            Dim fun As New Funciones
            Usuario.SETClave(fun.MD5Encrypt(txtClave.Text))
            Mensaje = Usuario.Modificar_Clave
            If Mensaje <> "" Then
                fun.Grabo_Archivo_Log(Mensaje, "")
                MessageBox.Show(Mensaje, Nombre_Proyecto, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Me.Close()
            End If
        Else
            ErrorClave.SetError(txtClave, "Ingrese clave")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class