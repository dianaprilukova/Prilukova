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
using static Prilukova.MainWindow;

namespace Prilukova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hranilishe hran = new Hranilishe();
        public MainWindow()
        {
            InitializeComponent();
            hran.obshObem();
        }

        public class Toplivo
        {
            public int obem {  get; set; }
            public int plotnost { get; set; }
            public Toplivo(int obem, int plotnost) 
            { 
               this.obem = obem;
               this.plotnost = plotnost;
            }
            public void Massa()
            {

            }
        }

        public class Hranilishe
        {
            public int hranObem { get; set; }
            public int zapas { get; set; }
            public void dostupniObem(int h)
            {
                zapas = zapas + h;
                MessageBox.Show("Объем топлива: " + Convert.ToString(zapas) + " литров топлива");
            }
            public void minusDostupniObem(int h)
            {
                zapas = zapas - h;
                MessageBox.Show("Объем топлива: " + Convert.ToString(zapas) + " литров топлива");
            }
            public void minusDostupniObemForZapravka(int h)
            {
                zapas = zapas - h;
            }
            public void obshObem()
            {
                zapas = 100;
            }
        }

        public class Stancia
        {
            public int zapravit { get; set; }
            public void Zapravka(int z)
            {
                zapravit = z;
                MessageBox.Show("Транспорт заправлен на " + Convert.ToString(z) + " литров топлива") ;
            }
        }

        private void btMassa_Click(object sender, RoutedEventArgs e)
        {
            Toplivo toplivo = new Toplivo(Convert.ToInt32(tbObem.Text), Convert.ToInt32(tbPlotnost.Text));
            MessageBox.Show(Convert.ToString(toplivo));
        }

        private void btZapravka_Click(object sender, RoutedEventArgs e)
        {
            hran.minusDostupniObemForZapravka(Convert.ToInt32(tbZapravka.Text));
            Stancia st = new Stancia();
            st.Zapravka(Convert.ToInt32(tbZapravka.Text));
        }

        private void btDobav_Click(object sender, RoutedEventArgs e)
        {
            hran.dostupniObem(Convert.ToInt32(tbDobav.Text));
        }

        private void btIzv_Click(object sender, RoutedEventArgs e)
        {
            hran.minusDostupniObem(Convert.ToInt32(tbIzv.Text));
        }

        private void btHran_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Объем хранилища " + Convert.ToString(hran.zapas) + " литров топлива");
        }
    }
}
