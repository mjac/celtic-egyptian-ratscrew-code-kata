# Fourth kata session for Celtic Egyptian Ratscrew game

## Problem: complex game workflow
The aim of this kata is to detect violations in play and impose penalties.

By the end of kata3, we got to the point where the game can be played, but anyone could play a card at any time. Also, if you attempted a snap when it wasn't valid, there was no penalty, so you could game it by attempting a snap each time a card was played.

In this kata, your aim is to detect these two violations of play, and impose the following penalties on players who commit them:
* When someone attempts a snap when it's not valid
  * they cannot attempt further snaps (i.e. pressing the snap key does nothing), until someone else successfully snaps. This is called the snapping penalty.
* When someone plays out of turn. 
  * the card they attemped to play is placed at the *bottom* of the stack.
  * they incur the snapping penalty.
* If everyone is barred from snapping, then the game is in a state of deadlock. If this situation occurs, then everyone is released from the snapping penalty so that play may continue.

## Learning objective: extending an existing codebase while maintaining its quality.
For example, as you are doing the kata, consider how many classes the concept of penalties is leaking into. Take note of what parts of the code base are making the task difficult; consider what refactorings could you undertake to improve the situation; which did you actually do and why?

## Tasks
We highly recommend you start by checking out the `kata4-start` branch and working from there. 

Extend the game to do the following (in any order):
* Detect when a player plays out of turn and log it.
  * Place the card they attempted to play at the bottom of the stack.
  * Apply the snapping penalty.
  * Log the penalty.
* Detect when a player snaps invalidly and log it.
  * Apply the snapping penalty to a player.
  * Log the penalty.
  * If all players have a snapping penalty applied to them, then remove all current snapping penalties.
  * Log when the above situation occurs.
