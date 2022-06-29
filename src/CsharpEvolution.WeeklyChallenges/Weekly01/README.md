Namespaces

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

