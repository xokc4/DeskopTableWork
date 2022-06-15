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

namespace DeskopTableWork.Views_wpf
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public static PeoplesWebBasaContext people = new PeoplesWebBasaContext();
        public Registr()
        {
            InitializeComponent();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int PeopleWorkName = HumanVerification(Login.Text);
            if (Password.Text == Password_Copy.Text)
            {
                if (PeopleWorkName == 1)
                {
                    PeopleWork work = new PeopleWork();

                    if (people.PeopleWorks.Count() == 0)
                    {
                        work = new PeopleWork(0, Login.Text, Password.Text, 1);
                    }
                    else
                    {
                        PeopleWork LastWork = people.PeopleWorks.ToList().Last();
                        work = new PeopleWork(LastWork.Idwork + 1, Login.Text, Password.Text, 1);
                    }
                    people.PeopleWorks.Add(work);
                    people.SaveChanges();
                    MainAftorization aftorization = new MainAftorization(work);
                    aftorization.Show();
                }
            }
        }
        public static int HumanVerification(string login)
        {
            List<PeopleWork> peopleWork = people.PeopleWorks.Where(x => x.NameWork == login).ToList();
            if (peopleWork == null)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
