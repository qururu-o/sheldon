using sheldon.база;
using sheldon.окна;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace sheldon.страницы
{
    /// <summary>
    /// Логика взаимодействия для infa_ob_actor.xaml
    /// </summary>
    public partial class infa_ob_actor : Page
    {
        string connect, f_a, f_p, i_a, i_p;

       

        int k_v_akt, ID;
        public infa_ob_actor()
        {
            InitializeComponent();
            connect = "data source=ALINA\\SQLEXPRESS;initial catalog=Sheldon_Childhood;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";


            string kol_vo_act = "select count(id) from Acter";

            using (SqlConnection connec = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(kol_vo_act, connec);
                connec.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    k_v_akt = rdr.GetInt32(0);
                }
            }
            int count;
            if (k_v_akt % 2 == 0 )
            {
                count = k_v_akt / 2;
            } 
            else 
            { count = (k_v_akt + 1) /2; }

            for (int i = 0; i < count; i++)
            {

                RowDefinition rowDefinition = new RowDefinition();
                grid.RowDefinitions.Add(rowDefinition);
               
            }
            int a_id = 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (k_v_akt % 2 != 0 && count - i == 1 && j == 1)
                    {
                        break;
                    }
                    else
                    {
                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Name = "stp_" + i.ToString() + j.ToString();
                        stackPanel.Orientation = Orientation.Horizontal;

                        Image image = new Image();
                        image.Name = "image_act_" + a_id.ToString();
                        image.Width = 100;
                        image.Height = 150;
                        image.Stretch = Stretch.UniformToFill;
                        image.Stretch = Stretch.Uniform;
                        image.Margin = new Thickness(20, 20, 20, 20);
                        image.MouseDown += Image_Click;

                        ToolTip toolTip = new ToolTip();
                        toolTip.Content = "Нажмите на фото, чтобы узнать больше об актере";
                        image.ToolTip = toolTip;

                        TextBlock textBlock = new TextBlock();
                        textBlock.Name = "tbk_" + a_id.ToString();
                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xF7, 0xE4));
                        textBlock.Background = brush;
                        a_id++;
                        Grid.SetRow(stackPanel, j);

                        Grid.SetColumn(stackPanel, j);


                        stackPanel.Children.Add(image);
                        stackPanel.Children.Add(textBlock);

                        Grid.SetRow(stackPanel, i);
                        Grid.SetColumn(stackPanel, j);
                        grid.Children.Add(stackPanel);
                    }


                }
            }
            int akterishka = 1;
            string vivod = "select Fotos, Familia_acter, Name_acter, Familia_personazh, Names, a.id from Acter a, Foto f, Personazh p, Personazh_and_Acter pa where f.id_Acter = a.id and pa.id_Acter = a.id and pa.id_Personazh = p.id";
            using (SqlConnection connec = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(vivod, connec);
                connec.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    byte[] imageBytes = (byte[])rdr["Fotos"];

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = new MemoryStream(imageBytes);
                    bitmapImage.EndInit();

                    f_a = rdr.GetString(1);
                    i_a = rdr.GetString(2);
                    f_p = rdr.GetString(3);
                    i_p = rdr.GetString(4);
                    ID = rdr.GetInt32(5);
                    foreach (StackPanel stackPanel in grid.Children)
                    {
                        foreach (var child in stackPanel.Children)
                        {
                            if (child is TextBlock textBlock && textBlock.Name == $"tbk_{akterishka}")
                            {
                                textBlock.Text = $"\n\n\n\tАктер\n\t{f_a} {i_a}\n\n\tРоль\n\t{f_p} {i_p}";
                            }
                            if (child is Image image && image.Name == $"image_act_{akterishka}")
                            {
                                image.Source = bitmapImage;
                            }
                        }
                    }
                    akterishka++;
                }
            }

        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            Image clickedImage = sender as Image;
            if (clickedImage != null)
            {
                string imageName = clickedImage.Name;

                string[] parts = imageName.Split('_');

                if (parts.Length >= 2)
                {
                    int partToUse = Convert.ToInt32(parts[2]);
                    podrobno_actor newWindow = new podrobno_actor(partToUse);
                    newWindow.Show();
                }
            }

           
        }
    }
}
