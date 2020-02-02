﻿using MahApps.Metro.Controls;
using Students.Okna;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Students
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StudentsDBEntities SDE = new StudentsDBEntities();
            var data = from d in SDE.StudentsTable select d;
            ListaStudentowDg.ItemsSource = data.ToList();
            ListaStudentowDg.Items.Refresh();
            ListaStudentowDg.SelectedIndex = 0;
        }

        private void DodajOceneBtn_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentsTable)ListaStudentowDg.SelectedItem;
            AddAssessment DodawanieOceny = new AddAssessment(row.Id);
            bool? result = DodawanieOceny.ShowDialog();
            ListaStudentowDg_SelectionChanged(null, null);
        }

        private void ListaStudentowDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = (StudentsTable)ListaStudentowDg.SelectedItem;
            StudentsDBEntities SDE = new StudentsDBEntities();
            var data = from d in SDE.AssessmentsTable select d;
            if (row != null)
            {
                OcenyDg.ItemsSource = data.ToList().Where(IndeksID => IndeksID.IndeksID == row.Id);
            }
            else
            {
                OcenyDg.ItemsSource = new List<AssessmentsTable>();
            }
        }

        private void DodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            StudentsTable ST = new StudentsTable();
            AddStudent DodawanieStudenta = new AddStudent();
            bool? result = DodawanieStudenta.ShowDialog();
            WyszykajTb_KeyUp(null, null);
            ListaStudentowDg_SelectionChanged(null, null);
        }

        private void EdytujStudenta_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentsTable)ListaStudentowDg.SelectedItem;
            EditStudent EdytujStudenta = new EditStudent(row);
            bool? result = EdytujStudenta.ShowDialog();
            WyszykajTb_KeyUp(null, null);
            ListaStudentowDg_SelectionChanged(null, null);
        }

        private void UsunStudenta_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentsTable)ListaStudentowDg.SelectedItem;
            StudentsDBEntities SDE = new StudentsDBEntities();
            var UsunStudenta = SDE.StudentsTable.Where(w => w.Id == row.Id).FirstOrDefault();
            var UsunOcenyStudenta = SDE.AssessmentsTable.Where(w => w.IndeksID == row.Id).FirstOrDefault();
            SDE.StudentsTable.Remove(UsunStudenta);
            if(UsunOcenyStudenta != null) SDE.AssessmentsTable.Remove(UsunOcenyStudenta);
            SDE.SaveChanges();
            WyszykajTb_KeyUp(null,null);
            ListaStudentowDg_SelectionChanged(null, null);
        }

        private void WyszykajTb_KeyUp(object sender, KeyEventArgs e)
        {
            StudentsDBEntities SDE = new StudentsDBEntities();
            if (WyszykajTb.Text.Count() > 0 || OdDp.SelectedDate.HasValue || DoDp.SelectedDate.HasValue)
            {
                IQueryable<StudentsTable> data;
                if (WyszykajTb.Text.Count() > 0)
                {
                    if (DoDp.SelectedDate.HasValue && OdDp.SelectedDate.HasValue)
                    {
                        data = from d in SDE.StudentsTable where d.StudentName.Trim().Contains(WyszykajTb.Text.Trim()) || d.StudentSurname.Trim().Contains(WyszykajTb.Text.Trim()) || d.Id.ToString().Contains(WyszykajTb.Text.Trim()) && d.DateOfBirt >= OdDp.SelectedDate.Value && d.DateOfBirt <= DoDp.SelectedDate.Value select d;
                    }
                    else if (DoDp.SelectedDate.HasValue)
                    {
                        data = from d in SDE.StudentsTable where d.StudentName.Trim().Contains(WyszykajTb.Text.Trim()) || d.StudentSurname.Trim().Contains(WyszykajTb.Text.Trim()) || d.Id.ToString().Contains(WyszykajTb.Text.Trim()) && d.DateOfBirt <= DoDp.SelectedDate.Value select d;
                    }
                    else if (OdDp.SelectedDate.HasValue)
                    {
                        data = from d in SDE.StudentsTable where d.StudentName.Trim().Contains(WyszykajTb.Text.Trim()) || d.StudentSurname.Trim().Contains(WyszykajTb.Text.Trim()) || d.Id.ToString().Contains(WyszykajTb.Text.Trim()) && d.DateOfBirt >= OdDp.SelectedDate.Value select d;
                    }
                    else
                    {
                        data = from d in SDE.StudentsTable where d.StudentName.Trim().Contains(WyszykajTb.Text.Trim()) || d.StudentSurname.Trim().Contains(WyszykajTb.Text.Trim()) || d.Id.ToString().Contains(WyszykajTb.Text.Trim()) select d;
                    }
                }
                else
                {
                    if (DoDp.SelectedDate.HasValue && OdDp.SelectedDate.HasValue)
                    {
                        data = from d in SDE.StudentsTable where d.DateOfBirt >= OdDp.SelectedDate.Value && d.DateOfBirt <= DoDp.SelectedDate.Value select d;
                    }
                    else if (DoDp.SelectedDate.HasValue)
                    {
                        data = from d in SDE.StudentsTable where d.DateOfBirt <= DoDp.SelectedDate.Value select d;
                    }
                    else if (OdDp.SelectedDate.HasValue)
                    {
                        data = from d in SDE.StudentsTable where d.DateOfBirt >= OdDp.SelectedDate.Value select d;
                    }
                    else
                    {
                        data = from d in SDE.StudentsTable select d;
                    }
                }
                
                ListaStudentowDg.ItemsSource = data.ToList();
                ListaStudentowDg.Items.Refresh();
                ListaStudentowDg.SelectedIndex = 0;
                ListaStudentowDg_SelectionChanged(null, null);
            }
            else
            {
                MetroWindow_Loaded(null, null);
            }
        }

        private void Dp_SelectedDateChanged(object sender, TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
        {
            WyszykajTb_KeyUp(null, null);
        }
    }
}