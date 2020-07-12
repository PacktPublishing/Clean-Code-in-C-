using PostSharp.Patterns.Threading;
using System;
using System.Windows;

namespace CH11_ThreadDispatching
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            SetControlState(false);
            DoWork();
        }

        [Dispatched(true)]
        private void SetControlState(bool state)
        {
            StartButton.IsEnabled = state;
        }

        [Background]
        private void DoWork()
        {
            var random = new Random();
            for (var i = 0; i <= 100; i++)
            {
                for (var j = 0; j < 1000000; j++)
                {
                    Math.Sin(random.NextDouble());
                }

                UpdateProgressBar(i);
            }
            SetControlState(true);
        }

        [Dispatched(true)]
        private void UpdateProgressBar(int progress)
        {
            ProgressBar.Value = progress;
        }
    }
}
