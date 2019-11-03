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

namespace DuckShooting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int duckTick = -1;
        int duck1Tick = -2;
        int duck2Tick = -3;
        public MainWindow()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(20, 0, 0);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Start();
            InitializeComponent();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            duck.Margin = new Thickness(duck.Margin.Left + duckTick, duck.Margin.Top, 0, 0);
            duck1.Margin = new Thickness(duck1.Margin.Left + duck1Tick, duck1.Margin.Top, 0, 0);
            duck2.Margin = new Thickness(duck2.Margin.Left + duck2Tick, duck2.Margin.Top, 0, 0);

            int i = 0;
            if (duck.IsVisible == true) {
                i++;
            }
            if (duck1.IsVisible == true)
            {
                i++;
            }
            if (duck2.IsVisible == true)
            {
                i++;
            }
            scoreLabel.Content = "Score 3/" + i;

            if (duck.Margin.Left <= this.Width / 2)
            {
                duck.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;
                duck.RenderTransform = flipTrans;
                duckTick = duckTick * -1;
            }
            if (duck.Margin.Left + duck.Width >= this.Width)
            {
                duck.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = 1;
                duck.RenderTransform = flipTrans;
                duckTick = duckTick * -1;
            }

            if (duck1.Margin.Left <= this.Width/2) {
                duck1.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;
                duck1.RenderTransform = flipTrans;
                duck1Tick = duck1Tick * -1;
            }
            if (duck1.Margin.Left + duck1.Width >= this.Width)
            {
                duck1.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = 1;
                duck1.RenderTransform = flipTrans;
                duck1Tick = duck1Tick * -1;
            }
            if (duck2.Margin.Left <= this.Width / 2)
            {
                duck2.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;
                duck2.RenderTransform = flipTrans;
                duck2Tick = duck2Tick * -1;
            }
            if (duck2.Margin.Left + duck2.Width >= this.Width)
            {
                duck2.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = 1;
                duck2.RenderTransform = flipTrans;
                duck2Tick = duck2Tick * -1;
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(this);
            target.Margin = new Thickness(point.X, point.Y, 0, 0);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(this);
            target.Margin = new Thickness(point.X - target.ActualWidth/2, point.Y - target.ActualHeight / 2, 0, 0);
        }

        private void Duck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            duck.Visibility = Visibility.Hidden;
        }

        private void Duck1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            duck1.Visibility = Visibility.Hidden;
        }

        private void Duck2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            duck2.Visibility = Visibility.Hidden;
        }
    }
}
