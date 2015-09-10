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
    /// Interaction logic for showquestion.xaml
    /// </summary>
    public partial class showquestion : Window
    {
        public showquestion()
        {
            InitializeComponent();
        }

   

        private void searchbotton_Click(object sender, RoutedEventArgs e)
        {
            using (databaseEntities shentities = new databaseEntities())
            {
  /*              var temp=shentities.Question
                    .Where(question=> question.causees==this.searchcontent.Text)
                    .Select( question => new question 
                {
                 question.level,
                 question.causees,
                 question.questioncontent

                });*/
                  IQueryable<Question> temp = from c in shentities.Question where c.causees == this.searchcontent.Text select c;
      //          IQueryable<Question> temp = from c in shentities.Question select c;
                foreach (var c in temp)
                {
                    {
                        string level_s;
                        switch (c.level)
                        {
                            case 1: level_s = "important"; break;
                            case 2: level_s = "bonus"; break;
                            case 3: level_s = "common"; break;
                            default: level_s = "common"; break;
                        }
                        text.Text = level_s+"\n" +c.causees+"\n"+c.questioncontent+"\n";
                        /*text.Inlines.Add(new Run(level_s));
                        text.Inlines.Add(new LineBreak());
                        text.Inlines.Add(new Run(c.causees));
                        text.Inlines.Add(new LineBreak());
                        text.Inlines.Add(new Run(c.questioncontent));
                        text.Inlines.Add(new LineBreak());
                        text.Inlines.Add(new LineBreak());
                        text.Inlines.Add(new LineBreak());*/
                    }



                    }
                }
            }
            
    }
}
