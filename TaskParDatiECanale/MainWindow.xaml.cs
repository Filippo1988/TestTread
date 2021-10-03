using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;//missing using per la classe Thread
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

namespace TaskParDatiECanale
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

        private void btnStartTask_Click(object sender, RoutedEventArgs e)
        {
            int max = Convert.ToInt32(txtInitial.Text);
            int delay = Convert.ToInt32(txtDelay.Text);
            Task.Factory.StartNew(() => DoWork(max, delay, lblCount));


        }

        void DoWork(int max, int delay, Label lbl)
        {
            for (int i = 0; i < max; i++)
            {
                Thread.Sleep(delay);
                Dispatcher.Invoke(() => UpdateUI(i, lbl));
            }
        }
        void UpdateUI(int i, Label lbl)
        {
            lbl.Content = i.ToString();
        }

    }
}
