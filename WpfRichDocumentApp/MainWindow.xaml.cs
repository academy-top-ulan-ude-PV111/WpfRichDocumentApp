using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRichDocumentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileName = "mydoc.xml";
        public MainWindow()
        {
            
            InitializeComponent();

            Paragraph p = new();
            p.Inlines.Add(new Run("Adding from code"));
            doc.Blocks.Add(p);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream file = File.Open(fileName, FileMode.Create))
            {
                if(reader.Document is not null)
                {
                    XamlWriter.Save(reader.Document, file);
                }
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            reader.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream file = File.Open(fileName, FileMode.Open))
            {
                FlowDocument doc = XamlReader.Load(file) as FlowDocument;
                if (doc is not null)
                    reader.Document = doc;
            }
        }
    }
}
