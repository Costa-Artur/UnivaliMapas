using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnivaliMapas.Api.Entities;

public class Sala
{
    public int SalaId { get; set; }
    public int Number { get; set; }
    public Bloco? Bloco { get; set; }
    public int BlocoId { get; set; }
}