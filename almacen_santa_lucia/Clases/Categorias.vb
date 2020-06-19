Public Class Categorias
    Private ID_Categoria As Integer
    Private Descripcion As String

    Public Sub SETID_Categoria(ByVal valor_idcategoria)
        ID_Categoria = valor_idcategoria
    End Sub

    Public Sub SETdescripcion(ByVal valor_descripcion)
        Descripcion = valor_descripcion
    End Sub

    Public Function GETID_Categoria() As Integer
        Return ID_Categoria
    End Function

    'listado de todas los categorias
    Function Listado_Categorias(ByVal Condicion As String) As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT id_categoria AS Codigo,descripcion AS Descripcion FROM categorias WHERE 1=1 " & Condicion
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'busco los datos de un producto
    Function Buscar_Datos_Categoria() As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM categorias WHERE id_categoria=" & ID_Categoria
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    Public Sub Llenar_ComboBox(ByRef Combo As ComboBox)
        Dim BD As New Base_De_Datos
        Dim Consulta As String = "SELECT * FROM categorias"
        BD.Conectar()
        'BD.CrearComando(Consulta)
        Combo.DataSource = BD.Listar(Consulta)
        Combo.DisplayMember = "descripcion"
        Combo.ValueMember = "id_categoria"
        BD.Desconectar()
    End Sub

    'genero un nuevo id para el alta de una categoria
    Function Generar_ID() As Integer
        Dim BD As New Base_De_Datos
        Dim ID As Integer
        ID = 1
        BD.Conectar()
        Dim Consulta As String = "SELECT MAX(id_categoria) FROM categorias"
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows()
            If row(0) IsNot DBNull.Value Then
                ID = row(0)
                ID = ID + 1
            End If
        Next
        BD.Desconectar()
        Return ID
    End Function

    Public Function Agregar_Categoria() As String
        Dim Mensaje As String = ""
        Me.ID_Categoria = Generar_ID()
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Dim Consulta As String = ""

        Consulta = "INSERT INTO CATEGORIAS(id_categoria,descripcion) VALUES(@id_categoria,@descripcion)"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_categoria", "int", Me.ID_Categoria)
        BD.AsignarParametro("@descripcion", "string", Me.Descripcion)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Modificar_Categoria() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Dim Consulta As String = ""

        Consulta = "UPDATE categorias SET descripcion=@descripcion WHERE id_categoria=@id_categoria"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_categoria", "int", Me.ID_Categoria)
        BD.AsignarParametro("@descripcion", "string", Me.Descripcion)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Eliminar_Categoria() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        BD.Conectar()
        Dim Consulta As String = ""
        Dim Cant As Integer = 0
        Cant = Cantidad_Productos_Categoria()

        If Cant = 0 Then
            Consulta = "DELETE FROM categorias WHERE id_categoria=@id_categoria"
            BD.CrearComando(Consulta)

            BD.AsignarParametro("@id_categoria", "int", Me.ID_Categoria)
            Mensaje = BD.EjecutarConsulta()
            BD.Desconectar()
        Else
            Mensaje = "No se puede eliminar la categoria debido a que tiene productos asociados"
        End If
        Return Mensaje
    End Function

    Public Function Cantidad_Productos_Categoria() As Integer
        Dim BD As New Base_De_Datos
        Dim Cant As Integer
        Cant = 0
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM productos WHERE id_categoria=" & Me.ID_Categoria
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows
            Cant = Cant + 1
        Next
        BD.Desconectar()
        Return Cant
    End Function

    Public Function Modificar_Precios_productos_Categorias(ByVal Porcentaje As Decimal, ByVal Positivo As Boolean) As String
        Dim Mensaje As String = ""
        Dim Leer
        Dim Producto As New Productos
        Producto.SETID_Categoria(Me.ID_Categoria)
        Leer = Producto.Buscar_Datos_Producto(" AND id_categoria=" & ID_Categoria)
        For Each row In Leer.rows
            Dim BD As New Base_De_Datos
            BD.Conectar()
            Dim Consulta As String = ""
            Dim Precio_Calculado As Decimal = (Porcentaje * row("precio")) / 100

            If Positivo = True Then
                Precio_Calculado = row("precio") + Precio_Calculado
            Else
                Precio_Calculado = row("precio") - Precio_Calculado
            End If
            Consulta = "UPDATE productos SET precio=@precio WHERE id_producto=" & row("id_producto")
            BD.CrearComando(Consulta)
            BD.AsignarParametro("@precio", "decimal", Precio_Calculado)
            Mensaje = Mensaje & BD.EjecutarConsulta
            BD.Desconectar()
        Next
        Return Mensaje
    End Function
End Class