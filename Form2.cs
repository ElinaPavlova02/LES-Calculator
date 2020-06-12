using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор_СЛАУ
{
    public partial class Form2 : MaterialForm
    {
        public int count_x; // Количество переменных
        public int accuracy; // Точность вычислений
        public double s; // Переменная для промежуточных расчетов в методе Гаусса

        public Form2()
        {
            InitializeComponent();

            // Подключение библиотеки Material Skin для создания дизайна
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey500, Primary.Grey500,
                Primary.BlueGrey800, Accent.Red700, TextShade.WHITE);
        }

        // Создание матриц для заполнения
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            // Очистка компонентов для ввода новых данных
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                count_x = Convert.ToInt32(comboBox1.SelectedItem);

                for (int i = 0; i < count_x; i++)
                {
                    dataGridView1.Columns.Add("", $"X{i + 1}");
                }
                for (int j = 0; j < count_x; j++)
                {
                    dataGridView1.Rows.Add();
                }

                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.Columns.Add("", "В");

                for (int j = 0; j < count_x; j++)
                {
                    dataGridView2.Rows.Add();
                }

                label4.Text = "Введите шаг от 1 до " + count_x + ": ";
            }
            else
                MessageBox.Show("Выберите количество переменных!", "Ошибка");
        }

        // Событие клика по кнопке "Рассчитать" вызывает решение Гаусса и вывод проверки и невязок 
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            count_x = Convert.ToInt32(comboBox1.SelectedItem); // Количество переменных
            accuracy = comboBox2.SelectedIndex;                // Точность расчетов

            // Очистка всех компонентов для вывода данных
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            dataGridView4.Columns.Add("", "Х");
            richTextBox1.Text = "";
            richTextBox2.Text = "";

            double[,] a_pryam_hod = new double[count_x, count_x]; // Коэффициенты для организации 
            double[] b_pryam_hod = new double[count_x];           // прямого хода Гаусса
            double[] roots;                                       // Корни квадратной СЛАУ
            double[,] a_obrat_hod;                                // Коэффициенты для организации 
            double[] b_obrat_hod = new double[count_x];           // обратного хода Гаусса       
            string[] check;                                       // Выражения проверки

            try
            {
                for (int i = 0; i < count_x; i++)
                {
                    b_pryam_hod[i] = double.Parse(dataGridView2[0, i].Value.ToString());
                    for (int j = 0; j < count_x; j++)
                    {
                        a_pryam_hod[j, i] = double.Parse(dataGridView1[i, j].Value.ToString());
                    }
                }

                a_obrat_hod = Pryamoi_Hod(count_x, a_pryam_hod, b_pryam_hod);
                for (int i = 0; i < count_x; i++)
                    b_obrat_hod[i] = a_obrat_hod[i, count_x];

                roots = Obratnii_hod(count_x, a_obrat_hod, b_obrat_hod);
                check = proverka(count_x, roots);
                string[] nevyaz = nevyazki(count_x);

                // Вывод корней квадратной СЛАУ, проверки и невязок
                for (int i = 0; i < count_x; i++)
                {
                    dataGridView4.Rows.Add(Math.Round(roots[i], accuracy));
                    richTextBox1.Text += check[i] + "\r\n";
                    richTextBox2.Text += nevyaz[i];
                }
            }
            catch
            {
                MessageBox.Show("Не все ячейки заполнены!", "Ошибка");
            }
        }

        // Очистка всех компонентов
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();

            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            dataGridView4.Columns.Clear();

            richTextBox1.Clear();
            richTextBox2.Clear();

            materialSingleLineTextField1.Clear();
        }

        // Обработка клика по кнопке "Назад" скрывает эту форму и оставляет главное окно
        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Организация пошагового вывода
        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            count_x = Convert.ToInt32(comboBox1.SelectedItem);   // Количество переменных
            accuracy = Convert.ToInt32(comboBox2.SelectedIndex); // Точность расчетов
            try
            {   // Проверка на соответствие введенного значения доступным значениям
                if (materialSingleLineTextField1.Text == "" || Convert.ToInt32(materialSingleLineTextField1.
                    Text) < 1 || Convert.ToInt32(materialSingleLineTextField1.Text) > count_x)
                {
                    MessageBox.Show($"Выберите шаг от 1 до {count_x}", "Ошибка!");
                }
                else if (Convert.ToInt32(materialSingleLineTextField1.Text) <= count_x && 
                    Convert.ToInt32(materialSingleLineTextField1.Text) > 0)
                {
                     double[,] a = new double[count_x, count_x];// Матрица коэффициентов при переменных
                     double[] b = new double[count_x];          // Матрица свободных коэффициентов
                     double[,] a_shag;                          // Матрица для вывода результатов

                     dataGridView3.Rows.Clear();
                     dataGridView3.Columns.Clear();

                     for (int i = 0; i < count_x; i++)
                     {
                        dataGridView3.Columns.Add("", $"X{i + 1}");
                        dataGridView3.Columns[i].Width = 55;
                     }

                     dataGridView3.Columns.Add("", "B");
                     dataGridView3.Columns[count_x].Width = 55;

                     for (int i = 0; i < count_x; i++)
                     {
                         dataGridView3.Rows.Add("", "");
                         for (int j = 0; j < count_x; j++)
                             a[j, i] = double.Parse(dataGridView1[i, j].Value.ToString());
                         b[i] = double.Parse(dataGridView2[0, i].Value.ToString());
                     }

                     a_shag = shag(count_x, a, b); // Вызов метода для расчета промежуточных результатов

                     // Вывод промежуточных результатов
                     for (int i = 0; i < count_x; i++)
                         for (int j = 0; j < count_x + 1; j++)
                            dataGridView3.Rows[i].Cells[j].Value = Math.Round(a_shag[i, j], accuracy);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в исходных данных!", "Ошибка");
            }
        }

        // Прямой ход Гаусса
        protected double[,] Pryamoi_Hod(int count_x, double[,] a_pryam_hod, double[] b_pryam_hod)
        {
            s = 0;                                      // Переменная для промежуточных результатов
            count_x = Convert.ToInt32(comboBox1.SelectedItem);  // Количество переменных
            int k, i, j, im;                            // Переменные, используемые в индексах
            double v;                                   // Переменная для промежуточных результатов

            for (i = 0; i < count_x; i++)
            {
                b_pryam_hod[i] = double.Parse(dataGridView2[0, i].Value.ToString());
                for (j = 0; j < count_x; j++)
                    a_pryam_hod[j, i] = double.Parse(dataGridView1[i, j].Value.ToString());
            }

            for (k = 0; k < count_x - 1; k++)
            {
                im = k;
                for (i = k + 1; i < count_x; i++)
                {
                    if (Math.Abs(a_pryam_hod[im, k]) < Math.Abs(a_pryam_hod[i, k]))
                        im = i;
                }
                if (im != k)
                {
                    for (j = 0; j < count_x; j++)
                    {
                        v = a_pryam_hod[im, j];
                        a_pryam_hod[im, j] = a_pryam_hod[k, j];
                        a_pryam_hod[k, j] = v;
                    }
                    v = b_pryam_hod[im];
                    b_pryam_hod[im] = b_pryam_hod[k];
                    b_pryam_hod[k] = v;
                }
                for (i = k + 1; i < count_x; i++)
                {
                    v = 1.0 * a_pryam_hod[i, k] / a_pryam_hod[k, k];
                    a_pryam_hod[i, k] = 0;
                    b_pryam_hod[i] = b_pryam_hod[i] - v * b_pryam_hod[k];
                    if (v != 0)
                        for (j = k + 1; j < count_x; j++)
                            a_pryam_hod[i, j] = a_pryam_hod[i, j] - v * a_pryam_hod[k, j];
                }
            }
            double[,] gauss = new double[count_x, count_x + 1];
            for (i = 0; i < count_x; i++)
            {
                for (j = 0; j < count_x; j++)
                    gauss[i, j] = a_pryam_hod[i, j];
                gauss[i, count_x] = b_pryam_hod[i];
            }
            return gauss;
        }

        // Обратный ход Гаусса
        protected double[] Obratnii_hod(int count_x, double[,] a_obrat_hod, double[] b_obrat_hod)
        {
            double[] x = new double[count_x];           // Массив с корнями квадратной СЛАУ
            double[,] a = new double[count_x, count_x]; // Массив с коэффициентами при переменных

            for (int i = 0; i < count_x; i++)
                for (int j = 0; j < count_x; j++)
                    a[j, i] = double.Parse(dataGridView1[i, j].Value.ToString());

            x[count_x - 1] = 1.0 * b_obrat_hod[count_x - 1] / a_obrat_hod[count_x - 1, count_x - 1];
            for (int i = count_x - 2; 0 <= i; i--)
            {
                s = 0;
                for (int j = i + 1; j < count_x; j++)
                    s = s + a_obrat_hod[i, j] * x[j];
                x[i] = 1.0 * (b_obrat_hod[i] - s) / a_obrat_hod[i, i];
            }
            return x;
        }

        // Метод, отвечающий за пошаговый вывод
        protected double[,] shag(int count_x, double[,] a, double[] b)
        {
            int iter = Convert.ToInt32(materialSingleLineTextField1.Text);// Количество пройденных шагов
            int k, i, j, im;                                            // Переменные для индексов
            double v;                                                   // Переменные для промежуточных
            s = 0;                                                      // расчетов                                      

            for (k = 0; k < iter - 1; k++)
            {
                im = k;
                for (i = k + 1; i < iter; i++)
                    if (Math.Abs(a[im, k]) < Math.Abs(a[i, k]))
                        im = i;
                if (im != k)
                    for (j = 0; j < iter; j++)
                    {
                        v = a[im, j];
                        a[im, j] = a[k, j];
                        a[k, j] = v;
                    }
                    v = b[im];
                    b[im] = b[k];
                    b[k] = v;

                for (i = k + 1; i < iter; i++)
                {
                    v = 1.0 * a[i, k] / a[k, k];
                    a[i, k] = 0;
                    b[i] = b[i] - v * b[k];
                    if (v != 0)
                        for (j = k + 1; j < iter; j++)
                            a[i, j] = a[i, j] - v * a[k, j];
                }
            }

            double[,] gauss = new double[count_x, count_x + 1];
            for (i = 0; i < count_x; i++)
            {
                for (j = 0; j < count_x; j++)
                    gauss[i, j] = a[i, j];
                gauss[i, count_x] = b[i];
            }
            return gauss;
        }

        // Организация проверки найденных корней
        protected string[] proverka(int count_x, double[] roots)
        {
            string[] proverka = new string[count_x];    // Массив со строками проверки
            string[] proverka1 = new string[count_x];   // Массив для вывода
            double[] otvet = new double[count_x];       // Значения свободных коэффициентов при проверке
            double[,] a = new double[count_x, count_x]; // Коэффициенты при переменных
            accuracy = Convert.ToInt32(comboBox2.Text); // Точность расчетов

            for (int i = 0; i < count_x; i++)
                for (int j = 0; j < count_x; j++)
                    a[j, i] = double.Parse(dataGridView1[i, j].Value.ToString()); 

            for (int i = 0; i < count_x; i++)
            {
                for (int j = 0; j < count_x; j++)
                {
                    proverka[i] += a[i, j] + " * ";
                    proverka[i] += (roots[j] >= 0) ? (Math.Round(roots[j], accuracy)).ToString() : "(" + 
                        (Math.Round(roots[j], accuracy)).ToString() + ")";
                    if (j != count_x - 1)
                        proverka[i] += (a[i, j + 1] >= 0) ? " + " : " ";
                    otvet[i] += a[i, j] * Math.Round(roots[j], accuracy);
                }
                proverka[i] += " = " + Math.Round(otvet[i], accuracy);
                proverka1[i] = proverka[i];
                proverka[i] = " ";
            }
            return proverka1;
        }

        // Расчет невязок
        protected string[] nevyazki(int count_x)
        {
            double[] otvet = new double[count_x];                 // Результаты проверки
            string[] nevyazki = new string[count_x];              // Массив со строками проверки
            double[,] a_pryam_hod = new double[count_x, count_x]; // Коэффициенты для организации 
            double[] b_pryam_hod = new double[count_x];           // прямого хода Гаусса
            double[,] a_obrat_hod;                                // Коэффициенты для организации 
            double[] b_obrat_hod = new double[count_x];           // обратного хода Гаусса
            double[] roots;                                       // Корни квадратной СЛАУ
            double[] b_results = new double[count_x];             // Свободные коэффициенты
            double[,] a_results = new double[count_x, count_x];   // Коэффициенты при переменных  
            accuracy = Convert.ToInt32(comboBox2.Text);           // Точность расчетов

            for (int i = 0; i < count_x; i++)
            {
                b_pryam_hod[i] = double.Parse(dataGridView2[0, i].Value.ToString());
                b_results[i] = double.Parse(dataGridView2[0, i].Value.ToString());

                for (int j = 0; j < count_x; j++)
                    a_pryam_hod[j, i] = double.Parse(dataGridView1[i, j].Value.ToString());
            }
            for (int i = 0; i < count_x; i++)
                b_results[i] = double.Parse(dataGridView2[0, i].Value.ToString());
            a_obrat_hod = Pryamoi_Hod(count_x, a_pryam_hod, b_pryam_hod);
            for (int i = 0; i < count_x; i++)
                b_obrat_hod[i] = a_obrat_hod[i, count_x];
            roots = Obratnii_hod(count_x, a_obrat_hod, b_obrat_hod);

            for (int i = 0; i < count_x; i++)
                for (int j = 0; j < count_x; j++)
                    a_results[j, i] = double.Parse(dataGridView1[i, j].Value.ToString()); // Коэффициенты              

            for (int i = 0; i < count_x; i++)
                for (int j = 0; j < count_x; j++)
                    otvet[i] += a_results[i, j] * Math.Round(roots[j], accuracy); // Результат проверки 

            for (int i = 0; i < count_x; i++)
            {
                nevyazki[i] += $"{i + 1} уравнение: | " + b_results[i] + " - ";
                nevyazki[i] += (otvet[i] >= 0) ? (Math.Round(otvet[i], accuracy)).ToString() : "(" + (Math.Round
                    (otvet[i], accuracy)).ToString() + ")";
                nevyazki[i] += " | = " + Math.Abs(Math.Round((b_results[i] - otvet[i]), accuracy)) + "\r\n";
            }
            return nevyazki;
        }
    }
}
