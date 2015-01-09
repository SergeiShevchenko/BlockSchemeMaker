using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Block
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<BlockPart> blocks = new List<BlockPart>();

        BlockPart CurrentBlock;

        BlockPart PropertyBlock;

        BlockPart OutBlock;
        BlockPart InBlock;

        List<BlockPart[]> link = new List<BlockPart[]>();

        int cubeSize = 20;



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (checkBox1.Checked)
            {
                for (int i = 0; i <= pictureBox1.Width / cubeSize; i++)
                {
                    e.Graphics.DrawLine(Pens.WhiteSmoke, i * cubeSize, 0, i * cubeSize, pictureBox1.Height);
                }

                for (int i = 0; i <= pictureBox1.Height / cubeSize; i++)
                {
                    e.Graphics.DrawLine(Pens.WhiteSmoke, 0, i * cubeSize, pictureBox1.Width, i * cubeSize);
                }
            }

            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Draw(e.Graphics, cubeSize);
            }

            for (int i = 0; i < link.Count; i++)
            {
                //e.Graphics.DrawLine(Pens.Black, link[i][0].x * cubeSize, link[i][0].y * cubeSize, link[i][1].x * cubeSize, link[i][1].y * cubeSize);
                e.Graphics.DrawLine(Pens.Black, (link[i][0].x + link[i][0].sizeW / 2) * cubeSize, (link[i][0].y + link[i][0].sizeH) * cubeSize, (link[i][0].x + link[i][0].sizeW / 2) * cubeSize, (link[i][0].y + link[i][0].sizeH + 1) * cubeSize);
                
                e.Graphics.DrawLine(Pens.Black, (link[i][1].x + link[i][1].sizeW / 2) * cubeSize, (link[i][1].y) * cubeSize, (link[i][1].x + link[i][1].sizeW / 2) * cubeSize, (link[i][0].y + link[i][0].sizeH + 1) * cubeSize);

                e.Graphics.DrawLine(Pens.Black, (link[i][0].x + link[i][0].sizeW / 2) * cubeSize, (link[i][0].y + link[i][0].sizeH + 1) * cubeSize, (link[i][1].x + link[i][1].sizeW / 2) * cubeSize, (link[i][0].y + link[i][0].sizeH + 1) * cubeSize);

            }

            if (CurrentBlock != null)
                CurrentBlock.Draw(e.Graphics, cubeSize);

            if (PropertyBlock != null)
            {
                Pen p = new Pen(Color.Red);
                p.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(p, PropertyBlock.x * cubeSize, PropertyBlock.y * cubeSize, PropertyBlock.sizeW * cubeSize, PropertyBlock.sizeH * cubeSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentBlock = new Rect(-10, -10);
            PropertyBlock = CurrentBlock;
            ShowTheProperties(PropertyBlock);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentBlock != null)
            {
                CurrentBlock.x = e.X / cubeSize - CurrentBlock.sizeW / 2;
                CurrentBlock.y = e.Y / cubeSize - CurrentBlock.sizeH / 2;
                pictureBox1.Invalidate();
            }
        }

        void ShowTheProperties(BlockPart b)
        {
            textBox1.Text = b.text;
            trackBar2.Value = (int)((b.textShiftX / b.sizeW) * 100);
            trackBar3.Value = 100-(int)((b.textShiftY / b.sizeH) * 100);
        }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < blocks.Count; i++)
                {
                    if ((e.X >= blocks[i].x * cubeSize) && (e.X <= (blocks[i].x + blocks[i].sizeW) * cubeSize) && (e.Y >= blocks[i].y * cubeSize) && (e.Y <= (blocks[i].y + blocks[i].sizeH) * cubeSize))
                    {
                        PropertyBlock = blocks[i];
                        ShowTheProperties(blocks[i]);
                    }
                }
            }
            else
            {
                if (CurrentBlock != null)
                {
                    blocks.Add(CurrentBlock);
                    CurrentBlock = null;
                }
                else
                {
                    if (e.Button == MouseButtons.Middle)
                    {
                        for (int i = 0; i < blocks.Count; i++)
                        {
                            if ((e.X >= blocks[i].x * cubeSize) && (e.X <= (blocks[i].x + blocks[i].sizeW) * cubeSize) && (e.Y >= blocks[i].y * cubeSize) && (e.Y <= (blocks[i].y + blocks[i].sizeH) * cubeSize))
                            {
                                CurrentBlock = blocks[i];
                                blocks.Remove(blocks[i]);
                            }
                        }
                    }
                }
            }
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurrentBlock = new Terminal(-10, -10);
            PropertyBlock = CurrentBlock;
            ShowTheProperties(PropertyBlock);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (PropertyBlock != null)
            {
                PropertyBlock.text = textBox1.Text;
                PropertyBlock = null;
            }
            pictureBox1.Invalidate();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            cubeSize = trackBar1.Value;
            pictureBox1.Invalidate();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (PropertyBlock!=null)
                PropertyBlock.textShiftX = (double)(trackBar2.Value*PropertyBlock.sizeW/100.0);
            pictureBox1.Invalidate();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            if (PropertyBlock != null)
                PropertyBlock.textShiftY = (double)((100-trackBar3.Value)*PropertyBlock.sizeH/100.0);
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CurrentBlock = new Proc(-10, -10);
            PropertyBlock = CurrentBlock;
            ShowTheProperties(PropertyBlock);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CurrentBlock = new Vetv(-10, -10);
            PropertyBlock = CurrentBlock;
            ShowTheProperties(PropertyBlock);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (PropertyBlock != null)
            {
                PropertyBlock.text = textBox1.Text;
                pictureBox1.Invalidate();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            blocks.Remove(PropertyBlock);
            int i = 0;
            while (i<link.Count)
            {
                if ((link[i][0] == PropertyBlock) || (link[i][1] == PropertyBlock))
                    link.RemoveAt(i);
                else i++;
            }

            PropertyBlock = null;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentBlock == null)
            {
                bool gotIt = false;
                for (int i = 0; i < blocks.Count; i++)
                {
                    if ((e.X >= blocks[i].x * cubeSize) && (e.X <= (blocks[i].x + blocks[i].sizeW) * cubeSize) && (e.Y >= blocks[i].y * cubeSize) && (e.Y <= (blocks[i].y + blocks[i].sizeH) * cubeSize))
                    {
                        OutBlock = blocks[i];
                        gotIt = true;
                        break;
                    }
                }
                if (!gotIt)
                    OutBlock = null;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((CurrentBlock == null)&&(OutBlock!=null)&&(e.Button==MouseButtons.Left))
            {
                bool gotIt = false;
                for (int i = 0; i < blocks.Count; i++)
                {
                    if ((e.X >= blocks[i].x * cubeSize) && (e.X <= (blocks[i].x + blocks[i].sizeW) * cubeSize) && (e.Y >= blocks[i].y * cubeSize) && (e.Y <= (blocks[i].y + blocks[i].sizeH) * cubeSize))
                    {
                        InBlock = blocks[i];
                        gotIt = true;
                        break;
                    }
                }
                if ((!gotIt)||(OutBlock==InBlock))
                {
                    OutBlock = null;
                    InBlock = null;
                }
                else
                {
                    link.Add(new BlockPart[2]{OutBlock, InBlock});
                    OutBlock = null;
                    InBlock = null;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CurrentBlock = new Textik(-10, -10);
            PropertyBlock = CurrentBlock;
            ShowTheProperties(PropertyBlock);
        }
    }
}
