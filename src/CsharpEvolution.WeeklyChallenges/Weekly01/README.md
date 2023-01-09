﻿Namespaces

Utilizado para organizar as classes existentes numa aplicação.

Pode expressar o caminho completo até a classe como: System.Console.Writeline("Text") - System é o namespace que 
contém a classe Console e Writeline é mum método dessa classe, ou através da diretiva using - 
using System - declarada no topo da tela, dessa forma dispensa-se a declaração
do namespace System toda vez que a classe for usada, bastando digitar 'Console.Writeline("Text")'

Class 

Classe, ou tipo, é uma espécie de planta, blueprint, que define, normalmente, características e comportamentos que um objeto, que é uma instância de dita classe,
terá. É do tipo Reference type. Desta forma, a classe é uma receita, um objeto é a criação específica feita a partir deste mapa, única.
Estão contidas dentro de um namespace e suas propriedades e métodos são chamados de membros. Apresentam modificadores de acessibilidade
e podem ainda ser abstract (não podendo ser instanciadas), sealed (não podem ser herdadas) e static. Classes podem ser herdadas por outras classes.

Structs 

Sua estrutura é semelhante a das classes, no entanto é do tipo value type, possuindo em si seu valor na stack e não alocando no heap como
as classes, que apresentam uma ref que aponta para seus valores no heap. São estruturas mais simples
e úteis em casos como se deseja representar um para de coordenadas, ou uma par valor - chave em um dicionário
ou ainda um número complexo. Structs não podem ser herdados, são sempre sealed. Alguns exemplos corricqueiros que não nos damos conta 
e que são structs são, por exemplo, o tipo int, double e bool. São passados por cópia e não como ref, como já mencionado,
portanto, mudando seu valor, não mudam os valores das cópias, ao contrário do que acontece com reference types,
que apontam todos para o mesmo valor, mudando um, mudam todos.
Structs tb só podem ter construtores com parâmetros e todos os campos do struct devem ser definidos nesse construtor.

Tipos Primitivos

São aqueles do tipo Value Type e sua cópia é por value, ou seja, quando copiado o valor para a variável esta fica armazenada
na stack e se for feito uma cópia desta, a alteração de uma não altera o valor da outra. São exemplos de value type os structs,
int, bool, double, long, float, byte, short, float.

Tipos de Referência

São os tipos a que chamamos nomeadamente de objetos. Estes tem uma ref e um valor, a ref na stack aponta para os valores atribuídos
ao objeto na heap, de forma que se houver dois objetos e suas refs apontarem para os mesmos valores, a alteração em um implicará alteração
de todos que apontam para o mesmo lugar. 

Operadores

Podem ser dos seguintes tipos:

Operadores aritméticos  - que executam operações aritméticas com operandos numéricos   + - * /  ++ -- %
Operadores de comparação - que comparam operandos numéricos  =  >  <  != <= >=  
Operadores lógicos boolianos - que executam operações lógicas com bool operandos  && || == ^ !  &  | 
Operadores bit a bit e shift - que executam operações bit a bit ou shift com operandos dos tipos integrais
Operadores de igualdade - que verificam se seus operandos são iguais ou não

Níveis de Acessibilidade

Classes and Methods:
Public - o acesso não seja restrito em nenhuma parte do nosso código;
Internal - Acesso somente no mesmo namespace
Protected - possibilidade de acesso apenas dentro da própria classe ou dentro de 
uma classe derivada dessa mesma;
Protected Internal - somente no mesmo namespace, a própria classe e classes derivadas desta
Private Protected - Somente a classe e classes derivadas desta no mesmo assembly tem acesso, fora do assemblu, mesmo que derivem desta classe não
Private - Somente a classe tem acesso 

Construtores

São chamados sempre que classes ou structs são criados. Pode haver mais de um construtor na mesma classe 
com argumentos diferentes, permitem ao programador definir valores padrão e limite a instanciação.
Apresentam nome igual alo nome de seu tipo e não apresenta um tipo de retorno.

Destrutores

Ou Finalizadores são utilizados para executar limpeza final quando um objeto é coletado pelo Garbage 
Collector. Não podem ser definidos em structs (que são value de qualquer forma, GC limpam o heap), uma classe pode 
apenas ter um destrutor e estes não podem ser herdades ou apresentar sobrecarga. Não podem ser chamados e são
invocados automaticamente, não apresenta modificadores ou parâmetros.
Ex:
class Car
{
    ~Car()  // finalizer
    {
        // cleanup statements...
    }
}

Condicionais



Loops


Métodos

