using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ТА6.Controller;
using ТА6.Data;

namespace WpfApp
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
        HTController controller;

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            bool choice = DoubleHasing.IsChecked == true ? true : false;

            try
            {
                controller = new HTController(choice, Int32.Parse(InputLength.Text));
            }
            catch (Exception ex)
            {
                Status.Background = Brushes.OrangeRed;
                Status.Content = ex.Message;
                return;
            }

            Status.Background = Brushes.DarkGreen;
            Status.Content = "Ok";

            InputLength.IsEnabled = false;
            DoubleHasing.IsEnabled = false;
            CuckooHashing.IsEnabled = false;
            Run.IsEnabled = false;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                controller.Set(InputSurname.Text, DateTime.Parse(InputDate.Text));
                sw.Stop();
            }
            catch (Exception ex)
            {
                sw.Stop();
                Status.Background = Brushes.OrangeRed;
                Status.Content = ex.Message + sw.Elapsed.TotalSeconds + "s.";
                return;
            }

            Status.Background = Brushes.DarkGreen;
            Status.Content = "Created;" + sw.Elapsed.TotalSeconds + "s."; ;
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            SurnameBirthData entity;
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                entity = controller.Get(InputSurname.Text);
                sw.Stop();
            }
            catch (Exception ex)
            {
                sw.Stop();
                Status.Background = Brushes.OrangeRed;
                Status.Content = ex.Message + sw.Elapsed.TotalSeconds + "s.";
                return;
            }

            Status.Background = Brushes.DarkGreen;
            Status.Content = $"Found entity {entity.surname} with {entity.dateOfBirth} date;" + sw.Elapsed.TotalSeconds + "s."; ;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                controller.Update(InputSurname.Text, DateTime.Parse(InputDate.Text));
            }
            catch (Exception ex)
            {
                Status.Background = Brushes.OrangeRed;
                Status.Content = ex.Message + sw.Elapsed.TotalSeconds + "s.";
                return;
            }

            Status.Background = Brushes.DarkGreen;
            Status.Content = "Updated;" + sw.Elapsed.TotalSeconds + "s."; ;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                controller.Delete(InputSurname.Text);
            }
            catch (Exception ex)
            {
                Status.Background = Brushes.OrangeRed;
                Status.Content = ex.Message + sw.Elapsed.TotalSeconds + "s.";
                return;
            }

            Status.Background = Brushes.DarkGreen;
            Status.Content = "Deleted;" + sw.Elapsed.TotalSeconds + "s.";
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Output.Text = controller.GetTableLog();
            }
            catch (Exception ex)
            {
                Status.Background = Brushes.OrangeRed;
                Status.Content = ex.Message;
                return;
            }
        }
    }
}
