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
    /// Interaction logic for showtrainer.xaml
    /// </summary>
    public partial class showtrainer : Window
    {
        public showtrainer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var theid_s = this.search.Text;
            int theid = System.Convert.ToInt32(theid_s);
            using (databaseEntities sentities = new databaseEntities())
            {

                IQueryable<Teacher> temp = from c in sentities.Teacher where (c.Id == theid) select c;
                foreach (var c in temp)
                {
                    result.Text = c.Id +'\n' +c.Name + '\n' +c.Firstname +'\n' +c.Promotion_during_validation + '\n' + c.Current_Promotion + '\n' + c.E_mail +'\n' + c.Campus +'\n' + c.Courses_that_he_already_teach + '\n' +c.Courses_that_he_would_teach +'\n' + c.The_campus_on_which_he_has_already_given_a_course +'\n' + c.The_campus_on_which_he_would_give_a_course +'\n';
                                      
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
    
                string thename_s = this.search.Text;
                using (databaseEntities sentities = new databaseEntities())
                {

                    IQueryable<Teacher> temp = from c in sentities.Teacher where (c.Name == thename_s) select c;
                    foreach (var c in temp)
                    {
                        result.Text = c.Id + '\n' + c.Name + '\n' + c.Firstname + '\n' + c.Promotion_during_validation + '\n' + c.Current_Promotion + '\n' + c.E_mail + '\n' + c.Campus + '\n' + c.Courses_that_he_already_teach + '\n' + c.Courses_that_he_would_teach + '\n' + c.The_campus_on_which_he_has_already_given_a_course + '\n' + c.The_campus_on_which_he_would_give_a_course + '\n';
                   
                    }
                }
        }
    }
}
