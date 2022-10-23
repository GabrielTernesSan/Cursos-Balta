## Domínios Ricos vs Domínios Anêmicos

### Domínios Anêmicos

Um modelo anêmico é um modelo sem comportamentos onde só temos a definição das propriedades sem nenhuma regra de negócio.

`````c#
public class Cliente
{
	public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
}
`````

Nesses modelos, o cliente precisa interpretar o objetivo e o uso da classe e a lógica é enviada para outras classes, denominadas serviços da classe de domínio.

### Domínios Ricos

Um modelo de *domínio rico* é um modelo que esta mais ajustado à filosofia DDD, onde temos uma classe definida com comportamentos e não apenas com *gets e sets.* Em um modelo de domínio rico as entidades precisam implementar o comportamento, além de implementar os atributos de dados.

````c#

    public class Pedido
    {
        public Pedido(int pedidoId, DateTime pedidoData, int clienteId )
        {
            PedidoItens = new List<Item>();

            PedidoId = pedidoId;
            PedidoData = pedidoData;
            ClienteId = clienteId;
        }
        private int _pedidoId;
        public int PedidoId
        {
            get => this._pedidoId;
            private set 
            {
                if (_pedidoId < 0)
                    throw new ArgumentNullException(nameof(PedidoId), 
                          "Código do pedido não pode ser negativo");
            }
        }
        private DateTime _pedidoData;
        public DateTime PedidoData {
            get => this._pedidoData;
            private set { 
                if(_pedidoData < DateTime.Now)
                    throw new ArgumentNullException(nameof(PedidoData),
                          "Data do pedido não pode ser anterior a data atual");
            }
        }
        private int _clienteId;
        public int ClienteId {
            get => this._clienteId;
            private set
            {
                if (_clienteId < 0)
                    throw new ArgumentNullException(nameof(ClienteId),
                          "Código do cliente não pode ser negativo");
            }
        }
        public List<Item> PedidoItens { get; set; }
    }
````

