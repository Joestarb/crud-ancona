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

    public class Profesor
    {
        public int Id { get; set; }
        public int FkColaborador { get; set; }  // Relación con la tabla Colaboradores
        public string Correo { get; set; }
        public string Departamento { get; set; }

        public Colaborador Colaborador { get; set; }  // Relación con el modelo Colaborador
    }

    public class Administrativo
    {
        public int Id { get; set; }
        public int FkColaborador { get; set; }  // Relación con la tabla Colaboradores
        public string Correo { get; set; }
        public string Puesto { get; set; }
        public string Nomina { get; set; }  // Número de nómina

        public Colaborador Colaborador { get; set; }  // Relación con el modelo Colaborador
    }
}
