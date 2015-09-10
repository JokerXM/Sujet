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
    /// Interaction logic for createquestion.xaml
    /// </summary>
    
    public partial class createquestion : Window
    {
        public createquestion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (databaseEntities qentities = new databaseEntities())                         //input the data in the question
            {
                Question q = new Question();
              
                var temp = this.questionid.Text;
                string m = Convert.ToString(temp);
                q.Id = Convert.ToInt32(m);
                int i;
                if(bonus.Tag=="1")
                {
                    i = 1;
                }
                else if(important.Tag=="1")
                {
                    i = 2;
                }
                else
                {
                    i = 3;
                }

                q.level = i;
                q.causees = Convert.ToString(this.course.Text);
                q.questioncontent = Convert.ToString(this.questioncontent.Text);
                q.ifask = Convert.ToString("noasked");
                qentities.Question.Add(q);
                qentities.SaveChanges();


            }

        }

        private void important_Checked(object sender, RoutedEventArgs e)
        {
            important.Tag = "1";
        }

        private void bonus_Checked(object sender, RoutedEventArgs e)
        {
            bonus.Tag = "1";
           
        }

        private void common_Checked(object sender, RoutedEventArgs e)
        {
            common.Tag = "1";
        }

        public class ABC
        {
            public int count; //全局变量
            
           public int get() { return this.count; }
           public void set(int i) { this.count = i; }
           
        }
    }
}
