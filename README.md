# DIO - Trilha .NET - API e Entity Framework
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de API e Entity Framework, da trilha .NET da DIO.

## Contexto
Você precisa construir um sistema gerenciador de tarefas, onde você poderá cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e deletar esses registros.

A sua aplicação deverá ser do tipo Web API ou MVC, fique a vontade para implementar a solução que achar mais adequado.

A sua classe principal, a classe de tarefa, deve ser a seguinte:

![Diagrama da classe Tarefa](diagrama.png)

Não se esqueça de gerar a sua migration para atualização no banco de dados.

## Métodos esperados
É esperado que você crie o seus métodos conforme a seguir:


**Swagger**


![Métodos Swagger](swagger.png)


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Task/{id}              | id        | N/A           |
| PUT    | /Task/{id}              | id        | Schema Task   |
| DELETE | /Task/{id}              | id        | N/A           |
| GET    | /Task/GetAll            | N/A       | N/A           |
| GET    | /Task/GetByTitle        | title     | N/A           |
| GET    | /Task/GetByDate         | date      | N/A           |
| GET    | /Task/GetByStatus       | status    | N/A           |
| POST   | /Task                   | N/A       | Schema Task   |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem

```json
{
  "id": 0,
  "title": "string",
  "description": "string",
  "createdDate": "2022-06-08T01:31:07.056Z",
  "status": "Pending"
}
```
