[TOC]



# Linguagens e compiladores

## Linguagem de programação

### O que é?

É a maneira que nos comunicamos com os computadores a fim de criar e/ou executar tarefas de forma automatizada.

A linguagem de programação é uma linguagem intermediária entre a linguagem comumente falada por nós e a linguagem que o computador entende (linguagem de máquina), o binário. Essa tradução é feita pelos compiladores e esse processo também é conhecido como compilação. Existem várias linguagens e cada uma delas possui seu compilador, por isso cada uma trabalha de um jeito diferente.

## Alto e baixo nível

Ao enviar uma instrução ao computador estamos falando em baixo nível, linguagem de máquina (binário). Quanto mais próximo a nós a linguagem está, mais alto é o nível da linguagem. Hoje, as linguagens mais utilizadas são quase todas de alto nível, ou seja, são mais próximas da linguagem falada do que da linguagem de máquina.

## Linguagens Compiladas e Interpretadas

#### Linguagens compiladas

São aquelas linguagens em que há uma tradução de texto para binário (Compilação).

**Prós**

- Tempo de compilação
  - Detecção mais rápida de erros
- Tamanho menor das aplicações
- Maior otimização da execução
- Apenas um arquivo final

**Contras**

- Precisa de um compilador
- Pode ser mais burocrática

#### Linguagens Interpretadas

São aquelas que são lidas e interpretadas em tempo de execução por um intérprete, como é o caso do JavaScript.

**Prós**

- Não precisa ser compilada
- Correções mais fáceis
- Mais simples de serem distribuídas

**Contras**

- Detecção de erros
  - Somente em tempo de execução
- Tamanho final da aplicação
- Menor otimização da execução
- Múltiplos arquivos

## Tipagem de dados

Um tipo de dado define o formato dele, onde definimos por exemplo que aquela informação é um número, uma letra, um cadeia de caracteres, etc.

Linguagens que obrigam a definição de um tipo para as variáveis são denominadas fortemente tipadas, como é o caso do C#. Devido a isso apresentam menor liberdade, porém, maior otimização. 

# C#

- Linguagem de programação
  - Tipada, **Compilada** e **Gerenciada**
- Focada em OOP
  - Suporte para programação funcional
- É compilada
- Código **gerenciado**

## Código gerenciado

- Significa que a execução depende de um gerenciador
- Também conhecido como Runtime
  - No caso do C# este Runtime se chama **CLR**[^*] ou **CLR Runtime**
- Gerencia memória, segurança, entre outros recursos básicos

## Compilação e Gerenciamento

- A Microsoft tem um único gerenciador para suas linguagens
- Os compiladores são separados
  - Um para cada linguagem
- A compilação inicial gera um código intermediário
  - Intermediate Language (IL)

## IL

- Embora as compilações sejam diferentes
  - O gerenciamento é igual
  - Alocação de memória
  - Execução de instruções no processador
- O CLR recebe um código e compila ele para IL
  - C#, VB.NET, F#, Cobol.NET
- Podemos ter arquivos C# e VB.NET no mesmo projeto
  - Nunca no mesmo arquivo
- O resultado da compilação do IL é sempre o mesmo

O processo de conversão do IL para binário é conhecido como JIT (Just in Time)

# Frameworks

## O que são?

- Framework é uma estrutura, um alicerce
  - Um conjunto de bibliotecas
- Usamos como base para construir nossas aplicações
- A ideia é trazer recursos comuns já prontos
  - Validados e testados

## .Net Framework

- Teve sua primeira versão em 2001
- Pode ser instalado Syde-by-Side, que significa que você pode instalar várias versões na máquina
- Compatível somente com Windows
- Considerado **legado**

## .Net Core

- Versão mais moderna do .Net Framework
- Veio para suportar outros Sistemas Operacionais, como Linux e Mac
- Suas primeiras versões coninham apenas o básico
  - Core significa núcleo, ou seja, só o essencial

## .Net Standard

- .Net Frameworks e .Net Core coexistem
  - Podem ser instalados juntos
  - Pode ser utilizados no mesmo projeto
- O **.Net Standard** garante que a aplicação rode em ambos os frameworks
  - Não é um Framework, apenas um contrato
  - Chamamos de **Surface API**
  - É a intersecção entre os frameworks

## .Net 5

- Unificação dos Frameworks

## Runtime e SDK

### Runtime

- Necessário para executar aplicações
- São divididos em 3
  - ASP.NET para aplicações web
  - Desktop para aplicações Desktop
  - .NET Core para qualquer outra aplicação
    - Console, Batch, Serviço
- Usado somente para distribuir as aplicações
  - Apenas executa

### SDK

- Sigla para Software Development Kit
  - Kit para desenvolvimento de software
- Possui tudo que precisamos para criar aplicações
- Já vem com runtime integrado

# .NET

## CLI

- Sigla para Command Line Interface
  - Interface de linha de comando
  - Comandos adicionais ao nosso terminal

[^*]: CLR é a sigla para Common Language Runtime ou gerenciador de linguagem comum
