using Diary.Parser;
using Diary.Parser.habrahabr;
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

namespace Diary.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParserWorker<string[]> parser;
        public MainWindow()
        {
            InitializeComponent();

            parser = new ParserWorker<string[]>(
                    new ParserHabra()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (var item in arg2)
            {
                lstV_news.Items.Add(item);
            }
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            parser.Settings = new SettingsHabra(1, 2);
            parser.Start();
        }
    }
}
