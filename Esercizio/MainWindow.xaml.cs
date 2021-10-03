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

namespace Esercizio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Rispettare le seguenti specifiche:

        //Creare 3 task in modo tale che: 
        //1. un task deve svolgere un conteggio fino a 100 con un delay di 100 ms; 
        //2. un task deve svolgere un conteggio fino ad un massimo stabilito dall’utente, con un delay di 100 
        //ms; 
        //3. un task deve svolgere un conteggio, dopo che l’utente abbia inserito in input sia il massimo sia il
        //delay.
        public MainWindow()
        {
            InitializeComponent();
        }

        //Punto1
        private void btnStartTaskNoPar_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => DoWork(100, 100, lblCountNoPar));

        }

        //Punto2
        private void btnStartTask_Click(object sender, RoutedEventArgs e)
        {
            int max = Convert.ToInt32(txtInitial.Text);
            Task.Factory.StartNew(() => DoWork(max, 100, lblCount));
        }

        //Punto3
        private void btnStartTaskLimitDelay_Click(object sender, RoutedEventArgs e)
        {
            int max2 = Convert.ToInt32(txtInitial2.Text);
            int delay = Convert.ToInt32(txtDelay.Text);
            Task.Factory.StartNew(() => DoWork(max2, delay, lblCount2));

        }

        private void DoWork(int max, int delay, Label lbl)
        {
            for (int i = 0; i < max; i++)
            {
                Dispatcher.Invoke(() => UpdateUI(i, lbl));
                Thread.Sleep(delay); //Using System.Threading perpoterlo utilizzare
            }
        }

        private void UpdateUI(int i, Label lbl)
        {
            lbl.Content = i.ToString();
        }

    }
}
