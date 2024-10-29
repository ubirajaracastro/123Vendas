using AutoMapper;
using v123Vendas.Aplicacao.Broker;
using v123Vendas.Aplicacao.Contratos;
using v123Vendas.Aplicacao.Dtos;
using v123Vendas.Data.Contratos;
using v123Vendas.Dominio.Entidades;

namespace v123Vendas.Aplicacao.Services
{
    public class VendaService : IVendaService
    {
        public IGeralPersistencia _geralPersist { get; }
        public IVendaPersistencia _vendaPersist { get; } 
        private readonly IMapper _mapper;

        string connectionString = "YourServiceBusConnectionString";
        string queueName = "YourQueueName";


        public VendaService(IGeralPersistencia geralPersist,IVendaPersistencia vendaPersist,IMapper mapper)
        {
            _mapper=mapper;
            _vendaPersist = vendaPersist;
            _geralPersist = geralPersist;
        }

        public async Task<PedidoDto> AtualizarVenda(int vendaId, PedidoDto model)
        {
            try
            {
                var pedido = await _vendaPersist.ObterVendaPorIdAsync(vendaId);              
                model.PedidoId = pedido.PedidoId;

                _mapper.Map(model, pedido);
                _geralPersist.Update<Pedido>(pedido);

                await _geralPersist.SaveChangesAsync();    
                var retorno = await _vendaPersist.ObterVendaPorIdAsync(model.PedidoId);

                var fila = new VendaPublish(connectionString, queueName).PublishVendaAsync(new VendaFila{

                    Id = pedido.PedidoId.ToString()

                }, "Alteração de venda publicada na fila: ");

                return _mapper.Map<PedidoDto>(retorno);
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirVenda(int vendaId)
        {
            try
            {
                var pedido = await _vendaPersist.ObterVendaPorIdAsync(vendaId);
                if (pedido == null) throw new Exception("Venda não encontrada.");

                _geralPersist.Delete<Pedido>(pedido);

                  var fila = new VendaPublish(connectionString, queueName).PublishVendaAsync(new VendaFila
                  {

                      Id = pedido.PedidoId.ToString()

                  }, "Exclusão de venda publicada na fila: ");

                return await _geralPersist.SaveChangesAsync();             



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> IncluirVenda(PedidoDto model)
        {
            try    
            {
                var pedido = _mapper.Map<Pedido>(model);
                _geralPersist.Add<Pedido>(pedido);
                await _geralPersist.SaveChangesAsync();
                                          

                var vendaRetorno = await _vendaPersist.ObterVendaPorIdAsync(pedido.PedidoId);

                //simula publish no AzureServiceBus   

                var fila =new VendaPublish(connectionString,queueName).PublishVendaAsync(new VendaFila {              
                                        
                    Id= vendaRetorno.PedidoId.ToString()               
                
                },"Venda publicada na fila: ");

                return _mapper.Map<PedidoDto>(vendaRetorno);                 

             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
            
        }

        public async Task<PedidoDto[]> ObterVendas()
        {
            try
            {
                var pedidos = await _vendaPersist.ObterVendasAsync();              
                return _mapper.Map<PedidoDto[]>(pedidos);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> ObterVendasPorCodigo(int PedidoId)
        {
            try
            {
                var pedido = await _vendaPersist.ObterVendaPorIdAsync(PedidoId);              
                return _mapper.Map<PedidoDto>(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}