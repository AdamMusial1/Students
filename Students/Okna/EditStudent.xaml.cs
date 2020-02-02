using MahApps.Metro.Controls;
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

namespace Students.Okna
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : MetroWindow
    {
        StudentsTable row;
        public EditStudent(StudentsTable row)
        {
            this.row = row;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IndeksTb.Text = row.Id.ToString(); 
            ImieTb.Text = row.StudentName;
            NazwiskoTb.Text = row.StudentSurname;
            DataDp.SelectedDate = row.DateOfBirt;
        }

        private void EdytujStudentaBtn_Click(object sender, RoutedEventArgs e)
        {
            StudentsDBEntities SDE = new StudentsDBEntities();
            var ST = SDE.StudentsTable.Where(p => p.Id == row.Id).FirstOrDefault();
            ST.StudentName = ImieTb.Text;
            ST.StudentSurname = NazwiskoTb.Text;
            ST.DateOfBirt = DataDp.SelectedDate.Value;
            SDE.SaveChanges();
            DialogResult = true;
        }

        private void Tb_Validate(object sender, RoutedEventArgs e)
        {
            if (ImieTb.Text.Count() < 3 || NazwiskoTb.Text.Count() < 3 || IndeksTb.Text.Count() != 6 )
            {
                WalidacjaLock.Visibility = Visibility.Visible;
                WalidacjaOpen.Visibility = Visibility.Hidden;
                EdytujStudentaBtn.IsEnabled = false;
            }
            else
            {
                WalidacjaLock.Visibility = Visibility.Hidden;
                WalidacjaOpen.Visibility = Visibility.Visible;
                EdytujStudentaBtn.IsEnabled = true;
            }
        }

        private void Tb_Validate(object sender, SelectionChangedEventArgs e)
        {
            if (ImieTb.Text.Count() < 3 || NazwiskoTb.Text.Count() < 3 || IndeksTb.Text.Count() != 6)
            {
                WalidacjaLock.Visibility = Visibility.Visible;
                WalidacjaOpen.Visibility = Visibility.Hidden;
                EdytujStudentaBtn.IsEnabled = false;
            }
            else
            {
                WalidacjaLock.Visibility = Visibility.Hidden;
                WalidacjaOpen.Visibility = Visibility.Visible;
                EdytujStudentaBtn.IsEnabled = true;
            }
        }
    }
}
