using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnivaliMapas.Api.Entities;

public class Sala
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SalaId { get; set; }

    [Required]
    public int Number { get; set; }
}