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
using System.IO;

namespace PandellRandomIntegerTester
{
    /// <summary>
    /// Generate List will create the desired list in global gIntList provided the correct min and max integers are entered
    /// 
    /// Test Each Value will itterate through the numbers min to max inclusively and check the number of times it appears.
    /// If the maximum and minimum number of times a number is repeated is one the entries are unique and all are present.
    /// 
    /// Test Via Statistics will generate a min max sum mean and standard deviation for the list 
    /// allowing the user to quickly test reasonability
    /// 
    /// Randomness is not tested as it relies on the c# Random Object and not the Knuth-Fisher-Yates Implementation
    /// </summary>
        
    public partial class MainWindow : Window
    {
        public static List<int> gIntList;
        public MainWindow()
        {
            InitializeComponent();
            GenerateList();
            StatisticalTest();
        }
        public void StatisticalTest(object sender, EventArgs e)
        {
            lblMax.Content = gIntList.Max();
            double mean = gIntList.Average();
            lblMean.Content = mean;
            lblMin.Content = gIntList.Min();
            lblSum.Content = gIntList.Sum();
            double dblVariance = gIntList.ToArray().Select(val => (val - mean) * (val - mean)).Sum();
            lblStDev.Content = Math.Sqrt(dblVariance / gIntList.Count); 
        }
        private void GenerateList(object sender, EventArgs e)
        {
            int min = 1;
            int max = 10000;
            RandomOrderList r= new RandomOrderList();
            bool bValidMin = int.TryParse(txtMin.Text, out min);
            bool bValidMax = int.TryParse(txtMax.Text, out max);
            DateTime start = DateTime.Now;
            gIntList = r.RandomOrderedInts(min, max);
            lblElapsed.Content=(DateTime.Now - start).TotalMilliseconds.ToString("###,###,##0.000");
            lblComplete.Content = " - ";
            lblCount.Content = " - ";
            lblMaxRep.Content = " - ";
            lblMean.Content = " - ";
            lblSum.Content = " - ";
            lblMin.Content = " - ";
            lblMax.Content = " - ";
            lblStDev.Content = " - ";

        }
        private void IterativeTest(object sender, EventArgs e)
        {
            bool Complete = true;
            int MaxReps = 0;
            for (int j = 1; j < 10001; j++)
            {
                Complete = gIntList.Contains(j);
                MaxReps = (gIntList.Count(l => l == j) > MaxReps) ? gIntList.Count(l => l == j) : MaxReps;
            }
            lblCount.Content = gIntList.Count();
            lblMaxRep.Content = MaxReps;
            lblComplete.Content = Complete;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Export.csv"))
            {
                writer.WriteLine("List of Int " + txtMin.Text +" to " + txtMax.Text);
                foreach (int i in gIntList)
                {
                    writer.WriteLine(i.ToString()+",");
                }
                writer.Flush();
            }
            System.Diagnostics.Process.Start("Export.csv");   
        }

    }
}
