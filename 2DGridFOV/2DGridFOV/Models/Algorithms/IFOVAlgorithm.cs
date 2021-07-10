using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models.Algorithms
{
    public interface IFOVAlgorithm<T>
    {
        public ICase<T>[] GetPath(ICase<T> startingCase, ICase<T> endingCase, IGrid<T> grid);
    }
}
