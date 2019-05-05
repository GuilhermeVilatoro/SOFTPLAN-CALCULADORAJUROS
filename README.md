# Calculadora de Juros WebApi

# Sistema criado para atender as seguintes necessidades:

Criar uma API com dois endpoints:

###  1) Calcula Juros
A primeira reponde pelo path relativo "/calculajuros"

Ela faz um cálculo em memória, de juros compostos, conforme abaixo:
Valor Final = Valor Inicial * (1 + juros) ^ Tempo

Valor inicial é um decimal recebido como parâmetro
Juros é 1% ou 0,01 (fixo no código)
Tempo é um inteiro, que representa meses, também recebido como parâmetro
^ representa a operação de potência
Resultado final deve ser truncado (sem arredondamento) em duas casas decimais

Exemplo: /calculajuros?valorinicial=100&tempoemmeses=5
Resultado esperado: 105,10

### 2) Show me the code
Este responde pelo path relativo /showmethecode
Deverá retornar a url de onde encontra-se o fonte no github

## Informações para teste da API:

###  1) Swagger
* Os testes poderão ser realizados rodando a API e batendo na raiz com swagger.

###  2) Postman
* Os testes também poderão ser realizados via Postman com as suas respectivas rotas.

###  3) Docker
* Baixar e rodar a imagem docker do container conforme comando abaixo:
** docker run --name CalculadoraJurosVilatoro -p 12345:80 -d guilhermevilatoro/calculadorajuroswebapifinal:latest

* Excutar o link:
** http://localhost:12345/index.html

###  4) Azure
* https://vilatorocalculadorajuros.azurewebsites.net

# Tecnologias usadas

* AspNet Core 2.2 (WebApi)
* Swagger
* AutoMapper
* DDD (Domain-Driven-Design)
* TDD (Test-Driven-Design)
* SOLID
* Injeção de dependências
* Testes unitários
* Testes Integração
* NSubstitute
* Docker
* Azure