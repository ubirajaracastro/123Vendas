using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Aplicacao.Dtos
{
    public class PedidoDto
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemDto> Itens { get; set; }
        
    }
}