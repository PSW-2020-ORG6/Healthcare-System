using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        public StatisticsView(String styleName)
        {
            InitializeComponent();

            GeneratePDFButton.IsEnabled = false;

            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    // Resources["tableStyle"] = Application.Current.Resources["tableWhite"];
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    // Resources["tableStyle"] = Application.Current.Resources["tableDark"];
                    break;
            }
        }

        private void GeneratePDFButton_Click(object sender, RoutedEventArgs e)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Create a new PDF document.
                PdfDocument doc = new PdfDocument();
                //Add a page.
                doc.PageSettings.Margins.All = 50;
                PdfPage page = doc.Pages.Add();
                //------------------------------------------------
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                DateTime pocetak =(DateTime) OD.SelectedDate;
                DateTime kraj = (DateTime)DO.SelectedDate;
                PdfTextElement element = new PdfTextElement("STATISTIKA ZAUZETOSTI SALA:\nGENERISANO NA DAN: " + DateTime.Now.ToString() + "\n\n" + " Za koriscenost prostorija tipa: " + Sala.Text + "\n\nU periodu od"
                   + " " + pocetak.ToString("dd.MM.yyyy.") + "\ndo " + kraj.ToString("dd.MM.yyyy") , font, PdfBrushes.Black);
                element.Draw(graphics);
                //------------------------------------------------
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                //Create a DataTable.
                DataTable dataTable = new DataTable();
                //Add columns to the DataTable
                dataTable.Columns.Add("BROJ SOBE");
                dataTable.Columns.Add("PROCENAT ZAUZETOSTI");
                //Add rows to the DataTable.
                dataTable.Rows.Add(new object[] { "101" , "20%" });
                dataTable.Rows.Add(new object[] { "102", "10%" });
                dataTable.Rows.Add(new object[] { "103", "30%" });
                dataTable.Rows.Add(new object[] { "104", "10%" });
                dataTable.Rows.Add(new object[] { "105", "30%" });
                //Assign data source.
                
                pdfGrid.DataSource = dataTable;
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new PointF(10, 200));
                //Save the document.
                doc.Save("Table.pdf");
                //close the document
                doc.Close(true);

                System.Diagnostics.Process.Start("Table.pdf");
            }
        }

        private void OD_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OD.SelectedDate == null || DO.SelectedDate == null)
            {
                return;
            }
            DateTime pocetak = (DateTime)OD.SelectedDate;
            DateTime kraj = (DateTime)DO.SelectedDate;

            if (OD.SelectedDate != null && DO.SelectedDate != null && (pocetak.CompareTo(kraj) < 0))
            {
                GeneratePDFButton.IsEnabled = true;
                return;
            }

            GeneratePDFButton.IsEnabled = false;
            return;
        }
    }
}
