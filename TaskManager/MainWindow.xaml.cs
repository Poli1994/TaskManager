using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Process> processes = new ObservableCollection<Process>();

        public MainWindow()
        {
            InitializeComponent();

            foreach (Process process in Process.GetProcesses())
            {
                processes.Add(process);
            }

            ProcessesList.ItemsSource = processes;
        }

        private void EndTask_Click(object sender, RoutedEventArgs e)
        {
            (ProcessesList.SelectedItem as Process).Kill();
            processes.Remove((Process)ProcessesList.SelectedItem);
        }

        private void ProcessesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessesList.SelectedItem == null)
            {
                EndTask.IsEnabled = false;
            }
            else
            {
                EndTask.IsEnabled = true;
            }
        }
    }
}
