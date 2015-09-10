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

namespace netminiproject2
{
    /// <summary>
    /// Interaction logic for question.xaml
    /// </summary>
    public partial class question : Window
    {
        public question()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new createquestion();
            createWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var showWindow = new showquestion();
            showWindow.Show();
        }
    }
}
 //<Frame Grid.Row="0" Name="frame"   Source="MainWindow.xaml" NavigationUIVisibility="Hidden" />