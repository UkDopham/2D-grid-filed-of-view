using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models
{
    /// <summary>
    /// Component which represent the grid
    /// </summary>
    /// <typeparam name="T">generic type for the cases of the grid</typeparam>
    public class Grid<T> : IGrid
    {
        private ICase<T>[,] _content;
        public ICase<T>[,] Content
        {
            get
            {
                return this._content;
            }
        }

        public Grid(int size)
        {
            this._content = new ICase<T>[size, size];
        }

        public override string ToString()
        {
            string output = string.Empty;

            for(int row = 0; 
                row < this._content.GetLength(0);
                row ++)
            {
                for(int column = 0;
                    column < this._content.GetLength(1);
                    column ++)
                {
                    output += $"{this._content[row, column]}|";
                }
                output += '\n';
            }
            return output;
        }
    }
}
