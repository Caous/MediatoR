# Framework MediatR 

Projeto com finalidade em mostrar a implementação do Framework MediatR disponível para tecnologias Microsoft.

![Command](https://refactoring.guru/images/patterns/content/command/command-comic-1.png?id=551df832f445080976f3116e0dc120c9)


### <h2>Fala Dev, seja muito bem-vindo
   Está POC é para mostrar como podemos implementar o <b>Framework MediatR</b> em diversos projetos, com adaptação para o cenário que você precisa, ou até mesmo combinação de Patterns diferentes, também te explico o que é o MediatR e como usar em diversas situações. Espero que encontre o que procura. <img src="https://media.giphy.com/media/WUlplcMpOCEmTGBtBW/giphy.gif" width="30"> 
</em></p></h5>
  
  </br>
  


<img align="right" src="https://refactoring.guru/images/patterns/content/command/command-pt-br.png?id=36096f8c2cd7783284eb80ce92db1a96" width="400" height="400"/>


</br></br>

### <h2>MediatR <a href="https://github.com/jbogard/MediatR" target="_blank"><img alt="MediatR" src="https://img.shields.io/badge/MediatR-blue?style=flat&logo=google-chrome"></a>

 <a href="https://jimmybogard.com/tag/mediatr/" target="_blank">Framework MediatR </a> uma biblioteca desenvolvida por Jimmy Bogard o mesmo criador do AutoMapper <b> combina o Design Pattern Mediator, juntamente com Command e mais alguns, para chegar a uma implementação sucinta e fácil para os nossos códigos</b>, sendo assim podemos fazer diversas implementações com benefícios de desacoplamento de código e seguindo um dos principios do SOLID.
 
<b>Objetivo MediatR</b> Pense que você tem um sistema que contém diversos setores (Telas), esses setores trabalham com suas regras que vamos denominar aqui de: <b>Regra de Negócio ou Domain</b>, sendo assim pense que a Tela A necessita de um processamento ou até mesmo de uma informação que só contém na Tela B, cada tela contém sua regra de negócio, desta forma precisamos nos comunicar entre eles, agora pense em um sistema muito grande, por exemplo um e-commerce o um sistema bancário, que contém diversas regras, validações etc... Para nosso código não ficar aquela salada de fruta aonde a Tela A vai conhecer a Tela B, Tela G, Tela Z, podemos ter um centralizador, ou como falamos um mediador, onde ele será responsável por chamar cada parte do sistema, sendo assim evitamos acoplamentos enormes, o mediador irá conhecer todas as telas, mas cada tela conhece-rá apenas o mediador.
   
Sendo assim costumo dizer que o MediatR contêm dois Patterns principais implementados nele:
   
   <b>[Design Pattern Mediator]</b> tem como objetivo centralizar códigos que precisam de complemento de outros, ou seja, uma ação quando solicitada, precisar processar outro código/classe, ao invés de termos uma classe chamando a outra, temos um centralizador. Desta forma pense que o Mediator é uma forma de arbitro pronto para orquestra o jogo da forma que precisa, ele é responsável por cada ação que acontece, ou seja, se uma falta for cometida ele dá um cartão, advertência, se alguém for ser trocado durante o jogo, ele também irá orquestrar e chamar os responsáveis para tal ação acontecer com sucesso.
   
   <b>[Design Pattern Command]</b> tem como objetivo utilizar um pedido da aplicação para transformar em um objeto, recebendo os parâmetros para aquele objeto. Essa transformação permite que você parametrize métodos com diferentes pedidos, atrase ou coloque a execução do pedido em uma fila, e suporte operações que não podem ser feitas.   

Legal né? Mas agora a pergunta é como posso usar o Command? Abaixo dou um exemplo de caso de uso.

</br></br>

### <h2>[Cenário de Uso]
Vamos imaginar o seguinte cenário, você tem uma API Rest <b>que gerencia seu cliente</b>, desta forma, sendo assim você precisa fazer várias coisas com seu cliente, como <b>alterar, cadastrar, excluir, listar, filtrar etc...</b> Então vamos colocar a mão na massa para esse código rodar

### <h2> Criação de Classes

Vamos criar a classe command que é responsável por iniciar e configurar os commandos
```C#
public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
```

Próxima etapa é criarmos interface com os comandos que teremos.
```C#

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly IRepository<Customer> _repository;

    public CreateCustomerHandler(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer(Guid.Empty, request.Name, request.LastName, request.Email);

        _repository.Save(customer);

        return Task.Run(() => new CreateCustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            DateRegister = customer.DateRegister
        });
    }
}
```
</br>

Agora vamos criar as classes que vão conter a implementação dos comandos mas não a verdadeira regra de negócio
```C#
  [HttpPost]
        public IActionResult Post([FromBody] CreateCustomerRequest command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }
```

E <b> neste caso não criamos uma receive por não ter necessidade de abstrair a regra de negócio</b> por ultimo a implementação.

```C#
Alexa invoke = new Alexa();

Guid guid = Guid.NewGuid();

invoke.SetStarCommand(new CoffePotCommand(new Coffe(guid, ETypeCoffe.Express)));

invoke.ExecuteCommand();

invoke.UndoCommand();

guid = Guid.NewGuid();

invoke.SetStarCommand(new TvCommand(new Tv(guid, "bedroom")));

invoke.ExecuteCommand();

invoke.UndoCommand();

guid = Guid.NewGuid();

invoke.SetStarCommand(new LightOnCommand(new Light(guid, "bathroom")));

invoke.ExecuteCommand();

invoke.UndoCommand();

```


### <h5> [IDE Utilizada]</h5>
![VisualStudio](https://img.shields.io/badge/Visual_Studio_2019-000000?style=for-the-badge&logo=visual%20studio&logoColor=purple)

### <h5> [Linguagem Programação Utilizada]</h5>
![C#](https://img.shields.io/badge/C%23-000000?style=for-the-badge&logo=c-sharp&logoColor=purple)

### <h5> [Versionamento de projeto] </h5>
![Github](http://img.shields.io/badge/-Github-000000?style=for-the-badge&logo=Github&logoColor=green)

</br></br></br></br>


<p align="center">
  <i>🤝🏻 Vamos nos conectar!</i>

  <p align="center">
    <a href="https://www.linkedin.com/in/gusta-nascimento/" alt="Linkedin"><img src="https://github.com/nitish-awasthi/nitish-awasthi/blob/master/174857.png" height="30" width="30"></a>
    <a href="https://www.instagram.com/gusta.nascimento/" alt="Instagram"><img src="https://github.com/nitish-awasthi/nitish-awasthi/blob/master/instagram-logo-png-transparent-background-hd-3.png" height="30" width="30"></a>
    <a href="mailto:caous.g@gmail.com" alt="E-mail"><img src="https://github.com/nitish-awasthi/nitish-awasthi/blob/master/gmail-512.webp" height="30" width="30"></a>   
  </p>
