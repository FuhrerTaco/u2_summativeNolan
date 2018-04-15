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
using System.Windows.Threading;

namespace u2_SummativeNolan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Spaceship s = new Spaceship(new Key[] { Key.Left, Key.Up, Key.Right }, 10, new Point(10, 10));
        Spaceship s2 = new Spaceship(new Key[] { Key.A, Key.W, Key.D }, 10, new Point(150, 150));
        public MainWindow()
        {
            MessageBox.Show("press escape to close. \nCollision also closes the program.");
            InitializeComponent();
            this.Hide();
            dt.Interval = new TimeSpan(170000);
            dt.Tick += dtTick;
            dt.Start();
            //canvas.Children.Add(s.getSprite());
            //canvas.Children.Add(s2.getSprite());
            //Canvas.SetLeft(s.getSprite(), 0);
            //Canvas.SetTop(s.getSprite(), -2);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(s1Window.ActualHeight + ", " + s1Window.ActualWidth);
        }
        private void dtTick(object sender, EventArgs e)
        {

            s.fly();
            s2.fly();
            s.update();
            s2.update();
            if (s.collisionCheck(s2)|| Keyboard.IsKeyDown(Key.Escape))
            {
                Application.Current.Shutdown();
            }
            
            //Console.WriteLine(s.collisionCheck(s2));
            //this.Content = canvas;
        }
    }
}
