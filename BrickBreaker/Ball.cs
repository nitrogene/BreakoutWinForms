using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
	class Ball : Shape
	{
		public int XSpeed { get; set; }
		public int YSpeed { get; set; }

		public Ball(int x, int y, int size = 10, int xspeed = 1, int yspeed = 1)
		{
			this.MyRect = new Rectangle(x, y, size, size);
			XSpeed = xspeed;
			YSpeed = yspeed;
		}

		public void DrawBall(Graphics g)
		{
			g.FillEllipse(new SolidBrush(Color.Black), this.MyRect);
		}

		public void Move()
		{
			Point newPoint = new Point(MyRect.X + XSpeed, MyRect.Y + YSpeed);
			Rectangle temp = new Rectangle(newPoint.X, newPoint.Y, MyRect.Width, MyRect.Height);
			MyRect = temp;
		}
	}
}
