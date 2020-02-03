using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Students.Okna
{
    /// <summary>
    /// Interaction logic for AddAssessment.xaml
    /// </summary>
    public partial class AddAssessment : MetroWindow
    {
        int indeksId;
        public AddAssessment(int indeksId)
        {
            InitializeComponent();
            this.indeksId = indeksId;
        }
        
        private void DodajOceneBtn_Click(object sender, RoutedEventArgs e)
        {
            StudentsDBEntities SDE = new StudentsDBEntities();
            AssessmentsTable AT = new AssessmentsTable();
            var checkedAssessment = OcenySp.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            var checkedSubject = PrzedmiotySp.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            AT.Assessment = Decimal.Parse(checkedAssessment.Content.ToString().Replace(".",","));
            AT.IndeksID = indeksId;
            AT.Subjects = checkedSubject.Content.ToString();
            SDE.AssessmentsTable.Add(AT);
            SDE.SaveChanges();
            DialogResult = true;
        }
    }
}