São blocos de código contendo uma série de instruções. O programa 
por sua vez executa as instruções quando é feita uma chamada para aquele método,
especificando argumentos necessários para o seu funcionamento. 
Quanto a sua assinatura:
Podem ser declarados em classes, records ou structs, apresentando acesso public ou private, o default
é private. Podem ainda ser abstract ou sealed e seu retorno default caso omitido é void.
É preciso um nome para o método e quaisquer parâmetros que se façam necessários, caso sejam.
Tais parâmetros ficam dentro dos parênteses do método, após seu nome, e são separados por vírgula.

podem ainda ser estáticos (fazendo ref ao nome do tipoao qual o método pertence)
ou de instância.

--------------------------------------------------------------------------------------
Namespaces

*System.Text

Contém classes que representam as codificações de caracteres ASCII e Unicode, classes base abstratas para 
conversão de blocos de caracteres entre blocos de bytes e uma classe auxiliar que manipula e formata objetos 
String sem criar instâncias de String intermediárias.

StringBuilder - Representa uma cadeia de caracteres MUTÁVEL. Desta forma, se o trabalho com strings exige sua constante 
manipuláção, e pelo fato de strings serem IMUTÁVEIS, fazer uso do StringBuilder gera muitas vantagens como a economia de recursos, por
exemplo, deixando de criar uma nova string toda vez que uma manipulação é feita.

Encoder - transforma uma sequência de caracteres em bytes

Decoder - Transforma uma sequência de bytes em caracteres

*System.Threading 

Fornece interfaces e classes do que permitem programação multithread. Além das classes para sincronizar as atividades 
de thread e acesso a dados (como Mutex, Monitor, Interlocked e AutoResetEvent e assim por diante), este namespace inclui 
uma classe ThreadPool que permite que você use um pool de threads fornecido pelo sistema e uma classe Timer que executa 
os métodos de retorno de chamada em threads do pool.

Thread - Cria e controla um thread, define sua prioridade e obtém seu status.

Timeout - Contém constantes que especificam intervalos de tempo limite infinitos. Essa classe não pode ser herdada.

Timer - Fornece um mecanismo para executar um método em um thread do pool de threads em intervalos especificados. 
Essa classe não pode ser herdada.

*System.Linq

Oferece classes e interfaces compatíveis com consultas que usam LINQ (Consulta Integrada à Linguagem).

Enumerable - Fornece um conjunto de métodos static (Shared no Visual Basic) para consultar objetos que implementam IEnumerable<T>.

Lookup - Representa uma coleção de chaves, cada uma mapeada para um ou mais valores.

*System.IO

Contém tipos que permitem ler e gravar em arquivos e fluxos de dados, e tipos que fornecem suporte básico de diretório e arquivo.

File - Fornece métodos estáticos para a criação, cópia, exclusão, deslocamento e abertura de um arquivo, além de ajudar na criação de 
objetos FileStream.

FileStream - Fornece um Stream para um arquivo, dando suporte a operações de leitura e gravação síncronas e assíncronas.

BufferedStream - Adiciona uma camada de armazenamento em buffer para ler e gravar operações em outro fluxo. 
Essa classe não pode ser herdada.

Path - Executa operações em instâncias de String que contêm informações de caminho de arquivo ou diretório. 
Essas operações são executadas de uma maneira em plataforma cruzada.

*System.Data

Fornece acesso a classes que representam a arquitetura de ADO.NET. ADO.NET permite que você crie componentes 
que gerenciam dados de várias fontes de dados com eficiência.

???

*System.Security

Fornece a estrutura subjacente do sistema de segurança do Common Language Runtime, incluindo classes base para permissões.

???

*System.Diagnostics 

Fornece classes que permitem que você interaja com processos do sistema, logs de eventos e contadores de desempenho.

StackTrace - Representa um rastreamento de pilha, que é uma coleção ordenada de um ou mais registros de ativação.

StopWatch - Fornece um conjunto de métodos e propriedades que você pode usar para medir com precisão o tempo decorrido.

*System.Runtime

???

*System.Globalization

Contém classes que definem informações relacionadas à cultura, incluindo idioma, país/região, calendários em uso, 
padrões de formato para datas, moeda, números e ordem de classificação para cadeias de caracteres. Essas classes são 
úteis para escrever aplicativos globalizados (internacionalizados). Classes como StringInfo e TextInfo fornecem funcionalidades 
avançadas de globalização, incluindo o processamento de elementos de texto e suporte substituto.

CultureInfo - Fornece informações sobre uma cultura específica (chamada de localidade para desenvolvimento de código não planejado). 
As informações incluem os nomes da cultura, o sistema de escrita, o calendário usado, a ordem de classificação das cadeias de 
caracteres e a formatação de datas e números.

DateTimeFormatInfo - Fornece informações específicas da cultura sobre o formato dos valores de data e hora.

