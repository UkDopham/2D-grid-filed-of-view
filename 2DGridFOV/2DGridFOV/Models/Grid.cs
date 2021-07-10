using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models
{
    public class Grid<T> : IGrid
    {
        private T[,] _content;
        public T[,] Content
        {
            get
            {
                return this._content;
            }
        }

        public Grid(int size)
        {
            this._content = new T[size, size];
        }
    }
}
