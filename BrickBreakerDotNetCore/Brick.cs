using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
	class Brick : Shape
	{
		public Brick(int x, int y, int width, int height)
		{
			MyRect = new Rectangle(x, y, width, height);

		}
		public void DrawBrick(Graphics g)
		{
			g.FillRectangle(new SolidBrush(Color.Black), this.MyRect);

		}
	}
}
