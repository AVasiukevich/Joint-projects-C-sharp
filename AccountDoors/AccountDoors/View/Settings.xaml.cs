using Microsoft.Win32;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void btn_load_pic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileWindow = new OpenFileDialog();
            openFileWindow.Filter = "Картинки(*.JPG;*.GIF;*.PNG)|*.JPG;*.GIF;*.PNG";
            openFileWindow.CheckFileExists = true;
            if(openFileWindow.ShowDialog() == true)
            {
                tb_pic.Text = openFileWindow.FileName;
            }
        }
    }
}
