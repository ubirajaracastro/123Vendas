using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Aplicacao.Dtos
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        //public PedidoDto Pedido { get; set; }
        //public ProdutoDto Produto { get; set; }
        public int Cancelado { get; set; }
    }
}
