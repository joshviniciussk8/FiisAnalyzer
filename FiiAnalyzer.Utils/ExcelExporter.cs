using ClosedXML.Excel;
using FiiAnalyzer.Shared;

namespace FiiAnalyzer.Utils
{
    public class ExcelExporter
    {
        public bool ExportarParaExcel(IEnumerable<FiiDto> dados, string caminhoArquivo)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("FIIs");

                // Cabeçalhos
                worksheet.Cell(1, 1).Value = "Ticker";
                worksheet.Cell(1, 2).Value = "Segmento";
                worksheet.Cell(1, 3).Value = "Cotação";
                worksheet.Cell(1, 4).Value = "FFO Yield";
                worksheet.Cell(1, 5).Value = "Dividend Yield";
                worksheet.Cell(1, 6).Value = "P/VP";
                worksheet.Cell(1, 7).Value = "Valor Mercado";
                worksheet.Cell(1, 8).Value = "Liquidez";
                worksheet.Cell(1, 9).Value = "Qtd Imóveis";
                worksheet.Cell(1, 10).Value = "Preço/m²";
                worksheet.Cell(1, 11).Value = "Aluguel/m²";
                worksheet.Cell(1, 12).Value = "Cap Rate";
                worksheet.Cell(1, 13).Value = "Vacância";

                // Dados
                var dadosList = dados.ToList(); // Convert IEnumerable to List to access Count
                for (int i = 0; i < dadosList.Count; i++)
                {
                    var fii = dadosList[i];
                    int row = i + 2;

                    worksheet.Cell(row, 1).Value = fii.Ticker;
                    worksheet.Cell(row, 2).Value = fii.Segmento;
                    worksheet.Cell(row, 3).Value = fii.Price;
                    worksheet.Cell(row, 4).Value = fii.FFODy;
                    worksheet.Cell(row, 5).Value = fii.Dy;
                    worksheet.Cell(row, 6).Value = fii.PVP;
                    worksheet.Cell(row, 7).Value = fii.MarketValue;
                    worksheet.Cell(row, 8).Value = fii.Liquidity;
                    worksheet.Cell(row, 9).Value = fii.RealState;
                    worksheet.Cell(row, 10).Value = fii.PriceM2;
                    worksheet.Cell(row, 11).Value = fii.RentM2;
                    worksheet.Cell(row, 12).Value = fii.CapRate;
                    worksheet.Cell(row, 13).Value = fii.vacancy;
                }

                // Ajusta largura automática
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(caminhoArquivo);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao exportar para Excel: {ex.Message}");
                // Aqui você pode registrar o erro em um log ou fazer outra ação apropriada
                return false;
            }
            finally
            {
                // Libera recursos, se necessário
            }
        }
    }
}
