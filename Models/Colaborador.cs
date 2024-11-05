// Models/Colaborador.cs
namespace CrudApi.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsProfesor { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
