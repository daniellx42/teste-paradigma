# Teste Paradigma

## Tarefas feitas
```md
[x] Tarefa 1 - Escreva uma consulta usando linguagem SQL para encontrar os colaboradores que tem o salário mais alto em cada um dos departamentos.
A tabela Pessoa possui a relação de todos os colaboradores de uma empresa. Cada pessoa tem um Id, um salário, e também uma coluna para o ID do departamento.

[x] Tarefa 2 - Dado um array inteiro sem duplicidade, construa um algoritmo de uma árvore a partir das seguintes regras:
A raiz da árvore deve ser o maior valor do array.
Os galhos da esquerda devem ser compostos somente por números à esquerda do valor raiz, na ordem decrescente.
Os galhos da direita devem ser compostos somente por número à direita do valor raiz, na ordem decrescente.
```

## Comandos para Rodar tarefa 1
```bash
# c#
cd tarefa1\testParadigmaCs; dotnet add package Microsoft.Data.Sqlite; clear; dotnet run; cd..; cd..

# javascript
cd tarefa1\testParadigmaJs; npm install; clear; node .\main.js; cd..; cd..

# SQL
### script SQL com as tabelas e consultas na pasta - tarefa1\testParadigmaSQL
```

## Explicao da Tarefa 2
```md
O que eu fiz nesse codigo foi criar uma arvore a partir de um array seguindo as regras da tarefa. Primeiro, eu pego o maior valor do array e coloco como raiz, porque a tarefa pede que a raiz seja sempre o maior. Depois, eu separo os numeros que estao a esquerda da raiz e os que estao a direita. Esses dois grupos viram os galhos da esquerda e da direita, respectivamente.

Como os galhos precisam estar em ordem decrescente, eu ordeno esses subarrays antes de construir os nos. Aí eu uso recursao, ou seja, chamo a mesma funcao para cada subarray, criando os filhos esquerdo e direito ate nao sobrar mais nada.

Para mostrar a arvore, eu fiz uma funcao que imprime cada no com um prefixo L-- ou R-- e um espaco indentado, so para ficar facil de ver a estrutura.
```

## Comandos para Rodar tarefa 2
```bash
cd tarefa2\testParadigmaCs; clear; dotnet run; cd..; cd..
```