*System.Buffers

Contém tipos usados na criação e no gerenciamento de buffers de memória, como aqueles representados por Span<T> e Memory<T>.

???

---------------------------------------------------------------------------------------------------------------------------------------

*Parameters

Input - They go in the method signature. Ex:  public void SomeFunction(string parameterToBePassed) { // some code }

Output - Ao invés de serem passados, são retornados. TryParse faz uso disso, por exemplo

int myOutputParameter;
var myBooleanVar = int.TryParse(someArgument, out myOutputParameter);

Pode tb ser 'montada', criada de forma custom, como em:

//
....Some code
//
int someInputParameter = 10;

public int MyMethod(out in someInputParameter)
{
    someInputParameter = 50; //a new valeu for this parameter
    
    return someInputParameter;//Setará a variável para o valor definido, pois 'somInputParameter' na assinatura está identificada como 'out' 
}

Object as a parameter - Essencialmente, inputs do tipo value type são passados via cópia, portanto não se alteram se manipulados dentro de um método.
Quando um object é passado (um reference type), qualquer alteração deste objeto resultará em alteração do objeto passado pois a referência 
aponta e atualiza para os mesmos valores na memória.

Função como parâmetro - Para fazer isso, utilizamos os delegates Func<T param, T Restult> (sendo o param o que vai ser passado e o Result o tipo
de retorno) ou Action<T param> (onde nbão temos um retorno).
Ex:
...
namespace pass_function_as_parameter
{
    class Program
    {
        static int functionToPass(int x)
        {
            return x + 10;
        }
        static void function(Func<int, int> functionToPass)
        {
            int i = functionToPass(22);
            Console.WriteLine("i = {0}", i);
        }
        static void Main(string[] args)
        {
            function(functionToPass);
        }
    }
}

e:
 
namespace pass_function_as_parameter
{
    class Program
    {
        static void functionToPass2(int x)
        {
            int increment = x + 10;
            Console.WriteLine("increment = {0}",increment);
        }
        static void function2(Action<int> functionToPass2)
        {
            functionToPass2(22);
        }
        static void Main(string[] args)
        {
            function2(functionToPass2);
        }
    }
}

*Interfaces

Uma interface contém definições para um grupo de funcionalidades relacionadas que uma class ou um struct podem implementar. 
Uma interface pode definir métodos static, que devem ter uma implementação. Uma interface pode definir uma implementação padrão para membros. 
Uma interface pode não declarar dados de instância, como campos, propriedades implementadas automaticamente ou eventos semelhantes a propriedades.
Usando interfaces, você pode, por exemplo, incluir o comportamento de várias fontes em uma classe. Essa funcionalidade é importante em C# porque 
a linguagem não dá suporte a várias heranças de classes. Além disso, use uma interface se você deseja simular a herança para structs, 
pois eles não podem herdar de outro struct ou classe.

*Generics

C# allows you to define generic classes, interfaces, abstract classes, fields, methods, static methods, properties, events, delegates, 
and operators using the type parameter and without the specific data type. A type parameter is a placeholder for a particular type specified 
when creating an instance of the generic type.
A generic type is declared by specifying a type parameter in an angle brackets after a type name, e.g. TypeName<T> where T is a type parameter.

*System Collections

Arrays - You can store multiple variables of the same type in an array data structure. You declare an array by specifying the type of its elements.
If you want the array to store elements of any type, you can specify object as its type. In the unified type system of C#, all types, 
predefined and user-defined, reference types and value types, inherit directly or indirectly from Object.
type[] arrayName;
int[] myArrayOfStrings = new int[] {2 , 3, 4 , 5};

Dictionary - 

TKey
The type of the keys in the dictionary.

TValue
The type of the values in the dictionary.

Ex: Dictionary<string, string> openWith =
    new Dictionary<string, string>();

// Add some elements to the dictionary. There are no
// duplicate keys, but some of the values are duplicates.
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");

keys are unique, values not necessarily. 

// The indexer can be used to change the value associated
// with a key.
openWith["rtf"] = "winword.exe";
Console.WriteLine("For key = \"rtf\", value = {0}.",
    openWith["rtf"]);

// If a key does not exist, setting the indexer for that key
// adds a new key/value pair.
openWith["doc"] = "winword.exe";

// The indexer throws an exception if the requested key is
// not in the dictionary.
try
{
    Console.WriteLine("For key = \"tif\", value = {0}.",
        openWith["tif"]);
}
catch (KeyNotFoundException)
{
    Console.WriteLine("Key = \"tif\" is not found.");
}

// When a program often has to try keys that turn out not to
// be in the dictionary, TryGetValue can be a more efficient
// way to retrieve values.
string value = "";
if (openWith.TryGetValue("tif", out value))
{
    Console.WriteLine("For key = \"tif\", value = {0}.", value);
}
else
{
    Console.WriteLine("Key = \"tif\" is not found.");
}

// ContainsKey can be used to test keys before inserting
// them.
if (!openWith.ContainsKey("ht"))
{
    openWith.Add("ht", "hypertrm.exe");
    Console.WriteLine("Value added for key = \"ht\": {0}",
        openWith["ht"]);
}

// When you use foreach to enumerate dictionary elements,
// the elements are retrieved as KeyValuePair objects.
Console.WriteLine();
foreach( KeyValuePair<string, string> kvp in openWith )
{
    Console.WriteLine("Key = {0}, Value = {1}",
        kvp.Key, kvp.Value);
}

// To get the values alone, use the Values property.
Dictionary<string, string>.ValueCollection valueColl =
    openWith.Values;

// The elements of the ValueCollection are strongly typed
// with the type that was specified for dictionary values.
Console.WriteLine();
foreach( string s in valueColl )
{
    Console.WriteLine("Value = {0}", s);
}

// To get the keys alone, use the Keys property.
Dictionary<string, string>.KeyCollection keyColl =
    openWith.Keys;

// The elements of the KeyCollection are strongly typed
// with the type that was specified for dictionary keys.
Console.WriteLine();
foreach( string s in keyColl )
{
    Console.WriteLine("Key = {0}", s);
}

// Use the Remove method to remove a key/value pair.
Console.WriteLine("\nRemove(\"doc\")");
openWith.Remove("doc");

if (!openWith.ContainsKey("doc"))
{
    Console.WriteLine("Key \"doc\" is not found.");
}

SortedDictionary - SortedDictionary is a generic collection which is used to store the key/value pairs in the sorted 
form and the sorting is done on the key.

ex:
using System.Collections.Generic;
  
class GFG {
  
    // Main Method
    static public void Main()
    {
  
        // Creating sorted dictionary
        // Using SortedDictionary class
        SortedDictionary<int, string> My_sdict = 
            new SortedDictionary<int, string>();
  
        // Adding key/value pair in Sorted 
        // Dictionary Using Add() method
        My_sdict.Add(004, "Ask.com");
        My_sdict.Add(003, "Yahoo");
        My_sdict.Add(001, "Google");
        My_sdict.Add(005, "AOL.com");
        My_sdict.Add(002, "Bing");
        Console.WriteLine("Top Search Engines:");
  
        // Accessing the key/value pair of the 
        // SortedDictionary Using foreach loop
        foreach(KeyValuePair<int, string> pair in My_sdict)
        {
            Console.WriteLine("Rank: {0} and Name: {1}",
                                  pair.Key, pair.Value);
        }
  
        // Creating another sorted dictionary
        // using SortedDictionary<TKey, TValue> class
        // adding key/value pairs
        // Using collection initializer
        SortedDictionary<int, string> My_sdict1 = 
              new SortedDictionary<int, string>() {
                                     {1, "Python"},
                                      {5, "Swift"},
                                 {2, "JavaScript"},
                                        {4, "Go" },
                                      {3, "Rust"}};
  
          
        Console.WriteLine("Top Programming Language in 2019: ");
  
        // Accessing the key/value pair of the 
        // SortedDictionary Using foreach loop
        foreach(KeyValuePair<int, string> pair in My_sdict1)
        {
            Console.WriteLine("Rank:{0} and Name: {1}",
                                 pair.Key, pair.Value);
        }
    }
}
The output brings the elements of the collection already in order using the key to define the sorting of said collection

Main methods to know about Dictionaries: Add(), Remove() and Clear().

Hashset - HashSet é uma coleção não ordenada de elementos exclusivos. Suporta a implementação de conjuntos e usa a tabela 
de hash para armazenamento. Fornece operações de conjunto de alto desempenho e desde o .NET 4.6 implementa IReadOnly.
Pode ser considerada como uma Dictionary<TKey,TValue> coleção sem valores.


Operação HashSet	    Equivalente matemático
UnionWith	            União ou adição de conjunto
IntersectWith	        Interseção
ExceptWith	            Definir subtração
SymmetricExceptWith	    Diferença simétrica

O exemplo a seguir demonstra como mesclar dois conjuntos diferentes. Este exemplo cria dois HashSet<T> objetos e os popula 
com números pares e ímpares, respectivamente. Um terceiro HashSet<T> objeto é criado a partir do conjunto que contém os números 
pares. Em seguida, o exemplo chama o UnionWith método, que adiciona o número ímpar definido ao terceiro conjunto.

HashSet<int> evenNumbers = new HashSet<int>();
HashSet<int> oddNumbers = new HashSet<int>();

for (int i = 0; i < 5; i++)
{
    // Populate numbers with just even numbers.
    evenNumbers.Add(i * 2);

    // Populate oddNumbers with just odd numbers.
    oddNumbers.Add((i * 2) + 1);
}

Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
DisplaySet(evenNumbers);

Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
DisplaySet(oddNumbers);

// Create a new HashSet populated with even numbers.
HashSet<int> numbers = new HashSet<int>(evenNumbers);
Console.WriteLine("numbers UnionWith oddNumbers...");
numbers.UnionWith(oddNumbers);

Console.Write("numbers contains {0} elements: ", numbers.Count);
DisplaySet(numbers);

void DisplaySet(HashSet<int> collection)
{
    Console.Write("{");
    foreach (int i in collection)
    {
        Console.Write(" {0}", i);
    }
    Console.WriteLine(" }");
}

List - Representa uma lista fortemente tipada de objetos que podem ser acessados por índice. 
Fornece métodos para pesquisar, classificar e manipular listas.
Para obter uma versão imutável da List<T> classe, consulte ImmutableList<T>.

ex: 

using System;
using System.Collections.Generic;
// Simple business object. A PartId is used to identify the type of part
// but the part name can change.
public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
    // Should also override == and != operators.
    }
