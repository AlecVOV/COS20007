using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApplication
{
    public class IntegerQueue
    {
        public List<int> _elements;

        public IntegerQueue()
        {
            _elements = new List<int>();
        }

        public int Count 
        {
            get
            { 
                return _elements.Count; 
            }
        }
        public void Enqueue(int value)
        {
            _elements.Add(value); //insert at end
        }

        public int Dequeue()
        {
            int result = _elements[0]; //remove at front
            _elements.RemoveAt(0);
            return result;
        }
    }
}
