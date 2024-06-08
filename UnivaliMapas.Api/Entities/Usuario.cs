namespace UnivaliMapas.Api.Entities
{
    public class Usuario
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CodigoPessoa { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<Materia> MateriasMinistradas { get; set; } = new List<Materia>();
        public ICollection<Materia> MateriasAssistidas { get; set; } = new List<Materia>();
        public ICollection<AlunoMateria> AlunoMaterias { get; set; } = new List<AlunoMateria>();
    }
}