using System;
using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class GameControllerTests
    {
        [Test]
        public void RedRouteWinnerAfterSomeRoundsOfPlay()
        {
            // Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var playerC = new Player("playerC");
            var playerD = new Player("playerD");
            var deck = CreateNewSimpleDeck();

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.AddPlayer(playerC);
            gameController.AddPlayer(playerD);
            gameController.StartGame(deck);

            Card card;
            gameController.TakeTurn(playerA, out card);
            Card temp = card;
            Card card1;
            gameController.TakeTurn(playerB, out card1);
            Card temp1 = card1;
            Card card2;
            gameController.TakeTurn(playerC, out card2);
            Card temp2 = card2;
            Card card3;
            gameController.TakeTurn(playerD, out card3);
            Card temp3 = card3;
            Card card4;
            gameController.TakeTurn(playerA, out card4);
            Card temp4 = card4;
            Card card5;
            gameController.TakeTurn(playerB, out card5);
            Card temp5 = card5;
            gameController.AttemptSnap(playerC);

            Card card6;
            gameController.TakeTurn(playerC, out card6);
            Card temp6 = card6;
            Card card7;
            gameController.TakeTurn(playerD, out card7);
            Card temp7 = card7;
            Card card8;
            gameController.TakeTurn(playerA, out card8);
            Card temp8 = card8;
            Card card9;
            gameController.TakeTurn(playerB, out card9);
            Card temp9 = card9;
            gameController.AttemptSnap(playerC);

            // Assert
            IPlayer winner;
            var hasWinner = gameController.TryGetWinner(out winner);
            Assert.True(hasWinner);
            Assert.That(winner.Name, Is.EqualTo(playerC.Name));
        }

        [Test]
        public void RedRouteNoWinnerAfterSomeRoundsOfPlay()
        {
            // Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var playerC = new Player("playerC");
            var playerD = new Player("playerD");
            var deck = CreateNewSimpleDeck();

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.AddPlayer(playerC);
            gameController.AddPlayer(playerD);
            gameController.StartGame(deck);

            Card card;
            gameController.TakeTurn(playerA, out card);
            Card temp = card;
            Card card1;
            gameController.TakeTurn(playerB, out card1);
            Card temp1 = card1;
            Card card2;
            gameController.TakeTurn(playerC, out card2);
            Card temp2 = card2;
            Card card3;
            gameController.TakeTurn(playerD, out card3);
            Card temp3 = card3;
            Card card4;
            gameController.TakeTurn(playerA, out card4);
            Card temp4 = card4;
            Card card5;
            gameController.TakeTurn(playerB, out card5);
            Card temp5 = card5;
            gameController.AttemptSnap(playerC);

            // Assert
            IPlayer potentialWinner;
            var hasWinner = gameController.TryGetWinner(out potentialWinner);
            Assert.False(hasWinner);
        }

        [Test]
        public void SnapWins()
        {
            // Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var deck = Cards.With(
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Diamonds, Rank.Three),
                new Card(Suit.Spades, Rank.Queen)
                );

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.StartGame(deck);

            Card card;
            gameController.TakeTurn(playerA, out card);
            Card temp = card;
            Card card1;
            gameController.TakeTurn(playerB, out card1);
            Card temp1 = card1;
            Card card2;
            gameController.TakeTurn(playerA, out card2);
            Card temp2 = card2;
            gameController.AttemptSnap(playerA);

            // Assert
            IPlayer potentialWinner;
            var hasWinner = gameController.TryGetWinner(out potentialWinner);
            Assert.True(hasWinner);
        }

        [Test]
        public void SnapAtWrongTime()
        {
            // Arrange
            var gameController = CreateLoggedGameController();

            var playerA = new Player("playerA");
            var playerB = new Player("playerB");

            var deck = Cards.With(
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Diamonds, Rank.Three),
                new Card(Suit.Spades, Rank.Queen)
                );

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.StartGame(deck);

            Card card;
            gameController.TakeTurn(playerA, out card);
            Card temp = card;
            Card card1;
            gameController.TakeTurn(playerB, out card1);
            Card temp1 = card1;
            var hasSnapped = gameController.AttemptSnap(playerA);

            // Assert
            Assert.That(hasSnapped, Is.False);
            Assert.That(playerA.HasPenalty, Is.True);
        }

        [Test]
        public void BothSnapAtWrongTimeRemovesPenalties()
        {
            // Arrange
            var gameController = CreateLoggedGameController();

            var playerA = new Player("playerA");
            var playerB = new Player("playerB");

            var deck = Cards.With(
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Diamonds, Rank.Three),
                new Card(Suit.Spades, Rank.Queen)
                );

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.StartGame(deck);

            Card card;
            gameController.TakeTurn(playerA, out card);
            Card temp = card;
            Card card1;
            gameController.TakeTurn(playerB, out card1);
            Card temp1 = card1;
            gameController.AttemptSnap(playerA);
            gameController.AttemptSnap(playerB);

            // Assert
            Assert.That(playerA.HasPenalty, Is.False);
            Assert.That(playerB.HasPenalty, Is.False);
        }

        [Test]
        public void SnapWithPenaltyFails()
        {
            // Arrange
            var gameController = CreateLoggedGameController();

            var playerA = new Player("playerA");
            var playerB = new Player("playerB");

            var deck = Cards.With(
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Diamonds, Rank.Three),
                new Card(Suit.Spades, Rank.Queen)
                );

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.StartGame(deck);

            Card card;
            gameController.TakeTurn(playerA, out card);
            Card temp = card;
            Card card1;
            gameController.TakeTurn(playerB, out card1);
            Card temp1 = card1;
            gameController.AttemptSnap(playerB);
            Card card2;
            gameController.TakeTurn(playerA, out card2);
            Card temp2 = card2;
            var hasSnapped = gameController.AttemptSnap(playerB);

            // Assert
            Assert.That(playerB.HasPenalty, Is.True);
            Assert.False(hasSnapped);
        }

        private static IGameController CreateLoggedGameController()
        {
            IGameController gameController = CreateGameController();
            gameController = new LoggedGameController(gameController, new ConsoleLog());
            return gameController;
        }

        private static GameController CreateGameController()
        {
            var gameState = new GameState();
            var completeSnapValidator = CreateCompleteSnapValidator();
            var dealer = new Dealer();
            var noneShufflingShuffler = new NoneShufflingShuffler();

            return new GameController(gameState, completeSnapValidator, dealer, noneShufflingShuffler);
        }

        private static ISnapValidator CreateCompleteSnapValidator()
        {
            var rules = new ISnapRule[]
                        {
                            new DarkQueenSnapRule(),
                            new SandwichSnapRule(),
                            new StandardSnapRule()
                        };
            return new SnapValidator(rules);
        }

        public static Cards CreateNewSimpleDeck()
        {
            return Cards.With(
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Diamonds, Rank.Three),
                new Card(Suit.Clubs, Rank.Five),
                new Card(Suit.Clubs, Rank.Four),
                new Card(Suit.Clubs, Rank.Six),
                new Card(Suit.Diamonds, Rank.Seven),
                new Card(Suit.Clubs, Rank.Eight),
                new Card(Suit.Clubs, Rank.Seven),
                new Card(Suit.Clubs, Rank.Ten),
                new Card(Suit.Clubs, Rank.Nine)
                );
        }
    }

    public class NoneShufflingShuffler : IShuffler
    {
        public Cards Shuffle(Cards deck)
        {
            return new Cards(deck);
        }
    }
    public class ConsoleLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}