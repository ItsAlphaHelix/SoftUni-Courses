using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeAllValues() 
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorIfDoesntExists()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Mitko", 50, 80);
            Warrior warrior2 = new Warrior("Mitko2", 150, 280);
            Warrior warrior3 = new Warrior("Mitko3", 350, 480);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            Assert.AreEqual(3, arena.Count);

            bool warriorExists = arena.Warriors.Contains(warrior);
            bool warrior2Exists = arena.Warriors.Contains(warrior2);
            bool warrior3Exists = arena.Warriors.Contains(warrior3);

            Assert.True(warriorExists);
            Assert.True(warrior2Exists);
            Assert.True(warrior3Exists);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionDuplicateWarrior()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Mitko", 50, 80);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidWarriors()
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiro", "Stoyan"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidAttacker()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Mitko", 40, 70);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiro", "Mitko"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidDefender()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Ganio", 40, 70);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ganio", "Mitko"));
        }

        [Test]
        public void FightShouldReduceHP()
        {
            Arena arena = new Arena();

            Warrior attacker = new Warrior("Mitko", 100, 50);
            Warrior defender = new Warrior("Ganio", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Mitko", "Ganio");

            Warrior warriorAttacker = arena.Warriors
                .FirstOrDefault(x => x.Name == "Mitko");

            Warrior warriorDefender = arena.Warriors
                .FirstOrDefault(x => x.Name == "Ganio");

            Assert.AreEqual(0, warriorAttacker.HP);
            Assert.AreEqual(0, warriorDefender.HP);
        }
    }
}
