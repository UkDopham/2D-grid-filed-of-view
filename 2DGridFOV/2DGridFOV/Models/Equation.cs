using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models
{
    /// <summary>
    /// Class which represent the equation
    /// </summary>
    public class Equation
    {
        private float _m;
        private float _b;

        public float M
        {
            get
            {
                return this._m;
            }
        }
        public float B
        {
            get
            {
                return this._b;
            }
        }
        public Equation(float m, float b)
        {
            this._m = m;
            this._b = b;
        }
        /// <summary>
        /// from coordinate
        /// </summary>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        public Equation(int[] a, int[] b)
        {
            int dx = b[0] - a[0];
            int dy = b[1] - a[1];
            this._m = dx == 0 ? 0 : (float)dy / (float)dx; // y = mx + b
            this._b = a[1] - this._m*a[0]; //b = y - mx
        }

        public int GetXValue(int y) // y = mx + b => x = (y - b)/m
        {
            return (int)((y - this._b) / this._m);
        }
        public int GetYValue(int x)
        {
            return (int)(this._m * x + this._b);
        }

        public override string ToString()
        {
            return $"y = {this._m}x + {this._b}";
        }
    }
}
