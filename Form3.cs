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
    public partial class Form3 : MaterialForm
    {
        public int count_x; // Количество переменных
        public int accuracy; // Точность расчетов

        public Form3()
        {
            InitializeComponent();
            // Подключение библиотеки Material Skin для создания дизайна
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey500, Primary.Grey500,
                Primary.BlueGrey800, Accent.Red700, TextShade.WHITE);
        }

        // Обработка нажатия на кнопку "Применить"
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            // Проверка на выбор количества переменных в comboBox1
            if (comboBox1.SelectedItem != null)
            {
                // Очистка компонентов для ввода новых данных
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                count_x = Convert.ToInt32(comboBox1.SelectedItem); // количество переменных

                // Создание новых таблиц для ввода данных и вывода промежуточных шагов
                for (int i = 0; i < count_x; i++)
                {
                    dataGridView1.Columns.Add("", $"X{i + 1}");
                    dataGridView2.Columns.Add("", $"X{i + 1}");
                }
                for (int j = 0; j < count_x; j++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView2.Rows.Add();
                }

                dataGridView1.Columns.Add("", "В");
                dataGridView2.Columns.Add("", "В");

                label4.Text = "Введите шаг от 1 до 3: ";
            }
            // Обработка ошибки "Отсутствие выбора количества переменных в comboBox1"
            else
                MessageBox.Show("Выберите количество переменных!", "Ошибка");
        }

        // Обработка нажатия на кнопку "Рассчитать"
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            count_x = Convert.ToInt32(comboBox1.SelectedItem);  // Количество уравнений 
            accuracy = Convert.ToInt32(comboBox2.SelectedItem); // Точность расчетов

            richTextBox1.Text = "";
            richTextBox2.Text = "";

            double[,] A = new double[count_x, count_x + 1];     // Расширенная матрица
            double[] roots;                                     // Массив, хранящий корни
            double[] b_results = new double[count_x];           // Свободные коэффициенты
            double[,] a_results = new double[count_x, count_x]; // Массив с коэффициентами при переменных
            string[] check;                                     // Вывод выражений с проверкой
            double[] otvet = new double[count_x];               // Результаты проверки

            // Заполнение массивов исходными данными
            try
            {
                for (int i = 0; i < count_x; i++)
                {
                    b_results[i] = double.Parse(dataGridView1[count_x, i].Value.ToString());
                    for (int j = 0; j < count_x + 1; j++)
                    {
                        A[i, j] = double.Parse(dataGridView1[j, i].Value.ToString());
                    }
                }

                roots = Jordan_Gauss(count_x, A);
                check = proverka(count_x, roots);

                for (int i = 0; i < count_x; i++)
                {
                    richTextBox1.Text += $"X{i + 1} = " + Math.Round(roots[i], accuracy) + "\r\n";
                    for (int j = 0; j < count_x; j++)
                    {
                        a_results[i, j] = double.Parse(dataGridView1[j, i].Value.ToString());
                        otvet[i] += a_results[i, j] * Math.Round(roots[j], accuracy); // Результат проверки
                    }
                }

                for (int i = 0; i < count_x; i++)
                {
                    richTextBox1.Text += check[i] + "\r\n";
                    richTextBox2.Text += $"{i + 1} уравнение: | " + b_results[i] + " - ";
                    richTextBox2.Text += (otvet[i] > 0) ? (Math.Round(otvet[i], accuracy)).ToString() :
                        "(" + (Math.Round(otvet[i], accuracy)).ToString() + ")";
                    richTextBox2.Text += " | = " + Math.Abs(Math.Round((b_results[i] - otvet[i]), accuracy)) + "\r\n";
                }
            }
            // Обработка ошибок "Незаполненная (неправильно заполненная) ячейка" и 
            // "Отсутствие выбора точности результатов"
            catch
            {
                MessageBox.Show("Не все ячейки заполнены!", "Ошибка");
            }
        }

        // Очистка полей для ввода данных, вывода промежуточных результатов и вывода конечных 
        // решений
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

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
            count_x = Convert.ToInt32(comboBox1.SelectedItem); // Количество переменных
            accuracy = Convert.ToInt32(comboBox2.SelectedIndex);   // Точность расчетов
            double[,] A = new double[count_x, count_x + 1];        // Расширенная матрица
            double[,] A_step;                           // Массив для вывода результатов решения на определенном этапе

            // Обработка ошибки "Отсутствие выбора шага"
            try
            {
                if (Convert.ToInt32(materialSingleLineTextField1.Text) < 1 || Convert.ToInt32
                    (materialSingleLineTextField1.Text) > 3)
                    MessageBox.Show("Введите номер стадии от 1 до 3!", "Ошибка");
                for (int z = 0; z < count_x; z++)
                {
                    for (int j = 0; j < count_x + 1; j++)
                    {
                        A[z, j] = double.Parse(dataGridView1[j, z].Value.ToString());
                    }
                }

                A_step = step(count_x, A); // Вызов метода, отвечающего за расчет решения на 
                                           // определенном этапе
                for (int i = 0; i < count_x; i++)
                    for (int k = 0; k < count_x + 1; k++)
                        dataGridView2.Rows[i].Cells[k].Value = Math.Round(A_step[i, k], accuracy);
            }
            catch
            {
                MessageBox.Show("Введите номер стадии решения!", "Ошибка");
            }
        }

        // Решение квадратной СЛАУ методом Жордана-Гаусса
        private double[] Jordan_Gauss(int count_x, double[,] A)
        {
            int i, k, q;               // Переменные, используемые в циклах для определения индексов
            double interval;           // Переменная, необходимая для промежуточных решений
            double[] answer = new double[count_x]; // Переменная, необходимая для вывода результатов

            // 1 этап: Приведение главной диагонали к единичному виду 
            for (q = 0; q < count_x; q++)
            {
                interval = A[q, q];
                for (k = 0; k < count_x + 1; k++)
                {
                    A[q, k] /= interval;
                }

                // 2 этап: Преобразование расширенной матрицы в верхнюю треугольную матрицу
                for (i = q + 1; i < count_x; i++)
                {
                    interval = A[i, q];
                    for (k = q; k < count_x + 1; k++)
                    {
                        A[i, k] = A[i, k] - A[q, k] * interval;
                    }
                }
            }

            // 3 этап: Преобразование верхней треугольной матрицы в нижнюю треугольную матрицу
            for (q = 0; q < count_x; q++)
                for (i = 0; i < (count_x - 1) - q; i++)
                {
                    interval = A[i, count_x - q - 1];
                    for (k = count_x - q - 1; k < count_x + 1; k++)
                    {
                        A[i, k] = A[i, k] - A[(count_x - 1) - q, k] * interval;
                    }
                }
            for (i = 0; i < count_x; i++)
                answer[i] = Math.Round(A[i, count_x], accuracy);
            return answer;
        }

        // Организация промежуточных результатов
        private double[,] step(int count_x, double[,] A)
        {
            int i, k, q; // Переменные, используемые в циклах для определения индексов элементов
            double interval; // Переменная, необходимая для промежуточных решений
            double[,] A_step = new double[count_x, count_x + 1]; // Локальная расширенная матрица

            for (int z = 0; z < count_x; z++)
                for (int j = 0; j < count_x + 1; j++)
                    A_step[z, j] = double.Parse(dataGridView1[j, z].Value.ToString());

            // 1 этап: Приведение главной диагонали к единичному виду 
            for (q = 0; q < count_x; q++)
            {
                interval = A_step[q, q];
                for (k = 0; k < count_x + 1; k++)
                    A_step[q, k] /= interval;

                // 2 этап: Преобразование расширенной матрицы в верхнюю треугольную матрицу
                if (Convert.ToInt32(materialSingleLineTextField1.Text) == 2 || Convert.ToInt32
                    (materialSingleLineTextField1.Text) == 3)
                {
                    for (i = q + 1; i < count_x; i++)
                    {
                        interval = A_step[i, q];
                        for (k = q; k < count_x + 1; k++)
                        {
                            A_step[i, k] = A_step[i, k] - A_step[q, k] * interval;
                        }
                    }
                }
            }

            // 3 этап: Преобразование верхней треугольной матрицы в нижнюю треугольную матрицу
            if (Convert.ToInt32(materialSingleLineTextField1.Text) == 3)
            {
                for (q = 0; q < count_x; q++)
                    for (i = 0; i < (count_x - 1) - q; i++)
                    {
                        interval = A_step[i, count_x - q - 1];
                        for (k = count_x - q - 1; k < count_x + 1; k++)
                        {
                            A_step[i, k] = Math.Round(A_step[i, k] - A_step[(count_x - 1) - q, k] *
                                interval, accuracy);
                        }
                    }
            }
            return A_step;
        }

        // Организация проверки найденных корней 
        protected string[] proverka(int count_x, double[] roots)
        {
            string[] proverka = new string[count_x];       // Массив для организации вывода проверки
            string[] proverka1 = new string[count_x];      // Массив для вывода
            double[] otvet = new double[count_x];       // Значения свободных коэффициентов при найденных переменных
            double[,] A = new double[count_x, count_x];    // Расширенная матрица

            for (int i = 0; i < count_x; i++)
                for (int j = 0; j < count_x; j++)
                    A[j, i] = double.Parse(dataGridView1[i, j].Value.ToString()); // коэффициенты

            for (int i = 0; i < count_x; i++)
            {
                for (int j = 0; j < count_x; j++)
                {
                    proverka[i] += A[i, j] + " * ";
                    proverka[i] += (roots[j] >= 0) ? (Math.Round(roots[j], accuracy)).ToString() : "(" +
                        (Math.Round(roots[j], accuracy)).ToString() + ")";
                    if (j != count_x - 1)
                    {
                        proverka[i] += (A[i, j + 1] >= 0) ? " + " : " ";
                    }
                    otvet[i] += A[i, j] * Math.Round(roots[j], accuracy);
                }
                proverka[i] += " = " + Math.Round(otvet[i], accuracy);
                proverka1[i] = proverka[i];
                proverka[i] = " ";
            }
            return proverka1;
        }
    }
}
