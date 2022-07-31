using RawPrint;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;

namespace PrintDocument
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int FitPageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            TxtPathOrigin.Text = @"C:\Print\Factura.pdf";
            PopulateInstalledPrintersCombo();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Casa de cambio Vita", new Font("Arial", 10), System.Drawing.Brushes.Black, 100, 200);
            e.HasMorePages = false;
        }

        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboInstalledPrinters.Items.Add(pkInstalledPrinters);

            }

            PrinterSettings ps = new PrinterSettings();
            comboInstalledPrinters.SelectedItem = ps.PrinterName; //Select default printer
            //comboInstalledPrinters.SelectedIndex = 1; //Select a printer by its number in the array


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Filepath = TxtPathOrigin.Text;
            string Filename = "Document_to_print";
            string PrinterName = comboInstalledPrinters.SelectedItem.ToString(); //"Microsoft Print to PDF";

            PrintDialog Dialog = new PrintDialog();
            IPrinter printer = new Printer();

            // Imprime el archivo
            printer.PrintRawFile(PrinterName, Filepath, Filename);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrinterSettings ps = new PrinterSettings();
            comboInstalledPrinters.SelectedItem = ps.PrinterName;
        }


        //################################################################################################

    }
}
