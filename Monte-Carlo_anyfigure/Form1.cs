using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


/*
 * Программа приблизительного рассчета площади N - угольного полигона
 * С помощью метода Монте - Карло
 * Первая группа элементов (Задание и отображение полигона):
 *  - Поле ввода для задания колличества вершин
 *  - два радиобатона для выбора способа задания полигона (вручную или генераця)
 *  - Текстовое поле для задания координат вершин полигона вручную,
 *    в формате X0;Y0
 *              X1;Y1
 *              .....
 *              Xn;Yn
 *  - Кнопка отображения полигона
 *  Прежде чем проводить вычисления необходимо создать полигон, т.е. задать колличество
 *  вершин и введя их (сгенерировав) нажать кнопку "Отобразить".
 * Вторая группа элементов (Задание параметров для одного эксперимента):
 * - Поле ввода для задания колличества случайно генерируемых точек
 * - Поле ввода для задания множителя стороны прямоугольника (области, которая
 *   описывает полигон)
 * - Поле ввода, в котором отображается площадь
 * - Кнопка рассчета
 * Третья группа элементов (Задание параметров для группы экспериментов. Необходимо задать
 *  колличество случайных точек и множитель для прямоугольной области):
 *  - Поле ввода для задания колличества экспериментов
 *  - Поле ввода для отображения средней площади
 *  - Поле ввода для отображения СКО
 *  - Поле ввода для отображения Оценки СКО
 *  - Поле ввода для отображения доверительного интервала
 *  - Кнопка рассчета
 *  
 * Необходимые доработки:
 *  1) Модифицировать метод генерации случайной точки (убрать цикл while()...., т.к. может замедлить вычисления
 */


namespace MonteCarlo_Polygon_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public struct Point//Произвольная точка
        {
            public double x, y;
        }

        Point[] VerticesOfThePolygon;//Вершины многоугольника
        int NumberOfVertices;//колличество вершин многоугольника
        double MaxX, MaxY, MinX, MinY, Max;//координаты прямоугольной области, описывающей полигон

        //класс для создания исключений 
        public class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            {

            }
            public MyException(string message, Exception innerException)
                : base(message, innerException)
            {

            }
        }