public class Example
{
    public static void Main()
    {
        // Create a list of parts.
        List<Part> parts = new List<Part>();

        // Add parts to the list.
        parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
        parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
        parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
        parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
        parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
        parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

        // Write out the parts in the list. This will call the overridden ToString method
        // in the Part class.
        Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        // Check the list for part #1734. This calls the IEquatable.Equals method
        // of the Part class, which checks the PartId for equality.
        Console.WriteLine("\nContains(\"1734\"): {0}",
        parts.Contains(new Part { PartId = 1734, PartName = "" }));

        // Insert a new item at position 2.
        Console.WriteLine("\nInsert(2, \"1834\")");
        parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });

        //Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        Console.WriteLine("\nParts[3]: {0}", parts[3]);

        Console.WriteLine("\nRemove(\"1534\")");

        // This will remove part 1534 even though the PartName is different,
        // because the Equals method only checks PartId for equality.
        parts.Remove(new Part() { PartId = 1534, PartName = "cogs" });

        Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }
        Console.WriteLine("\nRemoveAt(3)");
        // This will remove the part at index 3.
        parts.RemoveAt(3);

        Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

            /*

             ID: 1234   Name: crank arm
             ID: 1334   Name: chain ring
             ID: 1434   Name: regular seat
             ID: 1444   Name: banana seat
             ID: 1534   Name: cassette
             ID: 1634   Name: shift lever
             /.../

       }
    }

    ----------------------
    *ORM

    Object-Relational Mapping (ORM), em português, mapeamento objeto-relacional, é uma técnica para aproximar o 
    paradigma de desenvolvimento de aplicações orientadas a objetos ao paradigma do banco de dados relacional. 
    O uso da técnica de mapeamento objeto-relacional é realizado através de um mapeador objeto-relacional que 
    geralmente é a biblioteca ou framework que ajuda no mapeamento e uso do banco de dados.

    Problema da impedância de dados
    Quando estamos trabalhando com aplicações orientadas a objetos que utilizam banco de dados relacionais para 
    armazenamento de informações, temos um problema chamado impedância objeto-relacional devido às diferenças entre 
    os 2 paradigmas.

    O banco de dados relacional trabalha com tabelas e relações entre elas para representar modelos da vida real. 
    Dentro das tabelas temos várias colunas e a unidade que temos para representação no modelo relacional é uma linha:

    O paradigma orientado a objetos possui um modo um pouco diferente de trabalhar. Nele nós temos diversos elementos 
    como classes, propriedades, visibilidade, herança e interfaces. A unidade quando falamos de orientação a objetos é 
    o objeto que representa algo do mundo real, seja abstrato ou concreto:

    As principais dificuldades que essas diferenças entre paradigmas causa:

    Representação dos dados e do modelo, já que as estruturas são distintas;
    Mapeamento entre os tipos de dados da linguagem de programação e do banco de dados;
    Modelo de integridade relacional do banco relacional;
    
    O ORM
    Pensando nos problemas descritos acima, o ORM define uma técnica para realizar a conciliação entre os 2 modelos. 
    Uma das partes centrais é através do mapeamento de linhas para objetos:

    As bibliotecas ou frameworks ORM definem o modo como os dados serão mapeados entre os ambientes, como serão acessados
    e gravados. Isso diminui o tempo de desenvolvimento, uma vez que não é necessário desenvolver toda essa parte. 
    Outra vantagem está na adaptação de novos membros na equipe, como muitos projetos comerciais utilizam a mesma 
    ferramenta, é possível encontrar membros que já estão acostumados com o padrão de trabalho.

    -Padrões utilizados no mercado
    Independente da linguagem de programação que o ORM é implementado, geralmente ele segue um padrão bem definido. 
    No mercado existem dois padrões que são amplamente utilizados, o Data Mapper e o Active Record. Ambos os padrões 
    foram definidos por Martin Fowler em seu livro Padrões de Arquitetura de Aplicações Corporativas.

    Data Mapper
    Nesse padrão a classe que representa a tabela do banco de dados não deve conhecer os recursos necessário para realizar 
    as transações com banco de dados: inserir, atualizar e apagar informações. Esses recursos ficam em uma classe própria 
    do ORM, garantindo que as classes que representam a tabela tenha uma única responsabilidade:

    Na prática, para a maioria dos ORMs do mercado que implementam o padrão Data Mapper, independente da linguagem, vamos ter 
    um código muito parecido com abaixo:

    EntityManager entityManager = Persistence.createEntityManagerFactory("persistente-unit");

    entityManager.getTransaction().begin();
    
    Pessoa pessoa = new Pessoa();
    pessoa.setId(1);
    pessoa.setSobrenome("Silva");
    pessoa.setPrenome("João");
    pessoa.setNumeroDeDependentes(2);
    
    entityManager.persist(pessoa);
    entityManager.getTransaction().commit();

    O código acima é um exemplo do Hibernate para Java.

    -Active Record
    Nesse padrão, diferentemente do anterior, a classe que representa a tabela conhece os recursos necessários 
    para realizar as transações no banco de dados, geralmente ela herda uma classe com todos esses comportamentos. 
    Veja abaixo um diagrama retirado do livro “Padrões de Arquitetura de Aplicações Corporativa”:

    Na maioria dos ORM que implementam o padrão Active Record teremos um código muito parecido com esse:

    pessoa = pessoa.new
    pessoa.sobrenome = "Silva"
    pessoa.prenome = "João"
    pessoa.numeroDeDependentes = 2
    
    pessoa.save()

    O código é válido para o ORM do Ruby On Rails.

    -Principais ORMs do mercado

    C# - Entitity Framework

    Considerações finais
    Existem muitas discussões entre usar um ORM que implementa Data Mapper ou Active Record. 
    Muitos desenvolvedores defendem um ou outro com unhas e dentes, porém, na realidade, como quase 
    tudo na nossa área, não existe bala de prata. Se tiver a oportunidade aconselho estudar ORMs da sua 
    linguagem que trabalha em ambos os padrões, assim você terá um conhecimento maior para escolher entre 
    um ou outro dependendo dos requisitos do seu projeto.

    ----------------------------

    *Entity Framework Core

    Entity Framework Core

O Entity Framework Core (EF Core) é uma versão leve, extensível e multiplataforma do Entity Framework. O EF Core 
introduz muitas melhorias e novos recursos quando comparado com o EF6.x. Ao mesmo tempo, o EF Core é uma nova base 
de código e um novo produto.

O EF Core mantém a experiência do desenvolvedor do EF6.x e a maioria das APIs de alto nível permanece a mesma, 
portanto, o EF Core vai parecer muito familiar para quem já usou o EF6.x. Ao mesmo tempo, o EF Core é construído 
sobre um conjunto completamente novo de componentes principais.

Isso significa que o EF Core não herda automaticamente todos os recursos do EF6.x. Alguns desses recursos aparecerão 
em lançamentos futuros (como o lazy loading e a resiliência da conexão), outros recursos menos usados ​​não serão 
implementados no EF Core.

O novo núcleo , extensível e leve também permitiu adicionar alguns recursos ao EF Core que não serão implementados 
no EF6.x (como chaves alternativas e avaliação mista de cliente/banco de dados em consultas LINQ).

Nota1:  Usar as duas versões em uma mesma aplicação é possível pois elas possuem os mesmos tipos diferindo apenas 
no namespaces e isso pode tornar a manutenção do seu código muito complexa.

Nota2:  Devido a mudanças estruturais feitas no EF Core não é recomendado mover uma aplicação que usa o EF 6.x 
para o EF Core a não se que isso se caso de 'vida ou morte'.

Com isso em mente vamos iniciar a nossa jornada com o Entity Framework Core de agora em diante EF Core.

Entity Framework Core

O EF Core é um mapeador objeto-relacional (O/RM) que permite aos desenvolvedores .NET trabalhar com um banco 
de dados usando objetos .NET. Ele elimina a necessidade da maior parte do código de acesso a dados que os 
desenvolvedores normalmente precisam escrever. O EF Core suporta muitos mecanismos de banco de dados.

O EF Core é uma versão totalmente nova baseada no EF 6.x :

Ele foi reescrito a partir do zero;

É multiplataforma (Windows, Mac e Linux);

É Modular e suporta diversos provedores: SQL Server, MySQL, PostgreSQL, Oracle, SQLite, SQLCompact, DB2, InMemory, 
Azure Table Storage, etc;

É open source e esta disponível no GitHub;

Pode ser usado em aplicações Windows Forms, WPF, Console, ASP .NET, ASP .NET Core, WUP, Xamarin (em breve), etc;

Suporta as abordagens :  Code First, Database First,  Shadow Properties, Alternate Keys, etc;

Suporta a ferramenta de linha de comando : NET Core CLI

Pode ser instalado via Nuget : Install-Package Microsoft.EntityFrameworkCore.SqlServer

O modelo

Com o EF Core, o acesso a dados é executado usando um modelo. Um modelo é composto de classes de entidade 
e um contexto derivado que representa uma sessão com o banco de dados, permitindo que você pesquise e salve dados.

Podemos criar um modelo usando as seguintes abordagens:

1 - Você pode gerar um modelo a partir de um banco de dados existente;
2 - Codificar manualmente um modelo para corresponder ao seu banco de dados;
3 - Usar o EF Migrations para criar um banco de dados a partir do seu modelo (e depois evoluí-lo conforme 
seu modelo muda ao longo do tempo).

Exemplo de um modelo

Como exemplo de um modelo vamos criar as seguintes classes usando a linguagem C# :

classe Blog - representa um blog;

classe Post - representa os posts de um blog ;

classe BlogContext - representa uma sessão com o banco de dados;

Abaixo vemos as 3 classes criadas :

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Intro
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Nome_BancoDados;
            Trusted_Connection=True;");
        }
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Avaliacao { get; set; }
        public List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
O que vale a pena destacar :

1- A referência ao namespace : Microsoft.EntityFrameworkCore;

2- A classe de contexto, BlogContext, herda da classe DbContext ;

3- A definição da string de conexão com o banco de dados SQL Server Localdb;

4- Estamos usando apenas classes POCO (Plain Old CLR Objects);

Acessando e consultando o Modelo

Podemos acessar e consultar o modelo criado usando as instâncias das classes de entidades que são recuperadas do 
banco de dados usando a linguagem LINQ.

Exemplo de código usando LINQ para acessar todos os blogs com avaliação maior que 3 e ordenados pela Url :

using (var db = new BlogContext())
{
    var blogs = db.Blogs
                      .Where(b => b.Avaliacao > 3)
                      .OrderBy(b => b.Url)
                      .ToList();
}
Podemos também criar, deletar e modificar dados do banco de dados usando instâncias das entidades de classes criadas.

No exemplo a seguir criamos um novo blog e adicionamos á tabela Blogs do banco de dados usando o método SaveChanges:

using (var db = new BlogContext())
{
    var blog = new Blog { Url = "http://macoratti.net" };
    db.Blogs.Add(blog);
    db.SaveChanges();
}

*Camadas OSI (Open Systems Interconnection)

O processo de enviar uma requisição para um servidor é parecido com o de enviar um pacote pelos correios, 
isto é, os pacotes enviados pelo computador passam por algumas etapas até chegar ao destino final. 
Esses passos são o que chamamos de modelo OSI.

Quando fazemos uma requisição para um servidor web, essa percorre um longo caminho da sua máquina até o servidor.

Essa requisição saí do seu computador passa pelo seu provedor de internet e por diversos outros servidores até chegar no destino. 
Quando o servidor manda uma resposta, esse caminho se repete.

O modelo OSI é um padrão para os protocolos de rede. Protocolos nada mais são do que regras de comunicação usadas para 
conectar dois ou mais computadores. O que o modelo OSI faz é agrupar esses protocolos em grupos específicos, ou camadas.

Camada 1 - Física
A primeira camada do modelo OSI é a camada física. Voltando para o exemplo dos correios, a camada física seriam as 
estradas, ou seja, o caminho que os pacotes percorrem para chegar ao destino.

Nesta camada são especificados os dispositivos, como hubs e os meios de transmissão, como os cabos de rede. Os dados 
são transmitidos por esses meios e processados na próxima camada.

Camada 2 - Enlace ou Ligação
Fazendo um paralelo com os correios, essa camada funciona como um fiscal. Ele observa se o pacote tem algum defeito 
em sua formatação e controla o fluxo com que os pacotes são enviados.

Nesta camada, os dados recebidos do meio físico são verificados para ver se possuem algum erro e,se possuírem, 
esse erro pode ser corrigido. Dessa forma, as camadas superiores podem assumir uma transmissão praticamente sem erros. 
Esta camada também controla o fluxo que os dados são transmitidos.

Nesta camadas que são definidas as tecnologias como as VLans, ou topologias como a Token ring, ou a ponto-a-ponto.
Também é nesta camada que dispositivos como os switches funcionam.

Esta camada é dividida em duas subcamadas: A camada MAC e a camada LLC.

A subcamada MAC
É nesta camada que possibilita a conexão de diversos computadores em uma rede. Cada máquina conectada na rede tem 
um endereço físico, conhecido como endereço MAC. É esse endereço que a camada utiliza para identificar e enviar os pacotes.

Essa camada atua como uma interface entre a camada física e a subcamada LLC.

Já a subcamada LLC
É nesta camada que temos o controle de fluxo dos dados na rede. É por conta dessa camada que conseguimos ter vários 
protocolos da próxima camada convivendo dentro de uma mesma rede.

Camada 3 - Rede
Quando estamos enviando uma carta, os correios verificam quem é destinatário e quem é o remetente da mensagem. Se 
existirem muitas mensagens para serem enviadas, eles podem priorizar quais serão enviadas primeiro e qual é o melhor 
caminho para enviar essa carta.

Isso é justamente o que a camada 3 faz, ela atua como uma central dos correios. Esta é talvez a camada mais atuante nas 
redes, principalmente na internet.

É nesta camada que temos o endereçamento IP de origem e de destino, ela também pode priorizar alguns pacotes e decidir 
qual caminho seguir para enviar seus dados.

Essa camada basicamente controla o roteamento entre a origem e destino do pacote.

"Mas por que utilizar o endereço IP se já temos o endereço MAC?”

O endereço MAC é o endereço físico de quem envia o pacote. Ou seja, se enviarmos um pacote e esse pacote 
passar por cinco dispositivos diferentes (roteadores, switches, ou servidores, por exemplo) o endereço MAC é 
alterado no processo. Já o endereço IP não sofre essa alteração.

O endereço IP é a identificação da sua máquina na rede. É aquele endereço como 192.168.0.1.

É nessa camada que temos protocolos como o IP ou o ICMP.

Bem, as cartas chegaram a central dos correios, agora elas precisam ser transportadas.

Camada 4 - Transporte
Se na camada um temos as estradas e os caminhos que os dados percorrem, na camada quatro temos os caminhões e os carteiros.

É esta camada que garante o envio e o recebimento dos pacotes vindos da camada 3. Ela gerencia o transporte dos 
pacotes para garantir o sucesso no envio e no recebimento de dados.

Esta camada lida muito com a qualidade do serviço para que os dados sejam entregues com consistência, isto é, sem 
erros ou duplicações. Porém nem todos os protocolos desta camada garantem a entrega da mensagem.

Protocolos muito comuns dessa camada são os protocolos TCP em UDP. O primeiro garante a entrega da mensagem, 
diferente do segundo. Por não garantir a entrega da mensagem, o protocolo UDP é um pouco mais rápido que o TCP.

Bem, mas para ocorrer o transporte de um pacote entre os computadores, é necessário que as máquinas consigam se 
comunicar. Isso é função da próxima camada.

Camada 5 - Sessão
Está camada é responsável por estabelecer e encerrar a conexão entre hosts. É ela quem inicia e sincroniza os hosts.

Além de realizar o estabelecimento das sessões, esta camada também provém algum suporte a elas, como registros de 
log e realizando tarefas de segurança.

Recebemos os pacotes, vamos checá-los para ver que dados tem dentro?

Ainda não podemos. Os dados ainda precisam ser tratados para serem usados. Como a camada de sessão só é responsável 
por estabelecer a conexão entre os hosts, o tratamento dos dados é de responsabilidade da próxima camada.

Camada 6 - Apresentação
Está é a camada responsável por fazer a tradução dos dados para que a próxima camada os use. Nesta camada temos a 
conversão de códigos para caracteres, a conversão e compactação dos dados, além da criptografia desses dados, caso necessite.

Depois de tratados, esses dados estão prontos para serem usados na próxima camada.

Camada 7 - Aplicação
A última camada do modelo OSI é a camada para consumir os dados. Nesta camada temos os programas que garantem a 
interação humano-máquina. Nela conseguimos enviar e-mails, transferir arquivos, acessar websites, conectar remotamente 
em outras máquinas, entre outras coisas (Falando em conectar remotamente, você conhece as diferenças entre Telnet e SSH?).

É nesta camada que temos os protocolos mais conhecidos como o HTTP, FTP, além de serviços como o DNS.



