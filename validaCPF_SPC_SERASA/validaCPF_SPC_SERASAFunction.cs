using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public static class ValidaCPF_SPC_SERASA
{
    [FunctionName("validaCPF_SPC_SERASA")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Recebendo solicitação de validação de CPF...");

        string requestBody = new StreamReader(req.Body).ReadToEndAsync().Result;
        dynamic data = JsonConvert.DeserializeObject(requestBody);

        string cpf = data?.cpf;

        if (string.IsNullOrEmpty(cpf))
        {
            return new BadRequestObjectResult("Por favor, envie um CPF.");
        }

        bool isValid = ValidarCPF(cpf);

        if (isValid)
        {
            return new OkObjectResult($"CPF {cpf} válido e sem restrições no SPC/SERASA.");
        }
        else
        {
            return new BadRequestObjectResult($"CPF {cpf} inválido.");
        }
    }

    public static bool ValidarCPF(string cpf)
    {
        // Remove caracteres não numéricos
        cpf = Regex.Replace(cpf, "[^0-9]", "");

        // Verifica tamanho e CPFs inválidos conhecidos
        if (cpf.Length != 11 || Regex.IsMatch(cpf, @"^(.)\1+$"))
            return false;

        // Validação dos dígitos verificadores
        int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        tempCpf += resto;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        return cpf.EndsWith(resto.ToString());
    }
}
