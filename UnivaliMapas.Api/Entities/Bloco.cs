using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnivaliMapas.Api.Entities;

public class Bloco
{
    public int BlocoID { get; set; }
    public char LetraBloco { get; set; }

    public ICollection<Sala> Salas = new List<Sala>();

}