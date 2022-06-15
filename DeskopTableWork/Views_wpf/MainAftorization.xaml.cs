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
    /// Логика взаимодействия для MainAftorization.xaml
    /// </summary>
    public partial class MainAftorization : Window
    {
        public static PeoplesWebBasaContext context = new PeoplesWebBasaContext();
        public static List<Person> peoples = context.People.ToList();
        public static PeopleWork Worker;
        public MainAftorization(PeopleWork worker)
        {
            InitializeComponent();
            Worker = worker;
            People.ItemsSource = context.People.ToList();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPersonBD();
            MessageBox.Show("добавление произошло");
        }
        private void People_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Worker.IdaccessRights == 2)
            {
                Person person = People.SelectedItem as Person;
                Full_Information Ful_Inf = new Full_Information(person, Worker);
                Ful_Inf.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас нет доступа для изменения и удаления пользователя");
            }
        }
        public void AddPersonBD()
        {
            Person IDLast = peoples.Last();
            Person person = new Person(IDLast.Id + 1, Surname.Text, Name.Text, Lastname.Text, Phone.Text, Adress.Text, Dop.Text);
            context.People.Add(person);
            context.SaveChanges();
        }
    }
}
