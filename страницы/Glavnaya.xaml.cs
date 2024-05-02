using sheldon.окна;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace sheldon.страницы
{
    /// <summary>
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : Page
    {
        string connect, otz;
        List<string> list = new List<string> {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16"};
        List<string> list1 = new List<string> {"1","2","3","4","5","6"};
        public Glavnaya()
        {
            InitializeComponent();
            foreach (var item in list)
            { 
                seriya.Items.Add(item);
            }
            foreach (var item in list1)
            {
                seson.Items.Add(item);
            }

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

            string vid = "select Videos from Video where id = 1";

            using (SqlConnection connec = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(vid, connec);
                connec.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    string videoPath = rdr.GetString(0);
                    mediaElement.Source = new Uri(videoPath);
                    mediaElement.LoadedBehavior = MediaState.Manual;
                    mediaElement.UnloadedBehavior = MediaState.Manual;
                    mediaElement.Play();
                }
                rdr.Close();

            }
        }

        private static byte GetVideoData(SqlDataReader rdr)
        {
            return rdr.GetByte(0);
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
                hui hui = new hui();
            hui.Show();
            }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            pleer.Visibility = Visibility.Visible;
            seriya.Visibility = Visibility.Visible;
            seson.Visibility = Visibility.Visible;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            pleer.Visibility=Visibility.Hidden;
            seriya.Visibility = Visibility.Hidden;
            seson.Visibility = Visibility.Hidden;
        }
       
        
        private void seriya_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (seriya.Text == "1" || seriya.Text == "2" || seriya.Text == "3")
            {
                string vid = "select Videos from Video where id = @value1";
                using (SqlConnection connec = new SqlConnection(connect))
                {
                    SqlCommand cmd = new SqlCommand(vid, connec);
                    cmd.Parameters.AddWithValue("@value1", seriya.Text);
                    connec.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string videoPath = rdr.GetString(0);
                        mediaElement.Source = new Uri(videoPath);
                        mediaElement.LoadedBehavior = MediaState.Manual;
                        mediaElement.UnloadedBehavior = MediaState.Manual;
                        mediaElement.Play();
                    }
                    rdr.Close();
                }
            }
            else
            {
                hui hui = new hui();
                hui.Show();
            }
           
           
        }

        private void pleer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (mediaElement.CurrentState == MediaElementState.Playing)
            //{
                mediaElement.Pause();
            //}
            //else
            //{
            //    mediaElement.Play();
            //}
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


