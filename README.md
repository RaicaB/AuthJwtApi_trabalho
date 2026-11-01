# AuthJwtApi - Autenticação com JWT

API em ASP.NET Core (.NET 10) que demonstra autenticação com JWT.
Não usa banco de dados: o usuário e a senha são fixos no código, apenas para fins didáticos.

## Como executar

1. Abra a solução no Visual Studio.
2. Selecione o perfil http e pressione F5.
3. A API fica disponível em `http://localhost:5000` (confira a porta no console).

## Credenciais de teste

- usuario: `aluna`
- senha: `senha123`

## Rotas

**POST /api/auth/login**

Corpo (JSON):
```json
{ "usuario": "aluna", "senha": "senha123" }
```
- Credenciais corretas: 200 OK com o token JWT
- Credenciais incorretas: 401 Unauthorized

**GET /api/usuario/perfil** (rota protegida)

Header: `Authorization: Bearer <token>`
- Token válido: 200 OK com mensagem contendo o nome do usuário
- Sem token ou token inválido: 401 Unauthorized

## Como testar no Postman

1. Teste 1: POST /api/auth/login com usuário e senha corretos. Resultado: 200 OK e token.
2. Teste 2: POST /api/auth/login com senha errada. Resultado: 401 Unauthorized.
3. Teste 3: GET /api/usuario/perfil sem token. Resultado: 401 Unauthorized.
4. Teste 4: GET /api/usuario/perfil com Authorization > Bearer Token. Resultado: 200 OK e mensagem.

## Evidências

No pdf anexado, há capturas de tela do Postman mostrando os testes realizados com sucesso.
