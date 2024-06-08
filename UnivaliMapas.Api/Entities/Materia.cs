namespace UnivaliMapas.Api.Entities
{
    public class Materia
    {
        public int MateriaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Usuario? Professor { get; set; }
        public int ProfessorId { get; set; }
        public ICollection<Usuario> Alunos { get; set; } = new List<Usuario>();
        public ICollection<AlunoMateria> AlunoMaterias { get; set; } = new List<AlunoMateria>();
        public ICollection<Aula> Aulas { get; set; } = new List<Aula>();
    }
}