using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace MyCourseWork
{
    public class Song:IComparable //класс для роботы с треками
    {
        string name;//имя трека
        string performer;// имя исполнителя
        string path;//ссылка на файл
        int overheard;//прослушано
        string directory;//справочник
        //свойства полей
        public string Name { get { return name; } set { name = value; } }
        public string Performer { get { return performer; } set { performer = value; } }
        public string Path { get { return path; } set { path = value; } }
        public int Overheard { get { return overheard; } set { overheard = value; } }
        public string Directory { get { return directory; } set { directory = value; } }
        public Song()//конструктор по умолчанию
        { }
        public Song(string N, string Per, string Pat, int over)//конструктор с параметрами
        {
            name = N;
            performer = Per;
            path = Pat;
            overheard = over;
        }
        public int CompareTo(object obj)//для сортировки по убыванию, сравнение происходит по количеству прослушивания
        {

            if (this.overheard > ((Song)obj).overheard)
            {
                return -1;
            }
            if (this.overheard < ((Song)obj).overheard)
            {
                return 1;
            }
            return 0;
        }
    }
    

    public class song_list
    {
        int cout = 0;//счётчик
        XmlSerializer ser = new XmlSerializer(typeof(List<Song>));//сериализатор  
        List<Song> TRACK = new List<Song>();//сам лист
        public void add(string N, string Per, string Pat, int over, DataGridView dg)
            //метод для добавления песен
        {
            TRACK.Add(new Song(N, Per, Pat, over));
            dg.Rows.Add(TRACK[TRACK.Count - 1].Name, TRACK[TRACK.Count - 1].Performer,  TRACK[TRACK.Count - 1].Overheard.ToString());
            cout++;
        }
        //метод для вывода песен
        public void show(DataGridView dg)
        {
            dg.Rows.Clear();
            for (int i = 0; i < TRACK.Count; i++)
            {
                dg.Rows.Add(TRACK[i].Name, TRACK[i].Performer, TRACK[i].Overheard.ToString());
            }
        }
     //для вывода топ 5
        public void show_five(DataGridView dg)
        {
            dg.Rows.Clear();
         
            TRACK.Sort();
            if (TRACK.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    dg.Rows.Add(TRACK[i].Name, TRACK[i].Performer, TRACK[i].Overheard.ToString());
                }
            }
            else
            {
                for (int i = 0; i < TRACK.Count; i++)
                {
                    dg.Rows.Add(TRACK[i].Name, TRACK[i].Performer, TRACK[i].Overheard.ToString());
                }
            }
        }
        //метод удаления
        public void del(int i)
        {
            TRACK.RemoveAt(i);
        }
        //метод записи в файл
        public void record(string f)//берёт адресс
        {
            FileStream file;
            file = new FileStream(f, FileMode.Create, FileAccess.Write, FileShare.None);
            ser.Serialize(file, TRACK);
            file.Close();
        }
        //метод чтения из файла
        public void reading(string f)//берёт адресс
        {
            FileStream file;
            file = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.None);
            TRACK = (List<Song>)ser.Deserialize(file);
            file.Close();
        }
      //метод ввода данных в дневник
        public void in_directory(int Index,string newInf)//ввод в дневник
        {
            TRACK[Index].Directory = newInf;
        }
        //метод вывода из дневника
        public string out_directory(int Index)//вывод из дневника
        {
            return TRACK[Index].Directory;
        }
        //метод доступа к расположению файла
        public string PATH(int index)//возращает расположение файла для плеера
        {
            return TRACK[index].Path;
        }
    }
}
