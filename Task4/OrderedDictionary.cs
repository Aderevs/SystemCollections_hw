using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class OrderedDictionary<T, U> : IEnumerator, IEnumerable, IComparer<T>
    {
        private DictionaryNode<T, U> root;
        private IComparer<T> _comparer;
        private List<DictionaryNode<T, U>> elementsOrderedByAdding = new List<DictionaryNode<T, U>>();
        public OrderedDictionary()
        {
            _comparer = Comparer<T>.Default;
        }
        public OrderedDictionary(DictionaryNode<T, U> root)
        {
            this.root = root;
            elementsOrderedByAdding.Add(root);
            _comparer = Comparer<T>.Default;
        }
        public OrderedDictionary(T rootKay, U rootValue) 
        {
            DictionaryNode<T, U> root = new DictionaryNode<T, U>(rootKay, rootValue);
            this.root = root;
            elementsOrderedByAdding.Add(root);
            _comparer = Comparer<T>.Default;
        }
        public OrderedDictionary(DictionaryNode<T, U> root, IComparer<T> comparer)
        {
            this.root = root;
            elementsOrderedByAdding.Add(root);
            _comparer = comparer;
        }
        public void Add(T key, U value)
        {
            if (root != null)
            {
                DictionaryNode<T, U> currentNode = root;
                while (true)
                {
                    if (_comparer.Compare(key, currentNode.Key) > 0)
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = new DictionaryNode<T, U>(key, value);
                            elementsOrderedByAdding.Add(currentNode.Right);
                            break;
                        }
                        currentNode = currentNode.Right;
                    }
                    else if (_comparer.Compare(key, currentNode.Key) < 0)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = new DictionaryNode<T, U>(key, value);
                            elementsOrderedByAdding.Add(currentNode.Left);
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
            else
            {
                root = new DictionaryNode<T, U>(key, value);
                elementsOrderedByAdding.Add(root);
            }
        }
        public void Add(KeyValuePair<T, U> item) => Add(item.Key, item.Value);

        public void RemoveWithKey(T key)
        {
            OrderedDictionary<T, U> newDictionary = new OrderedDictionary<T, U>();
            foreach (DictionaryNode<T, U> item in elementsOrderedByAdding)
            {
                if (!item.Key.Equals(key))
                {
                    newDictionary.Add(item.Key, item.Value);
                }
            }
            root = null;
            foreach (KeyValuePair<T, U> item in newDictionary.elementsOrderedByAdding)
            {
                Add(item.Key, item.Value);
            }
        }

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
            if (branchings.Any() && current == branchings.Peek())
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
            public static implicit operator KeyValuePair<T, U>(DictionaryNode<T, U> node)
            {
                return new KeyValuePair<T, U> (node.Key, node.Value);
            }
        }

    }
}
