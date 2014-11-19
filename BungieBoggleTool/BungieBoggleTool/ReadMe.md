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
- sowpods.txt: [Europe Scrabble Word List](http://www.freescrabbledictionary.com/sowpods.txt)
- Progam.cs: Main file containing console application