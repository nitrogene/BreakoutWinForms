using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
	class Shape
	{
		public Rectangle MyRect { get; set; }

		public int PosLeft()
		{
			return MyRect.Location.X;
		}
		public int PosRight()
		{
			return MyRect.Location.X + MyRect.Width;
		}
		public int PosTop()
		{
			return MyRect.Location.Y;
		}
		public int PosBottom()
		{
			return MyRect.Location.Y + MyRect.Height;
		}

		public bool CollidesWith(Shape r)
		{
			return (MyRect.IntersectsWith(r.MyRect));
		}

	}
}
