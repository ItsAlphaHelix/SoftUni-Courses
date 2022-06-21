using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Mitko", 50, 70)]
        [TestCase("Konio", 30, 0)]
        [TestCase("Mitko", 1, 2)]
        public void ConstructorShouldSetEverythingIfDataIsValid(
            string name,
            int damage,
            int health)
        {
            Warrior warrior = new Warrior(name, damage, health);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(health, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructorShouldThrowArgumentExceptionForInvalidName(
            string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 12, 3));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-35)]
        public void ConstructorShouldThrowArgumentExceptionForInvalidDamage(
            int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Mitko", damage, 3));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-35)]
        public void ConstructorShouldThrowArgumentExceptionForInvalidHealth(
            int health)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Mitko", 60, health));
        }

        [Test]
        [TestCase("Mitko", 20, 50, "Konio", 40, 50)]
        [TestCase("Mitko", 30, 50, "Konio", 40, 50)]
        [TestCase("Mitko", 50, 50, "Konio", 30, 50)]
        [TestCase("Mitko", 50, 50, "Konio", 20, 50)]
        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqual30(
            string name,
            int health,
            int damage,
            string enemyName,
            int enemyHealth,
            int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Mitko", 50, 50, "Konio", 40, 90)]
        public void AttackMethodShouldThrowExceptionWhenOurHPIsBelowEnemyDamage(
            string name,
            int health,
            int damage,
            string enemyName,
            int enemyHealth,
            int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Mitko", 50, 100, 50,
                  "Konio", 50, 100, 50)]
        [TestCase("Mitko", 100, 100, 50,
                  "Konio", 50, 100, 0)]
        [TestCase("Mitko", 120, 100, 50,
                  "Konio", 50, 100, 0)]
        public void AttackMethodShouldReduceHPForWarriorAndEnemyWarrior(
           string name,
           int damage,
           int health,
           int resultHp,
           string enemyName,
           int enemyDamage,
           int enemyHealth,
            int resultEnemyHp)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            myWarrior.Attack(enemyWarrior);

            Assert.AreEqual(resultHp, myWarrior.HP);
            Assert.AreEqual(resultEnemyHp, enemyWarrior.HP);
        }
    }
}