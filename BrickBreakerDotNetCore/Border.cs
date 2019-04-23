using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
	class Border : Shape
	{
		int _thickness;
		public Border(int x, int y, int width, int height, int thickness)
		{
			this._thickness = thickness;
			this.MyRect = new Rectangle(x, y, width, height);
		}

		public void DrawBorder(Graphics g)
		{
			g.DrawRectangle(new Pen(Color.Black, _thickness), this.MyRect);

		}
	}
}
