using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace u2_SummativeNolan
{
    class Spaceship : Body
    {
        private const double accel = 0.2;
        private Key upKey, leftKey, rightKey;
        /// <summary>
        /// constructor for space ship.
        /// </summary>
        /// <param name="k"> keys to use in order of left, up, right</param>
        public Spaceship(Key[] k, double size, Point location) : base(location, size, new Uri("images/Spaceship.png",UriKind.Relative))
        {
            // base();
            Console.WriteLine("new spaceship");
            this.leftKey = k[0];
            this.upKey = k[1];
            this.rightKey = k[2];
        }
        public void fly()
        {
            if(Keyboard.IsKeyDown(this.upKey))
            {
                this.addSpeed();
                //Console.WriteLine("upkeypressed");
            }
            if (Keyboard.IsKeyDown(this.leftKey))
            {
                this.Turn(Body.Direction.left);
            }
            if (Keyboard.IsKeyDown(this.rightKey))
            {
                this.Turn(Body.Direction.right);
            }
        }
        public void addSpeed()
        {
            this.setSpeed(this.getSpeed() + new Vector((Spaceship.accel * Math.Cos(this.getAngle()*Math.PI/180)), (Spaceship.accel * Math.Sin(this.getAngle()*Math.PI/180))));
            //Console.WriteLine(this.getSpeed());
        }
        public override void update()
        {
            this.fly();
            base.update();
            this.render();
        }
        private void render()
        {
            TransformGroup tg = new TransformGroup();
            RotateTransform rt = new RotateTransform(this.getAngle()+90, this.getSize() / 2, this.getSize() / 2);
            //TranslateTransform tt = new TranslateTransform(this.getLocation().X, this.getLocation().Y);
            tg.Children.Add(rt);
            //tg.Children.Add(tt);
            //Console.WriteLine("rendering");
            this.getSprite().RenderTransform = tg;
        }
    }
}