//------------------------ Метод проверки на пересечение двух отрезков -----------------------------------
        /*
         * Проверка производится на основе анализа взаимного расположения
         * прямых в пространстве, на которых лежат данные отрезки.
         * В начале определяется, пересекаются ли прямые, на которых лежат
         * отрезки, затем проверяется принадлежность точки пересечения обоим
         * отрезкам. Прямые представляются в виде Ax + By + C = 0, где коэф-
         * фициенты А,В,С получаются с помощью уравнения прямой, проходящей
         * через 2 точки (это концы отрезков).
         * Взаимное расположение прямых определяется с помощью анализа рангов матриц:
         *       (A1  B1)          (A1 B1 -C1)
         *   А = (A2  B2)      B = (A2 B2 -C2).
         *   Если rgA = 2, значит прямые пересекаются, если rgA = 1 и rgB = 1 то прямые
         *   совпадают. Если rgA = 1, rgB = 2 значит прямые параллельны. Также отдельно
         *   учитываются случаи когда либо А = 0, В = 0 - тогда прямые лежат горизонтально
         *   или вертикально, и требуются особые условия, для проверки принадлежности точки
         *   данному отрезку.
         *   В качестве входных параметров в функции используются:
         *   F0 - начальная точка первого отрезка;
         *   F1 - конечная точка первого отрезка;
         *   S0 - начальная точка второго отрезка;
         *   S1 - конечная точка второго отрезка.
         *   Функция возвращает значения -1, 0, 1:
         *   -1  - Заданные отрезки пересекаются
         *    0  - Заданные отрезки не пересекаются и не совпадают
         *    1  - Заданные отрезки совпадают (частично или полностью)
         *   
        */
        public int CheckingCuts(Point F0, Point F1, Point S0, Point S1)
        {
            bool b1, b2, b3, b4;//Условия по разным координатам
            double A1, A2, B1, B2, C1, C2;//коэффициенты прямых, на кот. лежат отрезки
            double rgA, rgB;//ранги соответствующих матриц
            double Xp, Yp;//точка пересечения

            //случай полного совпадения отрезков
            if ((((F0.x == S0.x) && (F0.y == S0.y)) && ((F1.x == S1.x) && (F1.y == S1.y))) ||
                (((F0.x == S1.x) && (F0.y == S1.y)) && ((F1.x == S0.x) && (F1.y == S0.y))))
                return 1;

            //Вычисление коэффициентов А,В,С - прямых, проходящих через данные отрезки
            A1 =  F1.y - F0.y;
            B1 = -(F1.x - F0.x);
            C1 = F0.y * (F1.x - F0.x) - F0.x * (F1.y - F0.y);

            A2 = S1.y - S0.y;
            B2 = -(S1.x - S0.x);
            C2 = S0.y * (S1.x - S0.x) - S0.x * (S1.y - S0.y);

            //вычисление рангов соответствующих матриц
            if ((A1 * B2 - A2 * B1) != 0) rgA = 2; else rgA = 1;

            if (((A1 * B2 - A2 * B1) != 0) || ((-B1 * C2 + B2 * C1) != 0)) rgB = 2; else rgB = 1;

            if (rgA == 2)//если прямые пересекаются
            {
                //точка пересечения прямых
                //вычисляется путем решения СУ, определяемую матрицей В
                //Система решается методом Крамера
                Xp = (-C1 * B2 + C2 * B1) / (A1 * B2 - A2 * B1);
                Yp = (-C2 * A1 + C1 * A2) / (A1 * B2 - A2 * B1);

                //условия принадлежности точек пересечения отрезкам
                b1 = (Xp > Math.Min(F0.x, F1.x)) && (Xp < Math.Max(F0.x, F1.x));
                b2 = (Yp > Math.Min(F0.y, F1.y)) && (Yp < Math.Max(F0.y, F1.y));
                b3 = (Xp > Math.Min(S0.x, S1.x)) && (Xp < Math.Max(S0.x, S1.x));
                b4 = (Yp > Math.Min(S0.y, S1.y)) && (Yp < Math.Max(S0.y, S1.y));

                //если прямые лежат
                //вертикально
                if (A1 == 0)
                    b2 = Yp == F0.y;
                if (A2 == 0)
                    b4 = Yp == S0.y;

                //горизонтально
                if (B1 == 0)
                    b1 = Xp == F0.x;
                if (B2 == 0)
                    b3 = Xp == S0.x;

                //проверяем, принадлежит ли точка пересечения отрезкам
                if (b1 && b2 && b3 && b4)
                    return -1;
            }
            else//если прямые не пересекаются
                if (rgB == 1)//отрезки лежат на одной прямой
                {
                    double Min1, Max1, Min2, Max2;

                    //далее проверяем, не совпадают ли отрезки, лежащие на данной
                    //прямой частично, т.е. частично или полностью лежит ли отрезок
                    //в другом отрезке

                    if ((B1 != 0) && (B2 != 0))//если прямые не лежат вертикально
                    {//проверяем частичное совпадение отрезков, путем сравнения их
                        //координат в проекции на ось Х
                        Min1 = Math.Min(F0.x, F1.x);
                        Max1 = Math.Max(F0.x, F1.x);
                        Min2 = Math.Min(S0.x, S1.x);
                        Max2 = Math.Max(S0.x, S1.x);
                    }
                    else
                    {//если они вертикальны, то сравниваем их координаты в проекции на Оу
                        Min1 = Math.Min(F0.y, F1.y);
                        Max1 = Math.Max(F0.y, F1.y);
                        Min2 = Math.Min(S0.y, S1.y);
                        Max2 = Math.Max(S0.y, S1.y);
                    }

                    if (Min1 > Min2)//упорядочиваем орезки по координатам
                    {
                        double temp;

                        temp = Min2;
                        Min2 = Min1;
                        Min1 = temp;

                        temp = Max2;
                        Max2 = Max1;
                        Max1 = temp;

                    }
                    if ((B1 == 0) && (B2 == 0))
                    {
                        if ((F0.x - S0.x) == 0)//если отрезки не находятся на расстоянии друг от друга
                            if (Min2 < Max1)//если минимальная координата первого отрезка меньше максимальной второго, то отрезки частично совпадают
                                return 1;
                    }
                    else
                        if (Min2 < Max1)//случай, для не вертикальных отрезков
                            return 1;
                }

            return 0;
        }
