using v123Vendas.Aplicacao.Dtos;

namespace v123Vendas.Aplicacao.Contratos
{
    public interface IVendaService
    {
        Task<PedidoDto> IncluirVenda(PedidoDto model);
        Task<PedidoDto> AtualizarVenda(int vendaId, PedidoDto model);
        Task<bool> ExcluirVenda(int vendaId);

        Task<PedidoDto[]> ObterVendas();      
        Task<PedidoDto> ObterVendasPorCodigo(int vendaId);
        
    }
}