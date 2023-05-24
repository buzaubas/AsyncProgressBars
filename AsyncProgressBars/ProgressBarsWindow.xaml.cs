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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncProgressBars
{
    /// <summary>
    /// Логика взаимодействия для ProgressBarsWindow.xaml
    /// </summary>
    public partial class ProgressBarsWindow : Window
    {
        public ProgressBarsWindow()
        {
            InitializeComponent();
        }

        public ProgressBarsWindow(int barsNumber)
        {
            InitializeComponent();

            for (int i = 1; i <= barsNumber; i++)
            {
                //GenerateProgressBar();

                ProgressBar bar = new ProgressBar();

                Random r = new Random();
                Brush brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                                  (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

                bar.Foreground = brush;
                bar.Height = 30;
                bar.Width = 300;
                bar.Margin = new Thickness(10); 
                bar.HorizontalAlignment = HorizontalAlignment.Center;
                bar.VerticalAlignment = VerticalAlignment.Center;
                bar.Value = new Random().Next(100);


                RootGrid.RowDefinitions.Add(new RowDefinition());

                Grid.SetRow(bar, i);

                RootGrid.Children.Add(bar); 
            }
        }

        public async Task GenerateProgressBar(ProgressBar bar)
        {
            await Task.Run(() =>
            {
                //Random r = new Random();
                //Brush brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                //                  (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

                //ProgressBar progressBar = new ProgressBar();

                //progressBar.Foreground = brush;

                //RootGrid.Children.Add(progressBar); 

                //Duration duration = new Duration(TimeSpan.FromSeconds(1));

                //DoubleAnimation doubleanimation = new DoubleAnimation(bar.Value + 10, duration);

                //bar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);

                //bar.BeginAnimation(ProgressBar.ValueProperty, new DoubleAnimation(bar.Value + 10, duration));

                Random rnd = new Random();
                rnd.Next(1, 10);

                double num = rnd.NextDouble();

                int sec = rnd.Next(10);

                Thread.Sleep(sec);

                bar.Value += num;

                return num;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //await CallMethodAsync();
        }
    }
}