//-------------------------------- End CheckingCuts ------------------------------------------------
//**************************************************************************************************



        //========================== Рисование полигона =======================================
        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, NumPointAndComma;
            int LenX, LenY, Len;
            string Temp, X, Y;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();


            //---------построение многоугольника----------------------------
            try
            {
                NumberOfVertices = Convert.ToInt32(txtbxNumberOfVertices.Text);
                VerticesOfThePolygon = new Point[NumberOfVertices];

                if (radioButton1.Checked)
                {
                    //ввод координат вручную (получение координат из текстового поля)
                    for (i = 0; i < NumberOfVertices; i++)
                    {
                        Temp = rchtxtbxPoints.Lines[i];//временная строковая переменная для хранения строки с очередной координатой
                        NumPointAndComma = Temp.IndexOf(';');//положение точки с запятой (разделитель для координат
                        Y = Temp.Substring(NumPointAndComma + 1);//выделяем координату Y
                        LenY = Y.Length;
                        Len = Temp.Length;
                        LenX = Len - LenY - 1;
                        X = Temp.Substring(0, LenX);//выделяем координату Х
                        VerticesOfThePolygon[i].x = Convert.ToDouble(X);//Заносим координаты в 
                        VerticesOfThePolygon[i].y = Convert.ToDouble(Y);//массив вершин полигона
                    }

                    //ПРОВЕРКА ПОЛИГОНА
                    //проверка на совпадающие точки
                    for (i = 0; i < NumberOfVertices; i++)
                        for (j = i + 1; j < NumberOfVertices; j++)
                            if ((VerticesOfThePolygon[i].x == VerticesOfThePolygon[j].x) && (VerticesOfThePolygon[i].y == VerticesOfThePolygon[j].y))
                            {
                                throw new MyException("Есть совпадающие вершины");
                            }

                    //---------- проверка на самопересечение --------------
                    int k;

                    //цикл перебора всех отрезков, входящих в полигон, и проверка их взаимного
                    //расположения в пространстве
                    for (i = 0; i < NumberOfVertices; i++)
                        for (j = i + 1; j < NumberOfVertices; j++)
                        {
                            //Последняя точка соединяется с первой, поэтому отрезку, которому
                            //она принадлежит сопоставляются другие граничные точки 
                            if (j == NumberOfVertices - 1)
                                k = 0;
                            else
                                //промежуточные точки
                                k = j + 1;
                            
                            //вызов метода проверки взаимного расположения отрезков в пространстве
                            int a = CheckingCuts(VerticesOfThePolygon[i],
                                                 VerticesOfThePolygon[i + 1],
                                                 VerticesOfThePolygon[j], 
                                                 VerticesOfThePolygon[k]);
                            switch (a)
                            {
                                case -1:
                                    throw new MyException("Есть пересекающиеся отрезки");                             
                                case 1:
                                    throw new MyException("Есть совпадающие отрезки");
                            }

                        }
                }
                else
                {//генерация полигона
                    double X1, Y1, r, fi, delfi;

                    //генерация координат
                    Random Rnd = new Random();
                    //случайный центр окружности для генерации точек
                    X1 = Rnd.Next(-10, 10) + Rnd.NextDouble();
                    Y1 = Rnd.Next(-10, 10) + Rnd.NextDouble();

                    delfi = (2 * Math.PI) / NumberOfVertices;//шаг по углу

                    for (i = 0, fi = 0; i < NumberOfVertices; i++)
                    {
                        //точки генерируются по окружности со случайным радиусом и центром
                        //такая форма генерации исключает самопересечение многоугольника
                        r = Rnd.Next(0, 10) + Rnd.NextDouble();//случайный радиус очередной точки

                        VerticesOfThePolygon[i].x = r * Math.Cos(fi) + X1;//вычисляем координаты с помощью 
                        VerticesOfThePolygon[i].y = r * Math.Sin(fi) + Y1;//формул для полярных координат

                        fi += delfi;//делаем шаг по углу
                    }
                }

                for (i = 0; i < NumberOfVertices; i++)//отображение полигона на графике
                    chart1.Series[0].Points.AddXY(VerticesOfThePolygon[i].x, VerticesOfThePolygon[i].y);
                chart1.Series[0].Points.AddXY(VerticesOfThePolygon[0].x, VerticesOfThePolygon[0].y);

                //вычисляем координаты четырехугольной области, в которой лежит полигон
                MaxX = MinX = VerticesOfThePolygon[0].x;
                MaxY = MinY = VerticesOfThePolygon[0].y;

                //находим максимальные и минимальные координаты у полигона
                for (i = 0; i < NumberOfVertices; i++)
                {
                    if (VerticesOfThePolygon[i].x < MinX) MinX = VerticesOfThePolygon[i].x;
                    if (VerticesOfThePolygon[i].x > MaxX) MaxX = VerticesOfThePolygon[i].x;
                    if (VerticesOfThePolygon[i].y < MinY) MinY = VerticesOfThePolygon[i].y;
                    if (VerticesOfThePolygon[i].y > MaxY) MaxY = VerticesOfThePolygon[i].y;
                }


                //масштабирование системы координат
                chart1.ChartAreas[0].AxisX.Crossing = 0;
                chart1.ChartAreas[0].AxisY.Crossing = 0;
                chart1.ChartAreas[0].AxisX.Minimum = MinX;
                chart1.ChartAreas[0].AxisY.Minimum = MinY;
                chart1.ChartAreas[0].AxisX.Maximum = MaxX;
                chart1.ChartAreas[0].AxisY.Maximum = MaxY;

                //находим максимальную координату у прямоугольника
                double Min;
                if (MaxX < MaxY) Max = MaxY; else Max = MaxX;
                if (MinX > MinY) Min = MinY; else Min = MinX;
                if (Math.Abs(Min) > Max) Max = Math.Abs(Min);

                chart1.ChartAreas[0].AxisX.Interval = Math.Round(Max / 15);
                chart1.ChartAreas[0].AxisY.Interval = Math.Round(Max / 15);
            }
            catch (MyException E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Координаты точек отсутствуют или заполнены неверно", "Ошибка", MessageBoxButtons.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Не указано колличество вершин", "Ошибка", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Неприемлемые символы в поле набора координат", "Ошибка", MessageBoxButtons.OK);
            }

        }
