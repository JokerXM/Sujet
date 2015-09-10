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
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Data;

namespace netminiproject2
{
    /// <summary>
    /// Interaction logic for validation.xaml
    /// </summary>
    public partial class validation : Window
    {
        public validation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new showquestion();
            newWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Question q = new Question();
            notation result = new notation();
            using (databaseEntities shentities = new databaseEntities())
            {
                var emp = this.teacherid.Text;
                result.Id = Convert.ToInt32(emp);
                result.Certifications = this.Certifications.Text;
                string etcscore_s = this.ects.Text;
                int etcscore = Convert.ToInt32(etcscore_s);
                if (etcscore >= 15)
                {
                    result.Validation_of_ECTS_credits = "A";
                }
                else if (etcscore >= 10 && etcscore < 15)
                {
                    result.Validation_of_ECTS_credits = "B";
                }
                else
                {
                    result.Validation_of_ECTS_credits = "C";
                }

                result.work_experience = this.experience.Text;
               
                
                float s = 0;
                float count = 0;

                    Console.WriteLine("which question you asked him (input the id)? ");
                    var heihei = this.questionid.Text;
                    int qid = System.Convert.ToInt32(heihei);
                    string score = this.question.Text;
                    IQueryable<Question> soga = from c in shentities.Question where (c.Id == qid) select c;
                    foreach (var c in soga)
                    {


                        c.ifask = "asked";
                        int finalscore;
                        if (c.level == 1)
                        {
                            switch (score)
                            {
                                case "A": finalscore = 3; count++; break;
                                case "B": finalscore = 2; count++; break;
                                case "C": finalscore = 2; count += 2; break;
                                default: finalscore = 0; count++; break;
                            }
                            s += finalscore;

                        }
                        else if (c.level == 2)
                        {
                            switch (score)
                            {
                                case "A": finalscore = 6; count += 2; break;
                                case "B": finalscore = 3; count++; break;
                                case "C": finalscore = 1; count++; break;
                                default: finalscore = 0; count++; break;
                            }
                            s += finalscore;

                        }
                        else
                        {
                            switch (score)
                            {
                                case "A": finalscore = 3; count++; break;
                                case "B": finalscore = 2; count++; break;
                                case "C": finalscore = 1; count++; break;
                                default: finalscore = 0; count++; break;
                            }
                            s += finalscore;

                        }
                    }



                float finalfinalscore = s / count;
                if (finalfinalscore >= 2 && finalfinalscore <= 3) { result.questionmark = "A"; }
                else if (finalfinalscore >= 1 && finalfinalscore < 2) { result.questionmark = "B"; }
                else if (finalfinalscore < 1) { result.questionmark = "C"; }

                result.finalmark = result.Certifications + result.Validation_of_ECTS_credits + result.work_experience + result.questionmark;

                int Cfinalscore;
                int Efinalscore;
                int Wfinalscore;
                int Qfinalscore;
                int ifpass = 0;

                switch (result.Certifications)
                {
                    case "A": Cfinalscore = 3; ifpass += Cfinalscore; break;
                    case "B": Cfinalscore = 2; ifpass += Cfinalscore; break;
                    case "C": Cfinalscore = 1; ifpass += Cfinalscore; break;
                }
                switch (result.Validation_of_ECTS_credits)
                {
                    case "A": Efinalscore = 3; ifpass += Efinalscore; break;
                    case "B": Efinalscore = 2; ifpass += Efinalscore; break;
                    case "C": Efinalscore = 1; ifpass += Efinalscore; break;
                }
                switch (result.work_experience)
                {
                    case "A": Wfinalscore = 3; ifpass += Wfinalscore; break;
                    case "B": Wfinalscore = 2; ifpass += Wfinalscore; break;
                    case "C": Wfinalscore = 1; ifpass += Wfinalscore; break;
                }
                switch (result.questionmark)
                {
                    case "A": Qfinalscore = 3; ifpass += Qfinalscore; break;
                    case "B": Qfinalscore = 2; ifpass += Qfinalscore; break;
                    case "C": Qfinalscore = 1; ifpass += Qfinalscore; break;
                }
                if (ifpass >= 9)
                {
                    result.ifpassed = "pass";
                }
                else
                {
                    result.ifpassed = "failed";
                }

                resulttext.Inlines.Add(new Run("hey you " + result.ifpassed + " the score is " + result.finalmark));
                resulttext.Inlines.Add(new LineBreak());
     
                shentities.notation.Add(result);
                shentities.SaveChanges();

                if (result.ifpassed == "pass")
                {                
                    var mailwindow = new mailwindow();
                    mailwindow.Show();
   //                 sendmail(result.finalmark, result.Id);

                }
            }
        }
    }
  /*  public void sendmail(string theresult, int id)                                     //send the mail 
        {
            using (databaseEntities entities = new databaseEntities())
            {
                IQueryable<Teacher> temp = from c in entities.Teacher where (c.Id == id) select c;
                foreach (var c in temp)
                {
                    string mailaddress = c.E_mail;

                


                SmtpClient _smtpClient = new SmtpClient();                                        
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;                          
                _smtpClient.Host = "smtp.outlook.com";
                _smtpClient.Port = 25;
                _smtpClient.Credentials = new System.Net.NetworkCredential("167298@supinfo.com", "vDrusQAD3GCP");
                MailMessage _mailMessage = new MailMessage("167298@supinfo.com", c.E_mail);
                _mailMessage.Subject = "[ECTS code] : Validation obtained";                        //subject
                _mailMessage.Body = "hey congratulations,you have passed the validation "+" your result is "+theresult;         //content
                _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;                             
                _mailMessage.IsBodyHtml = true;                                                    
                _mailMessage.Priority = MailPriority.High;                                         
                _smtpClient.Send(_mailMessage);
                }
            }
        }*/
}
