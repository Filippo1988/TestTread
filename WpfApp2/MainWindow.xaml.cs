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

namespace WpfApp2
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

        private void btnTaskNoPar_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i < 1000; i++)
            {
                Dispatcher.Invoke(UpdateUI(i));//non posso convertire void in un azione di sistema

                //abbiamo un errore
                //noi stiamo passando un metodo
                //Passare un metodo significa 
                //passare un'azione ad un altro metodo. In realtà si passa l’indirizzo 
                //della prima istruzione del metodo(il puntatore al metodo), oltre al parametro i.

                //Per capire questo dobbiamo definire cosa è actione cosa functor
                //l'action è quella cosa vista fin ora ovvero passare metodi che svolgono 
                //un compito ma che non restituiscono nulla, se invece parliamo di passare un metodo
                // che restituisce qualcosa nell'invocazione precedente allora parliamo di functor.
                

                //vai a WpfApp3 - task parametrici - risoluzione del problema (passaggio parametri task)
            }
        }
        void UpdateUI(int i)
        {
            lblCount.Content = i.ToString();
        }
    }
}
