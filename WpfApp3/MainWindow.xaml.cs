using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;//libreria necessaria
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

namespace WpfApp3
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

        private void btnTaskPar_Click(object sender, RoutedEventArgs e)
        {

            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(100);
                //Con l’istruzione Thread.Sleep(100) si rallenta l’esecuzione del ciclo. Permette di simulare un ritardo di 
                //100 millisecondi.

                //Dispatcher.Invoke(UpdateUI(i)); invocazione senza funzione lambda
                Dispatcher.Invoke(() => UpdateUI(i));
                //funzione lambda attraverso la quale posso permettermi sia
                // di creare un azione ovvero di passare un metodo sia di passare
                //i parametri del metodo
            }
        }

        void UpdateUI(int i)
        {
            lblCount.Content = i.ToString();
        }

    }
}
