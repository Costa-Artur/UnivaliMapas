using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnivaliMapas.Api.Entities;

public class Bloco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlocoID { get; set; }

    [Required]
    public char LetraBloco { get; set; }

    public ICollection<Sala> Salas = new List<Sala>();

}