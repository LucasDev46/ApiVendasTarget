📌 API de Vendas e Controle de Estoque

Este projeto foi desenvolvido como solução para um desafio técnico envolvendo cálculo de comissões de vendedores e movimentação de estoque. A aplicação segue arquitetura em 3 camadas (API, Business e Data), utilizando boas práticas e tecnologias modernas.
Como rodar o projeto:
1. Clonar o repositório
2. Abrir a solução
3. Configurar o banco de dados (SQL server: não esquecer de configurar a ConnectionString)
4. Executar a API
5. Testar no Swagger

🚀 Tecnologias Utilizadas

.NET 8 – Web API
Entity Framework Core
SQL Server
Fluent API
FluentValidation
AutoMapper
Arquitetura em 3 camadas (API → Business → Data)

📍 Funcionalidades
1. Cálculo de Comissão de Vendas
A API retorna o total de comissão por vendedor.
*/API/Vendedor/Obter-Comissao-Id{id}*

2. Movimentações de Estoque
*/API/Produto/Adicionar-Estoque*
*/API/Produto/Retirar-Estoque*

