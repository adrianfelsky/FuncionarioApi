using _02_Application.DTOs;
using _02_Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _01_Presentation.Controllers;

[ApiController]
[Route("api/funcionarios")]
public class FuncionariosController : ControllerBase
{
    private readonly IFuncionarioService _service;

    public FuncionariosController(IFuncionarioService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra um novo funcionário no sistema.
    /// </summary>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(FuncionarioOutputDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post([FromBody] FuncionarioInputDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Lista todos os funcionários cadastrados.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<FuncionarioOutputDto>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Busca um funcionário específico pelo seu ID.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FuncionarioOutputDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Atualiza os dados de um funcionário existente.
    /// </summary>
    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Put(int id, [FromBody] FuncionarioInputDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Remove um funcionário do banco de dados.
    /// </summary>
    [Authorize]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}