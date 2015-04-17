using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingGameTest
    {
        private Game game;

        [SetUp]
        public void BeforeEach()
        {
            game = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        [Test]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.That(game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void AllOnes()
        {
            RollMany(20, 1);

            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void OneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);

            Assert.That(game.Score(), Is.EqualTo(16));
        }

        [Test]
        public void OneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.That(game.Score(), Is.EqualTo(24));
        }

        [Test]
        public void PerfectGame()
        {
            RollMany(12,10);
            Assert.That(game.Score(), Is.EqualTo(300));
        }

    }
}
