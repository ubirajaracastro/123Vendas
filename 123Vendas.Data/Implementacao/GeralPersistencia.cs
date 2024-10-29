using v123Vendas.Data.Contexto;
using v123Vendas.Data.Contratos;

namespace v123Vendas.Data.Implementacao
{
    public class GeralPersistencia:IGeralPersistencia
    {
        private readonly VendasDBContext _context;
        public GeralPersistencia(VendasDBContext context)
        {
            _context = context;
        }
        
         public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
             _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
             return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}