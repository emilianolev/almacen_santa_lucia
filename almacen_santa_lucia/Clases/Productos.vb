Public Class Productos
    Private ID_Producto As Integer
    Private Descripcion As String
    Private Codigo_Barras As String
    Private ID_Categoria As Integer
    Private Precio As Decimal
    Private Activo As String

    Public Sub SETID_Producto(ByVal valor_idproducto)
        ID_Producto = valor_idproducto
    End Sub

    Public Sub SETDescripcion(ByVal valor_descripcion)
        Descripcion = valor_descripcion
    End Sub

    Public Sub SETCodigo_Barras(ByVal valor_codigo_barras)
        Codigo_Barras = valor_codigo_barras
    End Sub

    Public Sub SETID_Categoria(ByVal valor_idcategoria)
        ID_Categoria = valor_idcategoria
    End Sub

    Public Sub SETPrecio(ByVal valor_precio)
        Precio = valor_precio
    End Sub

    Public Sub SETActivo(ByVal valor_activo)
        Activo = valor_activo
    End Sub

    Public Function GETID_Producto() As Integer
        Return ID_Producto
    End Function

    'listado de todas los productos
    Function Listado_Productos(ByVal Condicion As String) As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        BD.Conectar()
        Dim Consulta As String = "SELECT productos.id_producto AS Codigo,productos.Descripcion,productos.Codigo_Barras,categorias.descripcion AS Categoria,productos.Precio,productos.Activo FROM productos INNER JOIN categorias ON CATEGORIAS.ID_CATEGORIA=PRODUCTOS.ID_CATEGORIA WHERE 1=1 " & Condicion
        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'busco los datos de un producto
    Function Buscar_Datos_Producto(Optional ByVal Condicion As String = "") As DataTable
        Dim BD As New Base_De_Datos
        Dim Listado As DataTable
        Dim Consulta As String = ""
        BD.Conectar()
        If Condicion <> "" Then
            Consulta = "SELECT * FROM productos WHERE 1=1 " & Condicion
        Else
            Consulta = "SELECT * FROM productos WHERE id_producto=" & ID_Producto
        End If

        BD.CrearComando(Consulta)
        Listado = BD.EjecutarDataTable
        BD.Desconectar()
        Return Listado
    End Function

    'genero un nuevo id para el alta de un producto
    Function Generar_ID() As Integer
        Dim BD As New Base_De_Datos
        Dim ID As Integer
        ID = 1
        BD.Conectar()
        Dim Consulta As String = "SELECT MAX(id_producto) FROM productos"
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows
            If row(0) IsNot DBNull.Value Then
                ID = row(0)
                ID = ID + 1
            End If
        Next
        BD.Desconectar()
        Return ID
    End Function

    Public Function Agregar_Producto() As String
        Dim Mensaje As String = ""
        Me.ID_Producto = Generar_ID()
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        BD.Conectar()
        Consulta = "INSERT INTO productos(id_producto,descripcion,codigo_barras,id_categoria,precio,activo) VALUES(@id_producto,@descripcion,@codigo_barras,@id_categoria,@precio,@activo)"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_producto", "int", Me.ID_Producto)
        BD.AsignarParametro("@descripcion", "string", Me.Descripcion)
        BD.AsignarParametro("@codigo_barras", "string", Me.Codigo_Barras)
        BD.AsignarParametro("@id_categoria", "int", Me.ID_Categoria)
        BD.AsignarParametro("@precio", "decimal", Me.Precio)
        BD.AsignarParametro("@activo", "string", "S")
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Modificar_Producto() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        BD.Conectar()
        Consulta = "UPDATE productos SET descripcion=@descripcion,codigo_barras=@codigo_barras,id_categoria=@id_categoria,precio=@precio,activo=@activo WHERE id_producto=@id_producto"
        BD.CrearComando(Consulta)

        BD.AsignarParametro("@id_producto", "int", Me.ID_Producto)
        BD.AsignarParametro("@descripcion", "string", Me.Descripcion)
        BD.AsignarParametro("@codigo_barras", "string", Me.Codigo_Barras)
        BD.AsignarParametro("@id_categoria", "int", Me.ID_Categoria)
        BD.AsignarParametro("@precio", "decimal", Me.Precio)
        BD.AsignarParametro("@activo", "string", Me.Activo)
        Mensaje = BD.EjecutarConsulta()
        BD.Desconectar()
        Return Mensaje
    End Function

    Public Function Eliminar_Producto() As String
        Dim Mensaje As String = ""
        Dim BD As New Base_De_Datos
        Dim Consulta As String = ""
        Dim Cant As Integer = 0
        Cant = Cantidad_Ventas_Productos()

        If Cant = 0 Then
            BD.Conectar()
            Consulta = "DELETE FROM productos WHERE id_producto=@id_producto"
            BD.CrearComando(Consulta)

            BD.AsignarParametro("@id_producto", "int", Me.ID_Producto)
            Mensaje = BD.EjecutarConsulta()
            BD.Desconectar()
        Else
            Mensaje = "No se puede eliminar el producto debido a que tiene ventas asociadas"
        End If
        Return Mensaje
    End Function

    Public Function Cantidad_Ventas_Productos() As Integer
        Dim BD As New Base_De_Datos
        Dim Cant As Integer
        Cant = 0
        BD.Conectar()
        Dim Consulta As String = "SELECT * FROM ventas_detalles WHERE id_producto=" & Me.ID_Producto
        BD.CrearComando(Consulta)
        Dim Leer
        Leer = BD.EjecutarDataTable
        For Each row In Leer.Rows
            Cant = Cant + 1
        Next
        BD.Desconectar()
        Return Cant
    End Function
End Class
