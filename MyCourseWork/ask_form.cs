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
    public partial class ask_form : Form
    {
        string name;
        string performer;
        int overheard;
        public ask_form()
        {
            InitializeComponent();
        }
        public ask_form(OpenFileDialog obj)//новый перегруженый конструктор
        {
            InitializeComponent();
            textBox1.Text = obj.SafeFileName;//выводит название песни в первый текстбокс формы(текстбокс для имени)
        }
        //геттеры на поля формы(имя, исполнитель, прослушало)
        public string Name_Of_Song { get { return name; } }
        public string Performer { get { return performer; } }
        public int Overheard { get { return overheard; } }
        //событие нажатия кнопки
        private void button1_Click(object sender, EventArgs e)
        {     
                name = textBox1.Text;
                performer = textBox2.Text;
                overheard = Convert.ToInt32(textBox3.Text);
        }
    }
}
