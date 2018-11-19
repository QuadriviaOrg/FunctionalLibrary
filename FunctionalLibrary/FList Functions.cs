using System;
using System.Linq;

namespace Quadrivia.FunctionalLibrary
{
    // Static class that provides functions that apply to FList<T>
    public static class FList
    {
        #region Constructing lists
        /// <summary>
        /// Construct an empty list of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FList<T> Empty<T>()
        {
            return new FList<T>();
        }
        /// <summary>
        /// Construct a list from a head and tail. If head param is null returns the Tail only
        /// </summary>
        public static FList<T> New<T>(T head, FList<T> tail)
        {
            return tail == null || IsEmpty(tail) ?
                New(head)
                : new FList<T>(head, tail);
        }
        /// <summary>
        /// Construct a list from a head only
        /// </summary>
        public static FList<T> New<T>(T head)
        {
            return head == null ?
                Empty<T>()
                : new FList<T>(head, Empty<T>());
        }

        /// <summary>
        /// Construct a list from a set of values as separate arguments
        /// </summary>
        public static FList<T> New<T>(params T[] items)
        {
            return items == null || items.Length == 0 ?
                Empty<T>()
                : items.Length == 1 ?
                    New(items[0]) :
                    New(items[0], New(items.Skip(1).ToArray()));
        }
        #endregion

        #region Head, Tail, Init, Last 

        /// <summary>
        /// Returns true if list is empty.
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static bool IsEmpty<T>(FList<T> list)
        {
            return list == null ? throw new Exception("Null being passed in place of an FList.") : list.Empty;
        }

        /// <summary>
        /// Returns number of elements in the list.
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static int Length<T>(FList<T> list)
        {
            return IsEmpty(list) ?
                    0
                    : 1 + Length(Tail(list));
        }

        /// <summary>
        /// Returns the 'head' i.e. the first element in the list
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static T Head<T>(FList<T> list)
        {
            return IsEmpty(list) ? throw new EmptyListException() : list.Head;
        }

        /// <summary>
        /// Returns the 'tail' i.e. the list minus its head
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static FList<T> Tail<T>(FList<T> list)
        {
            return IsEmpty(list) ?
                throw new EmptyListException()
                : list.Tail;
        }

        /// <summary>
        /// Returns the last element in the list.
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static T Last<T>(FList<T> list)
        {
            return Length(list) == 1 ?
                     Head(list)
                     : Last(Tail(list));
        }

        /// <summary>
        /// Returns the list except for the last element
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static FList<T> Init<T>(FList<T> list)
        {
            return IsEmpty(Tail(list)) ?
                Empty<T>()
                : New(Head(list), Init(Tail(list)));
        }
        #endregion

        #region Query methods (don't return a list)
        /// <summary>
        /// Returns true if the list contains an element equal to the first argument
        /// </summary>
        /// <param name="list">Must not be null</param>
        public static bool Elem<T>(T elem, FList<T> list)
        {
            return IsEmpty(list) ?
                false
                : list.Head.Equals(elem) ?
                    true
                    : Elem(elem, Tail(list));
        }
        #endregion

        #region Simple functions to 'modify' a list (actually, make a new one)
        /// <summary>
        /// Returns a new list made from the item as the head and the passed-in list as the tail.
        /// </summary>
        public static FList<T> Prepend<T>(T item, FList<T> list)
        {
            return new FList<T>(item, list);
        }

        /// <summary>
        /// Creates a new list based on the old list, with the toAppend list appended to the end.
        /// </summary>
        public static FList<T> Append<T>(FList<T> inputList, FList<T> toAppend)
        {
            return IsEmpty(inputList) ?
                toAppend
                : New(inputList.Head, Append(Tail(inputList), toAppend));
        }

        // Remove first occurrence of item (if any) from list
        public static FList<T> RemoveFirst<T>(T item, FList<T> list)
        {
            return IsEmpty(list) ?
                list
                : Head(list).Equals(item) ?
                    Tail(list)
                    : New(Head(list), FList.RemoveFirst(item, Tail(list)));
        }

