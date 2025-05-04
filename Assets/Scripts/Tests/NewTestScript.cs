using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections.Generic;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestScore()
    {
        var game = new Game();
        game.CollectItem(10);
        Assert.AreEqual(10, game.Score);
    }

    public class Game
    {
        public int Score { get; private set; }

        public void CollectItem(int points)
        {
            Score += points;
        }
    }

    [Test]
    public void TestPlayerHealth()
    {
        var player = new Player();
        player.TakeDame(1);
        Assert.AreEqual(99, player.Health);
    }

    public class Player : MonoBehaviour
    {
        public int Health { get; private set; } = 100;
        public void TakeDame(int points)
        {
            Health -= points;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "W":
                    transform.position += Vector3.up;
                    break;
                case "S":
                    transform.position += Vector3.down;
                    break;
                case "A":
                    transform.position += Vector3.left;
                    break;
                case "D":
                    transform.position += Vector3.right;
                    break;
            }
        }

        public int AttackPower { get; private set; } = 10;

        public void Attack(Enemy target)
        {
            target.TakeDamage(AttackPower);
        }
    }

    [Test]
    public void TestInventoryItem()
    {
        var inventory = new Inventory();
        var item = new GameItem("HealthPotion");
        inventory.AddItem(item);
        Assert.IsTrue(inventory.Contains(item));
    }
    
    public class Inventory
    {
        private List<GameItem> items = new List<GameItem>();

        public void AddItem(GameItem item)
        {
            items.Add(item);
        }

        public bool Contains(GameItem item)
        {
            return items.Contains(item);
        }
    }

    // 🔥 Định nghĩa GameItem
    public class GameItem
    {
        public string Name { get; private set; }

        public GameItem(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is GameItem otherItem)
            {
                return Name == otherItem.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    [Test]
    public void TestPlayerMovement()
    {
        var player = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Player>();
        player.Move("W");
        Assert.AreEqual(new Vector3(0, 1, 0), player.transform.position);
    }


    [Test]
    public void TestAttack()
    {
        var enemy = new Enemy();
        var player = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Player>();
        player.Attack(enemy);
        Assert.AreEqual(90, enemy.Health);
    }

    public class Enemy
    {
        public int Health {get; private set;} = 100;
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
