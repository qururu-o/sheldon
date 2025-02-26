﻿using System;
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
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace sheldon.окна
{
    /// <summary>
    /// Логика взаимодействия для podrobno_actor.xaml
    /// </summary>
    public partial class podrobno_actor : Window
    {
        
        
        string connect = "data source=ALINA\\SQLEXPRESS;initial catalog=Sheldon_Childhood;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        public podrobno_actor(int id)
        {
            InitializeComponent();
            Image image = new Image();
            image.Name = "image_act";
            image.Width = 100;
            image.Height = 150;
            image.Stretch = Stretch.UniformToFill;
            image.Stretch = Stretch.Uniform;
           
            Border border = new Border();
            border.Margin = new Thickness(20, 20, 20, 20);
            border.Child = image;
            border.BorderThickness = new Thickness(4);
            border.BorderBrush = Brushes.Black;
            //border.Padding = new Thickness(1);
            border.Height = image.Height;
            border.Width = image.Width;
            TextBox LABLE = new TextBox();
            LABLE.Width = 100;
            LABLE.Height = 50;
            LABLE.BorderBrush = Brushes.White;
            TextBlock textBlockkk = new TextBlock();
            LABLE.Name = "LABEL_";
            textBlockkk.Name = "tbk_2";
           

            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xF7, 0xE4));
            LABLE.Background = brush;
            s_p.Children.Add(border);
            s_p3.Children.Add(LABLE);
            s_p2.Children.Add(textBlockkk);
            string f_a, i_a;
            string vivod = "select Fotos, Familia_acter, Name_acter, c.Name_career, Rost, Date_of_birth_acter, zn.Names_znak_zodiaka, Vozrast, mr.Strana_mesto_rozhenia, mr.State_mesto_rozhenia, mr.City_mesto_rozhenia, zh.Name_Zhanr, si.Kolichestvo_filmov, si.Promezhytok from Zhanr zh, Zhanr_actera zh_a, Acter a, Foto f, Career c, Career_actera ca, Znak_zodiaka zn, Mesto_rozhenia mr, Spravochnay_informacia si where si.id_Acter = a.id and zh.id=zh_a.id_Zhanr and zh_a.id_Acter = a.id and c.id = ca.id_Career and ca.id_Acter = a.id and f.id_Acter = a.id and zn.id = a.id_Znak_zodiaka and mr.id = a.id_Mesto_rozhenia and f.id_Acter = @Value1";
            using (SqlConnection connec = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(vivod, connec);
                connec.Open();
                cmd.Parameters.AddWithValue("@Value1", id);
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
                    string kariera = rdr.GetString(3);
                    string rost = rdr.GetString(4);
                    DateTime data_r = rdr.GetDateTime(5);
                    string zz = rdr.GetString(6);
                    string let = rdr.GetString(7);
                    string stana = rdr.GetString(8);
                    string shat = rdr.GetString(9);
                    string gorod = rdr.GetString(10);
                    string janr = rdr.GetString(11);
                    int kol_vo_f = rdr.GetInt32(12);
                    string prom = rdr.GetString(13);

                    foreach (var child in s_p.Children)
                    {
                        if (child is Border borde)
                        {
                            if (borde.Child is Image imagee && imagee.Name == "image_act")
                            {
                                imagee.Source = bitmapImage;
                            }
                        }
                    }
                    foreach (var childrr in s_p3.Children)
                    {
                        if (childrr is TextBox lll && lll.Name == $"LABEL_")
                        {
                            lll.Text = $"Актер\n{f_a} {i_a}";

                        }
                       
                    }
                    foreach (var childr in s_p2.Children)
                    {
                        
                        if (childr is TextBlock textBlo && textBlo.Name == $"tbk_2")
                        {
                            textBlo.Text = $"\n\n\nОб актере\n\n\nКарьера\n{kariera}\n\nРост\n{rost}\n\nДата рождения\n{data_r} * {zz} * {let}\n\nМесто рождения\n{stana}, {shat}, {gorod}\n\nЖанры\n{janr}\n\nВсего фильмов\n{kol_vo_f}, {prom}";
                        }
                    }

                }
            }
        }
    }
}
