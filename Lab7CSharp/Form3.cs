using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form3 : Form
    {
        private Random random = new Random();
        private Shape[] shapes; // Масив для зберігання об'єктів малюнка
        private Graphics graphics;

        public Form3()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics(); // Отримання об'єкту Graphics для малювання на PictureBox
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            
        }

        // Клас базового об'єкта малюнка
        abstract class Shape
        {
            protected int x, y, size;
            protected Color color;

            public Shape(int x, int y, int size, Color color)
            {
                this.x = x;
                this.y = y;
                this.size = size;
                this.color = color;
            }

            public abstract void Draw(Graphics g);
        }

        // Клас еліпса
        class Ellipse : Shape
        {
            public Ellipse(int x, int y, int size, Color color) : base(x, y, size, color) { }

            public override void Draw(Graphics g)
            {
                g.FillEllipse(new SolidBrush(color), x, y, size, size);
            }
        }

        // Клас трикутника
        class Triangle : Shape
        {
            public Triangle(int x, int y, int size, Color color) : base(x, y, size, color) { }

            public override void Draw(Graphics g)
            {
                Point[] points =
                {
                    new Point(x + size / 2, y),
                    new Point(x, y + size),
                    new Point(x + size, y + size)
                };
                g.FillPolygon(new SolidBrush(color), points);
            }
        }

        // Клас прямокутника
        class RectangleShape : Shape
        {
            public RectangleShape(int x, int y, int width, int height, Color color) : base(x, y, width, color) { }

            public override void Draw(Graphics g)
            {
                g.FillRectangle(new SolidBrush(color), x, y, size, size);
            }
        }

        // Клас зірки
        class Star : Shape
        {
            public Star(int x, int y, int size, Color color) : base(x, y, size, color) { }

            public override void Draw(Graphics g)
            {
                Point[] points =
                {
                    new Point(x + size / 2, y),
                    new Point(x + size, y + size),
                    new Point(x, y + size / 3),
                    new Point(x + size, y + size / 3),
                    new Point(x, y + size),
                };
                g.FillPolygon(new SolidBrush(color), points);
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            int numShapes = int.Parse(txtNumShapes.Text); // Отримання кількості фігур з текстового поля
            shapes = new Shape[numShapes]; // Ініціалізація масиву фігур

            for (int i = 0; i < numShapes; i++)
            {
                // Генерація випадкових параметрів для кожної фігури
                int x = random.Next(pictureBox1.Width);
                int y = random.Next(pictureBox1.Height);
                int size = random.Next(20, 100);
                Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                // Випадково вибираємо тип фігури
                switch (random.Next(4))
                {
                    case 0:
                        shapes[i] = new Ellipse(x, y, size, color);
                        break;
                    case 1:
                        shapes[i] = new Triangle(x, y, size, color);
                        break;
                    case 2:
                        shapes[i] = new RectangleShape(x, y, size, size, color);
                        break;
                    case 3:
                        shapes[i] = new Star(x, y, size, color);
                        break;
                }
            }

            // Малювання всіх фігур на PictureBox
            foreach (Shape shape in shapes)
            {
                shape.Draw(graphics);
            }
        }
    }
}
