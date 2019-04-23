using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
	class Paddle : Shape
	{

		public Paddle(int x, int y, int width, int height)
		{
			this.MyRect = new Rectangle(x, y, width, height);
		}

		public void DrawPaddle(Graphics g)
		{
			g.FillRectangle(new SolidBrush(Color.Black), this.MyRect);

		}
		public void MoveLeft(int speed = 10)
		{
			//this.MyRect.X -= speed;
			Point newPoint = new Point(MyRect.X - 10, MyRect.Y);
			Rectangle temp = new Rectangle(newPoint.X, newPoint.Y, MyRect.Width, MyRect.Height);
			MyRect = temp;
		}

		public void MoveRight(int speed = 10)
		{
			Point newPoint = new Point(MyRect.X + 10, MyRect.Y);
			Rectangle temp = new Rectangle(newPoint.X, newPoint.Y, MyRect.Width, MyRect.Height);
			MyRect = temp;
		}

	}
}
