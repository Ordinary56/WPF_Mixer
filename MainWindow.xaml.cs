using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace WPF_Mixer
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

        private void tb_man_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                if (!lw_Man.Items.Contains(tb_man.Text))
                {
                    lw_Man.Items.Add(tb_man.Text);
                    tb_man.Clear();
                }
            }
        }

        private void tb_woman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                if (!lw_Woman.Items.Contains(tb_woman.Text))
                {
                    lw_Woman.Items.Add(tb_woman.Text);
                    tb_woman.Clear();
                }
            }
        }
        void MixPairs(object sender, RoutedEventArgs e)
        {
            //Clear the list if it's not empty
            lb_Result.Items.Clear();
            Random rand = new();
            Dictionary<string, string> pairs = new();
            // shuffle the lists containing man and woman names
            List<string> shuffledMan = lw_Man.Items.Cast<string>().OrderBy(x => rand.Next()).ToList();
            List<string> shuffledWoman = lw_Woman.Items.Cast<string>().OrderBy(x => rand.Next()).ToList();
            if (shuffledMan.Count != shuffledWoman.Count)
            {
                MessageBox.Show("Error - Az egyik lista vagy hosszabb vagy rövidebb a másiknál",
                  "ErrorMsg",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
                return;
            }
            for (int i = 0; i < shuffledMan.Count; i++)
            {
                pairs[shuffledMan[i]] = shuffledWoman[i];
            }
            //iterate over the dictionary and add the pairs
            foreach (KeyValuePair<string, string> pair in pairs)
            {
                lb_Result.Items.Add($"{pair.Key} - {pair.Value}");
            }
        }

    }
}
