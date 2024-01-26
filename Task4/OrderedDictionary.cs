using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class OrderedDictionary<T, U> : IEnumerator, IEnumerable, IComparer<T>
    {
        private DictionaryNode<T, U> root;
        private IComparer<T> _comparer;


        public OrderedDictionary(DictionaryNode<T, U> root)
        {
            this.root = root;
            _comparer = Comparer<T>.Default;
        }
        public OrderedDictionary(T rootKay, U rootValue )
        {
            DictionaryNode<T, U> root = new DictionaryNode<T, U>(rootKay, rootValue );
            this.root = root;
            _comparer = Comparer<T>.Default;
        }
        public OrderedDictionary(DictionaryNode<T, U> root, IComparer<T> comparer)
        {
            this.root = root;
            _comparer = comparer;
        }
        public void Add(T key, U value)
        {
            DictionaryNode<T, U> currentNode = root;
            while (true)
            {
                if (_comparer.Compare(key, currentNode.Key) > 0)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new DictionaryNode<T, U>(key, value);
                        break;
                    }
                    currentNode = currentNode.Right;
                }
                else if (_comparer.Compare(key, currentNode.Key) < 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new DictionaryNode<T, U>(key, value);
                        break;
                    }
                    currentNode = currentNode.Left;
                }
                else
                {
                    throw new ArgumentException("Element with such key already exist");
                }
            }
        }

        public void Add(KeyValuePair<T, U> item) => Add(item.Key, item.Value);

        #region elments for IEnumerable

        private DictionaryNode<T, U> current;
        public DictionaryNode<T, U> Current
        {
            get
            {
                current = nodesToMoveStack.Pop();
                return current;
            }
            set
            {
                current = value;
            }
        }
        object IEnumerator.Current => Current;


        private Stack<DictionaryNode<T, U>> nodesToMoveStack = new Stack<DictionaryNode<T, U>>();
        private Stack<DictionaryNode<T, U>> branchings = new Stack<DictionaryNode<T, U>>();
        public bool MoveNext()
        {
            if (!nodesToMoveStack.Any() && current == null)
            {
                current = root;
                branchings.Push(current);
                nodesToMoveStack.Push(current);
                while (current.Left != null)
                {
                    if (current.Right != null)
                    {
                        branchings.Push(current);
                    }
                    current = current.Left;
                    nodesToMoveStack.Push(current);
                }
            }
            if (current == branchings.Peek())
            {
                current = current.Right;
                branchings.Pop();
                nodesToMoveStack.Push(current);
                while (current.Left != null)
                {
                    if (current.Right != null)
                    {
                        branchings.Push(current);
                    }
                    current = current.Left;
                    nodesToMoveStack.Push(current);
                }
            }
            if (nodesToMoveStack.Any())
            {
                return true;
            }
            else
            {
                Reset();
                return false;
            }

        }

        public void Reset()
        {
            current = null;
            nodesToMoveStack = new Stack<DictionaryNode<T, U>>();
            branchings = new Stack<DictionaryNode<T, U>>();
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        #endregion

        public int Compare(T? x, T? y)
        {
            return _comparer.Compare(x, y);
        }

        public class DictionaryNode<T, U>
        {
            public DictionaryNode<T, U> Right { get; set; }
            public DictionaryNode<T, U> Left { get; set; }
            public T Key { get; set; }
            public U Value { get; set; }
            public DictionaryNode(T key, U value)
            {
                Key = key;
                Value = value;
            }
            public override string ToString()
            {
                return $"{Key.ToString()}: {Value.ToString()}";
            }
        }

    }
}
