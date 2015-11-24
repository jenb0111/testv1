using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PepiPipe
{
    class block
    {
        public float _x, _y, _xv, _yv, _r /*, _l*/;
        public Brush brush;


        /*

        public float x
        {
            get;
            set;
        }

        public float y
        {
            get;
            set;
        }

        public float xv
        {   get;
            set;
        }

        public float yv
        {
            get;
            set;
        }

        public float r
        {
            get;
            set;
        }

        public double l
        {
            get;
            set;
        }
        */

        public block (int width, int height , Random r)
        {

            _x = r.Next(width);
            _y = r.Next(height);
            _xv = r.Next(5) + 5;
            _yv = r.Next(5) + 5;
            _r = r.Next(20) + 10;
            brush = new SolidBrush(Color.FromArgb(r.Next(127)+127, r.Next(127)+127 , r.Next(127)+127));

            /*b1 = new block()
            {
                _x = this.Width / 2,
                _y = this.Height / 2,
                _r = 15,
                _xv = 3,
                _yv = 3,
                brush = Brushes.Violet,

            };*/
        }

        /*public block duplicate()
        {
            var b = new block()
            {
                _x = this._x,
                _y = this._y,
                _xv = this._xv,
                _yv = this._yv,
                brush = this.brush,
            };
            return b;
        }*/

        public void move (int width , int height)
        {
            if (_x - _r < 0 || _x + _r > width)
            {
                _xv = -_xv;
            }
            if (_y - _r < 0 || _y + _r > height)
            {
                _yv = -_yv;
            }
            //_x += _xv;
            _y += _yv;
        }

        public void draw (Graphics g)
        {
            //g.FillRectangle(brush,new RectangleF(new PointF(x,y),new SizeF(l,l)));
            //ขนาดจุด
            g.FillEllipse(brush, new RectangleF(_x -_r , _y-_r, _r*2 , _r*2 ));
        }
    }
}
