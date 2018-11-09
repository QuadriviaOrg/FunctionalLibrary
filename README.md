# FunctionalLibrary
Library containing implementation of a functional list and supporting functions, that mimic behaviour of lists and related functions in Haskell.

Install package and add:

using Quadrivia.FunctionalLibrary;

Everything is then accessed via FList e.g.

var myList = FList.New(1,2,3,4,5);

var h = FList.Head(list);

var list2 = FList.Prepend(0, list);
