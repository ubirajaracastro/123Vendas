using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v123Vendas.Dominio.Entidades
{
    public class Item
    {
        public int ItemId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Pedido Pedido { get; set; }       
        public int Cancelado{ get; set; }
    }
}
