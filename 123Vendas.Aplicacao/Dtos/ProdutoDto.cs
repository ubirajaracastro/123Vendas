using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Aplicacao.Dtos
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public ICollection<ItemDto> Itens { get; set; }

    }
}
