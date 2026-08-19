using _03_Infrastructure.Data;
using _04_Domain.Entities;
using _04_Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _03_Infrastructure.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;

    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Funcionario> AddAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        return funcionario;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task<List<Funcionario>> GetAllAsync() => throw new System.NotImplementedException();
    public Task<Funcionario?> GetByIdAsync(int id) => throw new System.NotImplementedException();
    public void Update(Funcionario funcionario) => throw new System.NotImplementedException();
    public void Delete(Funcionario funcionario) => throw new System.NotImplementedException();
}