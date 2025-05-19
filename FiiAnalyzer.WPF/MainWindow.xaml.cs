using FiiAnalyzer.Core;
using FiiAnalyzer.Infrastructure;
using FiiAnalyzer.Shared;
using FiiAnalyzer.Utils;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FiiAnalyzer.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FiiScraper scraper = new FiiScraper();
            List<FiiDto> fiis = scraper.ObterLista();

            var filtro = new FiiFilter();
            var filtrados = filtro.FiltroDefault(fiis, 8);

            ExcelExporter exporter = new ExcelExporter();
            bool reposta = exporter.ExportarParaExcel(filtrados, "C:\\Users\\Josh Vinicius\\Pictures\\Fiis\\Teste.xlsx");
            if (!reposta) Console.WriteLine("Ops Não foi possivel Gerar o excel!");
        }
    }
}