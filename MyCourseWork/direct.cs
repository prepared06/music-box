using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCourseWork
{
    public partial class direct : Form
    {
        public direct()//конструктор по умолчанию
        {
            InitializeComponent();
        }
        public direct(string param)//конструктор с параметром, который принимает уже имеющиеся сведенье о треке и выводит его в текстбокс
        {
            InitializeComponent();
            textBox1.Text = param;
        }
        public string data { get; set; }//геттер вместе с полем
       

        //при нажатие ОК
        private void button1_Click(object sender, EventArgs e)
        {
            data = textBox1.Text;//закидываем в поле текущие положение текстбокса
        }
        //нажатие ОТМЕНА
        private void button2_Click(object sender, EventArgs e)
        {
        }
       
    }
}
