![Build status](https://dev.azure.com/bariodevops/Bario/_apis/build/status/Ambev.Bario.API.Docker.Build?branchName=master)

# calculadora-ir

Importante

Banco de dados: MongoDB
Linguagem Backend: C#
Linguagem Frontend: HTML, CSS, Javascript e Framework Typescript

* Alguns conceitos de DDD foram aplicados

Divisão do projeto - Backend

1. CalculadoraIR.Domain (Visual Studio C#)
  Responsável por conter as regras do negócio e modelagem
2. CalculadoraIR.Infra  (Visual Studio C#)
  Responsável por conter a infra do negócio, como exemplo, integração com a base de dados
3. CalculadoraIR.Shared (Visual Studio C#)
  Responsável por conter a libs comuns para todos os projetos
4. CalculadoraIR.Test   (Visual Studio C#)
  Responsável por realizar alguns teste unitários na ferramenta.
5. CalculadoraIR.WebApi (Visual Studio C#)
  Responsável por expor atráves de uma API Rest as regras do negócio
6. CalculadoraIR.Portal (TypeScript)
  Responsável por exibir as informações do negócio.
