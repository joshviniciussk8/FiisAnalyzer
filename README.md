# FiiAnalyzer

FiiAnalyzer é uma aplicação para análise de Fundos Imobiliários (FIIs) brasileiros. O sistema realiza scraping de dados do site Fundamentus, aplica filtros customizáveis e expõe os dados via API.

## Funcionalidades

- **Scraping de FIIs:** Coleta automática de dados do [Fundamentus](https://www.fundamentus.com.br/fii_resultado.php) usando Selenium.
- **Filtros customizáveis:** Permite aplicar filtros como rendimento mínimo, P/VP, liquidez, entre outros.
- **API REST:** Disponibiliza os dados filtrados via endpoint HTTP.
- **Arquitetura modular:** Separação entre scraping, lógica de negócio e API.

## Tecnologias Utilizadas

- .NET 8
- C# 12
- ASP.NET Core (API)
- Selenium WebDriver

## Estrutura do Projeto

API FiiAnalyzer.API/            
Regras de negócio FiiAnalyzer.Core/           
Web scraping FiiAnalyzer.Infrastructure/ 
DTOs FiiAnalyzer.Shared/         
UI Desktop FiiAnalyzer.WPF/            
ConsoleApp FiiAnalyzer.Console/

## Como Executar

1. **Pré-requisitos:**
   - .NET 8 SDK
   - Google Chrome instalado
   - ChromeDriver compatível com sua versão do Chrome

2. **Restaurar dependências:**
   dotnet restore
   
3. **Executar a API:**
   cd FiiAnalyzer.API dotnet run

4. **Acessar o endpoint:**
   - GET `http://localhost:5000/fiis`  
     Retorna a lista de FIIs filtrados.

## Exemplo de Uso

Requisição: GET http://localhost:5000/fiis
Resposta:
[ { "Ticker": "ABCD11",
  "Segmento": "Lajes Corporativas",
  "Price": 100.5,
  "FFODy": 8.2,
  "Dy": 8.5,
  "PVP": 1.05,
  "MarketValue": 50000000,
  "Liquidity": 1500000,
  "RealState": 3,
  "PriceM2": 9000,
  "RentM2": 90,
  "CapRate": 0.95,
  "vacancy": 5.0 } ]

## Observações
- O scraping pode demorar alguns segundos devido ao carregamento da página.
- Certifique-se de que o ChromeDriver está no PATH ou na mesma pasta do executável.

## Licença
MIT














   
