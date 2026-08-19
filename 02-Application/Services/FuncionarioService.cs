using _02_Application.DTOs;
using _02_Application.Interfaces;
using _04_Domain.Entities;
using _04_Domain.Interfaces;

namespace _02_Application.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<FuncionarioOutputDto> CreateAsync(FuncionarioInputDto dto)
    {
        var entity = new Funcionario
        {
            Nome = dto.Nome,
            Cargo = dto.Cargo,
            Salario = dto.Salario,
            Departamento = dto.Departamento
        };

        var created = await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return new FuncionarioOutputDto
        {
            Id = created.Id,
            Nome = created.Nome,
            Cargo = created.Cargo,
            Salario = created.Salario,
            Departamento = created.Departamento,
            Ativo = created.Ativo
        };
    }

    public Task<List<FuncionarioOutputDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<FuncionarioOutputDto> GetByIdAsync(int id) => throw new NotImplementedException();
    public Task UpdateAsync(int id, FuncionarioInputDto dto) => throw new NotImplementedException();
    public Task DeleteAsync(int id) => throw new NotImplementedException();
}