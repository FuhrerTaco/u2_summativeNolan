using System;
using System.Windows;
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
        private double speed;
        Rect boundingBox;
        Rectangle sprite;
        public Body(Point loc,double size, Uri image )
        {
            this.speed = 0;
            this.angle = 0;
            this.location = loc;
            this.sprite.Fill =new ImageBrush(new BitmapImage(image));
            Console.WriteLine("new body");
        }
        public void Turn(Direction d)
        {

        }
        public bool collisionCheck(Body b)
        {
            return false;
        }
    }
}