using FiiAnalyzer.Core;
using FiiAnalyzer.Infrastructure;
using FiiAnalyzer.Shared;
using System;
using System.Collections.Generic;
using FiiAnalyzer.Utils;

class Program
{
    static void Main(string[] args)
    {
        FiiScraper scraper = new FiiScraper();
        List<FiiDto> fiis = scraper.ObterLista();

        var filtro = new FiiFilter();
        var filtrados = filtro.FiltroDefault(fiis, 8);

        ExcelExporter exporter = new ExcelExporter();
        bool reposta = exporter.ExportarParaExcel(filtrados, "C:\\Users\\Josh Vinicius\\Pictures\\Fiis\\Teste.xlsx");
        if(!reposta) Console.WriteLine("Ops Não foi possivel Gerar o excel!");
        
    }
}
