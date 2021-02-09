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

    public class Some_Methods
    {
        public void from_bmp_to_ascii(Bitmap bmp, int height, int width)
        {
            char[][] ascii_image = new char[height][];
            const string symbols = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\" ^`'. ";
            StreamWriter SW = new StreamWriter(new FileStream("FileName.txt", FileMode.Create, FileAccess.Write));

            for (int i = 0; i < height; i++)
            {
                ascii_image[i] = new char[width];
            }

            for (int i = 0; i < height; i++)
            {
                int AVG = 0;
                Color PixInfo;
                int PixColor;
                int sym = 0;
                SW.Write("\n");
                for (int j = 0; j < width; j++)
                {
                    if (AVG != 0)
                    {
                        AVG /= 9;
                        sym = Convert.ToInt32(AVG / (double)70);
                        SW.Write(symbols[sym]);
                    }
                    for (int h = i * 4; h < (i + 1) * 4; h++)
                    {
                        for (int w = j * 2; w < (j + 1) * 2; w++)
                        {
                            PixInfo = bmp.GetPixel(w, h);
                            PixColor = PixInfo.R;
                            AVG += PixColor;
                        }
                    }
                }
            }
            SW.Close();
        }

        public Bitmap from_bmp_to_monochrome_bmp(Bitmap bmp)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color PixInfo = bmp.GetPixel(j, i);
                    int PixColor = (PixInfo.R + PixInfo.G + PixInfo.B) / 3;
                    bmp2.SetPixel(j, i, Color.FromArgb(255, PixColor, PixColor, PixColor));
                }
            }
            return bmp2;
        }

        public Bitmap from_bmp_to_negative_bmp(Bitmap bmp)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color PixInfo = bmp.GetPixel(j, i);
                    int R = 255 - PixInfo.R;
                    int G = 255 - PixInfo.G;
                    int B = 255 - PixInfo.B;
                    bmp2.SetPixel(j, i, Color.FromArgb(255, R, G, B));
                }
            }
            return bmp2;
        }

        public Bitmap from_bmp_to_mono_negative_bmp(Bitmap bmp)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color PixInfo = bmp.GetPixel(j, i);
                    int PixColor = 255 - (PixInfo.R + PixInfo.G + PixInfo.B) / 3;
                    bmp2.SetPixel(j, i, Color.FromArgb(255, PixColor, PixColor, PixColor));
                }
            }
            return bmp2;
        }

        public void create_bmp_Image(Bitmap bmp, string fileway)
        {
            bmp.Save(@fileway, ImageFormat.Bmp);
            Console.WriteLine("Image saved into " + fileway);
        }
    }

    public class MyBMP : Some_Methods
    {
        Bitmap private_data;
        string SaveWay = @"C:\Users\derta\Pictures\";

        public MyBMP(string link_to_bmp)
        {
            private_data = new Bitmap(link_to_bmp);
        }

        public MyBMP(Bitmap private_data_)
        {
            private_data = (Bitmap)private_data_.Clone();
        }

        public void Clone(out MyBMP BMP)
        {
            BMP = new MyBMP(private_data);
        }

        public static string make_bmp_from_any_image(string inputlink)
        {
            string SaveWay = @"C:\Users\derta\Pictures\";
            if (Path.GetExtension(inputlink) != ".bmp")
            {
                string outlink = Path.Combine(SaveWay, Path.GetFileNameWithoutExtension(inputlink) + ".bmp");
                Image img = Image.FromFile(@SaveWay+@inputlink);
                img.Save(@outlink, ImageFormat.Bmp);
                return outlink;
            }
            else return SaveWay+inputlink;
        }

        public void from_bmp_to_ascii()
        {
            from_bmp_to_ascii(private_data, private_data.Height / 4, private_data.Width / 2);
        }

        public void from_bmp_to_monochrome_bmp()
        {
            private_data = from_bmp_to_monochrome_bmp(private_data);
        }

        public void Save()
        {
            Guid g = Guid.NewGuid();
            private_data.Save(Path.Combine(@SaveWay, g + ".bmp"), ImageFormat.Bmp);
        }

        public void from_bmp_to_negative_bmp()
        {
            private_data = from_bmp_to_negative_bmp(private_data);
        }

        public void from_bmp_to_mono_negative_bmp()
        {
            private_data = from_bmp_to_mono_negative_bmp(private_data);
        }


    }
}

