using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TakParConInputText
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
            Task.Factory.StartNew(() => DoWork(max));

            //per passare il parametro task anche in questo caso trasformo il metodo in azione
            //parametro max stabilito dall'utente per definire la fine del ciclo
        
        }

        void DoWork(int max)
        {
            for (int i = 0; i < max; i++)
            {//simuliamo un ritardo
                
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => UpdateUI(i));

            }
        }

        void UpdateUI(int i)
        {
            lblCount.Content = i.ToString();
        }

        //ad un task posso passare piu dati e anche il canale di comunicazione
        //Vedi ex. TaskParDatiECanale
    }
}
