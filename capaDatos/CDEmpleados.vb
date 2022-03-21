Imports MySql.Data.MySqlClient
Imports capaEntidad
Public Class CDEmpleados

    Private _cadenaConexion As String = "Server=127.0.0.1;User=root;Password=123;Port=3306;database=crud_empleado"

    Public Sub ProbarConexion()

        Dim Conexion As New MySqlConnection(_cadenaConexion)

        Try
            Conexion.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

        MessageBox.Show("Conexion con Exito")
        Conexion.Close()

    End Sub

    Public Sub Insertar(ByVal empleado As CEEmpleado)

        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "INSERT INTO `empleados` (`nombre`,`apellido`,`foto`) 
                               VALUES ('" & empleado.Nombre & "', '" & empleado.Apellido & "', 
                               '" & MySql.Data.MySqlClient.MySqlHelper.EscapeString(empleado.Foto) & "');"
        Dim Comando As New MySqlCommand(Query, Conexion)
        Comando.ExecuteNonQuery()
        Conexion.Close()
        MessageBox.Show("Registro Creado")

    End Sub

    Public Sub Modificar(ByVal empleado As CEEmpleado)
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "UPDATE `empleados` SET `nombre`='" & empleado.Nombre & "', `apellido`='" & empleado.Apellido & "',
                               `foto`='" & MySql.Data.MySqlClient.MySqlHelper.EscapeString(empleado.Foto) & "' 
                               WHERE  `id`=" & empleado.Id & ";"

        Dim Comando As New MySqlCommand(Query, Conexion)
        Comando.ExecuteNonQuery()
        Conexion.Close()
        MessageBox.Show("Registro Editado")
    End Sub
    Public Sub Eliminar(ByVal empleado As CEEmpleado)
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "DELETE FROM `empleados` WHERE  `id`=" & empleado.Id & ";"
        Dim Comando As New MySqlCommand(Query, Conexion)
        Comando.ExecuteNonQuery()
        Conexion.Close()
        MessageBox.Show("Registro Eliminado")
    End Sub

    Public Function Listar() As DataSet

        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "SELECT * FROM `empleados` LIMIT 1000;"
        Dim Adapatador As MySqlDataAdapter
        Dim dataSet As New DataSet

        Adapatador = New MySqlDataAdapter(Query, Conexion)
        Adapatador.Fill(dataSet, "Empleado")

        Return dataSet

    End Function

End Class
