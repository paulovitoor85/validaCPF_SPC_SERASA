# validaCPF_SPC_SERASA


#  Validador de CPF - Azure Function

Esta é uma **Azure Function** chamada `validaCPF_SPC_SERASA`, que valida CPFs e retorna uma mensagem indicando se o CPF é válido e sem restrições no SPC/SERASA.

---

## Funcionalidades

✅ Validação de CPF seguindo as regras do algoritmo oficial.  
✅ API REST via HTTP (`POST`).  
✅ Testável localmente com **Azure Functions Core Tools**.  
✅ Deployável no **Microsoft Azure**.  
---

## 📂 Estrutura do Projeto

📦 validar-cpf-function ┣ 📂 validaCPF_SPC_SERASA ┃ ┣ 📜 validaCPF_SPC_SERASAFunction.cs ┃ ┣ 📜 host.json ┃ ┣ 📜 local.settings.json ┣ 📜 README.md ┗ 📜 .gitignore


---

## 🚀 Configuração e Execução Local

### 🔧 **1. Pré-requisitos**
Antes de rodar a função localmente, instale:

- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [.NET 6 SDK ou superior](https://dotnet.microsoft.com/en-us/download)
- [Azure CLI (opcional)](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)

### ▶ **2. Executando Localmente**

1. **Clone o repositório:**
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd validar-cpf-function

2 . Inicie a função:

func start

3. Acesse a API:

http://localhost:7071/api/validaCPF_SPC_SERASA

4. Teste com Postman ou cURL:

curl -X POST "http://localhost:7071/api/validaCPF_SPC_SERASA" -H "Content-Type: application/json" -d '{"cpf": "12345678909"}'

🚀 Implantação no Azure
🔹 1. Criar uma Function App no Azure
Caso ainda não tenha criado, execute:

az functionapp create --resource-group <RESOURCE_GROUP> --consumption-plan-location <LOCATION> --name <NOME_DA_FUNCTION> --storage-account <STORAGE_NAME> --runtime dotnet

2. Publicar a Função
Execute:
az functionapp publish <NOME_DA_FUNCTION>


📝 Exemplo de Retorno da API
✅ CPF Válido:

{
    "message": "CPF 12345678909 válido e sem restrições no SPC/SERASA."
}

❌ CPF Inválido:
{
    "message": "CPF 12345678909 inválido."
}

🛠 Tecnologias Utilizadas
🌐 Azure Functions
🔧 C# (.NET 6)
☁ Azure CLI
💾 JSON para comunicação HTTP

📌 Autor
Projeto desenvolvido por Paulo Vitor. 🚀
📧 Contato: paulovitoor85@yahoo.com.br
🔗 LinkedIn: www.linkedin.com/in/paulo-vitor-martins-nascimento






