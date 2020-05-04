using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAS_Environmental_Analysis
{
    public partial class Form1 : Form
    {

        //------------------------------------------------
        public int offset = 0;
        public String extension = "";
        public String url = "";
        public String id = "";

        List<Data> data = null;
        List<Dupla> Filter = new List<Dupla>();
        List<TextBox> Boxes = new List<TextBox>();

        TextBox txtFecha = new TextBox();
        TextBox txtTecnologia = new TextBox();
        TextBox txtAutoridad = new TextBox();
        TextBox txtEstacion = new TextBox();
        TextBox txtLatitud = new TextBox();
        TextBox txtLongitud = new TextBox();
        TextBox txtCDepartamento = new TextBox();
        TextBox txtDepartamento = new TextBox();
        TextBox txtCMunicipio = new TextBox();
        TextBox txtMunicipio = new TextBox();
        TextBox txtTEstacion = new TextBox();
        TextBox txtExposicion = new TextBox();
        TextBox txtVariable = new TextBox();
        TextBox txtUnidad = new TextBox();
        TextBox txtConcentracion = new TextBox();

        //----------------------------------------------------

        public Form1()
        {
            InitializeComponent();

            //---------------------------------------------
            this.Size = new Size(1100, 560);
            paneDataBase.Visible = true;
            paneMultipleFilters.Visible = false;
            paneFilters.Visible = false;
            rbSingle.Visible = false;
            rbMultiple.Visible = false;
            //---------------------------------------------
            Filter.Add(new Dupla("Fecha", "fecha=") { });
            Filter.Add(new Dupla("Autoridad", "autoridad_ambiental=") { });
            Filter.Add(new Dupla("Estacion", "nombre_de_la_estaci_n="));
            Filter.Add(new Dupla("Tecnologia", "tecnolog_a="));
            Filter.Add(new Dupla("Latiitud", "latitud="));
            Filter.Add(new Dupla("Longitud", "longitud="));
            Filter.Add(new Dupla("C Departamento", "c_digo_del_departamento="));
            Filter.Add(new Dupla("Departamento", "departamento="));
            Filter.Add(new Dupla("C Municipio", "c_digo_del_municipio="));
            Filter.Add(new Dupla("Municipio", "nombre_del_municipio="));
            Filter.Add(new Dupla("T Estacion", "tipo_de_estaci_n="));
            Filter.Add(new Dupla("Exposicion", "tiempo_de_exposici_n="));
            Filter.Add(new Dupla("Variable", "variable="));
            Filter.Add(new Dupla("Unidad", "unidades="));
            Filter.Add(new Dupla("Concentracion", "concentraci_n="));

            //---------------------------------------------------
            Boxes.Add(txtFecha);
            Boxes.Add(txtAutoridad);
            Boxes.Add(txtEstacion);
            Boxes.Add(txtTecnologia);
            Boxes.Add(txtLatitud);
            Boxes.Add(txtLongitud);
            Boxes.Add(txtCDepartamento);
            Boxes.Add(txtDepartamento);
            Boxes.Add(txtCMunicipio);
            Boxes.Add(txtMunicipio);
            Boxes.Add(txtTEstacion);
            Boxes.Add(txtExposicion);
            Boxes.Add(txtVariable);
            Boxes.Add(txtUnidad);
            Boxes.Add(txtConcentracion);
            createTable();
            //----------------------------------------------------
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            offset = offset + 20;
            callData(offset, url, id);
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            offset = offset - 20;
            if (offset < 0)
            {
                MessageBox.Show("No hay mas datos previos");
            }
            else
            {
                callData(offset, url, id);
            }
        }

        public void callData(int page, String url, String id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + url + "/resource/" + id + ".json?$limit=" + 20 + "&$offset=" + offset + extension);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<Data>>(json);
                dgData.DataSource = data;
            }
            for (int i = 0; i < 100000; i++)
            {
                if (i % 1000 == 0)
                {
                    if (progressBar.Value < 100)
                        progressBar.Value++;
                }
            }
            Thread.Sleep(500);
            progressBar.Value = 1;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            url = tbUrl.Text;
            id = tbId.Text;
            callData(0, url, id);
        }


        public void CreateExcel()
        {
            String file = "C:/Users/juanp/desktop/BaseDatos.csv";
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("Autoridad Ambiental,Nombre Estacion,Tecnologia,Latitud,Longitud,Codigo Departamento,Departamento,Codigo Municipio,Municipio,Tipo Estacion,Tiempo Exposicion,Variable,Unidad,Concentracion,Nueva Columna Georeferenciada");
            for (int c = 0; c < data.Count; c++)
            {
                sw.WriteLine(data[c].autoridad + "," + data[c].estacion + "," + data[c].tecnologia + "," + data[c].latitud + "," + data[c].longitud + "," + data[c].codigo_departamento + "," + data[c].departamento + "," + data[c].codigo_municipio + "," + data[c].municipio + "," + data[c].tipo_estacion + "," + data[c].tiempo_exposicion + "," + data[c].variable + "," + data[c].unidades + "," + data[c].concentracion + "," + data[c].georeferencia + ",");
            }
            sw.Close();
        }

        public void createTable()
        {
            tableLayoutPanel1.RowCount = 15;
            tableLayoutPanel1.ColumnCount = 2;
            for (int c = 1; c < 16; c++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = Filter[c - 1].Filter }, 0, c);
                tableLayoutPanel1.Controls.Add(Boxes[c - 1], 1, c);

            }
            tableLayoutPanel1.AutoScroll = true;
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            extension = "&" + Filter[cbFilter.SelectedIndex].Output + tbValue.Text;
            callData(offset, url, id);
        }

        private void btDataBase_Click(object sender, EventArgs e)
        {
            paneDataBase.Visible = true;
            paneFilters.Visible = false;
            rbSingle.Visible = false;
            rbMultiple.Visible = false;
            this.Size = new Size(1100, 560);
            btClose.Location = new Point(1065, 2);
            btMinimize.Location = new Point(1030, 2);
            paneMultipleFilters.Visible = false;
            paneDataBase.BringToFront();
        }

        private void btFilters_Click(object sender, EventArgs e)
        {
            paneDataBase.Visible = false;
            paneFilters.Visible = true;
            rbSingle.Visible = true;
            rbMultiple.Visible = true;
            paneFilters.BringToFront();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1350, 560);
            btClose.Location = new Point(1315, 2);
            btMinimize.Location = new Point(1280, 2);
            tbValue.Enabled = false;
            cbFilter.Enabled = false;
            btSearch.Enabled = false;
            paneMultipleFilters.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1100, 560);
            btClose.Location = new Point(1065, 2);
            btMinimize.Location = new Point(1030, 2);
            tbValue.Enabled = true;
            cbFilter.Enabled = true;
            btSearch.Enabled = true;
            paneMultipleFilters.Visible = false;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(4.570868, -74.2973328);
            map.MinZoom = 5;
            map.MaxZoom = 100;
            map.Zoom = 10;

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

            double lat = double.Parse(textLat.Text);
            double lon = double.Parse(textLong.Text);
            double t = Double.Parse(ttext.Text) / 1000;
            MessageBox.Show(lat + " " + lon);
            map.Position = new PointLatLng(lat, lon);
            double r = t;
            drawCircle(lat, lon, r);
        }
        
        public void drawCircle(double lat, double lon, double r)
        {
            Pen pen = getPenColor(r);
            SolidBrush solidBrush = getBrushColor(r);

            List <PointLatLng> points = getPoints(lat, lon, r);

            var polygon = new GMapPolygon(points, "MyArea")
            {
               
                Stroke = pen,
                Fill = solidBrush

            };

            var polygons = new GMapOverlay("polygons");
            polygons.Polygons.Add(polygon);

            map.Overlays.Add(polygons);

        }

        private List<PointLatLng> getPoints(double lat, double lon, double r)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            double[] a = new double[16];

            a[0] = 0;
            a[1] = Math.PI / 6;
            a[2] = Math.PI / 4;
            a[3] = Math.PI / 3;
            a[4] = Math.PI / 2;
            a[5] = Math.PI * 2 / 3;
            a[6] = Math.PI * 3 / 4;
            a[7] = Math.PI * 5 / 6;
            a[8] = Math.PI;
            a[9] = Math.PI * 7 / 6;
            a[10] = Math.PI * 5 / 4;
            a[11] = Math.PI * 4 / 3;
            a[12] = Math.PI * 3 / 2;
            a[13] = Math.PI * 5 / 3;
            a[14] = Math.PI * 7 / 4;
            a[15] = Math.PI * 11 / 6;

            for (int i = 0; i<a.Length; i++) {
                double x = r * Math.Cos(a[i]);
                double y = r * Math.Sin(a[i]);

                points.Add(new PointLatLng(x+lat, y+lon));
            }

            return points;
        }

        public Pen getPenColor(double r) {
            Pen pen = new Pen(Color.FromArgb(120, 255, 196, 0), 2);

            if (r * 1000 >= 35) {
                pen = new Pen(Color.FromArgb(120, 255, 87, 40), 2);
            }

            if (r * 1000 >= 70)
            {
                pen = new Pen(Color.FromArgb(120, 201, 0, 53), 2);
            }

            return pen;
        }

        public SolidBrush getBrushColor(double r) {

            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 255, 196, 0));

            if (r * 1000 >= 35)
            {
                solidBrush = new SolidBrush(Color.FromArgb(120, 255, 87, 40));
            }

            if (r * 1000 >= 70)
            {
                solidBrush = new SolidBrush(Color.FromArgb(120, 201, 0, 53));
            }

            return solidBrush;
        }


        
    }
}
