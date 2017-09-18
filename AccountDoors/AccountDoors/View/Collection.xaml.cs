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
using System.Windows.Shapes;

namespace AccountDoors.View
{
    /// <summary>
    /// Interaction logic for Model.xaml
    /// </summary>
    public partial class Collection : Window
    {
        public Collection()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectModel selectModel_window = new SelectModel();
            if(selectModel_window.ShowDialog() == true)
            {

            }
        }
    }
}
