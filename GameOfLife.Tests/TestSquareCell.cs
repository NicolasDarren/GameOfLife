using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class TestSquareCell
    {
        [TestFixture]
        public class GivenCellIsDead
        {
            [TestFixture]
            public class WhenTicked
            {
                [Test]
                public void WithNoNeighbors_ShouldStayDead()
                {
                    // Arrange
                    var sut = CreateSut(false);

                    // Act
                    sut.Tick(0);

                    // Assert
                    Assert.AreEqual(false, sut.IsAlive());
                }

                [Test]
                public void WithOneLivingNeighbors_ShouldStayDead()
                {
                    // Arrange
                    var sut = CreateSut(false);

                    // Act
                    sut.Tick(1);

                    // Assert
                    Assert.AreEqual(false, sut.IsAlive());
                }

                [Test]
                public void WithThreeLivingNeighbors_ShouldBecomeAlive()
                {
                    // Arrange
                    var sut = CreateSut(false);

                    // Act
                    sut.Tick(3);

                    // Assert
                    Assert.AreEqual(true, sut.IsAlive());
                }
            }
        }

        [TestFixture]
        public class GivenCellIsAlive
        {
            [TestFixture]
            public class WhenTicked
            {
                [Test]
                public void WithNoNeighbors_ShouldDie()
                {
                    // Arrange
                    var sut = CreateSut();

                    // Act
                    sut.Tick(0);

                    // Assert
                    Assert.AreEqual(false, sut.IsAlive());
                }

                [Test]
                public void WithTwoLivingNeighbors_ShouldNotDie()
                {
                    // Arrange
                    var sut = CreateSut();

                    // Act
                    sut.Tick(2);

                    // Assert
                    Assert.AreEqual(true, sut.IsAlive());
                }

                [Test]
                public void WithThreeLivingNeighbors_ShouldNotDie()
                {
                    // Arrange
                    var sut = CreateSut();

                    // Act
                    sut.Tick(3);

                    // Assert
                    Assert.AreEqual(true, sut.IsAlive());
                }

                [Test]
                public void WithMoreThanThreeLivingNeighbors_ShouldDie()
                {
                    // Arrange
                    var sut = CreateSut();

                    // Act
                    sut.Tick(4);

                    // Assert
                    Assert.AreEqual(false, sut.IsAlive());
                }
            }
        }

        private static SquareCell CreateSut(bool isAlive = true)
        {
            return new SquareCell(isAlive);
        }
    }
}
