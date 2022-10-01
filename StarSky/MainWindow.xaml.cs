using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StarSky
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += new MouseButtonEventHandler(MoveWindow);
        }
        void MoveWindow(object sender, MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.DragMove();
            this.WindowState = WindowState.Maximized;
        }
        private void PaintSky(object sender, RoutedEventArgs e)
        {
            Grid.Children.Clear();
            int height = (int)Grid.ActualHeight + 1024,
                width = (int)Grid.ActualWidth + 1024;
            Path stars = new Path();
            stars.Fill = Brushes.White;
            GeometryGroup myGeometryGroup = new GeometryGroup();
            Random rnd = new Random();
            for (int i = 0; i < height * width / 1000; i++)
            {
                RectangleGeometry star = new RectangleGeometry();
                star.Rect = new Rect(rnd.Next(width - 3), rnd.Next(height - 3), rnd.Next(1, 3), rnd.Next(1, 3));
                myGeometryGroup.Children.Add(star);
            }
            stars.Data = myGeometryGroup;
            Rectangle sky = new Rectangle();
            sky.Fill = Brushes.Black;
            sky.Height = height;
            sky.Width = width;
            Grid.Children.Add(sky);
            Grid.Children.Add(stars);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            int height = (int)Grid.ActualHeight + 1024,
                width = (int)Grid.ActualWidth + 1024;
            Path stars = new Path();
            stars.Fill = Brushes.White;
            GeometryGroup myGeometryGroup = new GeometryGroup();
            Random rnd = new Random();
            for (int i = 0; i < width * height / 1000; i++)
            {
                RectangleGeometry star = new RectangleGeometry();
                star.Rect = new Rect(rnd.Next(width - 3), rnd.Next(height - 3), rnd.Next(1, 3), rnd.Next(1, 3));
                myGeometryGroup.Children.Add(star);
            }
            stars.Data = myGeometryGroup;
            Rectangle sky = new Rectangle();
            sky.Fill = Brushes.Black;
            sky.Height = height;
            sky.Width = width;
            Grid.Children.Add(sky);
            Grid.Children.Add(stars);
        }
    }
}
