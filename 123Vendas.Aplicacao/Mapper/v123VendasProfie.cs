using AutoMapper;
using v123Vendas.Aplicacao.Dtos;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Aplicacao.Mapper
{
    public class v123VendasProfie:Profile
    {
        public v123VendasProfie() {
          
          CreateMap<Pedido, PedidoDto>().ReverseMap();
          CreateMap<Item, ItemDto>().ReverseMap();
         

        }
        
    }
}