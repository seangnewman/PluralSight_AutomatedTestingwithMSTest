using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Tests
{
    [TestClass]
    [TestCategory("Enemy Creation")]
    public class EnemyFactoryShould
    {
        [TestMethod]
        public void NotAllowNullName()
        {
            // Act
            Console.WriteLine("Creating EnemyFactory");
            EnemyFactory sut = new EnemyFactory();
            // Arrange

            // Asset
            Console.WriteLine("Calling Create Method");
            Assert.ThrowsException<ArgumentNullException>( () => sut.Create(null) );
        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            // Act
            EnemyFactory sut = new EnemyFactory();
            // Arrange

            // Asset
           EnemyCreationException ex =  Assert.ThrowsException<EnemyCreationException>(() => sut.Create("Cadet", true));
            Assert.AreEqual("Cadet", ex.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            // Act
            EnemyFactory sut = new EnemyFactory();

            //Arange
            Enemy enemy = sut.Create("Zombie");

            //Assert
            Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));
        }

        //[TestMethod]
        //public void CreateNormalEnemyByDefault_NotTypeExample()
        //{
        //    // Act
        //    EnemyFactory sut = new EnemyFactory();

        //    //Arange
        //    Enemy enemy = sut.Create("Zombie");

        //    //Assert
        //    Assert.IsNotInstanceOfType(enemy, typeof(NormalEnemy));
        //}

        [TestMethod]
        public void CreateBossEnemy()
        {
            // Act
            EnemyFactory sut = new EnemyFactory();

            //Arange
            Enemy enemy = sut.Create("Zombie King", true);

            //Assert
            Assert.IsInstanceOfType(enemy, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeparateInstances()
        {
            // Act
            EnemyFactory sut = new EnemyFactory();

            //Arange
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            //Assert
            Assert.AreNotSame(enemy1,enemy2);
        }
    }
}
