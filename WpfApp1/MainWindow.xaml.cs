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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //Prima app multithreading
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            //creazione del task e lancio di un task secondario attraverso metodo
            Task.Factory.StartNew(LavoroLungoEComplicato);
        }

        public void LavoroLungoEComplicato()
        {
            //metodo da svolgere lanciato dal task principale
            //esso però non può aggiornare le label della wpf dato che appartengono
            //al task principale e quindi per aggiornarle si usa il Dispatcher che invoca
            //un ulteriore metodo grazie al quale cambio il content della label
            //se non avessi fatto ciò sarei andato in eccezione del tipo
            //"the calling thread cannot access this object because a different thread owns it"
            int valore=0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 100; j++)
                { valore++; }//essendo un thread non parametrico non posso
                            //passare questo valore per stamparlo nella label
            }
            Dispatcher.Invoke(AggiornaInterfacciaUtente);
        }

        public void AggiornaInterfacciaUtente()
        {

            lblTask.Content = $"Finito!";
        }

    }
}
