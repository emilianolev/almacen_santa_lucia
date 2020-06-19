Module Modulo
    'Evaluo si la aplicacion ya esta abierta
    Public Class clsInstanciaPrevia
        ' Mutex local para sólo permitir una instancia de la aplicación por usuario
        Private Shared _mutex As System.Threading.Mutex

        'API de Windows
        <System.Runtime.InteropServices.DllImport("user32.dll")> _
        Private Shared Function ShowWindow(ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Integer
        End Function

        <System.Runtime.InteropServices.DllImport("user32.dll")> _
        Private Shared Function SetForegroundWindow(ByVal hWnd As System.IntPtr) As Integer
        End Function

        Private Const SW_SHOWMAXIMIZED As Integer = 3
        Private Const SW_SHOWNORMAL As Integer = 1

        'Enumerador para inicar el tipo de bloqueo
        Public Enum eTipo As Integer
            POR_SESION = 0
            [GLOBAL] = 1
        End Enum

        'Función que devuelve TRUE si ya existe una instancia previa del programa corriendo
        'En caso de que la aplicación estuviera corriendo, intenta darle foco a la ventana principal
        Public Shared Function InstanciaPrevia(ByVal Tipo As eTipo) As Boolean
            'Obtengo el nombre del ensamblado donde se encuentra ésta función
            Dim NombreAssembly As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name

            'Nombre del mutex según Tipo (visibilidad)
            Dim mutexName As String = If(Tipo = eTipo.GLOBAL, "Global\", "Local\") & NombreAssembly

            Dim newMutexCreated As Boolean
            Try
                'Abro/Creo mutex con nombre único
                _mutex = New System.Threading.Mutex(False, mutexName, newMutexCreated)

                If newMutexCreated Then
                    'Se creó el mutex, NO existe instancia previa
                    Return False
                Else
                    'El mutex ya existía, Libero el mutex 
                    _mutex.Close()
                    'Intento otorgar el foco al programa ya abierto anteriormente
                    If Not MostrarVentanaPPalProceso() Then
                        'No se encontró la ventana principal
                        MessageBox.Show("Ya existe una instancia previa del programa corriendo", "Seguridad E Higiene", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                    Return True
                End If
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Seguridad E Higiene")
                Return False
            End Try
        End Function

        'Intenta mostrar la ventana principal de los procesos con mi mismo nombre
        Private Shared Function MostrarVentanaPPalProceso() As Boolean
            Dim sProcessName As String = Process.GetCurrentProcess.ProcessName

            'Apuntador a la ventana ppal del proceso con nombre sProcessName
            Dim mainhWnd As System.IntPtr = _
                    (From p In Process.GetProcessesByName(sProcessName) _
                    Where Not p.MainWindowHandle.Equals(IntPtr.Zero) _
                    Select p.MainWindowHandle).FirstOrDefault

            If Not mainhWnd.Equals(IntPtr.Zero) Then
                'Muestro la ventana
                SetForegroundWindow(mainhWnd)
                ShowWindow(mainhWnd, SW_SHOWNORMAL)
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Module
