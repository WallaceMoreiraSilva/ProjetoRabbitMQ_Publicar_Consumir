using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Definimos uma conexão com um nó rabbitMQ em localhost
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            //Abrimos uma conexão com um nó rabbitMQ
            using (var connection = factory.CreateConnection())

            //Cria o canal na conexão para o operar no rabbitMQ
            using (var channel = connection.CreateModel())
            {
                //Declarando a fila a partir da qual vamos consumir as mensagens
                //queue => o nome da fila 
                //durable => se true a fila permanece ativa após o servidor ser reiniciado
                //exclusive => se true só pode ser acessada via conexão atual e sao excluídas ao fechar a conexão
                //autodelete => se true será deletada automaticamente após os consumidores usar a fila
                channel.QueueDeclare(
                    queue: "saudacao_1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                //Solicita a entrada das mensagens de forma assíncrona e fornece um retorno de chama. Ele faz isso atraves da classe EventingBasicConsumer
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();

                    //Recebe a mensagem da fila e converte para string. Porque ela vem como um array de bytes
                    var message = Encoding.UTF8.GetString(body); 

                    //Imprime no console a mensagem
                    Console.WriteLine($" [x] Recebida : {message}");
                };

                //Indica o consumo da mensagem no rabbitMQ
                channel.BasicConsume(
                    queue: "saudacao_1",
                    autoAck: true,
                    consumer: consumer
                );
            }
        }
    }
}
