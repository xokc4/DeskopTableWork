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

namespace DeskopTableWork.Views_wpf
{
    /// <summary>
    /// Логика взаимодействия для Full_Information.xaml
    /// </summary>
    public partial class Full_Information : Window, InterfaceUserChanges
    {
        public static PeoplesWebBasaContext peoplesList = new PeoplesWebBasaContext();
        public static Person personOnly;
        public static PeopleWork Worker;
        public Full_Information(Person person, PeopleWork Worker)
        {
            InitializeComponent();
            personOnly = person;
            ID.Text = person.Id.ToString();
            Lastname.Text = person.Lastname;
            Name.Text = person.Name;
            Surname.Text = person.Surname;
            Phone.Text = person.Phone;
            Adress.Text = person.Adress;
            Dop.Text = person.Description;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ChangeUser();
            MessageBox.Show("Изменение произошло");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser();
            this.Close();
        }

        private void Bak_Click(object sender, RoutedEventArgs e)
        {
            MainAftorization main = new MainAftorization(Worker);
            main.Show();
            this.Close();
        }
        public void DeleteUser()
        {
            peoplesList.People.Remove(personOnly);
            peoplesList.SaveChanges();
        }
        public void ChangeUser()
        {
            personOnly.Id = Convert.ToInt32(ID.Text);
            personOnly.Lastname = Lastname.Text;
            personOnly.Name = Name.Text;
            personOnly.Surname = Surname.Text;
            personOnly.Phone = Phone.Text;
            personOnly.Adress = Adress.Text;
            personOnly.Description = Dop.Text;
            peoplesList.People.Update(personOnly);
            peoplesList.SaveChanges();
        }
    }
}
