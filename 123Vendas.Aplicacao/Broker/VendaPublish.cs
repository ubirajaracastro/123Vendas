using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v123Vendas.Aplicacao.Broker
{
    public class VendaPublish
    {
        private readonly string _connectionString;
        private readonly string _queueName;


        public VendaPublish(string connectionString, string queueName)
        {
            _connectionString = connectionString;
            _queueName= queueName;  
                
        }


        public async Task PublishVendaAsync(VendaFila venda, string tipoEvento)
        {
            ServiceBusClient client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(_queueName);

            var saleMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(venda.ToString()));
            //await sender.SendMessageAsync(saleMessage);

            Console.WriteLine(tipoEvento + venda.Id);
        }

    }



    public class VendaFila
    {
        public string Id { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Product: {Produto}, Amount: {Preco}";
        }
    }
}
