using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesingCalculator2022_work
{
    public partial class Form1 : Form
    {
        double FirstNumber; //переменная для хранения первого числа
        string operation; // переменная для хранения знаков операций 
        bool isOperationClicked = false; // флаг была ли нажата кнопка операции 
        

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNumber_Click(Object sender, EventArgs e) // метод для распознавания какая кнопка нажата используя sender 
        {
            if (txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0";
            }
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0" || isOperationClicked) // "||" - или (or) --- если на экране 0 или нажата кнока операции
             // то убираем 0 и выводим нажатую кнопку и убераем флаг что бы следующие цифры приклеивались 
            {
                txtDisplay.Text = btn.Text;
                isOperationClicked = false; // сбрасываем флаг что бы следующие цифры приклеивались 
            }

            else
            {
                txtDisplay.Text += btn.Text;
            }
        }
        private void BtnOperation_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            FirstNumber = Convert.ToDouble(txtDisplay.Text);
            operation = btn.Text; // сохраняем знак будущего действия
            isOperationClicked = true; // Знак операции нажат! При следующем клике на любую цифру не склеивай её со старым числом, а сотри экран и начни число заново

        }
        private void Btn_ravno_click(object sender, EventArgs e) // метед для " = " 
        {
            if (txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0";
            }
            double secondNumber = Convert.ToDouble(txtDisplay.Text);
            double result = 0; // задаем начальную переменную результату 
            switch (operation) // берем переменную операций и смотрим что в ней лежит 
            {
                case "+": // лежит + выполняем действие и выходим 
                    result = FirstNumber + secondNumber;
                    break; // нужное действие сделано останавливаем процесс перебора вариантов 

                case "-":
                    result = FirstNumber - secondNumber;
                    break;

                case "×":
                    result = FirstNumber * secondNumber;
                    break;
                
                case "÷":
                    if (secondNumber == 0) // если второе число равно нулю при делении 
                    {
                        txtDisplay.Text = "Ошибка"; // выводим ошибку 
                        return;
                    }
                    else
                    {
                        result = FirstNumber / secondNumber;
                        break;
                    }
            }
            txtDisplay.Text = result.ToString();
        }

        private void BtnC_Click(object sender, EventArgs e) // метод для очистки 
        {
            if (txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0";
            }
            txtDisplay.Text = "0";
            FirstNumber = 0;
            operation = "";
            isOperationClicked = false;
            
            
        }

        private void BtnSteret_Click(object sender, EventArgs e) // метод для стирания посленего символа с конца 
        {
            if (txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0";
            }
            if (txtDisplay.Text.Length > 0) // возвращает кол-во символов в строке текущее 
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1); // стирает число с конца 
            }
            else 
            {
                txtDisplay.Text = "0";
            }

        }

        private void BtnTochka_Click(object sender, EventArgs e) // метод для точки с ограничениями 
        {
            if (txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0";
            }
            if(isOperationClicked == true) // если был нажат знак операции 
            {
                txtDisplay.Text = "0,"; // стираем старое число и пишем 0 с точкой 
                isOperationClicked = false;
            }
            else
            {
                if (!txtDisplay.Text.Contains(",")) // если в тексте !НЕТУ точки 
                {
                    txtDisplay.Text += ","; // то присваеваем точку в конец 
                }
            } 
                

        }

        private void BtnCE_Click(object sender, EventArgs e) // метод для очистки второго числа 
        {
            if (txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0";
            }
            txtDisplay.Text = "0";
            
        }

        private void BtnPlusMinus_Click(object sender, EventArgs e) // метод для превращени числа из положительного в отрицательное и наоборот 
        {
            if (txtDisplay.Text == "Ошибка") 
            { 
                txtDisplay.Text = "0"; 
            }
            double number = Convert.ToDouble(txtDisplay.Text);
            number = number * -1;
            txtDisplay.Text = number.ToString();
        }
    }
    }

