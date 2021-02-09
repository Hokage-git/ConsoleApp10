using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите название файла для обработки(Файл должен находиться в папке \"Изображения\" и пожалуйста указывайте расширение файла):");
            MyBMP bmp = new MyBMP(MyBMP.make_bmp_from_any_image(Console.ReadLine()));
            MyBMP bmp2;
            bmp.Clone(out bmp2);
            MyBMP bmp3;
            bmp.Clone(out bmp3);
            bmp.from_bmp_to_monochrome_bmp();
            bmp.Save();
            bmp.from_bmp_to_ascii();
            bmp3.from_bmp_to_negative_bmp();
            bmp3.Save();
            bmp2.from_bmp_to_mono_negative_bmp();
            bmp2.Save();
        }
    }
}
