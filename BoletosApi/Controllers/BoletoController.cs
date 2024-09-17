using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;
using BoletosApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoletosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoletoController : ControllerBase
{
    private readonly IBoletoService _boletoService;

    public BoletoController(IBoletoService boletoService)
    {
        _boletoService = boletoService;
    }

    /// <summary>
    /// Obtém um boleto específico pelo ID fornecido.
    /// </summary>
    /// <param name="boletoId">O ID do boleto a ser obtido.</param>
    /// <returns>Retorna o boleto correspondente ao ID fornecido.</returns>
    /// <response code="200">Retorna o boleto solicitado.</response>
    /// <response code="404">Se o boleto com o ID fornecido não for encontrado.</response>
    [HttpGet("{boletoId}")]
    public async Task<IActionResult> ObterBoleto(string boletoId)
    {
        var result = await _boletoService.ObterBoleto(boletoId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    /// Cadastra um novo boleto.
    /// </summary>
    /// <param name="boletoObj">O objeto do boleto a ser cadastrado.</param>
    /// <returns>Retorna o boleto cadastrado.</returns>
    /// <response code="200">Retorna o boleto cadastrado.</response>
    /// <response code="400">Se o objeto do boleto fornecido for inválido.</response>
    [HttpPost]
    public async Task<IActionResult> CadastrarBoleto([FromBody] BoletoRequest boletoObj)
    {
        if (boletoObj == null)
        {
            return BadRequest("Dados do boleto são inválidos.");
        }

        var result = await _boletoService.CadastrarBoleto(boletoObj);

        return Ok(result);
    }
}

