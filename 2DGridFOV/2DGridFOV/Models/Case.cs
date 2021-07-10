using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models
{
    /// <summary>
    /// Implement the ICase interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Case<T> : ICase<T>
    {
        private int _row;
        private int _column;
        private T _value;
        public int Row
        {
            get
            {
                return this._row;
            }
        }

        public int Column
        {
            get
            {
                return this._column;
            }
        }

        public T Value
        {
            get
            {
                return this._value;
            }
        }

        public Case(int row, int column, T value)
        {
            this._row = row;
            this._column = column;
            this._value = value;
        }

        public override string ToString()
        {
            return $"[{this._row};{this.Column}] : {this._value}";
        }
    }
}
