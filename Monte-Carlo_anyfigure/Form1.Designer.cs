namespace MonteCarlo_Polygon_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rchtxtbxPoints = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtbxNumberOfVertices = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbxFactorSqr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbxNumberOfPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtbxAreaofPolygon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbxInt = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtbxAverageAreaSqrErrorEvaluation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbxAverageSqrError = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbxAverageArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbxNumberOfTests = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsMarksNextToAxis = false;
            chartArea2.AxisX.LabelStyle.Format = "00.00";
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea2.AxisY.LabelStyle.Format = "00.00";
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MaximumAutoSize = 100F;
            chartArea2.AxisY.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series5.Legend = "Legend1";
            series5.MarkerBorderColor = System.Drawing.Color.Red;
            series5.MarkerColor = System.Drawing.Color.Red;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "Series1";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "Series2";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Color = System.Drawing.Color.Black;
            series7.Legend = "Legend1";
            series7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series7.Name = "Series3";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            series8.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            series8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series8.Name = "Series4";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(668, 685);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.rchtxtbxPoints);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtbxNumberOfVertices);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(692, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Генерация полигона";
            // 
            // rchtxtbxPoints
            // 
            this.rchtxtbxPoints.Location = new System.Drawing.Point(27, 162);
            this.rchtxtbxPoints.Name = "rchtxtbxPoints";
            this.rchtxtbxPoints.Size = new System.Drawing.Size(179, 84);
            this.rchtxtbxPoints.TabIndex = 5;
            this.rchtxtbxPoints.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Отобразить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(31, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 107);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заполнение координат";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(30, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(79, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Генерация";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(30, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Вручную";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtbxNumberOfVertices
            // 
            this.txtbxNumberOfVertices.Location = new System.Drawing.Point(112, 21);
            this.txtbxNumberOfVertices.Name = "txtbxNumberOfVertices";
            this.txtbxNumberOfVertices.Size = new System.Drawing.Size(98, 22);
            this.txtbxNumberOfVertices.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во вершин";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.txtbxFactorSqr);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtbxNumberOfPoints);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtbxNumberOfTests);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(692, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 114);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Свойство испытания";
            // 
            // txtbxFactorSqr
            // 
            this.txtbxFactorSqr.Location = new System.Drawing.Point(26, 84);
            this.txtbxFactorSqr.Name = "txtbxFactorSqr";
            this.txtbxFactorSqr.Size = new System.Drawing.Size(100, 22);
            this.txtbxFactorSqr.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Множитель стороны квадрата";
            // 
            // txtbxNumberOfPoints
            // 
            this.txtbxNumberOfPoints.Location = new System.Drawing.Point(25, 43);
            this.txtbxNumberOfPoints.Name = "txtbxNumberOfPoints";
            this.txtbxNumberOfPoints.Size = new System.Drawing.Size(100, 22);
            this.txtbxNumberOfPoints.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Кол-во точек";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.txtbxAreaofPolygon);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(694, 429);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 81);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Одно исптание";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(76, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "Рассчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbxAreaofPolygon
            // 
            this.txtbxAreaofPolygon.Location = new System.Drawing.Point(119, 19);
            this.txtbxAreaofPolygon.Name = "txtbxAreaofPolygon";
            this.txtbxAreaofPolygon.Size = new System.Drawing.Size(100, 22);
            this.txtbxAreaofPolygon.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Площадь фигуры";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtbxInt);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.txtbxAverageAreaSqrErrorEvaluation);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtbxAverageSqrError);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtbxAverageArea);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(694, 516);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(274, 181);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Группа испытаний";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(8, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Дов. Интервал";
            // 
            // txtbxInt
            // 
            this.txtbxInt.Location = new System.Drawing.Point(97, 107);
            this.txtbxInt.Name = "txtbxInt";
            this.txtbxInt.Size = new System.Drawing.Size(145, 22);
            this.txtbxInt.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(76, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 26);
            this.button3.TabIndex = 8;
            this.button3.Text = "Рассчет";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtbxAverageAreaSqrErrorEvaluation
            // 
            this.txtbxAverageAreaSqrErrorEvaluation.Location = new System.Drawing.Point(97, 79);
            this.txtbxAverageAreaSqrErrorEvaluation.Name = "txtbxAverageAreaSqrErrorEvaluation";
            this.txtbxAverageAreaSqrErrorEvaluation.Size = new System.Drawing.Size(145, 22);
            this.txtbxAverageAreaSqrErrorEvaluation.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(18, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Оценка СКО";
            // 
            // txtbxAverageSqrError
            // 
            this.txtbxAverageSqrError.Location = new System.Drawing.Point(97, 49);
            this.txtbxAverageSqrError.Name = "txtbxAverageSqrError";
            this.txtbxAverageSqrError.Size = new System.Drawing.Size(145, 22);
            this.txtbxAverageSqrError.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(26, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "СКО";
            // 
            // txtbxAverageArea
            // 
            this.txtbxAverageArea.Location = new System.Drawing.Point(97, 21);
            this.txtbxAverageArea.Name = "txtbxAverageArea";
            this.txtbxAverageArea.Size = new System.Drawing.Size(145, 22);
            this.txtbxAverageArea.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(22, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Среднее S";
            // 
            // txtbxNumberOfTests
            // 
            this.txtbxNumberOfTests.Location = new System.Drawing.Point(142, 43);
            this.txtbxNumberOfTests.Name = "txtbxNumberOfTests";
            this.txtbxNumberOfTests.Size = new System.Drawing.Size(100, 22);
            this.txtbxNumberOfTests.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(143, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Кол-во испытаний";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 701);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtbxNumberOfVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchtxtbxPoints;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtbxFactorSqr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxNumberOfPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtbxAreaofPolygon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtbxAverageAreaSqrErrorEvaluation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbxAverageSqrError;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbxAverageArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxNumberOfTests;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbxInt;
    }
}

