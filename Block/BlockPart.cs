using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Block
{
    abstract class BlockPart
    {
        public int sizeH, sizeW;
        public string text;
        public int x, y;
        public double textShiftX, textShiftY;
        abstract public void Draw(Graphics g, int mashtab);/*
        {
            g.DrawRectangle(Pens.Black, x * mashtab, y * mashtab, sizeW * mashtab, sizeH * mashtab);
            g.DrawString("Unknown shit", new Font("Times New Roman", 12F), Brushes.Red, x * mashtab, y * mashtab);
        }*/
    }

    class Rect : BlockPart
    {
        public Rect(int X, int Y)
        {
            sizeH = 4;
            sizeW = 3 * sizeH;
            x = X;
            y = Y;
            text = "Блок вычислений";
            textShiftX = sizeW / 10.0;
            textShiftY = sizeH / 10.0;
        }

        public override void Draw(Graphics g, int mashtab)
        {
            g.FillRectangle(Brushes.White, x * mashtab, y * mashtab, sizeW * mashtab, sizeH * mashtab);
            g.DrawRectangle(Pens.Black, x * mashtab, y * mashtab, sizeW * mashtab, sizeH * mashtab);
            g.DrawString(text, new Font("Times New Roman", 12F), Brushes.Black, (int)((x + textShiftX) * mashtab), (int)((y + textShiftY) * mashtab));
        }
    }


    class Terminal : BlockPart
    {
        public Terminal(int X, int Y)
        {
            sizeH = 4;
            sizeW = 3 * sizeH;
            x = X;
            y = Y;
            text = "Начало";
            textShiftX = sizeW / 2.0;
            textShiftY = sizeH / 2.0;
        }

        public override void Draw(Graphics g, int mashtab)
        {
            int r = sizeH / 2;

            g.FillEllipse(Brushes.White, (x) * mashtab, y * mashtab, (int)(sizeH * mashtab) - 2, (int)(sizeH * mashtab) - 2);
            g.FillEllipse(Brushes.White, (x + sizeW - sizeH) * mashtab, (y) * mashtab, (int)(sizeH * mashtab) - 2, (int)(sizeH * mashtab) - 2);

            g.DrawEllipse(Pens.Black, (x) * mashtab, y * mashtab, (int)(sizeH * mashtab), (int)(sizeH * mashtab));
            g.DrawEllipse(Pens.Black, (x + sizeW - sizeH) * mashtab, y * mashtab, (int)(sizeH * mashtab), (int)(sizeH * mashtab));
                       

            g.FillRectangle(Brushes.White, (int)(x + r) * mashtab, y * mashtab, (int)(sizeW - sizeH) * mashtab, sizeH * mashtab);

            g.DrawLine(Pens.Black, (x + r) * mashtab, y * mashtab, (x + sizeW-r) * mashtab, y * mashtab);
            g.DrawLine(Pens.Black, (x + r) * mashtab, (y+sizeH) * mashtab, (x + sizeW-r) * mashtab, (y+sizeH) * mashtab);

            g.DrawString(text, new Font("Times New Roman", 12F), Brushes.Black, (int)((x + textShiftX) * mashtab), (int)((y + textShiftY) * mashtab));
        }
    }

    class Proc : BlockPart
    {
        public Proc(int X, int Y)
        {
            sizeH = 4;
            sizeW = 3 * sizeH;
            x = X;
            y = Y;
            text = "Процедурка";
            textShiftX = 0.5*sizeW;
            textShiftY = 0.5*sizeH;
        }

        public override void Draw(Graphics g, int mashtab)
        {
            g.FillRectangle(Brushes.White, x * mashtab, y * mashtab, sizeW * mashtab, sizeH * mashtab);
            g.DrawRectangle(Pens.Black, x * mashtab, y * mashtab, sizeW * mashtab, sizeH * mashtab);
            g.DrawRectangle(Pens.Black, (int)((x+sizeW/10.0) * mashtab), y * mashtab, (int)((sizeW-sizeW/5.0) * mashtab), sizeH * mashtab);
            g.DrawString(text, new Font("Times New Roman", 12F), Brushes.Black, (int)((x + textShiftX) * mashtab), (int)((y + textShiftY) * mashtab));
        }
    }

    class Vetv : BlockPart
    {
        public Vetv(int X, int Y)
        {
            sizeH = 6;
            sizeW = 6;
            x = X;
            y = Y;
            text = "if";
            textShiftX = 0.5*sizeW;
            textShiftY = 0.5*sizeH;
        }

        public override void Draw(Graphics g, int mashtab)
        {
            Point r1 = new Point(x * mashtab, (y + sizeH / 2) * mashtab);
            Point r2 = new Point((x + sizeW / 2) * mashtab, y * mashtab);
            Point r3 = new Point((x + sizeW) * mashtab, (y + sizeH / 2) * mashtab);
            Point r4 = new Point((x + sizeW / 2) * mashtab, (y + sizeH) * mashtab);

            g.DrawLine(Pens.Black, r1, r2);
            g.DrawLine(Pens.Black, r2, r3);
            g.DrawLine(Pens.Black, r3, r4);
            g.DrawLine(Pens.Black, r4, r1);
            g.DrawString(text, new Font("Times New Roman", 12F), Brushes.Black, (int)((x + textShiftX) * mashtab), (int)((y + textShiftY) * mashtab));
        }
    }

    class Textik : BlockPart
    {
        public Textik(int X, int Y)
        {
            sizeH = 1;
            sizeW = 10;
            x = X;
            y = Y;
            text = "Text";
            textShiftX = 0.5 * sizeW;
            textShiftY = 0;
        }

        public override void Draw(Graphics g, int mashtab)
        {
            g.DrawString(text, new Font("Times New Roman", 12F), Brushes.Black, (int)((x + textShiftX) * mashtab), (int)((y + textShiftY) * mashtab));
        }
    }

}