        //Remove all occurrences of item from list
        public static FList<T> RemoveAll<T>(T item, FList<T> list)
        {
            return list.Empty ?
                list
                : Head(list).Equals(item) ?
                    RemoveAll(item, Tail(list))
                    : New(Head(list), FList.RemoveAll(item, Tail(list)));
        }

        public static FList<T> Drop<T>(int number, FList<T> list)
        {
            return number <= 0 || IsEmpty(list) ?
                 list
                 : number == 1 ?
                    Tail(list)
                    : Drop(number - 1, Tail(list));
        }

        public static FList<T> Take<T>(int n, FList<T> list)
        {
            return n <= 0 || IsEmpty(list) ?
                FList.Empty<T>()
                : n == 1 ?
                    FList.New(Head(list))
                    : FList.New(Head(list), Take(n - 1, Tail(list)));
        }

        public static FList<T> Reverse<T>(FList<T> list)
        {
            return IsEmpty(list) ?
                list
                : FList.New(Last(list), Reverse(Init(list)));
        }
        #endregion

        #region Higher-order functions: Map, Filter, Reduce, Any
        public static bool Any<T>(Func<T, bool> f, FList<T> list)
        {
            return !IsEmpty(Filter(f, list));
        }

        public static FList<T> Filter<T>(Func<T, bool> func, FList<T> list)
        {
            return list.Empty ?
                list
                : func(list.Head) ?
                        New(Head(list), Filter(func, Tail(list))) :
                        Filter(func, Tail(list));
        }

        public static FList<U> Map<T, U>(Func<T, U> f, FList<T> list)
        {
            return IsEmpty(list) ?
                      Empty<U>()
                        : IsEmpty(Tail(list)) ?
                        f(list.Head) != null ?
                            New<U>(f(list.Head))
                            : Empty<U>()
                        : f(list.Head) != null ?
                            New<U>(f(list.Head), Map(f, list.Tail))
                            : Map(f, list.Tail);
        }

        public static T FoldL<T>(Func<T, T, T> f, T start, FList<T> list)
        {
            return IsEmpty(list) ?
                start
                : IsEmpty(Tail(list)) ?
                    f(start, Head(list))
                    : FoldL(f, f(start, Last(list)), Init(list));
        }

        public static T FoldR<T>(Func<T, T, T> f, T start, FList<T> list)
        {
            return list.Empty ?
                start
                : list.Tail.Empty ?
                    f(list.Head, start)
                    : FoldR(f, f(list.Head, start), list.Tail);
        }

        #endregion

        #region Sorting
        /// <summary>
        /// Sorts an FList, using a function that compares any pair of elements
        /// Uses the Merge Sort algorithm.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="f">Function for comparing elements, returning true if the first should be placed before the second</param>
        /// <param name="list"></param>
        /// <returns>A new FList, sorted</returns>
        public static FList<T> SortBy<T>(Func<T, T, bool> f, FList<T> list)
        {
            return Length(list) < 2 ?
                    list :
                    Merge(SortBy(f, LeftHalf(list)), SortBy(f, RightHalf(list)), f);
        }

        private static FList<T> LeftHalf<T>(FList<T> list)
        {
            return Drop(FList.Length(list) / 2, list);
        }

        private static FList<T> RightHalf<T>(FList<T> list)
        {
            return Take(Length(list) / 2, list);
        }

        private static FList<T> Merge<T>(FList<T> a, FList<T> b, Func<T, T, bool> f)
        {
            return a.Empty ?
                b :
                b.Empty ?
                    a :
                    f(a.Head, b.Head) ?
                        new FList<T>(a.Head, Merge(a.Tail, b, f)) :
                        new FList<T>(b.Head, Merge(a, b.Tail, f));
        }

        public static FList<T> Sort<T>(FList<T> list, bool descending = false) where T : IComparable
        {
            return descending? SortBy(InverseDefaultCompare, list) : SortBy(DefaultCompare, list);
        }

        private static bool DefaultCompare<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) <= 0;
        }

        private static bool InverseDefaultCompare<T>(T a, T b) where T : IComparable
        {
            return b.CompareTo(a) <= 0;
        }
        #endregion
    }
}
