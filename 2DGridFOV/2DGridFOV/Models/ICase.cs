using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models
{
    /// <summary>
    /// Represent the case of a grid
    /// </summary>
    /// <typeparam name="T">Generic type for the case</typeparam>
    public interface ICase<T>
    {
        int Row { get; }
        int Column { get; }
        T Value { get; }
    }
}
