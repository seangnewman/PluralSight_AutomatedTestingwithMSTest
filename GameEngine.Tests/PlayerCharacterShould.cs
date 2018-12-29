using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        PlayerCharacter sut;
        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PlayerCharacter
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };
        }


        [TestMethod]
       
        [PlayerDefaults]
        //[Ignore]
        public void BeInexperienceWhenNew()
        {
            //Arrange
            

            // Act
            
            // Assert
            Assert.IsTrue(sut.IsNoob);
        }  // BeInexperienceWhenNew

        [TestMethod]
        [PlayerDefaults]

        public void NotHaveNickNameByDefault()
        {
            //Arrange
          

            //Act
           
            //Asset
            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        [PlayerDefaults]
        public void StartWithDefaultHealth()
        {
            // Arrange
          

            // Act

            // Assert
            Assert.AreEqual(100, sut.Health);

        }

        public static IEnumerable<object[]> Damages
        {
            get
            {
                return new List<object[]>
                {
                    new object[] {1, 99},
                    new object[] {0, 100},
                    new object[] {100, 1},
                    new object[] { 101, 1},
                    new object[] {50, 50},
                     new object[] {40, 60}
                };
            }
        }

        public static IEnumerable<object[]> GetDamages()
        {
            return new List<object[]>
                {
                    new object[] {1, 99},
                    new object[] {0, 100},
                    new object[] {100, 1},
                    new object[] { 101, 1},
                    new object[] {50, 50},
                     new object[] {40, 60}
                };
        }

       [DataTestMethod]
       [CsvDataSource("Damage.csv")]
        [PlayerHealth]
        public void TakeDamage(int damage, int expectedHealth)
        {
            // Arrange
           

            // Act
            sut.TakeDamage(damage);

            //Assert
            Assert.AreEqual(expectedHealth, sut.Health);


        }

        [TestMethod]
        [PlayerHealth]
        public void TakeDamage_NotEqual()
        {
            // Arrange
            
            // Act

            sut.TakeDamage(1);

            //Assert
            Assert.AreNotEqual(100, sut.Health);

        }

        [TestMethod]
        [PlayerHealth]
        [TestCategory("Another Category")]
        public void IncreaseHealthAfterSleeping()
        {
            // Arrange
           
            // Act
            sut.Sleep();        // Expect value between 1 to 100 inclusive

            // Assert
            //Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
            Assert.That.IsInRange(sut.Health, 101, 200);
        }

         [TestMethod]
         public void CalculateFullName()
        {
            //Act
           

            //Act
          

            // Assert
            Assert.AreEqual("SARAH SMITH", sut.FullName, true);  // true ignores case 
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            // Arrange
            

            // Act
          

            // Assert
           
            StringAssert.StartsWith(sut.FullName, "Sarah");
        }

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {
            // Arrange
            

            // Act
           

            // Assert
           
            StringAssert.EndsWith(sut.FullName, "Smith");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Arrange
            

            // Act
           

            // Assert
            StringAssert.Contains(sut.FullName, "ah Sm");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            // Arrange
             

            // Act
           

            // Assert
            //Assert.IsTrue(sut.FullName.StartsWith("Sarah"));
            StringAssert.Matches(sut.FullName,  new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            // Arrange
            

            // Act

            // Assert
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void DoNotHaveAStaffOfWonder()
        {
            // Arrange
             

            // Act

            // Assert
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            // Arrange
            

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
            

            // Act


            // Assert
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            // Arrange


            // Act


            // Assert
            //Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
            CollectionAssert.That.AtLeastOnItemSatisfies(sut.Weapons,
                                                                                                        weapon => weapon.Contains("Sword"));
        }

        [TestMethod]
        public void HaveNoDefaultEmptyWeapons()
        {
            // Arrange
           
            // Act

            // Assert
            //Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
           // CollectionAssert.That.AllItemsNotNullOrWhitespace(sut.Weapons);
           // CollectionAssert.That.AllItemsSatisfy(sut.Weapons,
               //                                                                      weapons => !string.IsNullOrWhiteSpace(weapons));

            CollectionAssert.That.All(sut.Weapons,
                                                               weapon =>
                                                               {
                                                                   StringAssert.That.NotNullOrWhiteSpace(weapon);
                                                                   Assert.IsTrue(weapon.Length > 5);
                                                               }
                );
        }

    }
}
