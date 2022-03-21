Imports capaEntidad
Imports capaDatos
Public Class CNEmpleado

    Dim DatosEmpleados As New CDEmpleados
    Public Function ValidarDatos(ByVal empleado As CEEmpleado) As Boolean
        Dim Resultado As Boolean = True

        If empleado.Nombre = "" Then
            Resultado = False
            MessageBox.Show("Completar el campo de Nombre")
        End If
        If empleado.Apellido = "" Then
            Resultado = False
            MessageBox.Show("Completar el campo de Apellido")
        End If

        Return Resultado
    End Function
    Public Sub PruebaMySql()

        DatosEmpleados.ProbarConexion()

    End Sub

    Public Sub Insertar(ByRef empleado As CEEmpleado)
        DatosEmpleados.Insertar(empleado)
    End Sub

    Public Sub Editar(ByVal empleado As CEEmpleado)
        DatosEmpleados.Modificar(empleado)
    End Sub

    Public Sub Eliminar(ByVal empleado As CEEmpleado)

        If MessageBox.Show("¿Estas Seguro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DatosEmpleados.Eliminar(empleado)
        End If

    End Sub

    Public Function Listar() As DataSet
        Return DatosEmpleados.Listar()
    End Function

End Class
