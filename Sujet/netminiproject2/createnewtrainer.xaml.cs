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
    /// Interaction logic for createnewtrainer.xaml
    /// </summary>
    public partial class createnewtrainer : Window
    {
        public createnewtrainer()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (databaseEntities entities = new databaseEntities())                              //put the information in teacher
            {

                Teacher t = new Teacher();
                var temp = this.trainerid.Text;
                string m = Convert.ToString(temp);
                t.Id = Convert.ToInt32(m);
                t.Name = Convert.ToString(this.trainername.Text);
                t.Firstname = Convert.ToString(this.trainerfirstname.Text);
                t.Promotion_during_validation = Convert.ToString(this.trainervalidation.Text);
                t.Current_Promotion = Convert.ToString(this.trainerPromotion.Text);
                t.E_mail = Convert.ToString(this.trainermail.Text);
                t.Campus = Convert.ToString(this.Campus.Text);
                t.Courses_that_he_would_teach = Convert.ToString(this.alcourse.Text);
                t.Courses_that_he_already_teach = Convert.ToString(this.hacourse.Text);
                t.The_campus_on_which_he_would_give_a_course = Convert.ToString(this.alcampus.Text);
                t.The_campus_on_which_he_has_already_given_a_course = Convert.ToString(this.wouldcampus.Text);
                entities.Teacher.Add(t);
                entities.SaveChanges();
            }
        }
    }
}
