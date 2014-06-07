/* Task 01. You are given a C# application which displays an animated 3D model of the Solar system.
 * Use a profiler to find the places in its source code which cause significant performance
 * degradation (bottlenecks). Provide a screenshot of the profiler’s result and indicate the place
 * in the source code where the bottleneck resides (name of the file, line of code).
 * Make a quick fix in the source code in order to significantly improve the performance.
 * Test the code after the fix for correctness + performance.
 */

using System.Windows;

namespace SolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrbitsCalculator _data = new OrbitsCalculator();
        public MainWindow()
        {
            DataContext = _data;
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _data.StartTimer();
        }

        private void Pause_Checked(object sender, RoutedEventArgs e)
        {
            _data.Pause(true);
        }

        private void Pause_Unchecked(object sender, RoutedEventArgs e)
        {
            _data.Pause(false);
        }
    }
}
