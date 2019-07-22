# C# Evolution
08 Semanas de intensivo estudo e dedicação para evoluçõa técnica, aprimoramento de conceitos usando a linguagem C#, Sql, Lógia de Programação, Testes, Revisão de conceitos e outros conceitos.

## Instruções Básicas
* Todo resumo e parte conceitual devem estar no projeto na pasta de cada teste e exercio, já presente no projeto.
* Mesmo que a excplicação encontrada seja boa, tente descrever com suas proprias palavras de maneira mais resumida possivel. Nunca copie redigite, parece bobagem mas não é!
* Cite a fonte que você achou a explicação e tente elaborar sempre exemplo diferentes.
* Não pule etapas elas foram pensadas para serem feitas em sequência.
* Divirta-se e sempre vá alêm do que foi pedido! :)

## Cronograma inicial

### Semana 01 - Introdução Relampago :)
* **Sintaxe Básica 01:** **Namespaces**, **Classes**, **Structs**, **Principais Tipos Primitivos**, **Principais Tipos de Referência**, **Tipo de Acessibilidade(Classes e métodos)**.
* **Sintaxe Básica 02:** **Construtores**, **Destrutores**, **Condicionais**, **Loops**, **Interupção de Loops**, **Métodos**.
* **Teste 01 (Aritiméticos e Lógicos)** - **Console application** - Calculadora com as principais operações, e um simples menu. Dica exlore a classe console.
* Descrevar as principais funções e o que encontramos do ponto de vista macro (Só o que contém de forma mais abrangente) nos namespaces e destaque no mínimo 03 classes que podemos trabalhar em cada um deles: System.Text, System.Threading, System.Linq, System.IO, System.Data, System.Security, System.Diagnostics, System.Runtime, System.Globalization, System.Buffers;
* **Trabalhando com Parâmetros:** de entrada, de saida, objeto parâmetro, funções como pârametros, refletindo sobre efeitos colaterais (Imutabilidade e porque é importante).
* O que são e para que sevem Interfaces, e que são Generics?
* **Coleções 01 (System.Collections)** -  Arrays, Dictionary, SortedDictionary, HashSet, Listas, SortedList, Queues e Stack. Quais são as diferenças entre esses tipos, tem que métodos distintos, qual o uso indicado?
* **Teste 02** - **Console application** - Evolução da Calculadora Adicionando as operações: Potenciação, Raiz Quadrada e Cúbica, Calculo de Area de Algumas figuras(Triangulo, Quadrado, Circulo), Calculo de Volume em Metros Cubicos e Conversão de Base (Binário, Decimal e Hexadecimal).

> **Desafio Semana 01** - Criar um roteiro básico e gravar um resumo da semana (>= 20min), passando por cada tópico em sequência.

