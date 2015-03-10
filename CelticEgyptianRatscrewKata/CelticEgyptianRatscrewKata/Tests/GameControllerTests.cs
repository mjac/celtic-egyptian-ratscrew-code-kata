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

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.PlayCard(playerC);
            gameController.PlayCard(playerD);
            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.AttemptSnap(playerC);

            gameController.PlayCard(playerC);
            gameController.PlayCard(playerD);
            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
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

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.PlayCard(playerC);
            gameController.PlayCard(playerD);
            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
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

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.PlayCard(playerA);
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

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
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

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
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

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.AttemptSnap(playerB);
            gameController.PlayCard(playerA);
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
            var rules = new ICardSnapRule[]
                        {
                            new DarkQueenCardSnapRule(),
                            new SandwichCardSnapRule(),
                            new StandardCardSnapRule()
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