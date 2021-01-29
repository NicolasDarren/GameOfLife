using System.Linq;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class TestSimulation
    {
        [TestFixture]
        public class AddCell
        {
            [Test]
            public void ShouldHaveCellsAtPosition()
            {
                // Arrange
                var sut = CreateSut();
                var expectedX = 3;
                var expectedY = 4;

                sut.AddCell(expectedX, expectedY);
                // Act
                var cell = sut.GetCell(expectedX, expectedY);

                // Assert
                Assert.AreEqual(expectedX, cell.X);
                Assert.AreEqual(expectedY, cell.Y);
            }
        }

        [TestFixture]
        public class CreateSeed
        {
            [Test]
            public void ShouldCreateLivingCellsAroundSeed()
            {
                // Arrange
                var sut = CreateSut();
                
                // Act
                sut.Seed(10, 10);
                var relevantCells = sut.GetCells(5, 5, 15, 15);

                // Assert
                Assert.AreNotEqual(0, relevantCells.Count(c => c.IsAlive()));
            }
        }

        [TestFixture]
        public class WhenTicked
        {
            [Test]
            public void GivenLivingCell_WithNoNeighbors_ShouldDie()
            {
                // Arrange
                var sut = CreateSut();
                var cell = sut.AddCell(0, 0);
                
                // Act
                sut.Tick();

                // Assert
                Assert.AreEqual(false, cell.IsAlive());
            }

            [Test]
            public void GivenLivingCell_WithOneNeighbor_ShouldDie()
            {
                // Arrange
                var sut = CreateSut();
                var cell = sut.AddCell(0, 0);
                sut.AddCell(1, 0);
                // Act
                sut.Tick();
                
                // Assert
                Assert.AreEqual(false, cell.IsAlive());
            }

            [Test]
            public void GivenLivingCell_WithTwoNeighbors_ShouldLive()
            {
                // Arrange
                var sut = CreateSut();
                var cell = sut.AddCell(0, 0);
                sut.AddCell(1, 0);
                sut.AddCell(1, 1);
                // Act
                sut.Tick();
                
                // Assert
                Assert.AreEqual(false, cell.IsAlive());
            }

            [Test]
            public void GivenLivingCell_WithThreeNeighbors_ShouldLive()
            {
                // Arrange
                var sut = CreateSut();
                var cell = sut.AddCell(0, 0);
                sut.AddCell(1, 0);
                sut.AddCell(1, 1);
                sut.AddCell(0, 1);

                // Act
                sut.Tick();
                
                // Assert
                Assert.AreEqual(false, cell.IsAlive());
            }

            [Test]
            public void GivenDeadCell_WithThreeLiveNeighbors_ShouldBecomeAlive()
            {
                // Arrange
                var sut = CreateSut();
                var cell = sut.AddCell(0, 0, false);
                sut.AddCell(1, 0);
                sut.AddCell(-1, 0);
                sut.AddCell(0, 1);

                // Act
                sut.Tick();
                
                // Assert
                Assert.AreEqual(true, cell.IsAlive());
            }
        }

        private static SquareCell CreateLivingCellAt(int x, int y)
        {
            return new SquareCell(true, x, y);
        }

        private static Simulation CreateSut()
        {
            return new Simulation();
        }
    }
}
