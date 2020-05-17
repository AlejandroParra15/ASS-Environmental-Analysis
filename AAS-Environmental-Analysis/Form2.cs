using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAS_Environmental_Analysis
{
    public partial class Form2 : Form
    {
        List<Data> data = null;
        List<String> Dates = new List<String>();
        public static double Dslope;
        public static double DYintercept;
        double[] year = new double[] { 2011, 2012, 2013, 2014, 2015, 2016, 2017 };
        double[] concentration;

        public Form2()
        {
            InitializeComponent();
            Dates.Add("09/04/2011 12:00:00 a. m.");
            Dates.Add("09/04/2012 12:00:00 a. m.");
            Dates.Add("09/04/2013 12:00:00 a. m.");
            Dates.Add("09/04/2014 12:00:00 a. m.");
            Dates.Add("09/04/2015 12:00:00 a. m.");
            Dates.Add("09/04/2016 12:00:00 a. m.");
            Dates.Add("09/04/2017 12:00:00 a. m.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String variable = "";
            switch (comboBox1.SelectedItem)
            {

                case "PM10":
                    variable = "PM10";
                    break;

                case "NO2":
                    variable = "NO2";
                    break;
                case "O3":
                    variable = "O3";
                    break;

            }
            RegresionChart.Series.Clear();
            RegresionChart.Series.Add("Data Points");
            RegresionChart.Series["Data Points"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            concentration = new double[Dates.Count];
            for (int r = 0; r < Dates.Count; r++)
            {
                callData("www.datos.gov.co", "ysq6-ri4e", Dates[r], variable);
                double average = Average(data);
                concentration[r] = average;

                RegresionChart.Series["Data Points"].Points.AddXY(2011 + r, average);


            }
            RegresionChart.Series.Add("QR Line");
            RegresionChart.Series["QR Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            RegresionChart.Series["QR Line"].Color = Color.Cyan;

            double slope, yintercept, rSquared;
            LinearRegression(year, concentration, out rSquared, out yintercept, out slope);
            double predicted1 = (slope * year[0]) + yintercept;
            double predicted2 = (slope * year[6]) + yintercept;
            RegresionChart.Series["QR Line"].Points.AddXY(year[0], predicted1);
            RegresionChart.Series["QR Line"].Points.AddXY(year[6], predicted2);
            result.Text = "Pendiente : " + Math.Round(slope) + "\n" + "\n" + "Intercepto con Y : " + Math.Round(yintercept);
        }

        public void callData(String url, String id, String extension, String variable)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + url + "/resource/" + id + ".json?$limit=" + 20 + "&fecha=" + extension + "&variable=" + variable);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<Data>>(json);

            }

        }

        public double Average(List<Data> data)
        {
            double acum = 0;
            for (int c = 0; c < data.Count; c++)
            {
                acum += data[c].concentracion;
            }
            double average = acum / data.Count;
            return average;
        }

        public static void LinearRegression(
           double[] xVals,
           double[] yVals,
           out double rSquared,
           out double yIntercept,
           out double slope)
        {
            if (xVals.Length != yVals.Length)
            {
                throw new Exception("Input values should be with the same length.");
            }

            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double sumCodeviates = 0;

            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }

            var count = xVals.Length;
            var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

            var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
            var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = rNumerator / Math.Sqrt(rDenom);

            rSquared = dblR * dblR;
            yIntercept = meanY - ((sCo / ssX) * meanX);

            slope = sCo / ssX;
            Dslope = slope;
            DYintercept = yIntercept;
        }

        public static double[] fillArray(List<Data> data, double[] array)
        {
            for (int c = 0; c < data.Count; c++)
            {
                array[c] = data[c].concentracion;
            }
            return array;
        }
    }
}
