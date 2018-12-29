using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
       
        [TestCategory("Player Defaults")]
        //[Ignore]
        public void BeInexperienceWhenNew()
        {
            //Arrange
            var sut = new PlayerCharacter();

            // Act
            
            // Assert
            Assert.IsTrue(sut.IsNoob);
        }  // BeInexperienceWhenNew

        [TestMethod]
        [TestCategory("Player Defaults")]
       // [Ignore("Temporarily disabled for refactoring")]
        public void NotHaveNickNameByDefault()
        {
            //Arrange
            var sut = new PlayerCharacter();

            //Act
           
            //Asset
            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void StartWithDefaultHealth()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.AreEqual(100, sut.Health);

        }

       [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamage()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            sut.TakeDamage(1);

            //Assert
            Assert.AreEqual(99, sut.Health);


        }

        [TestMethod]
        [TestCategory("Player Health")]

        public void TakeDamage_NotEqual()
        {
            // Arrange
            var sut = new PlayerCharacter();
            // Act

            sut.TakeDamage(1);

            //Assert
            Assert.AreNotEqual(100, sut.Health);

        }

        [TestMethod]
        [TestCategory("Player Health")]
        [TestCategory("Another Category")]
        public void IncreaseHealthAfterSleeping()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            sut.Sleep();        // Expect value between 1 to 100 inclusive

            // Assert
            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

         [TestMethod]
         public void CalculateFullName()
        {
            //Act
            var sut = new PlayerCharacter();

            //Act
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert
            Assert.AreEqual("SARAH SMITH", sut.FullName, true);  // true ignores case 
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            // Arrange
            var sut  = new PlayerCharacter();

            // Act
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert
            //Assert.IsTrue(sut.FullName.StartsWith("Sarah"));
            StringAssert.StartsWith(sut.FullName, "Sarah");
        }

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert
            //Assert.IsTrue(sut.FullName.StartsWith("Sarah"));
            StringAssert.EndsWith(sut.FullName, "Smith");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert
            StringAssert.Contains(sut.FullName, "ah Sm");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert
            //Assert.IsTrue(sut.FullName.StartsWith("Sarah"));
            StringAssert.Matches(sut.FullName,  new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act

            // Assert
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void DoNotHaveAStaffOfWonder()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act

            // Assert
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            // Assert
            CollectionAssert.AreEqual(expectedWeapons, sut.Weapons);
        }

        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act
            var expectedWeapons = new[]
           {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
           
            // Assert
            CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons);
        }

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act


            // Assert
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act


            // Assert
            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoDefaultEmptyWeapons()
        {
            // Arrange
            var sut = new PlayerCharacter();

            // Act


            // Assert
            Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
        }

    }
}
