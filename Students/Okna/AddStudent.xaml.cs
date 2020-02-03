using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Students.Okna
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : MetroWindow
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void DodajStudentaBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(IndeksTb.Text);
            StudentsDBEntities SDE = new StudentsDBEntities();
            StudentsTable ST = new StudentsTable();
            var czy_istnieje = SDE.StudentsTable.Where(p => p.Id == id).FirstOrDefault();
            if (czy_istnieje == null)
            {

                ST.Id = Int32.Parse(IndeksTb.Text);
                ST.StudentName = ImieTb.Text;
                ST.StudentSurname = NazwiskoTb.Text;
                ST.DateOfBirt = DataDp.SelectedDate.Value;
                SDE.StudentsTable.Add(ST);
                SDE.SaveChanges();
            }
            else
{
                MessageBox.Show("Istnieje już taki student");
            }
            DialogResult = true;
        }

        private void Tb_Validate(object sender, KeyEventArgs e)
        {
            if (ImieTb.Text.Count() < 3 || NazwiskoTb.Text.Count() < 3 || IndeksTb.Text.Count() != 6 || !DataDp.SelectedDate.HasValue)
            {
                WalidacjaLock.Visibility = Visibility.Visible;
                WalidacjaOpen.Visibility = Visibility.Hidden;
                DodajStudentaBtn.IsEnabled = false;
            }
            else
            {
                WalidacjaLock.Visibility = Visibility.Hidden;
                WalidacjaOpen.Visibility = Visibility.Visible;
                DodajStudentaBtn.IsEnabled = true;
            }
        }

        private void Tb_Validate(object sender, SelectionChangedEventArgs e)
        {
            if (ImieTb.Text.Count() < 3 || NazwiskoTb.Text.Count() < 3 || IndeksTb.Text.Count() != 6 || !DataDp.SelectedDate.HasValue)
            {
                WalidacjaLock.Visibility = Visibility.Visible;
                WalidacjaOpen.Visibility = Visibility.Hidden;
                DodajStudentaBtn.IsEnabled = false;
            }
            else
            {
                WalidacjaLock.Visibility = Visibility.Hidden;
                WalidacjaOpen.Visibility = Visibility.Visible;
                DodajStudentaBtn.IsEnabled = true;
            }
        }

        private void IndeksTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
