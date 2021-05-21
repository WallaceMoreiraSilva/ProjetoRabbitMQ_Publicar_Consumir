# ProjetoRabbitMQ_Publicar_Consumir
Uso do rabbitMQ para publicar e consumir filas

# É necessario instalar o RabbitMQ na sua máquina => https://www.rabbitmq.com/#features 

A url do RabbitMQ para verificar a publicação e consumo das filas => http://localhost:15672/

obs: Padrão => login = guest, senha = guest

# É necessario instalar nos dois projetos o package => RabbitMQ.Client

Os dois Projetos Consoles são:

1) Publisher => Publicará as mensagens na fila

2) Consumer => Consumir as mensagens na Fila

#Abra o Prompt de Comando e vá até a pasta de cada projeto (onde esta o arquivo de projeto)

obs: Para voltar uma pasta cd ..
obs: Para entrar em uma pasta cd nomeDaPasta

1) Ir na pasta do Publisher, onde esta o arquivo de projeto, e digite o comando => dotnet run

2) Ir na pasta do Consumer, onde esta o arquivo de projeto, e digite o comando => dotnet run

#Prestar atencao nos seguintes campos : incoming, deliver/get, ack

1) Ao executar o comando na pasta de arquivo de projeto do Publisher e ir no site do RabbitMQ você verá que a fila foi criada e que 
    deliver/get e ack não estão preenchidos , ou seja, a mensagem foi publicada mas não consumida

2) Ao executar o comando na pasta de arquivo de projeto do Consumer e ir no site do RabbitMQ você verá que a fila esta criada e que 
    deliver/get e ack estão preenchidos , ou seja, a mensagem esta publicada e foi consumida
