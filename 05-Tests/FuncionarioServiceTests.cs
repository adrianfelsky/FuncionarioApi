using _02_Application.DTOs;
using _02_Application.Services;
using _04_Domain.Entities;
using _04_Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Xunit;

namespace _05_Tests;

public class FuncionarioServiceTests
{
    private readonly Mock<IFuncionarioRepository> _repositoryMock;
    private readonly FuncionarioService _service;

    public FuncionarioServiceTests()
    {
        _repositoryMock = new Mock<IFuncionarioRepository>();
        _service = new FuncionarioService(_repositoryMock.Object);
    }

    [Fact]
    public async Task DeveCriarFuncionarioComSucesso()
    {
        var inputDto = new FuncionarioInputDto
        {
            Nome = "João Silva",
            Cargo = "Desenvolvedor",
            Salario = 5000,
            Departamento = "TI"
        };

        var entidadeRetorno = new Funcionario
        {
            Id = 1,
            Nome = "João Silva",
            Cargo = "Desenvolvedor",
            Salario = 5000,
            Departamento = "TI"
        };

        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Funcionario>()))
                       .ReturnsAsync(entidadeRetorno);

        // Act 
        var resultado = await _service.CreateAsync(inputDto);

        // Assert 
        Assert.NotNull(resultado);
        Assert.Equal(1, resultado.Id);
        Assert.Equal("João Silva", resultado.Nome);
        _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeveBuscarFuncionarioPorId()
    {
        // Arrange
        var entidadeBanco = new Funcionario { Id = 5, Nome = "Maria Souza" };

        _repositoryMock.Setup(r => r.GetByIdAsync(5))
                       .ReturnsAsync(entidadeBanco);

        var resultado = await _service.GetByIdAsync(5);

        Assert.NotNull(resultado);
        Assert.Equal(5, resultado.Id);
        Assert.Equal("Maria Souza", resultado.Nome);
    }

    [Fact]
    public async Task DeveDarErroSeFuncionarioNaoExistir()
    {
        _repositoryMock.Setup(r => r.GetByIdAsync(999))
                       .ReturnsAsync((Funcionario?)null);

        var excecao = await Assert.ThrowsAsync<KeyNotFoundException>(
            () => _service.GetByIdAsync(999)
        );

        Assert.Equal("Funcionário não encontrado.", excecao.Message);
    }
}