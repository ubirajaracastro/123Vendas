using Microsoft.EntityFrameworkCore;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Data.Contexto
{
    public class VendasDBContext:DbContext
    {
        #region Construtores
        public VendasDBContext()
        {          
            
        }

        public VendasDBContext(DbContextOptions<VendasDBContext> options):base(options)
        {
            
        }
        #endregion
         
          public DbSet<Pedido> tblPedido { get; set; }



     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Item>()
               .HasKey(p => p.ItemId);


            modelBuilder.Entity<Pedido>()
               .HasMany(p => p.Itens)
               .WithOne(p => p.Pedido);



        }
        
    }
}