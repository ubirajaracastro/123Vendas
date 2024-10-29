using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Data.Contratos
{
    public interface IVendaPersistencia
    {
        Task<Pedido[]> ObterVendasAsync();
        Task<Pedido> ObterVendaPorIdAsync(int id);
       
        
    }
}