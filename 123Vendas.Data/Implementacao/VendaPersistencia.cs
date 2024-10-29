using Microsoft.EntityFrameworkCore;
using v123Vendas.Data.Contexto;
using v123Vendas.Data.Contratos;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Data.Implementacao
{
    public class VendaPersistencia : GeralPersistencia,IVendaPersistencia
    {
        private readonly VendasDBContext _contexto;
        public VendaPersistencia(VendasDBContext contexto):base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<Pedido> ObterVendaPorIdAsync(int id)
        {
            IQueryable<Pedido> query = _contexto.tblPedido.AsNoTracking()
            .Include(e => e.Itens);
            

            query = query.Where(v=>v.PedidoId==id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido[]>ObterVendasAsync()
        {
            IQueryable<Pedido> query = _contexto.tblPedido.AsNoTracking()
            .Include(e => e.Itens);          
            
            

            return await query.ToArrayAsync();
        }
    }
}