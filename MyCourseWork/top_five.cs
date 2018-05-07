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
    public partial class top_five : Form
    {
        public top_five()
        {
            InitializeComponent();
        }
        public top_five(song_list obj)//передаем ссылку на список
        {
            InitializeComponent();
            obj.show_five(dataGridView5);//вызываем в этой форме метод show_five со здешней dataGridView5
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();//событие для закрытия формы
        }
    }
}
