using sheldon.окна;
using sheldon.страницы;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace sheldon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.Navigate(new Glavnaya());
        }


        private void SubMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                // Определяем, какую страницу нужно отобразить в зависимости от выбора в подменю
                switch (menuItem.Header.ToString())
                {
                    case "Главная":
                        myFrame.Navigate(new Glavnaya());
                        break;
                    case "Все эпизоды":
                        myFrame.Navigate(new vse_episodi());

                        break;
                    case "Актеры":
                        myFrame.Navigate(new infa_ob_actor());
                        break;
                }
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myFrame.Navigate(new Glavnaya());
        }
        private void i_tema_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (grid.Background == Brushes.LightYellow)
            {
                grid.Background = Brushes.DarkBlue;
            }
            else { grid.Background = Brushes.LightYellow; }

            hui hui = new hui();    
            hui.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
