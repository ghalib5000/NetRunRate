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

namespace NetRunRate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StreamReader file;
        public MainWindow()
        {
            InitializeComponent();
        }
        RateCalculator.Rate_Calculator manage = new RateCalculator.Rate_Calculator();
        public int runscore = 0, rungive = 0;
        public double overface = 0, overgive = 0;
        public double res = 0;

        private void Okbtn_Click(object sender, RoutedEventArgs e)
        {
            if (runsConceded.Text != "" && runsScored.Text != "" && oversBowled.Text != "" && oversFaced.Text != "")
            {
                try
                {
                   rungive = Convert.ToInt32(runsConceded.Text);
                    runscore = Convert.ToInt32(runsScored.Text);
                    overface = Convert.ToDouble(oversFaced.Text);
                    overgive = Convert.ToDouble(oversBowled.Text);
                    res = manage.calculate(runscore, rungive, overface, overgive);
                    Result.Text = Convert.ToString(res);
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }

            }
            //reading the data from file
            else if (dataFile.Text != "")
            {
                try
                {//Pass the file path and file name to the StreamReader constructor
                    file = new StreamReader(dataFile.Text);

                    runscore = Convert.ToInt32(file.ReadLine());
                    overface = Convert.ToDouble(file.ReadLine());
                    rungive = Convert.ToInt32(file.ReadLine());
                    overgive = Convert.ToDouble(file.ReadLine());
                   res =  manage.calculate(runscore, rungive, overface, overgive);
                    Result.Text = Convert.ToString(res);
                    file.Close();
                }
                 catch (Exception ex)
                   {
                    Result.Text = ex.Message;
                   }
            }
            else
            {
                Result.Text = " please input correct numbers";
            }
        }
    }
}
