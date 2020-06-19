Imports System.Drawing.Printing

Public Class Frm_Pantalla_Inicial

    Private Sub Frm_Pantalla_Inicial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Frm_Pantalla_Inicial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "Usuario: " & Nombre_Usuario
    End Sub

    Private Sub AltaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaToolStripMenuItem.Click
        Accion_Usuario = "A"
        ABM_Categorias.ShowDialog()
    End Sub

    Private Sub ListadoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoToolStripMenuItem.Click
        Listado_Categorias.ShowDialog()
    End Sub

    Private Sub AltaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaToolStripMenuItem1.Click
        Accion_Usuario = "A"
        ABM_Productos.ShowDialog()
    End Sub

    Private Sub ListadoProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoProductosToolStripMenuItem.Click
        Listado_Productos.ShowDialog()
    End Sub

    Private Sub AltaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaToolStripMenuItem2.Click
        Accion_Usuario = "A"
        ABM_Ventas.ShowDialog()
    End Sub

    Private Sub AltaToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaToolStripMenuItem3.Click
        Accion_Usuario = "A"
        ABM_Tarjetas_Credito.ShowDialog()
    End Sub

    Private Sub ListadoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoToolStripMenuItem2.Click
        Listado_Tarjetas_Credito.ShowDialog()
    End Sub

    Private Sub AltaToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaToolStripMenuItem4.Click
        Accion_Usuario = "A"
        ABM_Tarjetas_Debito.ShowDialog()
    End Sub

    Private Sub ListadoToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoToolStripMenuItem3.Click
        Listado_Tarjetas_Debito.ShowDialog()
    End Sub

    Private Sub ModificarClaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarClaveToolStripMenuItem.Click
        Modificar_Clave.ShowDialog()
    End Sub

    Private Sub ListadoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoToolStripMenuItem1.Click
        Listado_Ventas.ShowDialog()
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Exportar_Base_Datos.ShowDialog()
    End Sub

    Private Sub ConfigurarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Configurar.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        SplashScreen1.ShowDialog()
    End Sub
End Class