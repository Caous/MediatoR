# Framework MediatR 

Projeto com finalidade em mostrar a implementação do Framework MediatR disponível para tecnologias Microsoft.

![MediatR](https://user-images.githubusercontent.com/38294660/236552188-58a48d2d-5927-4b41-b0dc-942495a443a6.png)



### <h2>Fala Dev, seja muito bem-vindo
   Está POC é para mostrar como podemos implementar o <b>Framework MediatR</b> em diversos projetos, com adaptação para o cenário que você precisa, ou até mesmo combinação de Patterns diferentes, também te explico <b>o que é o MediatR</b> e como usar em diversas situações. Espero que encontre o que procura. <img src="https://media.giphy.com/media/WUlplcMpOCEmTGBtBW/giphy.gif" width="30"> 
</em></p></h5>
  
  </br>
  


<img align="right" src="https://methodpoet.com/wp-content/uploads/2022/06/mediator-pattern-solution.png" width="300" height="300"/>


</br></br>

### <h2>MediatR <a href="https://github.com/jbogard/MediatR" target="_blank"><img alt="MediatR" src="https://img.shields.io/badge/MediatR-blue?style=flat&logo=google-chrome"></a>

 <a href="https://jimmybogard.com/tag/mediatr/" target="_blank">Framework MediatR </a> uma biblioteca desenvolvida por Jimmy Bogard o mesmo <b>criador do AutoMapper, MediatR combina o Design Pattern Mediator, juntamente com Command e mais alguns, para chegar a uma implementação sucinta e fácil para os nossos códigos</b>, sendo assim podemos fazer diversas implementações com benefícios de desacoplamento de código e seguindo um dos princípios do SOLID.
 
<b>Objetivo MediatR</b> Pense que você tem um sistema que contém diversas <b>TELAS</b>, essas telas trabalham com suas regras que vamos denominar aqui de  <b>Regra de Negócio ou Domain</b>, sendo assim pense que a Tela A necessita de um processamento ou até mesmo de uma informação que só contém na Tela B, cada tela contém sua regra de negócio, desta forma precisamos nos comunicar entre eles, mas <b>como vamos se comunicas sem que a tela A conheça a Tela B?</b>, agora pense em um sistema muito grande, por exemplo um e-commerce, um sistema bancário, que contém diversas regras, validações etc... Para nosso código não ficar aquela salada de fruta aonde a Tela A vai conhecer a Tela B, Tela G, Tela Z, podemos ter um centralizador, ou como falamos um mediador, onde ele será responsável por chamar cada parte do sistema, sempre que solicitado, sendo assim evitamos acoplamentos enormes e seguimos princípios de programação, o mediador irá conhecer todas as telas, mas cada tela conhecerá apenas o mediador.
   
O MediatR trabalha basicamente temos dois componentes principais chamados de Request e Handler, que implementamos através das interfaces IRequest e IRequestHandler<TRequest> respectivamente.

   <b>Request → mensagem que será processada.</b><br>
   <b>Handler → responsável por processar determinada(s) mensagen(s).</b>
   
Não confunda o Request do MediatR com um request HTTP. Request é o nome usado pelo MediatR para descrever uma mensagem que será processada por um Handler. Além disso, algumas literaturas usam o termo Command para descrever essas mensagens, eu mesmo ainda uso esse termo de vez em quando.
   
Sendo assim costumo dizer que o MediatR contêm dois Patterns principais implementados nele:
   
   <b>[Design Pattern Mediator]</b> tem como objetivo centralizar códigos que precisam de complemento de outros, ou seja, uma ação quando solicitada, precisar processar outro código/classe, ao invés de termos uma classe chamando a outra, temos um centralizador. Desta forma pense que o Mediator é uma forma de arbitro pronto para orquestra o jogo da forma que precisa, ele é responsável por cada ação que acontece, ou seja, se uma falta for cometida ele dá um cartão, advertência, se alguém for ser trocado durante o jogo, ele também irá orquestrar e chamar os responsáveis para tal ação acontecer com sucesso.
   
   <b>[Design Pattern Command]</b> tem como objetivo utilizar um pedido da aplicação para transformar em um objeto, recebendo os parâmetros para aquele objeto. Essa transformação permite que você parametrize métodos com diferentes pedidos, atrase ou coloque a execução do pedido em uma fila, e suporte operações que não podem ser feitas.   


   
   
Legal né? Mas agora a pergunta é como posso usar o Command? Abaixo dou um exemplo de caso de uso.

</br></br>

### <h2>[Cenário de Uso]
Vamos imaginar o seguinte cenário, você tem uma API Rest <b>que gerencia seu cliente</b>, desta forma, você precisa fazer várias alterações com seu cliente, como <b>alterar, cadastrar, excluir, listar, filtrar etc...</b> Então vamos colocar a mão na massa para esse código rodar

### <h2> Criação de Classes

Vamos criar a classe de request que chegara por meio de um comando, configuramos também o seu retorno colocando a interface do MediatR IRequest, ela é responsável para o MediatR procurar suas classes equivalentes.
```C#
public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
```

Próxima etapa é criarmos o Handler no caso o nosso manipulador que será responsável por executar a criação do nosso usuário.
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

Por ultimo criamos nossa Controller com o método de criar usuário
```C#
[ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CreateCustomerRequest command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }
     }
```

Não podemos esquecer de configurar nosso Program.Cs para reconhecer e injetar o MediatR em nossa aplicação

```C#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Customer>,CustomerRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


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
