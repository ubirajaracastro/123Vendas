using Microsoft.AspNetCore.Mvc;
using v123Vendas.Aplicacao.Contratos;
using v123Vendas.Aplicacao.Dtos;
using Serilog;

namespace v123Vendas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{   

    //private readonly ILogger<VendaController> _logger;
    private readonly IVendaService _vendaService;

    public VendaController(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }


    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            Log.Information("Obtendo Vendas");
            var vendas = await _vendaService.ObterVendas();
            if (vendas == null) return NotFound("Nenhuma venda encontrada.");

            return Ok(vendas);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return StatusCode(500, $"Erro ao tentar recuperar vendas. Erro: {ex.Message}");
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        try
        {
            Log.Information("Obtendo Vendas por Codigo");
            var pedido = await _vendaService.ObterVendasPorCodigo(id);
            if (pedido == null) return NotFound("Venda não encontrada.");

            return Ok(pedido);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return StatusCode(500, $"Erro ao tentar recuperar venda. Erro: {ex.Message}");
        }
    }


    [HttpPost]
    public async Task<ActionResult> Post(PedidoDto model)
    {
        try
        {
            Log.Information("Registrando venda.");
            var venda = await _vendaService.IncluirVenda(model);
            if (venda == null) return NoContent();

            return Ok(venda);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return StatusCode(500, $"Erro ao tentar adicionar a venda. Erro: {ex.Message}");
        }
    }


    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            Log.Information("Excluindo venda.");
            var pedido = await _vendaService.ObterVendasPorCodigo(id);
            if (pedido == null) return NoContent();

            return await _vendaService.ExcluirVenda(id)
                  ? Ok(new { message = "Deletado" })
                  : throw new Exception("Ocorreu um problema ao tentar deletar a venda.");

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return StatusCode(500, $"Erro ao tentar deletar venda. Erro: {ex.Message}");
        }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, PedidoDto model)
    {
        try
        {
            Log.Information("Alterando venda.");
            var pedido = await _vendaService.AtualizarVenda(id, model);
            if (pedido == null) return NoContent();

            return Ok(pedido);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return this.StatusCode(500,
                $"Erro ao tentar atualizar venda. Erro: {ex.Message}");
        }
    }


}
