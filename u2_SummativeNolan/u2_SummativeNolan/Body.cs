using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace u2_SummativeNolan
{
    class Body
    {
        public enum Direction { left, right};
        private Point location;
        private double angle;
        private Vector speed;
        Rect boundingBox;
        Rectangle sprite;
        Window w;
        Canvas c;
        double borderHeight = SystemParameters.PrimaryScreenHeight;
        double borderWidth = SystemParameters.PrimaryScreenWidth;
        public Body(Point loc,double size, Uri image )
        {
            this.w = new Window();
            this.c = new Canvas();
            this.speed = new Vector();
            this.angle = 0;
            this.location = loc;
            this.sprite = new Rectangle();
            this.boundingBox.Width = size;
            this.boundingBox.Height = size;
            this.sprite.Width = size;
            this.sprite.Height = size;
            this.sprite.Fill =new ImageBrush(new BitmapImage(image));
            Console.WriteLine("new body");

            w.Width = 23;
            w.Height = 23;
            w.BorderThickness = new Thickness(0);
            w.WindowStyle = WindowStyle.None;
            c.Children.Add(this.getSprite());
            w.AllowsTransparency = true;
            w.Background = Brushes.Transparent;
            w.Topmost = true;
            w.Show();
        }
        public void Turn(Direction d)
        {
            switch(d)
            {
                case Direction.left:
                    this.angle -= 5;
                    break;
                case Direction.right:
                    this.angle += 5;
                    break;
                default:
                    break;
            }
        }
        public bool collisionCheck(Body b)
        {
            //Console.WriteLine(this.boundingBox.X + ", " + this.boundingBox.Y);
            return ! (this.boundingBox.X > b.boundingBox.X + b.boundingBox.Width
                || this.boundingBox.X + this.boundingBox.Width < b.boundingBox.X
                || this.boundingBox.Y > b.boundingBox.Y + b.boundingBox.Height
                || this.boundingBox.Y + this.boundingBox.Height < b.boundingBox.Y);
        }
        public Rectangle getSprite()
        {
            return this.sprite;
        }
        public Point getLocation()
        {
            return this.location;
        }
        public Vector getSpeed()
        {
            return this.speed;
        }
        public void setSpeed(Vector v)
        {
            this.speed = v;
        }
        public double getAngle()
        {
            return this.angle;
        }
        public double getSize()
        {
            return this.sprite.Width;
        }
        public virtual void update()
        {
            //Console.WriteLine(this.boundingBox.X + ", " + this.boundingBox.Y);
            if (this.location.X > borderWidth) this.location.X = 0;
            if (this.location.X < 0) this.location.X = borderWidth-1;
            if (this.location.Y > borderHeight) this.location.Y = 1;
            if (this.location.Y < 0) this.location.Y = borderHeight-1;

            this.location = Point.Add(this.location, speed);
            this.boundingBox.X = this.location.X;
            this.boundingBox.Y = this.location.Y;

            w.Left = this.getLocation().X;
            w.Top = this.getLocation().Y;
            w.Content = c;
            //w.Topmost = true;
        }
    }
}