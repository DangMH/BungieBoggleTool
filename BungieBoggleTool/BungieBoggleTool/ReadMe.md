BungieBoggleTool
================
GOAL
----------------
Write a program which will find all the words on a generalized Boggle™ board.  It should take as input
the board dimensions and the board, and should load a dictionary of valid words (shared for all users).
It should output the list of all found words. You should consider how your approach will perform with a
large dictionary and a large board.

If you've never heard of Boggle then see http://en.wikipedia.org/wiki/Boggle for a better description
than I can write.  A 3x3 boggle board that looks like this:

    y o x
    r b a
    v e d

Has exactly the following words on it (according to my program):

	bred, yore, byre, abed, oread, bore, orby, robed, broad, byroad, robe
	bored, derby, bade, aero, read, orbed, verb, aery, bead, bread, very, road

Note that it doesn't have “robbed” or “robber” because that would require reusing some letters to form
the word.  And it doesn’t have “board” or “dove” because that would require using letters which aren’t
neighbors.

Use the program you’ve created! 

Write a suite of automated tests to be run against the program you created, then generate a report of
passed and failed cases. Be sure to include enough information in the reports that you could follow up
effectively on the issues.  Why did you choose to automate what you did?  How do you provide information
from failures that’s easily debuggable?

SOLUTION
----------------
###Files

- **sowpods.txt**: [Europe Scrabble Word List](http://www.freescrabbledictionary.com/sowpods.txt).
- **BungieBoggleTool.cd**: Class diagram of the console application.
- **BungieBoggleTool.cs**: Main file containing console application.
- **Dictionary.cs**: Class representing the dictionary list of words to check against.
- **BoggleGrid.cs**: Class representing the Boggle Grid.
- **Letter.cs**: Class representing the Boggle Block.

###Approach
Essentially the problem has two parts:

1.  **Finding the possible string combinations among the grid.**  
    For this portion I decided that the best approach would be a *depth-first search*.  Since it is a
graph and we cannot double over traversed nodes, *DFS* would be the fastest approach.  *DFS* also allows
for failing fast.  If we start a search, every iteration can be treated as a prefix that can be
verified against the **Dictionary** (The **Dictionary** will contain the possible prefixes according the the
of words as well).

2.  **Checking string combinations against a list.**  
    For this portion I decided to create a **Dictionary** class that will contain a **Set** of *words* and
*possible pre-fixes*.  I chose **Set**'s because I do not care about duplicates.  The class also constructs
against both the file of words as well as the grid instance, as we only care about *possible words* (we rule
out any words that contain letters not found in the grid).

###Pros
- **Extensible**: Dictionaries can be swapped out by simply changing the file.  Object-oriented design means that
different algorithms can be implemented by subclassing the appropriate classes.
- **Agile**: After populating a full dictionary without a grid, subsequent grids can be checked against the
Dictionary at will.  Pre-fix and word lookup are *O(1)* expected with HashSets.
- **Scalable**: **HashSet**'s and **Dictionary< Tkey, TValue >**'s are implemented with large scalability in mind
while maintaining expected *O(1)* time lookup.  Also, unlike **Array**'s, they are usually stored in non-continguous
memory, meaning they are not as expensive to resize larger.
- **Automatable**: With the framework provided, the solution is easy to automate.  **BoggleGrid**'s can generate boards
at will and swapping dictionaries is a simple matter.

###Cons
- **Expensive**: Requires time to process the dictionary and its pre-fixes before checking against string combinations.
- **Slow Construction**:  Construction of the objects (**Dictionary** specifically) takes time as they require File IO.

TESTING
----------------
*TBD*