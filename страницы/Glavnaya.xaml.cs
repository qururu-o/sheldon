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

namespace sheldon.страницы
{
    /// <summary>
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : Page
    {
        string connect, otz;
        public Glavnaya()
        {
            InitializeComponent();
            
                connect = "data source=ALINA\\SQLEXPRESS;initial catalog=Sheldon_Childhood;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

                string otziiiv = "select Otziv from Otzivi";

                using (SqlConnection connec = new SqlConnection(connect))
                {
                    SqlCommand cmd = new SqlCommand(otziiiv, connec);
                    connec.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string oooo = rdr.GetString(0);
                        otz += $"- {oooo}\n\n";
                    }
                }
            
                string opisani = "select  Opisanie_seriala from Informacia_about_film ";

                using (SqlConnection connec = new SqlConnection(connect))
                {
                    SqlCommand cmd = new SqlCommand(opisani, connec);
                    connec.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string opi = rdr.GetString(0);

                        opisanie.Text = $"{opi}";
                    }
                }
                tbx_otzivi.Text = otz;
            }

           
            

            private void i_tema_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (grid.Background == Brushes.LightYellow)
                {
                    grid.Background = Brushes.DarkBlue;
                }
                else { grid.Background = Brushes.LightYellow; }

            }

            private void bt_podpiska_Click(object sender, RoutedEventArgs e)
            {

            }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void bt_opublik_Click(object sender, RoutedEventArgs e)
            {
                if (tbk_vash_otziv.Text.Length > 0)
                {
                    string polis = "insert into Otzivi(Otziv) values (@Value1)";

                    using (SqlConnection connection = new SqlConnection(connect))
                    using (SqlCommand command = new SqlCommand(polis, connection))
                    {
                        command.Parameters.AddWithValue("@Value1", tbk_vash_otziv.Text);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                    }
                    tbk_vash_otziv.Clear();
                }
            }
        }
    }


