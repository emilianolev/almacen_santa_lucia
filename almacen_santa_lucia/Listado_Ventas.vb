Imports System.IO
Imports Microsoft.Office.Interop

Public Class Listado_Ventas

    Private Sub Listado_Ventas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Listado_Ventas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        If cmbFormaPago.Focused = False And dtpDesde.Focused And dtpHasta.Focused Then
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                dgvVentas.Focus()
            End If
        End If
    End Sub

    Private Sub Listado_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbFormaPago.SelectedIndex = 0
        dtpHasta.Value = Now.Date
        Dim FechaDesde As Date = Now.Date
        FechaDesde = FechaDesde.AddDays(-1)
        dtpDesde.Value = FechaDesde
    End Sub

    Protected Function Validar_Datos() As Integer
        Dim Cant_Errores As Integer = 0
        ErrorFechas.Clear()
        If CDate(dtpHasta.Value) < CDate(dtpDesde.Value) Then
            Cant_Errores = Cant_Errores + 1
            ErrorFechas.SetError(dtpHasta, "Fecha hasta no puede ser menor a fecha desde")
        End If
        Return Cant_Errores
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Busqueda_Ventas()
    End Sub

    Protected Sub Busqueda_Ventas()
        If Validar_Datos() = 0 Then
            Dim Condicion As String = ""

            Dim FechaDesde As Date = dtpDesde.Value
            Dim FechaDesdeFormateada As String = ""
            FechaDesdeFormateada = Format(FechaDesde, "yyyy-MM-dd")

            Dim FechaHasta As Date = dtpHasta.Value
            Dim FechaHastaFormateada As String = ""
            FechaHastaFormateada = Format(FechaHasta, "yyyy-MM-dd")

            Condicion = " AND ventas.fecha BETWEEN '" & FechaDesdeFormateada & "' AND '" & FechaHastaFormateada & "' "

            Select Case cmbFormaPago.Text
                Case "Efectivo"
                    Condicion = Condicion & " AND ventas.forma_pago='e' "
                Case "Credito"
                    Condicion = Condicion & " AND ventas.forma_pago='c' "
                Case "Debito"
                    Condicion = Condicion & " AND ventas.forma_pago='d' "
            End Select
            Dim Venta As New Ventas
            dgvVentas.DataSource = Venta.Listado_Ventas(Condicion)

            dgvVentas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            dgvVentas.Columns(0).Width = 50

            'SUMO LOS PRECIOS
            Dim Total As Decimal = 0
            For i = 0 To dgvVentas.Rows.Count - 1
                Total = Total + CDec(dgvVentas.Rows(i).Cells(3).Value)
            Next

            lblTotal.Text = Total
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Accion_Usuario = "A"
        ABM_Ventas.ShowDialog()
        Busqueda_Ventas()
        Dim fun As New Funciones
        fun.Seleccionar_Dato_Grilla(dgvVentas, Pasa_ID_Venta, 0)
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If dgvVentas.RowCount > 0 Then
            Pasa_ID_Venta = dgvVentas.CurrentRow.Cells(0).Value
            Accion_Usuario = "M"
            ABM_Ventas.ShowDialog()
            Busqueda_Ventas()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvVentas, Pasa_ID_Venta, 0)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If dgvVentas.RowCount > 0 Then
            Pasa_ID_Venta = dgvVentas.CurrentRow.Cells(0).Value
            Accion_Usuario = "B"
            ABM_Ventas.ShowDialog()
            Busqueda_Ventas()
            Dim fun As New Funciones
            fun.Seleccionar_Dato_Grilla(dgvVentas, Pasa_ID_Venta, 0)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Listado_Ventas_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvVentas.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        lblDesde.Location = New Point(dgvVentas.Location.X, dgvVentas.Location.Y + dgvVentas.Height + 10)
        dtpDesde.Location = New Point(lblDesde.Location.X + lblDesde.Width + 10, lblDesde.Location.Y)

        lblHasta.Location = New Point(dtpDesde.Location.X + dtpDesde.Width + 10, lblDesde.Location.Y)
        dtpHasta.Location = New Point(lblHasta.Location.X + lblHasta.Width + 10, lblDesde.Location.Y)

        lblFormaPago.Location = New Point(dtpHasta.Location.X + dtpHasta.Width + 10, lblDesde.Location.Y)
        cmbFormaPago.Location = New Point(lblFormaPago.Location.X + lblFormaPago.Width + 10, lblDesde.Location.Y)

        btnAgregar.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, btnAgregar.Location.Y)
        btnModificar.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, btnModificar.Location.Y)
        btnEliminar.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, btnEliminar.Location.Y)
        btnExportar.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, btnExportar.Location.Y)
        btnSalir.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, dgvVentas.Location.Y + dgvVentas.Height - btnSalir.Height)

        Label1.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, btnExportar.Location.Y + btnExportar.Height + 10)
        lblTotal.Location = New Point(dgvVentas.Location.X + dgvVentas.Width + 5, Label1.Location.Y + Label1.Height + 10)
        btnBuscar.Location = New Point(cmbFormaPago.Location.X + cmbFormaPago.Width + 10, lblDesde.Location.Y)
    End Sub

    Protected Sub Generar_Excel()
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = Nombre_Proyecto
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = "LISTADO DE VENTAS DEL " & dtpDesde.Value & " AL " & dtpHasta.Value & ""
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In dgvVentas.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In dgvVentas.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In dgvVentas.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In dgvVentas.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If dgvVentas.Rows.Count > 0 Then
            Generar_Excel()
        End If
    End Sub
End Class