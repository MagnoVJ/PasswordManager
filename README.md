# Password Manager (Gerenciador de Senhas)

Este projeto é um Gerenciador de Senhas que permite gerenciar uma lista de itens (que representam o acesso a cada sistema) após acessar o programa.

## Tabela de Conteúdo

- [Instalação](#instalação)
- [Recursos](#recursos)
- [Contribuições](#contribuições)
- [Licença](#licença)

## Instalação

1. Clone o repositório ou baixe o arquivo ZIP do projeto.
2. Execute o arquivo `.exe` localizado no seguinte caminho: PassManager\bin\Debug\net8.0-windows\PassManager.exe
3. Em relação ao banco de dados, é necessário acessar um servidor MySQL. Adicione a string de conexão do servidor MySQL nas variáveis de ambiente da seguinte forma:
Nome da variável: DB_CONNECTION_STRING
Valor: Server="ip do servidor";Database="Nome do banco de dados";User="Nome do Usuário";Password="Senha";

O banco/esquema deve conter apenas 2 tabelas: account e password_item. O script de criação das tabelas está na pasta db do projeto.

## Recursos

- Autenticação de usuário.
- Criação de um novo item de senha.
- Opção de visualizar ou ocultar senhas durante a criação e na lista principal.
- Edição de um item de senha pela janela principal.
- Localização de itens de senha pelo código.
- Exclusão de itens de senha pelo código.

## Imagens do Projeto

### Tela Inicial
![Tela Inicial](https://github.com/MagnoVJ/PasswordManager/blob/main/Screenshots/Screenshot1.jpg)

### Tela de Cadastro
![Tela de Cadastro](https://github.com/MagnoVJ/PasswordManager/blob/main/Screenshots/Screenshot2.jpg)

### Localizar Item
![Localizar](https://github.com/MagnoVJ/PasswordManager/blob/main/Screenshots/Screenshot3.jpg)

## Contribuições

Se quiser contribuir, entre em contato pelo email:  
**magnodss.lp@gmail.com**

## Licença

Este projeto é livre para uso não comercial.

## Tecnologias Usadas
WPF - C# - Entity Framework - MySQL