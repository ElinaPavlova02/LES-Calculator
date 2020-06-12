﻿using MaterialSkin;
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
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            // Подключение библиотеки Material Skin для создания дизайна
            var materialSkinManager = MaterialSkinManager.Instance; 
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; 
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey500, Primary.Grey500, 
                Primary.BlueGrey800, Accent.Red700, TextShade.WHITE);
        }
        // Обработка нажатия на кнопку "Перейти"
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked)
            {
                Form2 form2 = new Form2();
                form2.Show(); // Загрузка метода Гаусса
            }
            else if (materialRadioButton2.Checked)
            {
                Form3 form3 = new Form3();
                form3.Show(); // Загрузка метода Жордана-Гаусса
            }           
        }

        // Текст вкладки "Теоретическая справка" и вкладки "О программе"
        private void Form1_Load(object sender, EventArgs e)
        {
            materialLabel3.Text = "Система линейных алгебраических уравнений — система уравнений," +
                " каждое уравнение в которой является линейным — алгебраическим уравнением первой " +
                "степени.\r\n\r\nКвадратная система линейных уравнений — система, у которой количество" +
                " уравнений совпадает с числом неизвестных.\r\n\r\nСистема называется совместной, если " +
                "она имеет хотя бы одно решение, и несовместной, если у неё нет ни одного решения. " +
                "Совместная система с единственным решением называется определённой. \r\n \r\nМетоды " +
                "решения квадратных СЛАУ, применяемые в этой программе:\r\n • Метод Гаусса;\r\n • " +
                "Метод Жордана-Гаусса.\r\n\r\nМетод Гаусса – это метод последовательного исключения " +
                "неизвестных. Суть метода Гаусса состоит в преобразовании исходной системы к системе " +
                "с треугольной матрицей (все элементы ниже главной диагонали равны нулю), из которой" +
                " затем последовательно обратным ходом получаются значения всех неизвестных.\r\n\r\n" +
                "Метод Жордана-Гаусса — один из методов, предназначенный для решения систем линейных" +
                " алгебраических уравнений. Этот метод является модификацией метода Гаусса — в " +
                "отличие от него метод Жордана-Гаусса позволяет решить СЛАУ в один этап (без " +
                "использования прямого и обратного ходов).\r\n";
            
            materialLabel1.Text = "Программа \"Решение квадратных СЛАУ\" предназначена для " +
                "нахождения корней квадратных систем линейных алгебраических уравнений. Также у " +
                "пользователя есть возможность ознакомиться с теоретической информацией по данной " +
                "теме.\r\nПеред началом работы следует ознакомиться со следующими алгоритмом " +
                "действий:\r\n\r\n1. Выберите количество переменных и необходимую точность расчетов" +
                " и нажмите кнопку \"Применить\"(вы можете изменить точность во время работы " +
                "программы, выбрав другое значение и нажав кнопку \"Расчитать\");\r\n\r\n2. Введите" +
                " коэффициенты при переменных и свободные коэффициенты в таблицы; при этом " +
                "положительные числа вводятся без указания знака, в десятичных дробях целая и " +
                "дробная часть разделяется запятой, отсутствуют пробелы между знаком и числом;\r\n\r\n3. Нажмите кнопку " +
                "\"Расчитать\";\r\n\r\n4. Если необходимо вывести промежуточные результаты, введите " +
                "номер шага в указанное поле из промежутка допустимых натуральных значений;\r\n\r\n" +
                "5. Если необходимо ввести новые данные, нажмите кнопку \"Очистить\";\r\n\r\n6. Если" +
                " необходимо вернуться в главное меню, нажмите кнопку \"Назад\".\r\n\r\nПримечание:" +
                " если исходная квадратная СЛАУ не может иметь корней, то в компонентах с выходными" +
                " данными вместо числа будет написано \"не число\".";
        }
    }
}
