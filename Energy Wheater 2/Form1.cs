using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Energy_Wheater_2
{
    public partial class Form1 : Form
    {
        static int weatherToday = 0; //Contains the level of rain for the current day
        public static List<int> weatherEachDay = new List<int>(); //Contains the level or rain for each day
        static IEnumerable<int> daysList = Enumerable.Range(1, 30);
        static int mwPrice = 3;
        static int hydroPower = 0;
        static int windPower = 0;
        static int solarPower = 0;
        static int monthlyIncome = 0;

        public Form1()
        {
            InitializeComponent();
            txtLog.Text += "          Welcome to the weather generation App";
            txtLog.Text += Environment.NewLine;
            txtLog.Text += Environment.NewLine;
            txtLog.Text += "Click Generate Weather to create random weather for this month, the click on Calculate Income to see the revenue generated.";
            txtLog.Text += Environment.NewLine;
            txtLog.Text += Environment.NewLine;
        }

        public void ForEachMethod(int weatherToday)
        {
            txtLog.Text = string.Empty;
            txtLog.Text += "          Welcome to the weather generation App";
            txtLog.Text += Environment.NewLine;
            txtLog.Text += Environment.NewLine;
            
            foreach (int day in daysList)
            {
                //Random number from 100 
                //Random rnd = new Random();
                //int randomRain = rnd.Next(1, 100);
                int startValue = 1;
                int endValue = 100;
                var random = new Random((int)DateTime.Now.Ticks);
                var randomRain = random.Next(startValue, endValue + 1);

                if (weatherToday == 0)
                {
                    if (randomRain > 30)
                    {
                        weatherToday = 1;
                        weatherEachDay.Add(1);
                        txtLog.Text += "Rain level on day " + day + " is " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                    else
                    {
                        weatherEachDay.Add(0);
                        txtLog.Text += "\n" + "Rain level on day " + day + " is 0";
                        txtLog.Text += Environment.NewLine;
                    }
                }
                else if (weatherToday == 1)
                {
                    if (randomRain > 40)
                    {
                        weatherToday = 2;
                        weatherEachDay.Add(2);
                        txtLog.Text += "Rain level on day " + day + " goes up to level " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                    else
                    {
                        weatherToday = 0;
                        weatherEachDay.Add(0);
                        txtLog.Text += "Rain level on day " + day + " is at " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                }
                else if (weatherToday == 2)
                {
                    if (randomRain > 50)
                    {
                        weatherToday = 3;
                        weatherEachDay.Add(3);
                        txtLog.Text += "Rain level on day " + day + " moves up to " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                    else
                    {
                        weatherToday = 1;
                        weatherEachDay.Add(1);
                        txtLog.Text += "Rain level on day " + day + " goes down to " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                }
                else if (weatherToday == 3)
                {
                    if (randomRain > 60)
                    {
                        weatherToday = 4;
                        weatherEachDay.Add(4);
                        txtLog.Text += "Rain level on day " + day + " climbs to the dangerous level " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                    else
                    {
                        weatherToday = 2;
                        weatherEachDay.Add(2);
                        txtLog.Text += "Rain level on day " + day + " calms down to level " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                }
                else if (weatherToday == 4)
                {
                    if (randomRain > 75)
                    {
                        weatherToday = 5;
                        weatherEachDay.Add(5);
                        txtLog.Text += "Rain level on day " + day + " goes to violent storm level " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                    else
                    {
                        weatherToday = 3;
                        weatherEachDay.Add(3);
                        txtLog.Text += "Rain level on day " + day + " is a less dangerous level " + weatherToday;
                        txtLog.Text += Environment.NewLine;
                    }
                }
                else if (weatherToday == 5)
                {
                    weatherToday = 3;
                    weatherEachDay.Add(5);
                    txtLog.Text += "Rain level on day " + day + " after the storm, rests at level 3 ";
                    txtLog.Text += Environment.NewLine;
                }
                //txtLog.Text += "Random: " + randomRain + Environment.NewLine; for testing (Random Next issue)
                System.Threading.Thread.Sleep(3); //pause for 3 miliseconds to eliminate the Random Next issue(duplicate randoms)
            }
        }
        public static void PowerGeneration(List<int> weatherEachDay)
        {
            foreach (int z in weatherEachDay)
            {
                hydroPower += z;
                if (z <= 4)
                {
                    windPower += z;
                }
                else
                {
                    windPower += 0;
                }
                switch (z)
                {
                    case 0:
                        solarPower += 5;
                        break;
                    case 1:
                        solarPower += 4;
                        break;
                    case 2:
                        solarPower += 3;
                        break;
                    case 3:
                        solarPower += 2;
                        break;
                    case 4:
                        solarPower += 1;
                        break;
                    case 5:
                        solarPower += 0;
                        break;
                }
            }
        }
        public static void MonthlyIncomeMethod(int mwprice)
        {
            monthlyIncome = (hydroPower + solarPower + windPower) * mwPrice;
        }

        public void btnGenerateWeather_Click(object sender, EventArgs e)
        {
            weatherEachDay.Clear();
            ForEachMethod(weatherToday);
        }

        public void btnCalculateIncome_Click(object sender, EventArgs e)
        {
            PowerGeneration(weatherEachDay);
            MonthlyIncomeMethod(mwPrice);
            textBox1.Text = hydroPower.ToString();
            textBox2.Text = solarPower.ToString();
            textBox3.Text = windPower.ToString();
            textBox7.Text = monthlyIncome.ToString();
            hydroPower = 0;
            solarPower = 0;
            windPower = 0;
            monthlyIncome = 0;
            weatherEachDay.Clear();
        }

        public void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
