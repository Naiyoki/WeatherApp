using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mail;
using MySql.Data.MySqlClient;


namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public static string Email = "";
        public static string Role = "";
        public static string City = "";
        const string APPID = "1a77b322b79e2880f4bd9f5cc4467d6f";
        string cityName;
        string ConString = "server=localhost; database=ppt_evaluation; user id=root; password=ppt_testSample;";
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        public Form1()
        {
            
            DateTime Date2,Date3,Date4,Date5;
            InitializeComponent();
            pnlNav.Visible = false;
            pictureBox2.BackColor = Color.Transparent;
            Date2 = DateTime.Now.AddDays(2);
            Date3 = DateTime.Now.AddDays(3);
            Date4 = DateTime.Now.AddDays(4);
            Date5 = DateTime.Now.AddDays(5);
            dateTxt.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            day2Txt.Text = Date2.ToString("dddd");
            day3Txt.Text = Date3.ToString("dddd");
            day4Txt.Text = Date4.ToString("dddd");
            day5Txt.Text = Date5.ToString("dddd");
            NAMEtxt.Visible = false;
            visibilityOff();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void getWeather(string city, string APIID)
        {
            using (WebClient web = new WebClient())
            {
               
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + APIID+"&units=metric&cnt=6");
                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                WeatherInfo.root outPut = result;
                maintempTxt.Text = string.Format("{0} \u00B0"+"C", outPut.main.temp);
                
            }
           
        }

        void visibilityOff()
        {
            pictureBox2.Visible = true;
            label3.Visible = false;
            button1.Visible = false;
            pictureBox3.Visible = true;
            condition1.Visible = false;
            condition2.Visible = false;
            condition3.Visible = false;
            condition4.Visible = false;
            condition5.Visible = false;
            conditionTxt.Visible = false;
            imgMain.Visible = false;
            imgTmw.Visible = false;
            img2.Visible = false;
            img3.Visible = false;
            img4.Visible = false;
            img5.Visible = false;
            NAMEtxt.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            maintempTxt.Visible = false;
            dateTxt.Visible = false;
            label1.Visible = false;
        }
        void visibilityOn()
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            button1.Visible = true;
            condition1.Visible = true;
            condition2.Visible = true;
            condition3.Visible = true;
            condition4.Visible = true;
            condition5.Visible = true;
            conditionTxt.Visible = true;
            imgMain.Visible = true;
            imgTmw.Visible = true;
            img2.Visible = true;
            img3.Visible = true;
            img4.Visible = true;
            img5.Visible = true;
            NAMEtxt.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            maintempTxt.Visible = true;
            dateTxt.Visible = true;
            label1.Visible = true;
        }

        void displayForcast(string city, string APIID)
        {
            string url= string.Format("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + APIID);
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<weatherForcast>(json);
                weatherForcast forcast = Object;
                condition1.Text = string.Format("{0}", forcast.list[1].weather[0].main);
                condition2.Text = string.Format("{0}", forcast.list[2].weather[0].main);
                condition3.Text = string.Format("{0}", forcast.list[3].weather[0].main);
                condition4.Text = string.Format("{0}", forcast.list[4].weather[0].main);
                condition5.Text = string.Format("{0}", forcast.list[5].weather[0].main);
                conditionTxt.Text = string.Format("{0}", forcast.list[0].weather[0].main);


                

                if (conditionTxt.Text == "Rain")
                {
                    imgMain.Image = Properties.Resources.rain;
                }
                else if(conditionTxt.Text == "Clear")
                {
                    imgMain.Image = Properties.Resources.sun;
                }
                else if(conditionTxt.Text == "Clouds")
                {
                    imgMain.Image = Properties.Resources.cloud;
                }

                if (condition1.Text == "Rain")
                {
                    imgTmw.Image = Properties.Resources.rain;
                }
                else if (condition1.Text == "Clear")
                {
                    imgTmw.Image = Properties.Resources.sun;
                }
                else if (condition1.Text == "Clouds")
                {
                    imgTmw.Image = Properties.Resources.cloud;
                }

                if (condition2.Text == "Rain")
                {
                    img2.Image = Properties.Resources.rain;
                }
                else if (condition2.Text == "Clear")
                {
                    img2.Image = Properties.Resources.sun;
                }
                else if (condition2.Text == "Clouds")
                {
                    img2.Image = Properties.Resources.cloud;
                }

                if (condition3.Text == "Rain")
                {
                    img3.Image = Properties.Resources.rain;
                }
                else if (condition3.Text == "Clear")
                {
                    img3.Image = Properties.Resources.sun;
                }
                else if (condition3.Text == "Clouds")
                {
                    img3.Image = Properties.Resources.cloud;
                }

                if (condition4.Text == "Rain")
                {
                    img4.Image = Properties.Resources.rain;
                }
                else if (condition4.Text == "Clear")
                {
                    img4.Image = Properties.Resources.sun;
                }
                else if (condition4.Text == "Clouds")
                {
                    img4.Image = Properties.Resources.cloud;
                }

                if (condition5.Text == "Rain")
                {
                    img5.Image = Properties.Resources.rain;
                }
                else if (condition5.Text == "Clear")
                {
                    img5.Image = Properties.Resources.sun;
                }
                else if (condition5.Text == "Clouds")
                {
                    img5.Image = Properties.Resources.cloud;
                }
            }
        }
        string getForcast1(string city, string APIID)
        {
            string condition;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + APIID);
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<weatherForcast>(json);
                weatherForcast forcast = Object;
                condition = string.Format("{0}", forcast.list[1].weather[0].main);
            }
            return condition;
        }
        private void Kingston_Click(object sender, EventArgs e)
        {
            visibilityOn();
            string city = "Kingston";
            pnlNav.Height = Kingston.Height;
            pnlNav.Top = Kingston.Top;
            pnlNav.Left = Kingston.Left;
            Kingston.BackColor = Color.FromArgb(46, 52, 73);

            pnlNav.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            dateTxt.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            NAMEtxt.Visible=true;
            NAMEtxt.Text = city;
            getWeather(city, APPID);
            displayForcast(city, APPID);
            
        }

        private void MBay_Click(object sender, EventArgs e)
        {
            visibilityOn();
            string city = "Montego Bay";
            pnlNav.Visible = true;
            pnlNav.Height = MBay.Height;
            pnlNav.Top = MBay.Top;
            MBay.BackColor = Color.FromArgb(46, 52, 73);
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            NAMEtxt.Text = city;
            getWeather(city, APPID);
            displayForcast(city, APPID);
        }

        private void Kingston_Leave(object sender, EventArgs e)
        {

            Kingston.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void MBay_Leave(object sender, EventArgs e)
        {

            MBay.BackColor = Color.FromArgb(24, 30, 54);
        }


        private void close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void emailValues()
        {
            string username = "anagami54@gmail.com";
            string password = "sonic5678";
            string smtpcli = "smtp.gmail.com";
            int port = 587;
            string to = Email;
            string cc = "";
            string subject = "Schedule Change Notice";
            string condition;
            string message;
          

        condition = getForcast1(City, APPID);
        if (condition == "Clouds")
        {
            if (Role == "IT")
            {
                message = "Schedule Change: Effectively, you will only be working 4 hours tomorrow and not the usual 8 hours. Do not hit the streets.";
            }
            else
            {
                message = "Schedule Change: Effectively, you will only be working 4 hours today and not the usual 8 hours.";
            }
        }
        else
        {
            message = "Work hours will remain 8 hours.";
        }
            
            
            
            label3.Text = smtpcli;
            login = new NetworkCredential(username, password);
            client = new SmtpClient(smtpcli);
            client.Port = port;
            client.EnableSsl = true;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress("anagami54@gmail.com", "Krace Grennedy Boss", Encoding.UTF8) };
            msg.To.Add(new MailAddress(to));

            msg.Subject = subject;
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
           // msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
           // client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            client.SendAsync(msg, userstate);
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error!=null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState,e.Error),"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void getData()
        {
            MySqlConnection cnn = new MySqlConnection(ConString);
            try
            {
                cnn.Open();
                //MessageBox.Show("Connection Open!");

                string sqlSelectQuery = "SELECT * FROM emprecord";
                MySqlCommand cmd = new MySqlCommand(sqlSelectQuery, cnn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    City = dr.GetValue(4).ToString();
                    Role = dr.GetValue(7).ToString();
                    Email = dr.GetValue(8).ToString();
                    
                    emailValues();
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }
        }
    }
}
