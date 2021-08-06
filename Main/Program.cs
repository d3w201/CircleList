using System;
using System.Collections.Generic;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("New Circular List");
            var circle = new CircularList<int>
            {
                0,
                1,
                2
            };
            Console.WriteLine(circle.Current);
            Console.WriteLine(circle.MoveNext);
            Console.WriteLine(circle.MovePrevious);
            Console.WriteLine(circle.MoveNext);
            Console.WriteLine(circle.MoveNext);
            Console.WriteLine(circle.MoveNext);
            Console.WriteLine(circle.NextIndex);
            Console.WriteLine(circle.CurrentIndex);
            Console.WriteLine(circle.MoveNext);
            Console.WriteLine(circle.PreviousIndex);
        }
        
        private class CircularList<T> : List<T>
        {
            private int _currentIndex = 0;
            public int CurrentIndex
            {
                get
                {
                    if (_currentIndex > Count - 1) { _currentIndex = 0; }
                    if (_currentIndex < 0) { _currentIndex = Count - 1; }
                    return _currentIndex;
                }
                set => _currentIndex = value;
            }
            
            public int NextIndex
            {
                get
                {
                    if (_currentIndex == Count - 1) return 0;
                    return _currentIndex + 1;
                }
            }
            
            public int PreviousIndex
            {
                get
                {
                    if (_currentIndex == 0) return Count - 1;
                    return _currentIndex - 1;
                }
            }
            
            public T Next => this[NextIndex];

            public T Previous => this[PreviousIndex];

            public T MoveNext
            {
                get { _currentIndex++; return this[CurrentIndex]; }
            }

            public T MovePrevious
            {
                get { _currentIndex--; return this[CurrentIndex]; }
            }

            public T Current => this[CurrentIndex];
            
            
        }
    }
}