//================================= button1_Click END========================================
//****************************************************************************************

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rchtxtbxPoints.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rchtxtbxPoints.Enabled = false;
        }


//=============================== Одиночный случайный эксперимент ===============================
        private void button2_Click(object sender, EventArgs e)
        {
            double FactorSqr; 
            double AreaOfPolygon;
            Random Rnd = new Random();
            double MinXFact, MinYFact, MaxXFact, MaxYFact, MaxFact,//координаты точек прямоугольника с учетом множителя 
                   AY, AX, //стороны многоугольника
                   x, y;//случайная точка
            int N,//общее волличество генерируемых случайных точек 
                n = 0, //колличество случайных точек, попавших в данный многоугольник
                i, j; //колличество отрезков, которые пересек луч, из данной точки 
                int ost;//остаток от деления k_point на 2, т.е. проверка на четность/нечетность

                try
                {
                    if (VerticesOfThePolygon == null)
                        throw new MyException("Создайте полигон");
                    chart1.Series[1].Points.Clear();
                    chart1.Series[2].Points.Clear();

                    AY = Math.Abs(MaxY - MinY);//сторона по Y четырехугольника
                    AX = Math.Abs(MaxX - MinX);//сторона по X четырехугольника

                    FactorSqr = Convert.ToDouble(txtbxFactorSqr.Text);//множитель для сторон описывающего фигуру четырехугольника
                    N = Convert.ToInt32(txtbxNumberOfPoints.Text);//колличество генерируемых точек

                    if (FactorSqr != 1)
                    {//Множитель больше 1
                        //выводим новый четырехугольник
                        MinYFact = MinY - ((FactorSqr - 1) * AY) / 2;
                        MaxYFact = MaxY + ((FactorSqr - 1) * AY) / 2;
                        MinXFact = MinX - ((FactorSqr - 1) * AX) / 2;
                        MaxXFact = MaxX + ((FactorSqr - 1) * AX) / 2;
                        MaxFact = FactorSqr * Max;
                    }
                    else
                    {
                        //отображаем исходный четырехугольник
                        MinYFact = MinY;
                        MaxYFact = MaxY;
                        MinXFact = MinX;
                        MaxXFact = MaxX;
                        MaxFact = Max;
                    }

                    AY = Math.Abs(MaxYFact - MinYFact);//сторона по Y четырехугольника
                    AX = Math.Abs(MaxXFact - MinXFact);//сторона по X четырехугольника

                    chart1.Series[1].Points.AddXY(MinXFact, MinYFact);
                    chart1.Series[1].Points.AddXY(MinXFact, MaxYFact);
                    chart1.Series[1].Points.AddXY(MaxXFact, MaxYFact);
                    chart1.Series[1].Points.AddXY(MaxXFact, MinYFact);
                    chart1.Series[1].Points.AddXY(MinXFact, MinYFact);

                    chart1.ChartAreas[0].AxisX.Crossing = 0;
                    chart1.ChartAreas[0].AxisY.Crossing = 0;
                    chart1.ChartAreas[0].AxisX.Minimum = MinXFact;
                    chart1.ChartAreas[0].AxisY.Minimum = MinYFact;
                    chart1.ChartAreas[0].AxisX.Maximum = MaxXFact;
                    chart1.ChartAreas[0].AxisY.Maximum = MaxYFact;

                    chart1.ChartAreas[0].AxisX.Interval = Math.Round(MaxFact / 15);
                    chart1.ChartAreas[0].AxisY.Interval = Math.Round(MaxFact / 15);


                    //проведение случайного эксперимента - 
                    //-генерация точки и определение области её попадания
                    for (i = 0; i < N; i++)
                    {
                        int k;
                        int k_point = 0;//колличество сторон полигона, которые пересек луч

                        x = Rnd.Next(Convert.ToInt32(Math.Floor(MinXFact - 1)), Convert.ToInt32(Math.Floor(MaxXFact + 1))) + Rnd.NextDouble();
                        y = Rnd.Next(Convert.ToInt32(Math.Floor(MinYFact - 1)), Convert.ToInt32(Math.Floor(MaxYFact + 1))) + Rnd.NextDouble();

                        while (((x < MinXFact) || (x > MaxXFact)) || ((y < MinYFact) || (y > MaxYFact)))
                        {//проверка попадания точки внутрь прямоугольника, если не попадают, генерируем новые
                            x = Rnd.Next(Convert.ToInt32(Math.Floor(MinXFact - 1)), Convert.ToInt32(Math.Floor(MaxXFact + 1))) + Rnd.NextDouble();
                            y = Rnd.Next(Convert.ToInt32(Math.Floor(MinYFact - 1)), Convert.ToInt32(Math.Floor(MaxYFact + 1))) + Rnd.NextDouble();
                        }

                        //------проверка точки на попадание внутрь полигона-------
                        Point X0, X1;//отрезок, через который проходит луч

                        X0.x = x;//начальные координаты отрезка совпадают со случайной точкой
                        X0.y = y;

                        X1.x = MaxX + 1.1;//конечные координаты по Х больше максимальной координаты Х на 1,1 
                        X1.y = MaxY + 1.1;//для того, чтобы отрезок в любом случае выходил за правую границу полигона

                        //метод определения пересечения аналогичен, как в проверке на самопересечения многоугольника
                        for (j = 0; j < NumberOfVertices; j++)
                        {
                            if (j == NumberOfVertices - 1)
                                k = 0;
                            else
                                k = j + 1;

                            int a = CheckingCuts(X0, X1, VerticesOfThePolygon[j], VerticesOfThePolygon[k]);

                            switch (a)
                            {//если луч пересек отрезок или отрезок лежит на луче
                                case -1:
                                case 1:
                                    k_point++;
                                    break;
                            }

                        }

                        Math.DivRem(k_point, 2, out ost);//определяем, четно ли число пересечений лучом отрезков полигона
                        if (ost != 0) n++;//если нечетно, то точка внутри полигона
                        chart1.Series[2].Points.AddXY(x, y);
                    }

                    AreaOfPolygon = AX * AY * (Convert.ToDouble(n) / Convert.ToDouble(N));//находим площадь
                    txtbxAreaofPolygon.Text = AreaOfPolygon.ToString("000.000");
                }
                catch (MyException E)
                {
                    MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Заполните поля","Ошибка",MessageBoxButtons.OK);
                }
           }
        //============================ button2Click END==========================================
        //*********************************************************************************************************


