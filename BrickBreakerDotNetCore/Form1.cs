using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
	public partial class Form1 : Form
	{
		// graphics variables
		Graphics g;
		Bitmap canvas;

		//shapes to be drawn
		Border border;
		Paddle paddle;
		Ball ball;

		List<Brick> firstRow; // top row
		List<Brick> secondRow; // bottom row
		int bricksPerRow; // initialized with 7 
		bool hitBottom; // if ball goes past bottom border

		public Form1()
		{
			InitializeComponent();

			// setup graphics objects
			// draw to image which will be displayed in picturebox
			g = this.CreateGraphics();
			canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			g = Graphics.FromImage(canvas);


		}

		// initialize objects
		private void Form1_Load(object sender, EventArgs e)
		{
			// create the shapes
			border = new Border(0, 0, ClientRectangle.Width, ClientRectangle.Height, 10);
			paddle = new Paddle(120, 245, 40, 10);
			ball = new Ball(50, 50);

			// create 7 bricks and space them apart by 36 units starting at x=20
			firstRow = new List<Brick>();
			secondRow = new List<Brick>();
			bricksPerRow = 7;
			int startXPos = 20;
			for (int i = 0; i < bricksPerRow; i++)
			{
				firstRow.Add(new Brick(startXPos, 8, 30, 10));
				secondRow.Add(new Brick(startXPos, 25, 30, 10));
				startXPos += 36;
			}

		}

		private void BallBounces()
		{
			// ball bounce
			// within paddle bounds, change y direction
			if (ball.PosBottom() > paddle.PosTop() && ((ball.PosRight() >= paddle.PosLeft()) && (ball.PosRight() <= paddle.PosRight())))
			{
				ball.YSpeed *= -1;
			}
			// sets the hitbotton flag to be true, in which the GameOver function will be called in our game loop and game will exit
			if (ball.PosBottom() >= border.PosBottom())
			{
				hitBottom = true;
			}
			// top of screen, change y direction
			if (ball.PosTop() <= border.PosTop())
			{
				ball.YSpeed *= -1;
			}
			// left and right side of screen, change x direction
			if (ball.PosRight() >= border.PosRight() || ball.PosLeft() <= border.PosLeft())
			{
				ball.XSpeed *= -1;
			}

		}
		// iterate through both the rows and if ball collides with the brick in first or secondrow, set brick to null, the null bricks will not be drawn
		public void BrickCollisions()
		{
			for (int i = 0; i < bricksPerRow; i++)
			{
				if (firstRow[i] != null)
				{
					if (ball.CollidesWith(firstRow[i]))
					{
						ball.YSpeed *= -1;
						firstRow[i] = null;
						break;
					}
				}
				if (secondRow[i] != null)
				{
					if (ball.CollidesWith(secondRow[i]))
					{
						ball.YSpeed *= -1;
						secondRow[i] = null;
						break;
					}
				}
			}

		}

		// draw each of the shapes, for the bricks, if its null, it wont be drawn because it will be considered broken
		public void DrawShapes()
		{
			border.DrawBorder(g);
			paddle.DrawPaddle(g);
			ball.DrawBall(g);

			for (int i = 0; i < bricksPerRow; i++)
			{
				if (firstRow[i] != null)
				{
					firstRow[i].DrawBrick(g);
				}
				if (secondRow[i] != null)
				{
					secondRow[i].DrawBrick(g);
				}
			}

		}
		// if the ball goes past edge it will end game or when both rows contain only nulls
		public bool GameOver()
		{
			bool gameOver = true;

			if (hitBottom)
			{
				return true;
			}
			else
			{
				for (int i = 0; i < bricksPerRow; i++)
				{
					if (firstRow[i] != null || secondRow[i] != null)
					{
						gameOver = false;
						break;
					}
				}
				return gameOver;
			}
		}

		// ticks every 10ms
		private void timer1_Tick(object sender, EventArgs e)
		{
			// erase display
			g.Clear(Control.DefaultBackColor);

			// if all bricks are destroyed
			if (GameOver())
			{
				timer1.Enabled = false;
				MessageBox.Show("Game Over");
				Application.Exit();
			}
			// handle collisions with border
			BallBounces();

			// ball collison with bricks
			BrickCollisions();

			// update position
			ball.Move();

			// draw shapes
			DrawShapes();

			pictureBox1.Image = canvas;
		}

		private void KeysPressed(object sender, KeyEventArgs e)
		{
			// move left
			if (e.KeyCode == Keys.Left)
			{
				if (paddle.MyRect.X > 9)
					paddle.MoveLeft();
			}
			// move right
			if (e.KeyCode == Keys.Right)
			{
				if (paddle.MyRect.X + paddle.MyRect.Width < ClientRectangle.Width - 13)
					paddle.MoveRight();
			}
		}
	}
}
