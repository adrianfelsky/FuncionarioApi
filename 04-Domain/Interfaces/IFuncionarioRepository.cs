using _04_Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _04_Domain.Interfaces;

public interface IFuncionarioRepository
{
    Task<List<Funcionario>> GetAllAsync();
    Task<Funcionario?> GetByIdAsync(int id);
    Task<Funcionario> AddAsync(Funcionario funcionario);
    void Update(Funcionario funcionario);
    void Delete(Funcionario funcionario);
    Task SaveChangesAsync();
}