// ================================== Группа экспериментов ===================================
        /*
         * Определнеие средней площади по группе экспериментов - AverageArea
         * Средней квадратичной ошибки - AverageSqrError
         * Оценки Средней квадратичной ошибки - AverageSqrErrorEvaluation
         * Доверительного интервала (при помощи распределения Стьюдента)
         */
        private void button3_Click(object sender, EventArgs e)
        {
            //распределение Стьюдента
            double[,] Student = { {2,            3,             4,            5,             6,             7,             8,             9,             10,            11,            12,           13,            14,            15,            16,            17,            18,            19,            20,            21,            22,            23,            24,            25,            26,            27,            28,            29,            30,            31,            41,            61,            121,           0.0}, 
                                  {6.3137515148, 2.91998558036, 2.3533634348, 2.13184678134, 2.01504837267, 1.94318028039, 1.89457860506, 1.85954803752, 1.83311293265, 1.81246112281, 1.7958848187, 1.78228755565, 1.77093339599, 1.76131013577, 1.75305035569, 1.74588367628, 1.73960672608, 1.73406360662, 1.72913281152, 1.72471824292, 1.72074290281, 1.71714437438, 1.71387152775, 1.71088207991, 1.70814076125, 1.70561791976, 1.70328844572, 1.70113093427, 1.69912702653, 1.69726089436, 1.68385101139, 1.67064886465, 1.65765089935, 1.64485515072}};
            double AverageArea = 0,//средняя площадь 
                   AverageSqrError = 0,//СКО 
                   AverageSqrErrorEvaluation;//оценка СКО
            double MinXFact, MinYFact, MaxXFact, MaxYFact, MaxFact;//координаты точек прямоугольника с учетом множителя 
            int NumberOfTests;//колличество экспериментов
            int i, j, a, 
                n, //Колличество точек попавших в полигон в данном испытании 
                N, //Общее колличество точек
                ost; //остаток от деления колличества пересекшихся с лучом отрезков на 2
            double AreaOfPolygon;//площадь полигона в данном эксперименте
            Random Rnd = new Random();
            double x, y, //случайная точка 
                   AX, AY, //стороны прямоугольной области
                   FactorSqr; //множитель сторон области
            
            try
            {
                if (VerticesOfThePolygon == null)
                    throw new MyException("Создайте полигон");

                NumberOfTests = Convert.ToInt32(txtbxNumberOfTests.Text);
                N = Convert.ToInt32(txtbxNumberOfPoints.Text);
                FactorSqr = Convert.ToDouble(txtbxFactorSqr.Text);//множитель для сторон описывающего фигуру четырехугольника

                AY = Math.Abs(MaxY - MinY);//сторона по Y четырехугольника
                AX = Math.Abs(MaxX - MinX);//сторона по X четырехугольника

                //вычисляем новую область (согласно введенному множителю)
                if (FactorSqr != 1)
                {//Множитель больше 1
                    //выводим новый четырехугольник
                    MinYFact = MinY - ((FactorSqr - 1) * AY) / 2;
                    MaxYFact = MaxY + ((FactorSqr - 1) * AY) / 2;
                    MinXFact = MinX - ((FactorSqr - 1) * AX) / 2;
                    MaxXFact = MaxX + ((FactorSqr - 1) * AX) / 2;
                    MaxFact = FactorSqr * Max;
                }
                else
                {
                    //отображаем исходный четырехугольник
                    MinYFact = MinY;
                    MaxYFact = MaxY;
                    MinXFact = MinX;
                    MaxXFact = MaxX;
                    MaxFact = Max;
                }

                AY = Math.Abs(MaxYFact - MinYFact);//сторона по Y четырехугольника
                AX = Math.Abs(MaxXFact - MinXFact);//сторона по X четырехугольника

                //цикл по испытаниям
                for (a = 0; a < NumberOfTests; a++)
                {
                    //проводим испытание из генерации N точек
                    n = 0;
                    for (i = 0; i < N; i++)
                    {
                        int k;
                        int k_point = 0;//колличество отрезков, которые пересек луч, пущенный из данной случ. точки

                        //генерируем точку
                        x = Rnd.Next(Convert.ToInt32(Math.Floor(MinXFact - 1)), Convert.ToInt32(Math.Floor(MaxXFact + 1))) + Rnd.NextDouble();
                        y = Rnd.Next(Convert.ToInt32(Math.Floor(MinYFact - 1)), Convert.ToInt32(Math.Floor(MaxYFact + 1))) + Rnd.NextDouble();

                        while (((x < MinXFact) || (x > MaxXFact)) || ((y < MinYFact) || (y > MaxYFact)))
                        {//проверка попадания точки внутрь прямоугольника, если не попадают, генерируем новые
                            x = Rnd.Next(Convert.ToInt32(Math.Floor(MinXFact - 1)), Convert.ToInt32(Math.Floor(MaxXFact + 1))) + Rnd.NextDouble();
                            y = Rnd.Next(Convert.ToInt32(Math.Floor(MinYFact - 1)), Convert.ToInt32(Math.Floor(MaxYFact + 1))) + Rnd.NextDouble();
                        }

                        //------проверка точки на попадание внутрь полигона-------
                        Point X0, X1;//отрезок, через который проходит луч

                        X0.x = x;//начальные координаты отрезка совпадают со случайной точкой
                        X0.y = y;

                        X1.x = MaxX + 1.1;//конечные координаты по Х больше максимальной координаты Х на 1,1 
                        X1.y = MaxY + 1.1;//для того, чтобы отрезок в любом случае выходил за правую границу полигона

                        //метод определения пересечения аналогичен, как в проверке на самопересечения многоугольника
                        for (j = 0; j < NumberOfVertices; j++)
                        {
                            if (j == NumberOfVertices - 1)
                                k = 0;
                            else
                                k = j + 1;

                            //определяем взаимное расположение двух точек
                            int m = CheckingCuts(X0, X1, VerticesOfThePolygon[j], VerticesOfThePolygon[k]);

                            switch (m)
                            {
                                case -1://если луч пересекает данный отрезок или отрезок лежит на луче
                                 case 1:
                                    k_point++;//наращиваем колличетво пересеченных отрезков
                                    break;
                            }

                        }

                        Math.DivRem(k_point, 2, out ost);//определяем, четно ли число пересечений лучом отрезков полигона
                        if (ost != 0) n++;//если нечетно, то точка внутри полигона
                    }

                    //наращиваем суммы в формулах Средней и СКО
                    AreaOfPolygon = AX * AY * (Convert.ToDouble(n) / Convert.ToDouble(N));//находим площадь
                    AverageArea += AreaOfPolygon;
                    AverageSqrError += Math.Pow(AreaOfPolygon, 2);
                }

                //СКО
                AverageSqrError -= (Math.Pow(AverageArea, 2) / NumberOfTests);
                AverageSqrError /= (NumberOfTests - 1);
                //оценка СКО
                AverageSqrErrorEvaluation = Math.Sqrt(AverageSqrError / NumberOfTests);
                //среднее
                AverageArea /= NumberOfTests;

                //Рассчет доверительного интервала
                double t, X2, X3;//табличное значение распр. стьюдента с M-1 степ. свободы, и при р = 0,95


                //определение значения t из таблицы разпределения Стьюдента
                // Число степеней свободы NumberOfTests - 1 и p = 0,95

                if (NumberOfTests <= 31)
                    t = Student[1, NumberOfTests - 2];
                else
                    if (NumberOfTests < 41)
                    {
                        //линейная интерполяция таблицы распр. Стьюдента
                        t = Student[1, 29] + ((Student[1, 30] - Student[1, 29]) / 10) * (Convert.ToDouble(NumberOfTests) - 31);
                    }
                    else
                        if (NumberOfTests == 41) t = Student[1, 30];
                        else
                            if (NumberOfTests < 61)
                            {
                                t = Student[1, 30] + ((Student[1, 31] - Student[1, 30]) / 20) * (Convert.ToDouble(NumberOfTests) - 41);
                            }
                            else
                                if (NumberOfTests == 61) t = Student[1, 31];
                                else
                                    if (NumberOfTests < 120)
                                    {
                                        t = Student[1, 31] + ((Student[1, 32] - Student[1, 31]) / 60) * (Convert.ToDouble(NumberOfTests) - 61);
                                    }
                                    else
                                        if (NumberOfTests == 120) t = Student[1, 32];
                                        else
                                        {
                                            t = Student[1, 33];
                                        }
                //доверительный интервал
                X2 = AverageArea - t * AverageSqrErrorEvaluation;
                X3 = AverageArea + t * AverageSqrErrorEvaluation;

                //выводы соответствующих величин
                txtbxInt.Text = String.Concat("(", X2.ToString("000.000"), "..", X3.ToString("000.000"), ")");
                txtbxAverageArea.Text = AverageArea.ToString("000.000");
                txtbxAverageSqrError .Text = AverageSqrError.ToString("000.000");
                txtbxAverageAreaSqrErrorEvaluation.Text = AverageSqrErrorEvaluation.ToString("000.000");

            }
            catch (MyException E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните необходимые поля","Ошибка",MessageBoxButtons.OK);
            }

        }
//================================= button3Click END==========================================
//*********************************************************************************************************

    }

}
