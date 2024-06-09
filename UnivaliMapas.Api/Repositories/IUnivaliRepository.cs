using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Repositories;

public interface IUnivaliRepository
{
    Task<Sala?> GetSalaByIdAsync(int blocoID, int salaId);
    
    void DeleteSala(Sala sala);
    void AddSala(Sala sala);
    Task<bool> SaveChangesAsync();
    void UpdateSala(Sala sala, SalaForUpdateDto salaForUpdateDto);
    Task<Bloco?> GetBlocoByIdAsync(int blocoId);
    Task<Bloco?> GetBlocoWithSalaByIdAsync(int blocoId);
    void AddBloco (Bloco bloco);
    void DeleteBloco(Bloco bloco);
    void UpdateBloco(Bloco bloco, BlocoForUpdateDto blocoForUpdate);

    void AddUser(Usuario user);
    Task<Usuario?> GetUserByIdAsync(int userId);
    Task<ICollection<Usuario>?> GetUsersAsync();
    Task<ICollection<Aula>?> GetAulasByStudentIdAsync(int studentId);
    void AddAula (Aula aula);
    void UpdateAula(Aula aula, AulaForUpdateDto aulaForUpdateDto);
    Task<Aula?> GetAulaByIdAsync(int aulaId);
}