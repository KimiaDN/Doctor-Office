using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DoctorOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public User u;
        User_BLL user_bll = new User_BLL();
        Dashbord_BLL dash_bll = new Dashbord_BLL();
        Secretary_BLL secretary_bll = new Secretary_BLL();
        Turn_BLL turn_bll = new Turn_BLL();
        MSG msg = new MSG();
        private void Open_Window(Form f)
        {
            Window w = (Window)this.FindName("MainW");
            BlurBitmapEffect blur = new BlurBitmapEffect();
            blur.Radius = 15;
            w.BitmapEffect = blur;
            f.ShowDialog();
            blur.Radius = 0;
            w.BitmapEffect = blur;
        }


        public void Refresh_Page()
        {
            LogedInUser_Name.Text = u.Name;
            LogedInUser_UserName.Text = u.UserName;
            LogedInUser_ReminderNum.Text = dash_bll.CountReminders(u).ToString();
            Patients_Num.Text = dash_bll.Office_TotalPatients().ToString();
            int a = 0;
            if (user_bll.IsDoctor(u))
            {
                List<Turn> turns = new List<Turn>();
                turns = turn_bll.Read(u.Name, DateTime.Now.Date);
                foreach (var item in turns)
                {
                    if (a <= 5)
                    {
                        PatientTurnXML_UC p = new PatientTurnXML_UC();
                        p.PatientName.Text = item.PatientName;
                        p.PatientPhone.Text = item.PatientPhone;
                        p.VisitTime.Text = item.Time;
                        Grid.SetRow(p, 5 + a);
                        Grid.SetColumnSpan(p, 6);
                        Main_Grid.Children.Add(p);
                        a++;
                    }
                }
                Today_Patients.Text = dash_bll.Today_TotalPatients(u.Name).ToString();
            }
            else if (user_bll.IsSecretary(u))
            {
                Secretary s = secretary_bll.Find(u.id);
                List<Turn> turns = new List<Turn>();
                turns = turn_bll.Read(s.doctor.Name, DateTime.Now.Date);
                foreach (var item in turns)
                {
                    if (a <= 5)
                    {
                        PatientTurnXML_UC p = new PatientTurnXML_UC();
                        p.PatientName.Text = item.PatientName;
                        p.PatientPhone.Text = item.PatientPhone;
                        p.VisitTime.Text = item.Time;
                        Grid.SetRow(p, 5 + a);
                        Grid.SetColumnSpan(p, 6);
                        Main_Grid.Children.Add(p);
                        a++;
                    }
                }
                Today_Patients.Text = dash_bll.Today_TotalPatients(s.doctor.Name).ToString();

            }
            else
            {
                foreach (var item in dash_bll.ReadReminders(u))
                {
                    if (a <= 5)
                    {
                        RemindersXML_UC r = new RemindersXML_UC();
                        r.Reminder_Title.Text = item.Title;
                        r.Reminder_info.Text = item.Info;
                        Grid.SetRow(r, 5 + a);
                        Grid.SetColumnSpan(r, 6);
                        Main_Grid.Children.Add(r);
                        a++;
                    }
                }
                Today_Patients.Text = dash_bll.Today_TotalPatients().ToString();

            }
        }

        private void Users_Managment(object sender, MouseButtonEventArgs e)
        {
            if (user_bll.Access(u, 1, 1))
            {
                UserForm userForm = new UserForm();
                userForm.user = u;
                Open_Window(userForm);
                Refresh_Page();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
           
        }
        private void Patients_Managment(object sender, MouseButtonEventArgs e)
        {
            if (user_bll.Access(u, 2, 1))
            {
                PatientForm patientForm = new PatientForm();
                patientForm.user = u;
                Open_Window(patientForm);
                Refresh_Page();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
            
        }
        private void Visiting_Managment(object sender, MouseButtonEventArgs e)
        {
            if (user_bll.Access(u, 7, 1))
            {
                PatientTurn turn = new PatientTurn();
                turn.user = u;
                Open_Window(turn);
                Refresh_Page();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
        }
        private void Financial(object sender, MouseButtonEventArgs e)
        {
            if (user_bll.Access(u, 8, 1))
            {
                FinantialForm finantial = new FinantialForm();
                finantial.user = u;
                Open_Window(finantial);
                Refresh_Page();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
        }
        private void Reports(object sender, MouseButtonEventArgs e)
        {
            if (user_bll.Access(u, 10, 1))
            {
                ReportsForm reports = new ReportsForm();    
                Open_Window(reports);
                Refresh_Page();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
        }
        private void Reminders(object sender, MouseButtonEventArgs e)
        {
            ReminderForm reminderForm = new ReminderForm();
            Open_Window(reminderForm);
            Refresh_Page();
        }
        private void Messages(object sender, MouseButtonEventArgs e)
        {

        }
        private void Settings(object sender, MouseButtonEventArgs e)
        {

        }
        private void Shut_Dowm(object sender, MouseButtonEventArgs e)
        {
         
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            UploadForm uploadForm = new UploadForm();
            Open_Window(uploadForm);
        }
    }
}
