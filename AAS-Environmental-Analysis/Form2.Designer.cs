﻿using System;

namespace AAS_Environmental_Analysis
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RegresionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCalculate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.result = new System.Windows.Forms.Label();
            this.future = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RegresionChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(191, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "Linear Regression";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PM10",
            "CO2",
            "NO2",
            "O3"});
            this.comboBox1.Location = new System.Drawing.Point(167, 144);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // RegresionChart
            // 
            chartArea1.Name = "ChartArea1";
            this.RegresionChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.RegresionChart.Legends.Add(legend1);
            this.RegresionChart.Location = new System.Drawing.Point(45, 220);
            this.RegresionChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegresionChart.Name = "RegresionChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.RegresionChart.Series.Add(series1);
            this.RegresionChart.Size = new System.Drawing.Size(715, 405);
            this.RegresionChart.TabIndex = 7;
            this.RegresionChart.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 100);
            this.panel1.TabIndex = 9;
            // 
            // btCalculate
            // 
            this.btCalculate.Active = false;
            this.btCalculate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(209)))));
            this.btCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.btCalculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCalculate.BorderRadius = 4;
            this.btCalculate.ButtonText = " Calculate";
            this.btCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCalculate.DisabledColor = System.Drawing.Color.Gray;
            this.btCalculate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btCalculate.Iconcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.btCalculate.Iconimage = null;
            this.btCalculate.Iconimage_right = null;
            this.btCalculate.Iconimage_right_Selected = null;
            this.btCalculate.Iconimage_Selected = null;
            this.btCalculate.IconMarginLeft = 0;
            this.btCalculate.IconMarginRight = 0;
            this.btCalculate.IconRightVisible = true;
            this.btCalculate.IconRightZoom = 0D;
            this.btCalculate.IconVisible = true;
            this.btCalculate.IconZoom = 55D;
            this.btCalculate.IsTab = false;
            this.btCalculate.Location = new System.Drawing.Point(405, 139);
            this.btCalculate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btCalculate.Name = "btCalculate";
            this.btCalculate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.btCalculate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(209)))));
            this.btCalculate.OnHoverTextColor = System.Drawing.Color.White;
            this.btCalculate.selected = false;
            this.btCalculate.Size = new System.Drawing.Size(123, 38);
            this.btCalculate.TabIndex = 11;
            this.btCalculate.Text = " Calculate";
            this.btCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCalculate.Textcolor = System.Drawing.Color.White;
            this.btCalculate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalculate.Click += new System.EventHandler(this.btCalculate_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(279, 650);
            this.result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 29);
            this.result.TabIndex = 12;
            // 
            // future
            // 
            this.future.AutoSize = true;
            this.future.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.future.Location = new System.Drawing.Point(579, 120);
            this.future.Name = "future";
            this.future.Size = new System.Drawing.Size(0, 29);
            this.future.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 705);
            this.Controls.Add(this.future);
            this.Controls.Add(this.result);
            this.Controls.Add(this.btCalculate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.RegresionChart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linear Regression";
            ((System.ComponentModel.ISupportInitialize)(this.RegresionChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart RegresionChart;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btCalculate;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label future;
    }
}