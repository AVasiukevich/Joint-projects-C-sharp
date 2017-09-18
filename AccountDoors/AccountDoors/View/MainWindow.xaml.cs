using AccountDoors.View;
using AccountDoors.Model;
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

namespace AccountDoors
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

        private void img_main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //main_text.Text = this.WindowState.ToString();
            Point x = e.GetPosition(img_main);
            if ((x.X > 223 || x.X < 28) || x.Y < 25)
            {
                SelectWindow select_window = new SelectWindow();
                if (select_window.ShowDialog() == true)
                {

                }
            }
            else
            {
                Collection model_window = new Collection();
                if(model_window.ShowDialog() == true)
                {

                }
            }
        }
        private void add_model_Click(object sender, RoutedEventArgs e)
        {
            Settings settings_window = new Settings();
            if(settings_window.ShowDialog() == true)
            {

            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ModelDoorRepository.SaveXML();
        }
    }
}
