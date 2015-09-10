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
    /// Interaction logic for trainer.xaml
    /// </summary>
    public partial class trainer : Window
    {
        public trainer()
        {
            InitializeComponent();
        }

     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newwindow = new createnewtrainer();
            newwindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newwindow = new showtrainer();
            newwindow.Show();
        }
    }
}
