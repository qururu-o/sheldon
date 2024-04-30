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
using static System.Net.WebRequestMethods;

namespace sheldon.страницы
{
    /// <summary>
    /// Логика взаимодействия для vse_episodi.xaml
    /// </summary>
    public partial class vse_episodi : Page
    {
        public vse_episodi()
        {
            InitializeComponent();

            string connect = "data source=ALINA\\SQLEXPRESS;initial catalog=Sheldon_Childhood;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

            for (int i = 0; i < 3; i++)
            {

                RowDefinition rowDefinition = new RowDefinition();
                grid.RowDefinitions.Add(rowDefinition);

            }
            int a_id = 1;
            for (int i = 0; i < 3; i++)
            {
                    {
                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Name = "stp_" + i.ToString() ;
                        stackPanel.Orientation = Orientation.Horizontal;
                        stackPanel.Margin = new Thickness(20, 20, 20, 20);

                        Image image = new Image();
                        image.Name = "im_" + a_id.ToString();
                        image.Width = 300;
                        image.Stretch = Stretch.UniformToFill;
                        image.Stretch = Stretch.Uniform;
                        image.Margin = new Thickness(20, 20, 20, 20);
                    image.MouseLeftButtonDown += Image_MouseLeftButtonDown;

                    TextBlock textBlock = new TextBlock();
                        textBlock.Name = "tbk_" + a_id.ToString();
                        textBlock.TextWrapping = TextWrapping.Wrap;
                        textBlock.Width = 400;
                        textBlock.Height = 100;

                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xF7, 0xE4));
                        textBlock.Background = brush;
                        a_id++;
                        stackPanel.Children.Add(image);
                        stackPanel.Children.Add(textBlock);
                        Grid.SetRow(stackPanel, i);
                        Grid.SetColumn(stackPanel, i);
                        grid.Children.Add(stackPanel);
                    }

            }
            int akterishka = 1;
            string vivod = "select Oblozhkas, sas.Opisanie_seria, Name_seria from Something s, Seria_and_Sezon sas, Video v where s.id_Video = v.id and v.id_Seria_and_Sezon = sas.id";
            using (SqlConnection connec = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(vivod, connec);
                connec.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    byte[] imageBytes = (byte[])rdr["Oblozhkas"];

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = new MemoryStream(imageBytes);
                    bitmapImage.EndInit();

                    string obl = rdr.GetString(1);
                    string nam = rdr.GetString(2);
                    foreach (StackPanel stackPanel in grid.Children)
                    {
                        foreach (var child in stackPanel.Children)
                        {
                            if (child is TextBlock textBlock && textBlock.Name == $"tbk_{akterishka}")
                            {
                                textBlock.Text =$" {nam}\n\n{obl}";
                            }
                            if (child is Image image && image.Name == $"im_{akterishka}")
                            {
                                image.Source = bitmapImage;
                            }
                        }
                    }
                    akterishka++;
                }
            }
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            // Получаем доступ к фрейму на главном окне и выполняем навигацию
            mainWindow.myFrame.Navigate(new Glavnaya());
        }
    }
}
