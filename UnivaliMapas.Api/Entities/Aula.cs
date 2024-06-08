namespace UnivaliMapas.Api.Entities
{
    public class Aula
    {
        public int AulaId { get; set; }
        public DateTime  Data { get; set; }
        public Materia? Materia { get; set; }
        public int MateriaId { get; set; }
        public Sala? Sala { get; set; }
        public int SalaId { get; set; }
    }
}