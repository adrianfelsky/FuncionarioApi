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
        var entity = MapearParaEntidade(dto);
        var created = await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return MapearParaOutput(created);
    }
    public async Task<List<FuncionarioOutputDto>> GetAllAsync()
    {
        var funcionarios = await _repository.GetAllAsync();
        var listaDto = new List<FuncionarioOutputDto>();

        foreach (var f in funcionarios)
        {
            listaDto.Add(MapearParaOutput(f));
        }

        return listaDto;
    }

    public async Task<FuncionarioOutputDto> GetByIdAsync(int id)
    {
        var funcionario = await _repository.GetByIdAsync(id);

        if (funcionario == null)
            throw new KeyNotFoundException("Funcionário não encontrado."); 

        return MapearParaOutput(funcionario);
    }
    public Task UpdateAsync(int id, FuncionarioInputDto dto) => throw new System.NotImplementedException();
    public Task DeleteAsync(int id) => throw new System.NotImplementedException();
    private Funcionario MapearParaEntidade(FuncionarioInputDto dto)
    {
        return new Funcionario
        {
            Nome = dto.Nome,
            Cargo = dto.Cargo,
            Salario = dto.Salario,
            Departamento = dto.Departamento
        };
    }

    private FuncionarioOutputDto MapearParaOutput(Funcionario entity)
    {
        return new FuncionarioOutputDto
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Cargo = entity.Cargo,
            Salario = entity.Salario,
            Departamento = entity.Departamento,
            Ativo = entity.Ativo
        };
    }
}