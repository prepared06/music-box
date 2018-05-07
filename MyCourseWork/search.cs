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
    public partial class search : Form
    {
        DataGridView sea;
        public search()
        {
            InitializeComponent();
        }
        public search(DataGridView obj)//передаем главный объэкт dataGridView1
        {
            InitializeComponent();
            sea = obj;//инициализируем параметром здешнюю ссылку
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //label4.Text = "";//онуляем предидущии
            //label5.Text = "";//
            for (int i = 0; i < sea.RowCount - 1; i++)//проверяем по всем строкам
            {
                if (sea.Rows[i].Cells[0].Value.ToString() == " " + textBox1.Text)//если есть сходство по имени трека
                {
                    label4.Text = Convert.ToString(sea.Rows[i].Cells[1].Value);//выводим остальную инфу
                    label5.Text = Convert.ToString(sea.Rows[i].Cells[2].Value);
                    break;
                }
                else//иначе выводим текст, что ниже
                {
                    label4.Text = "Не найдено совпадений";
                    label5.Text = "Не найдено совпадений";
                }
            }
        }
    }
}
