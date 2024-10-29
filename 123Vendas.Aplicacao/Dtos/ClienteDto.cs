using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Aplicacao.Dtos
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ICollection<PedidoDto> Pedidos { get; set; }

    }
}