### Semana 02 - Rastreando Problemas e Revisitando Orientação a Objetos
* **Teste 03 Exceptions** - O que é uma exceção, como identificar onde podem ocorrer, explicar como aferam o fluxo de execução - Exemplo Implemmentar (Capturar, Lançar, Relançar e Suprimir)
* **Teste 04 [NullReferenceExceptions](https://www.thecodefreeze.com/dotnet/avoiding-null-in-csharp-code/)** - Implementar e expliciar formas de evitar, um dos maiores males do C# e Java.
* **Resumo Escrito de Conceitos:** Classes, Objetos, Encapsulamento, Herança, Adbstrações e Polimorfismo.
* **Teste 05 Encapsulamentos**, a arte de expor o que realmente importa - Criar exemplos dem um console que demonstre os conveitos de emcapsulamento.
* **Teste 06 Polimorfismos**, "Seja você mesmo, mas não seja sempre o mesmo"  - Criar um console com exemplo de criação de Interfaces, Classes Abstratas e Herança, demonstrando os conceitos.
* **Resumo Escrito a Mão de Conceitos:** Principios S.O.L.I.D (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion)

> **Desafio Semana 02** - Agora nossa calculadora precisa demonstrar os conceitos aprendidos até aqui, e suas metas são:
Separar cada tipo  de calculo em uma classe com essa responsabilidade, controlar as exceções que podem ocorrer e retornar mensagens amigáveis para cada calculo que sabe executar. É necessário também refinar sua implementação usando interface(s) para representar os calculos, depois disso através de uma estrutura condicional, decidir que implementação desta mesma interface deve ser instanciada para a execução do calculo.

### Semana 03 - Liberando Recursos utilizados e Trabalhando com Streams
* **Teste 07 A interface IDisposable e a palavra chave Using** - Entender o funcionammento e demonstrar em uma classe sua como implementar e liberar recursos quaisquer.
* **Teste 08 Diretórios** - Nevegar em diretórios e buscar arquivos  pelo nome e listar arquivos de um diretório. Dica classes: Path, Directory.
* **Explorar as Classes** : StringReader,  StreamReader, MemoryStream, FileStream - Resumir seus propositos e os principais recursos
* **Explorar as Classes** : StringWriter e  StreamWriter - Resumir seus propositos e os principais recursos
* **Actions e Funcs**: Explique o que é e parao que serem essas 2 classes
* **Teste 09 Crazy Things**: Demonstre, Explique e Diferencie  de forma simples a utilização de Events, Delegates, Expressions, Actions e Funcs, simplificando alguns pontos da sua calculadora, explique o porque dos pontos escolhidos e a tomada de decisão.
* **Instalar Nuget para MemoryCache**: `nuget install Microsoft.Extensions.Caching.Memory`

> **Desafio Semana 03** - Agora nossa calculadora terá 2 novas funções a primeira é salvar as operações em um MemoryCache a outra é a cada 10 calculos devemos salvar esses calculos com os resultados formatados em um arquivo.


Nº   | Operação | Parâmetros | Resultado |
-----|------------ | ------------- | -----------
001  |**Soma** | Parâmetros (A=10, B=20) | 30
002  | **Subtração** | Parâmetros (A=30, B=10) | 20


### Semana 04 - Primeiros acessos a dados
* Installar o SqlServer Localmente
* As interfaces IDBCommand, IDBConnection, suas implementação com o SQLServer
* **Teste 10 Demo Acesso a Dados** - Faça uma classe que seja capaz de conectar a uma base de dados, fazer uma consulta
* **Teste 11 os Joins** - Explique/Exemplifique com uma simples implementação os tipos de Joins.

```sql 
-- Consulta
Select FROM GetDate();
```

> **Desafio Semana 04** - Agora todas as nossas operações além de um cache em memória, vão ter uma pequena base de dados com a tabela de **MemoriaDeCalculo**, que reflete a mesma estrutura que criamos em memória. As operações de **Salvar** e **Listar** o histórico de calculos devem ser feitas, a operação de **Listar** deve exibir os calculos de forma do mais rescente para o mais antigo de 10 em 10, opcionalmente filtrando por operação.

### Semana 05 - Simplificando acesso a dados com o uso de um ORM
* **O que é um ORM e para que serve** - Reumo dos principais aspectos
* **O que é Entity Framework Core** - Reumo dos principais aspectos e Funcionalidades, e quais os propositos desse framework
* **Configurações Basicas** - As Classes DbContext e DBSet, configuração via código (EF Code First).
* **Teste 12 Acesso a dados aprimorado** - 2 Patterns **Repository** e o **UnitOfWork**, Descreva e implemente em poucas classes, com apenas uma entidade o uso desses 2 padrões e como eles trabalham juntos.
* **Teste 13 Um tapinha na performance** - Usando a classe StopWatch (`namespace System.Diagnostics`) e uma pitada de eventos sua interface que define um repositóriro deve implementar 2 eventos. OnStartExecution e OnFinishExecution que irão medir o tempo de acesso a dados, com isso é necessário imprimir o tempo de acesso a dado no console.

> **Desafio Semana 05** - Nada vai mudar em nossa calculadora Calculadora, ela só vai ser migrada para o EF Core usando os padrões aprendidos. Como bonus podemos colocar o log em uma tabela de PerformanceProfile para que possamos ver o log das consultas.

### Semana 06 - Nossa calculadora na Web, Introdução ao AspNet.Core
* **Revisando camada OSI** - Pipeline de uma requisição HTTP, Layers, DNS, LoadBalancer, HostWeb, SSL. Desenhe no draw.io e explique os principais conceitos.
* **Pipeline de uma Requisição Asp.Net Core** - Owin Middleware e o Pipeline do MVC até o objeto enviado em uma requisição chegar no controller. Explicar cada etapa do processo de maneira resumida.
* **IOptions e modelo de configuração no .NetCore** - Explique/Implemente exemplos de criar cessões de configuração por ambiente e por tipo, exemplo: Configuração de produção, de desenvolvimento e de testes.
* **Restfull Apis** - Principios, boas praticas e convenções. StatusCodes, Hipermedia, Verbos, Semantica, Design - **Base teórica**

> **Desafio Semana 06** - As operações de nossa API agora devem estar em uma API AspNet.Core com todo modelo de persistência que já implementamos salvando na base com EF Core.


### Semana 07 - Aprimorando qualidade com Testes de Unidade
* **A arte do Arrange, Act and Assert** - Dividir para conquitar, o mindset do testador e dividir o problema nas menores partes possíveis para testar.
* **Mocks e Stubs Testando o que importa** - Isolar as peças que queremos testar de forma isolada.
* **Não só o caminho Feliz** - Testar caminhos, passagem em métodos ecasos de exceção.

> **Desafio Semana 07** - Implementar testes de unidade nas operações da nossa calculadora.

### Semana 08 - Testes integrados e Revisão final

> **Desafio Semana 08** - Implementar testes integrados da nossa calculadora.


### Temas complementares

### Leituras Complementares

* https://blog.ploeh.dk/2015/04/13/less-is-more-language-features/
