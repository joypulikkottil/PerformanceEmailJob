using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Mail;
using System.Net;
using System.Diagnostics.Metrics;

namespace PerformanceEmailJob
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPerformanceEmailTemplate = new DataTable();
                string constring = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM PerformanceEmailTemplate", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dtPerformanceEmailTemplate);
                        }
                    }
                }
                if (dtPerformanceEmailTemplate !=null)
                {
                    if (dtPerformanceEmailTemplate.Rows.Count > 0)
                    {
                        using (SqlConnection con = new SqlConnection(constring))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    using (DataTable dt = new DataTable())
                                    {
                                        sda.Fill(dt);

                                        if (dt !=null)
                                        {
                                            if(dt.Rows.Count>0)
                                            {

                                                //Condition to check the result -- Exceptional,Exceeds expectations,Meets expectations,Partially meets expectations,Needs Improvement

                                                //Email Template avaialble in the dtPerformanceEmailTemplate datatable

                                                SendEmail();
                                            }
                                        }
                                    }
                                }
                            }
                        }                       

                    }
                }
                MessageBox.Show("Completed");
            }
            catch (Exception ex)
            {
                //
                throw ex;
            }            
        }
        private static void SendEmail()
        {
            System.Net.Mail.MailMessage MyMail = new System.Net.Mail.MailMessage();
            MyMail.From = new MailAddress("");
            MyMail.To.Add("");
            MyMail.CC.Add("");
            MyMail.Subject = "";
            MyMail.Body = "";
            MyMail.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("webmail.dof.abudhabi.ae");
            //smtpClient.Port = 0;
            //smtpClient.Host = "";
            //smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential("", "");
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(MyMail);
        }
    }
}