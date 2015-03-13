# Fifth kata session for Celtic Egyptian Ratscrew game

## Problem: extending the snap rules
The aim of this kata is to add the calling out rule. It works like this: each player, when they lay a card, calls out a rank. The first player calls "ace", the next "two" and so until "king", after which the next player calls "ace" and the sequence repeats. If the rank called out is the same as the rank of the card laid, then this makes a valid snap. The snap is valid until the next player lays a card.

## Learning objective: introducing a new implementation of an interface.
The problem we have here is that the new rule requires more information than is currently conveyed by the `IRule` interface. The question is how to introduce this new information? Two immediate things you might consider could be 
* passing the additional information to the `CanSnap` method
* adding the information to to the `Stack` class
but both are a bit hacky - consider how the method parameters could grow if yet more complex rules were added.
So the aim is to find a better way.

## Tasks
We highly recommend you start by checking out the `kata5-start` branch and working from there. 

Don't forget that you're welcome to refactor any part of the code as you see fit.

Here are the tasks we suggest to tackle. Feel free to undertake them in any reasonable order. 
* Automatically generate the rank that is called on each turn (players don't have to call out the rank themselves)
* Log the called out rank
* Decide how to pass the current called out rank to the calling out rule
* Implement the calling out rule
* Add the rule to the game

There are bonus points for writing tests that assure us that the calling out rule is working correctly in the game. What is the simplest, most minimal set of tests that will do?