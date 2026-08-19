using _02_Application.DTOs;
using _02_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FuncionarioInputDto dto)
    {
        var result = await _service.CreateAsync(dto);

        // Retorna HTTP 201 (Created) com os dados recém-salvos
        return StatusCode(201, result);
    }
}