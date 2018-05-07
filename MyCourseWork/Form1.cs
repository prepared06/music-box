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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;//разрешение редакции dataGridView
        }

        song_list lister = new song_list();//новый список
        //метод добавления трека
        private void button1_Click(object sender, EventArgs e)
        {  
            string path;
            string name;
            string performer;
            int overheard;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)//если нажали ОК, то
            {
                ask_form ob = new ask_form(openFileDialog1);//создаем новую форму
                try
                {
                    if (ob.ShowDialog() == DialogResult.OK)
                    {
                        path = openFileDialog1.FileName;
                        name = ob.Name_Of_Song;
                        performer = ob.Performer;
                        overheard = ob.Overheard;
                        //добавляем в список
                        lister.add(name, performer, path, overheard, dataGridView1);
                    }
                }
                catch(FormatException)//если ловим екзепшн
                { 
                    MessageBox.Show("Не верные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//то  выводим это сообщение
                }
                
            }
        }
        //метод удаления трека
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;//получаем индекс выбраного ряда
                lister.del(i);//удаляем выбраный ряд
                lister.show(dataGridView1);////выводим новый список
            }
            catch// если нечего удалять
            {
                MessageBox.Show("Нечего удолять", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//то  выводим это сообщение
            }
        }
        //справочник
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;//получаем индекс выбраного ряда
                direct dir_obj = new direct(lister.out_directory(i));//передаем конструктору формы уже имеющиеся данные из поля Directory
                dir_obj.ShowDialog();//выводим форму
                if (dir_obj.DialogResult == System.Windows.Forms.DialogResult.OK)//если нажат "ОК"
                {
                    lister.in_directory(i, dir_obj.data);//передаем данные в класс lister из текстбокса
                    dir_obj.Close();//закрываем форму
                }
                else if (dir_obj.DialogResult == System.Windows.Forms.DialogResult.Cancel)//если нажат "Cancel"
                {
                    dir_obj.Close();//то закрываем форму
                }
            }
            catch (ArgumentOutOfRangeException)//на случай попытки редактирования пустого поля, ловим екзепшн "ArgumentOutOfRangeException"
            {
                MessageBox.Show("Некуда вводить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//то  выводим это сообщение
            }
        }
        //запись в файл
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)//выбираем куда и как записать
                {
                    lister.record(saveFileDialog1.FileName);//вызываем метода записи, передаем ему путь
                }
            }
            catch//если ловим екзепшн
            {
                 MessageBox.Show("Ошибка при записи в файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//выводим данное сообщение
            }
        }
        //чтение из файла
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lister.reading(openFileDialog2.FileName);//передаем расположение файла
                    lister.show(dataGridView1);//выводим данные
                }
            }
            catch//если ловим екзепшн
            {
                MessageBox.Show("Ошибка при чтении из файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//выводим данное сообщение
            }
        }   
        //вызов окна топ 5
        private void button8_Click(object sender, EventArgs e)
        {
            //сохраняем неявно файлик со старым порядком
            lister.record("sys.txt");
            top_five obj = new top_five(lister);//инициализируем списком новую форму, для вызова её методов
            obj.ShowDialog();
            //считываем тот файлик
            lister.reading("sys.txt");       
        }
        //поиск трека(вводяться исполнитель или же название трека)
        private void button9_Click(object sender, EventArgs e)
        {
            search obj = new search(dataGridView1);//ищем треки по dataGridView1
            obj.ShowDialog();        
        }
        //событие двойного клацания по списку
        private void wayToPlayer(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;//получаем индекс выбраного ряда
                axWindowsMediaPlayer1.URL = lister.PATH(i);//передача плееру путя к фалу     
            }
            catch (ArgumentOutOfRangeException)//при попытке проиграть пустую строку
            {
                MessageBox.Show("Нечего проигрывать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//выводим данное сообщение
            }
        }
    }
}
