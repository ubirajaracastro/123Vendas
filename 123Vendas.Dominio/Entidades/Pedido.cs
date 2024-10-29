using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace v123Vendas.Dominio.Entidades
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }      
        public StatusPedido Status { get; set; }
        public ICollection<Item> Itens { get; set; }
       
    }
}