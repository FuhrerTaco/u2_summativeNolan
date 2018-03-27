using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace u2_SummativeNolan
{
    class Spaceship : Body
    {
        private const double accel = 3;
        private Key upKey, leftKey, rightKey;
        /// <summary>
        /// constructor for space ship.
        /// </summary>
        /// <param name="k"> keys to use in order of left, up, right</param>
        public Spaceship(Key[] k, double size, Point location) : base(location, size, new Uri("//images/Spaceship.png"))
        {
            // base();
            Console.WriteLine("new spaceship");
            this.leftKey = k[0];
            this.upKey = k[1];
            this.rightKey = k[2];
        }
    }
}
