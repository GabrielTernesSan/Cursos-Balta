# Fundamentos do Azure, Git, Github e DevOps

## O que é DevOps

- É uma cultura;

- **DevOps** *(junção das palavras “desenvolvimento” e “operação”)* é um modelo que combina filosofias culturais, práticas e ferramentas que aumentam a capacidade de uma empresa distribuir seus serviços em alta velocidade.

  Essa é uma prática de engenharia de software para unir o desenvolvimento de software com a operação, ou seja, integrar essas áreas e alcançar uma maior qualidade nas entregas. Quando essas áreas não são integradas, você pode presenciar falhas na comunicação destes times, o que pode resultar em atrasos, retrabalhos e baixa qualidade.

## Git e Github

### Git

​	É um sistema de controle de versão open-source. Ele é utilizado para a criação de um histórico de alterações em código-fonte de projetos de desenvolvimento de software.

#### Repositório

Local físico onde os arquivos e suas cópias ficarão armazenados. O repositório pode ser local ou remoto, podendo salvar não apenas arquivos de texto, mas também imagens, áudios e outros elementos relacionados ao projeto.

#### Branch

Branches são os ramos, cópias do código original que podem ser manipuladas de forma livre pela pessoa que trabalha em programação, sem afetar as funcionalidades em produção no código-fonte.

Isso permite que todas as alterações sejam realizadas de forma segura, sem que erros ocorram na cópia principal do projeto.

#### Merge

Após a finalização de um trabalho em um Branch, é necessário realizar o Merge, fundir a cópia e seus arquivos modificados com o ramo principal do projeto. Isso acontece apenas no repositório local para que ajustes possam ser feitos.

#### Push Request

O Push Request é o envio das modificações após o Merge para o repositório central, para que todas as outras pessoas que atuam no desenvolvimento possam atualizar suas cópias e revisar o código criado, verificando conflitos com seus próprios trabalhos.

#### Pull Request

O Pull Request é utilizado quando outra pessoa que atua no desenvolvimento muda o ramo principal no repositório central, puxando as modificações realizadas para a sua máquina, fundindo a nova versão com o seu código local.

#### Fork

Trata-se do comando de cópia de um repositório remoto para a máquina local, realizado sempre que vamos começar a trabalhar em um projeto que já existe. Também é usado para pegar um código público para posterior modificação e utilização em um programa interno.

### Github

O Github é um repositório remoto, criado como um serviço online de hospedagem de repositórios do Git.

Funciona como um servidor que agrega todas as modificações realizadas por cada uma das pessoas envolvidas em um projeto, unificando as diferentes versões de código e seus históricos, permitindo compartilhamento entre as equipes.

Além disso, o GitHub também conta com várias integrações com outros serviços online, permitindo o deploy automático de aplicação. Assim, garante a integração contínua e facilita o desenvolvimento.

## Nuget e GitHub Packages

### Ci e CD

O acrônimo CI/CD tem alguns significados. "CI" sempre se refere à integração contínua, que é um processo de automação para desenvolvedores. Uma CI bem-sucedida é quando novas mudanças no código de uma aplicação são desenvolvidas, testadas e consolidadas regularmente em um repositório compartilhado. É a solução ideal para evitar conflitos entre ramificações quando muitas apps são desenvolvidas ao mesmo tempo.

"CD" se refere à entrega contínua e/ou à implantação contínua, conceitos relacionados e usados alternadamente às vezes. Em ambos os casos, trata-se da automação de fases avançadas do pipeline. Porém, são usados às vezes separadamente para ilustrar o nível de automação presente.

Geralmente, a entrega contínua representa as mudanças feitas por desenvolvedores em uma aplicação para verificar automaticamente a presença de bugs e carregá-las em um repositório, como o GitHub ou um registro de containers. Nesse repositório, a equipe de operação pode implantar essas mudanças em um ambiente de produção ativo. Isso resolve o problema de baixa visibilidade e comunicação entre as equipes de negócios e desenvolvimento. Por isso, a finalidade da entrega contínua é reduzir ao máximo o esforço na implantação de novos códigos.

A implantação contínua, outro significado para "CD", se refere ao lançamento automático das mudanças feitas por uma pessoa desenvolvedora, do repositório à produção, onde podem ser usadas por clientes. Assim, as equipes de operação não ficam sobrecarregadas com processos manuais que atrasam a entrega de apps.

### Iniciando o Workflow

- Builds na máquina local não significam nada pra produção, porque usa os recursos da máquina local e isso não significa que os mesmos estarão em produção, ou seja, não funcionará em produção
- Precisamos subir uma máquina virtual copiar o código para essa máquina, temporária, fazer o build e testes pegar as dlls e os pacotes e depois excluir essa máquina
  - Geralmente Linux
- GitHub actions
  - Workflow
    - main.yml (Não pode mudar a indentação)

`````yaml
# Define o nome desse workflow 
name: Build and Deploy package

# Define para que branch todo push deve ir
on:
  push:
    branches:
      - main

# Define os passos que devemos seguir
jobs:
# Primeiro passo é definir onde ela vai rodar, então primeiro subimos uma máquina Linux
 build:
   runs-on: ubuntu-latest
   
 # O próximo passo é pegar nosso código fonte, para isso vamos na raiz do repositório e pegamos todos os arquivos e trazemos para a máquina que criamos
 steps:
 - uses: actions/checkout@main
 
 # Vai instalar o .Net Core na máquina virtual
 - name: Set up .NET Core
 	uses: actions/setup-dotnet@v2
 	with:
 		dotnet-version: '6.0.x'
 		
 # Próximo passo é fazer um build
 - name: Build with dotnet
 	run: dotnet build --configuration Release
 	
 # Realiza os testes
 - name: Test
 	run: dotnet test
 	
 # Cria o pacote
 - name: Create the Package
 	run: dotnet pack --configuration Release
 
 # Publica o pacote no NuGet ou no GitHub Packages
 - name: Publish
 	run: dotnet nuget push ...
`````

