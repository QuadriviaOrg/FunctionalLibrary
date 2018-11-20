# FunctionalLibrary

Release 2.0 of the NuGet package changes the location, and improves the design of the Sort and Random functionality (previously undocumented)- see below.

Library containing implementation of a functional list and supporting functions, that mimic behaviour of lists and related functions in Haskell. Also, pseudo random number generation, adhering to the 'no side-effects' rules of functional prorgamming.

Install package and add:

using Quadrivia.FunctionalLibrary;

All list-related accessed via FList e.g.

var list = FList.New(1,2,3,4,5);

var h = FList.Head(list);

var list2 = FList.Prepend(0, list);


Functions include:

Query functions:

Head, Tail, Init, Last

Modification functions (all return new list):

Prepend, Append, Take, Drop, Reverse, RemoveFirst, RemoveAll

Higher order functions:

Map, Filter, FoldL, FoldR (reduce), Any, 

Sorting:

SortBy, Sort

Random Numbers:

All random number functionality is accessed via FRandom.  The process can be seeded with:

FRandom.SeedDefault, FRandom.Seed, FRandom.SeedFromClock  (passing in DateTime.Now typically)

All functions return an FRandom object, which contains the generated Number, plus (hidden) the two new seed values derived from the original.

Subsequent numbers are generated using FRandom.Next, passing in the previously-generated FRandom result as the first argument.
