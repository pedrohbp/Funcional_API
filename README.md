<h1>Desafio Técnico</h1>

API para a empresa Funcional Health Tech.<br/>
Especificação: https://github.com/funcional-health/challenge/blob/master/csharp.md

Stack:
```
C#
GraphQL
Postgres(via Docker)
```

(Pré-Reqs: **Docker Desktop** instalado.)<br/>
Na pasta do projeto, abra um terminal e crie a database no docker com o comando:
```
docker-compose up -d
```

O executável Para rodar a API está na pasta 'API_EXECUTAVEL', nome: 'Funcional_API.exe'.

Para acessar o playground: 'http://localhost:5000/ui/playground'.
-------------------------

"DADO QUE eu consuma a API
QUANDO eu chamar a mutation sacar informando o número da conta e um valor válido
ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo
E a mutation retornará o saldo atualizado."<br/>
"DADO QUE eu consuma a API
QUANDO eu chamar a mutation sacar informando o número da conta e um valor maior do que o meu saldo
ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente."

Primeiro, adicione uma ou mais contas no banco:
```
mutation addConta {
  addConta(conta: INSERIR_NUMERO, saldo: INSERIR_VALOR){
    conta
    saldo
  }
}
```
Agora, use a mutation sacar:
```
mutation sacar {
  sacar(conta: INSERIR_NUMERO, valor: INSERIR_VALOR)
  {
    conta
    saldo
  }
}
```

"DADO QUE eu consuma a API
QUANDO eu chamar a mutation depositar informando o número da conta e um valor válido
ENTÃO a mutation atualizará o saldo da conta no banco de dados
E a mutation retornará o saldo atualizado."

```
mutation depositar{
  depositar(conta: INSERIR_NUMERO, valor: INSERIR_VALOR)
  {
    conta
    saldo
  }
}
```

"DADO QUE eu consuma a API
QUANDO eu chamar a query saldo informando o número da conta
ENTÃO a query retornará o saldo atualizado."
```
query saldo{
  saldo(conta: INSERIR_NUMERO)
  {
    conta
    saldo
  }
```
