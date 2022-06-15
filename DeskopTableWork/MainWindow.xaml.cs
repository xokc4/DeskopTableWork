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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeskopTableWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PeoplesWebBasaContext context = new PeoplesWebBasaContext();
        public MainWindow()
        {
            InitializeComponent();  
            People.ItemsSource = context.People.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
          string  loginWork = LoginText.Text;
          string  passwordWork = PasswordBox.Password;
          List<PeopleWork> work = new List<PeopleWork>(context.PeopleWorks.Where(x => x.NameWork == loginWork && x.PasswordWork == passwordWork));
          int t = 1 + 2;
          Views_wpf.MainAftorization af = new Views_wpf.MainAftorization(work[0]);
          af.Show();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            Views_wpf.Registr retistr = new Views_wpf.Registr();
            retistr.Show();
        }
    }
}
