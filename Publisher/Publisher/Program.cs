using System;
using System.Text;
using RabbitMQ.Client;

namespace Publisher
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

            //Criamos um canal onde vamos denifir uma fila, uma mensagem e publicar a mensagem
            using (var channel1 = connection.CreateModel())
            {
                //Declarando uma fila
                //queue => o nome da fila 
                //durable => se true a fila permanece ativa após o servidor ser reiniciado
                //exclusive => se true só pode ser acessada via conexão atual e sao excluídas ao fechar a conexão
                //autodelete => se true será deletada automaticamente após os consumidores usar a fila
                channel1.QueueDeclare(queue: "saudacao_1",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //Criamos a mensagem a ser posta na fila
                string message = "Bem vindo ao RabbitMQ";

                //Codificamos a mensagem como um array de bytes
                //A mensagem em rabbitMQ é um bloco de dados binario
                var body = Encoding.UTF8.GetBytes(message);

                //Publico a mensagem informando a fila e o corpo da mensagem
                channel1.BasicPublish(exchange: "",
                                        routingKey: "saudacao_1",
                                        basicProperties: null,
                                        body: body);

                Console.WriteLine($" [x] Enviada: {message}");

            }
        }
    }
}
