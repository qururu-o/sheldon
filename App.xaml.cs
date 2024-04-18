using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace sheldon
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        base.OnStartup(e);
    //        // Создаем главное окно
    //        MainWindow mainWindow = new MainWindow();
    //        // Проверяем цвет грида в главном окне
    //        if (mainWindow.grid.Background == Brushes.LightYellow)
    //        {
    //            // Устанавливаем синий цвет грида во всех остальных окнах
    //            EventManager.RegisterClassHandler(typeof(Window), FrameworkElement.LoadedEvent, new RoutedEventHandler((sender, args) =>
    //            {
    //                Window window = sender as Window;
    //                if (window != null)
    //                {
    //                    Grid grid = FindChild<Grid>(window);
    //                    if (grid != null)
    //                    {
    //                        grid.Background = Brushes.DarkBlue;
    //                    }
    //                }
    //            }));
    //        }
    //        else if (mainWindow.grid.Background == Brushes.DarkBlue)
    //        {
    //            EventManager.RegisterClassHandler(typeof(Window), FrameworkElement.LoadedEvent, new RoutedEventHandler((sender, args) =>
    //            {
    //                Window window = sender as Window;
    //                if (window != null)
    //                {
    //                    Grid grid = FindChild<Grid>(window);
    //                    if (grid != null)
    //                    {
    //                        grid.Background = Brushes.DarkBlue;
    //                    }
    //                }
    //            }));
    //        }

    //        // Отображаем главное окно
    //    }
    //    // Рекурсивный метод для поиска элемента Grid в окне
    //    private static T FindChild<T>(DependencyObject parent) where T : DependencyObject
    //    {
    //        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
    //        for (int i = 0; i < childrenCount; i++)
    //        {
    //            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
    //            if (child != null && child is T)
    //            {
    //                return (T)child;
    //            }
    //            else
    //            {
    //                T childOfChild = FindChild<T>(child);
    //                if (childOfChild != null)
    //                {
    //                    return childOfChild;
    //                }
    //            }
    //        }
    //        return null;
    //    }
    }
}
