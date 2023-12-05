using BlazorApp2.DataBase;
using Microsoft.AspNetCore.Mvc;

public class EstudiantesController : ControllerBase
{
    private readonly ConexionBaseDeDatos _conexionDB;

    public EstudiantesController(ConexionBaseDeDatos conexionDB)
    {
        _conexionDB = conexionDB;
    }

    [HttpPost]
    public IActionResult RegistrarEstudiante([FromBody] Estudiante estudiante)
    {
        try
        {
            _conexionDB.AbrirConexion();
            var cmd = _conexionDB.ObtenerConexion().CreateCommand();
            cmd.CommandText = "INSERT INTO estudiantes (Nombre, Apellido, FechaNacimiento, CI, Sexo) VALUES (@nombre, @apellido, @fechaNacimiento, @ci, @sexo)";
            cmd.Parameters.AddWithValue("@id_alumno", estudiante.id_alumno);
            cmd.Parameters.AddWithValue("@id_curso", estudiante.id_curso);
            cmd.Parameters.AddWithValue("@nombre_a", estudiante.nombre_a);
            cmd.Parameters.AddWithValue("@apellido_a", estudiante.apellido_a);
            cmd.Parameters.AddWithValue("@apellido2_a", estudiante.apellido2_a);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", estudiante.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@ci_a", estudiante.ci_a);
            cmd.Parameters.AddWithValue("sexo_a", estudiante.sexo_a);


            cmd.ExecuteNonQuery();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        finally
        {
            _conexionDB.CerrarConexion();
        }
    }
}