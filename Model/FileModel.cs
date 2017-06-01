using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using MyShapes;

namespace DAL
{
    //struct Coordinates
    //{
    //    private double x;
    //    private double y;
    //    public Coordinates(double x, double y)
    //    {
    //        this.x = x;
    //        this.y = y;
    //    }
    //    public double X
    //    {
    //        get { return x; }
    //        set { x = value; }
    //    }
    //    public double Y
    //    {
    //        get { return y; }
    //        set { y = value; }
    //    }

    //}

    public class FileModel
    {

        public static void FileWrite(string path, Canvas cv, MyPolygon myPolygon)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.Default);
            bw.Write(cv.Children.Count);
            bw.Write(myPolygon.FillColor.Color.A);
            bw.Write(myPolygon.FillColor.Color.R);
            bw.Write(myPolygon.FillColor.Color.G);
            bw.Write(myPolygon.FillColor.Color.B);
            bw.Write(myPolygon.BorderColor.Color.A);
            bw.Write(myPolygon.BorderColor.Color.R);
            bw.Write(myPolygon.BorderColor.Color.G);
            bw.Write(myPolygon.BorderColor.Color.B);
            bw.Write(myPolygon.PolyThickness);
            foreach (var mPol in cv.Children)
            {
                if (mPol is MyPolygon)
                {
                    bw.Write(Canvas.GetLeft((MyPolygon)mPol));
                    bw.Write(Canvas.GetTop((MyPolygon)mPol));
                }
            }
            bw.Close();
            fs.Close();
        }
        public static void FileRead(string path,ref Canvas cv, ref MyPolygon myPolygon)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs, Encoding.Default);
            int amount = br.ReadInt32();
            myPolygon.FillColor = new SolidColorBrush(Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte()));
            myPolygon.BorderColor = new SolidColorBrush(Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte()));
            myPolygon.PolyThickness = br.ReadInt32();
            for (int i = 0; i < amount; i++)
            {
                MyPolygon myPol = new MyPolygon();
                myPol.FillColor = myPolygon.FillColor;
                myPol.BorderColor = myPolygon.BorderColor;
                myPol.PolyThickness = myPolygon.PolyThickness;
                cv.Children.Add(myPol);
                Canvas.SetLeft(myPol, br.ReadDouble());
                Canvas.SetTop(myPol, br.ReadDouble());
            }
            br.Close();
            fs.Close();
            /////////////////////////////////
        }
    }
}
