using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepiPipe
{
    public partial class Form1 : Form
    {
        bool right;
        bool left;
        
        private int _x;
        private int _y;

        List<block> blocks;

        //block b1;
        const int fps = 60;

        public Form1()
        {
            InitializeComponent();

            _x = 50;
            _y = 50;

            blocks = new List<block>();

            Random r = new Random();

            for (int i = 0; i < 3; i++)
            {
                blocks.Add(new block(Width, Height,r));
            }


            /*b1 = new block()
            {
                _x = this.Width / 2,
                _y = this.Height / 2,
                _r = 15,
                _xv = 3,
                _yv = 3,
                brush = Brushes.Violet,

            };*/

            var task = new Task(Run);
            task.Start();

        }

        protected void Run ()
        {
            while (true)
            {
                foreach ( var block in blocks)
                {
                    block.move(this.Width, this.Height);
                }

                // b1.move(this.Width, this.Height);
                this.Invalidate();
                Thread.Sleep(1000 / fps); //ความเร็ว
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 100,100 คือขนาดของรูป
            e.Graphics.FillRectangle(Brushes.BlueViolet, _x, _y, 30, 30);
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            foreach (var block in blocks)
            {
                block.draw(g);
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _y += 10;

            // สำคัญมาก
            Invalidate();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (right == true)
            {
                pictureBox1.Left += 5;
            }

            if (left == true)
            {
                pictureBox1.Left -= 5;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            if (e.KeyCode == Keys.Right) x += 5;
            else if (e.KeyCode == Keys.Left) x -= 5;
            else if (e.KeyCode == Keys.Up) y -= 5;
            else if (e.KeyCode == Keys.Down) y += 5;
            
            pictureBox1.Location = new Point(x, y);
            /*
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }*/
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }*/
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'Z' || e.KeyChar == 'z')
            {
                pictureBox2.Image = Image.FromFile(@"F:\homework\OOP Project 2\Straight_02edit.jpg");
            }

            if (e.KeyChar == 'X' || e.KeyChar == 'x')
            {
                pictureBox2.Image = Image.FromFile(@"F:\homework\OOP Project 2\Straight_01.jpg");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                pictureBox2.Image = Image.FromFile(@"F:\homework\OOP Project 2\Straight_02edit.jpg");
            }
            if (e.Clicks == 1)
            {
                pictureBox2.Image = Image.FromFile(@"F:\homework\OOP Project 2\Straight_01.jpg");
            }

        }


        private void timer3_Tick(object sender, EventArgs e)
        {

        }
    }
}



/*
   private bool reduce = false;
private int size = 0;
private void tmrCharacterWalking_Tick(object sender, EventArgs e)
{
    if (reduce) size--;
    else size++;
    if (size > 500) reduce = true;
    else if (size < 1) reduce = false;
    this.Invalidate();


            enum Position
            {
                Left, Right, Up, Down
            }



            private int _x;
            private int _y;
            private Position _objPosition;


            public FormView()
            {
                //ตำแน่งก่อนเคลื่อนที่
                InitializeComponent();

                _x = 50;
                _y = 50;
                _objPosition = Position.Down;
            }



            private void FormView_Paint(object sender, PaintEventArgs e)
            {
                // 100,100 คือขนาดของรูป
                e.Graphics.FillRectangle(Brushes.BlueViolet, _x, _y, 30, 30);
            }




            /*private void tmrMoving_Tick(object sender, EventArgs e)
            {
                if (_objPosition == Position.Right)
                {
                    _x += 10;
                }
                else if (_objPosition == Position.Left)
                {
                    _x -= 10;
                }
                else if (_objPosition == Position.Up)
                {
                    _y -= 10;
                }
                else if (_objPosition == Position.Down)
                {
                    _y += 10;
                }
                // สำคัญมาก
                Invalidate();
            }
            */

/* private void FormView_KeyDown(object sender, KeyEventArgs e)
 {
     if (e.KeyCode == Keys.Left)
     {
         _objPosition = Position.Left;
     }
     else if (e.KeyCode == Keys.Right)
     {
         _objPosition = Position.Right;
     }
     else if (e.KeyCode == Keys.Up)
     {
         _objPosition = Position.Up;
     }
     else if (e.KeyCode == Keys.Down)
     {
         _objPosition = Position.Down;
     }

 }

}
}

}
}
*/
