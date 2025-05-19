using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FiiAnalyzer.Shared;
using System.Collections.Generic;
using System.Threading;

namespace FiiAnalyzer.Infrastructure
{
    public class FiiScraper
    {
        public List<FiiDto> ObterLista()
        {
            var fiis = new List<FiiDto>();
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.fundamentus.com.br/fii_resultado.php");

                // Aguarda a página carregar (melhor usar WebDriverWait se for produção)
                Thread.Sleep(3000);

                var rows = driver.FindElements(By.CssSelector("table tbody tr"));
                foreach (var row in rows)
                {
                    var cols = row.FindElements(By.TagName("td"));
                    if (cols.Count >= 12)
                    {
                        // Ajuste os índices conforme a ordem das colunas na tabela
                        var ticker = cols[0].Text.Trim();
                        var segmento = cols[1].Text.Trim();

                        double TryParseDouble(string s)
                        {
                            s = s.Replace("%", "").Trim();
                            return double.TryParse(s, out var v) ? v : 0;
                        }

                        int TryParseInt(string s)
                        {
                            s = s.Replace(".", "").Trim();
                            return int.TryParse(s, out var v) ? v : 0;
                        }

                        var price = TryParseDouble(cols[2].Text);
                        var ffody = TryParseDouble(cols[3].Text);
                        var dy = TryParseDouble(cols[4].Text);
                        var pvp = TryParseDouble(cols[5].Text);
                        var marketValue = TryParseDouble(cols[6].Text);
                        var liquidity = TryParseDouble(cols[7].Text);
                        var realState = TryParseInt(cols[8].Text);
                        var priceM2 = TryParseDouble(cols[9].Text);
                        var rentM2 = TryParseDouble(cols[10].Text);
                        var capRate = TryParseDouble(cols[11].Text);
                        var vacancy = TryParseDouble(cols[12].Text);

                        fiis.Add(new FiiDto
                        {
                            Ticker = ticker,
                            Segmento = segmento,
                            Price = price,
                            FFODy = ffody,
                            Dy = dy,
                            PVP = pvp,
                            MarketValue = marketValue,
                            Liquidity = liquidity,
                            RealState = realState,
                            PriceM2 = priceM2,
                            RentM2 = rentM2,
                            CapRate = capRate,
                            vacancy = vacancy
                        });
                    }
                }
                driver.Quit();
            }

            return fiis;
        }
    }
}
