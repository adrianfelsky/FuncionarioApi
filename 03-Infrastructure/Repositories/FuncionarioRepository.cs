using _03_Infrastructure.Data;
using _04_Domain.Entities;
using _04_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Funcionario>> GetAllAsync()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
    }

    public void Update(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
    }
    public void Delete(Funcionario funcionario) => throw new System.NotImplementedException();
}