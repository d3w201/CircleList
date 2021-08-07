using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        private static bool _ready;

        static void Main(string[] args)
        {
            Console.WriteLine("r u n");
            _ready = false;
            Task.Run(async () => await AsyncMethod());
            //AsyncMethod().GetAwaiter().OnCompleted(()=>ready = true);
            Console.WriteLine("c o n t i n u e");
            while (_ready != true)
            {
                
            }
            Console.WriteLine("m a i n - e n d");
        }

        private static async Task<int> AsyncMethod()
        {
            Console.WriteLine("s t a r t");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var duration = 3000f;
            
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Task.Yield();
            }
            Console.WriteLine("f i n i s h");
            return 1;
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
