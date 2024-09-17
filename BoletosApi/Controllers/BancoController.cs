using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;
using BoletosApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BoletosApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BancoController : ControllerBase
{
    private IBancoService _bancoService;

    public BancoController(IBancoService bancoService)
    {
        _bancoService = bancoService;
    }

    /// <summary>
    /// Obtém uma lista de todos os bancos.
    /// </summary>
    /// <returns>Uma lista de bancos.</returns>
    /// <response code="200">Retorna a lista de bancos com sucesso.</response>
    /// <response code="404">Nenhum banco encontrado.</response>
    [HttpGet]
    public async Task<IActionResult> ObterBancos()
    {
        var result = await _bancoService.ObterBancos();

        if (result == null || result.Count == 0)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    /// Obtém um banco específico pelo código.
    /// </summary>
    /// <param name="codigo">O código do banco a ser retornado.</param>
    /// <returns>O banco correspondente ao código fornecido.</returns>
    /// <response code="200">Retorna o banco correspondente ao código.</response>
    /// <response code="404">Banco não encontrado com o código fornecido.</response>
    [HttpGet("{codigo}")]
    public async Task<IActionResult> ObterBancoPorCodigo(string codigo)
    {
        var result = await _bancoService.ObterBancoPorCodigo(codigo);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    /// Cadastra um novo banco.
    /// </summary>
    /// <param name="bancoRequest">Os detalhes do banco a ser cadastrado.</param>
    /// <returns>Os detalhes do banco cadastrado.</returns>
    /// <response code="200">Retorna os detalhes do banco cadastrado.</response>
    /// <response code="400">Requisição inválida.</response>
    [HttpPost]
    public async Task<IActionResult> CadastrarBanco(BancoRequest bancoRequest)
    {
        var exists = await _bancoService.ObterBancoPorCodigo(bancoRequest.Codigo);

        if (exists != null)
        {
            return BadRequest("Ja existe um cadastro de banco com o código fornecido");
        }

        var result = await _bancoService.CadastrarBanco(bancoRequest);
        return Ok(result);
    }
}
