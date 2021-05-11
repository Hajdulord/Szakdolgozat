using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using HMF.Thesis.Logic;
using Moq;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Tests.Logic
{
    public class InventoryLogicTest
    {
        [Test]
        public void CheckPropertiesWithDefaultConstructorValues()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();


            //* Affect
            
            var inventory = new InventoryLogic(1, itemMoq.Object);

            //* Testing

            Assert.NotNull(inventory.InventoryShelf);
            Assert.NotNull(inventory.InUse);
            Assert.Null(inventory.CurrentItem);
            Assert.AreEqual(1, inventory.InUseSize);
            Assert.AreEqual(itemMoq.Object, inventory.MainWeapon);

        }

        [Test]
        public void CheckPropertiesWithInventory()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();

            var newInventoryShelf = new Dictionary<string, (IItem Item, int Quantity)>();

            newInventoryShelf.Add("Test Item", (itemMoq.Object, 2));

            //* Affect
            
            var inventory = new InventoryLogic(1, itemMoq.Object, newInventoryShelf);

            //* Testing

            Assert.NotNull(inventory.InUse);
            Assert.Null(inventory.CurrentItem);
            Assert.AreEqual(1, inventory.InUseSize);
            Assert.AreEqual(itemMoq.Object, inventory.MainWeapon);

            Assert.AreEqual(newInventoryShelf, inventory.InventoryShelf);
        }

        [Test]
        public void CheckPropertiesWithInventoryAndInUse()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();

            var newInventoryShelf = new Dictionary<string, (IItem Item, int Quantity)>();

            newInventoryShelf.Add("Test Item", (itemMoq.Object, 2));

            var newInUse = new Dictionary<int, IItem>();

            newInUse.Add(0, itemMoq.Object);

            //* Affect
            
            var inventory = new InventoryLogic(1, itemMoq.Object, newInventoryShelf, newInUse);

            //* Testing

            Assert.Null(inventory.CurrentItem);
            Assert.AreEqual(1, inventory.InUseSize);
            Assert.AreEqual(itemMoq.Object, inventory.MainWeapon);

            Assert.AreEqual(newInventoryShelf, inventory.InventoryShelf);
            Assert.AreEqual(newInUse, inventory.InUse);
        }

        [Test]
        public void CheckPropertiesWithInventoryAndInUseCurrentItem()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();

            var newInventoryShelf = new Dictionary<string, (IItem Item, int Quantity)>();

            newInventoryShelf.Add("Test Item", (itemMoq.Object, 2));

            var newInUse = new Dictionary<int, IItem>();

            newInUse.Add(0, itemMoq.Object);

            //* Affect
            
            var inventory = new InventoryLogic(1, itemMoq.Object, newInventoryShelf, newInUse, itemMoq.Object);

            //* Testing

            Assert.AreEqual(1, inventory.InUseSize);
            Assert.AreEqual(itemMoq.Object, inventory.MainWeapon);

            Assert.AreEqual(newInventoryShelf, inventory.InventoryShelf);
            Assert.AreEqual(newInUse, inventory.InUse);
            Assert.AreEqual(itemMoq.Object, inventory.CurrentItem);
        }

        [Test]
        public void AddNewItem()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var inventory = new InventoryLogic(1, itemMoq.Object);

            //* Affect
            
            inventory.AddItem(itemMoq.Object, 1);

            //* Testing

            Assert.AreEqual((itemMoq.Object, 1), inventory.InventoryShelf["Test Item"]);

        }

        [Test]
        public void AddExistingItem()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var inventory = new InventoryLogic(1, itemMoq.Object);

            inventory.AddItem(itemMoq.Object, 1);

            //* Affect
            
            inventory.AddItem(itemMoq.Object, 1);

            //* Testing

            Assert.AreEqual((itemMoq.Object, 2), inventory.InventoryShelf["Test Item"]);

        }

        [Test]
        public void RemoveItem()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var inventory = new InventoryLogic(1, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);

            inventory.AddItem(itemMoq.Object, 1);

            //* Affect
            
            inventory.RemoveItem(itemMoq.Object, 1);

            //* Testing

            Assert.AreEqual((itemMoq.Object, 1), inventory.InventoryShelf["Test Item"]);

        }

        [Test]
        public void RemoveItemFully()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var inventory = new InventoryLogic(1, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);

            //* Affect
            
            inventory.RemoveItem(itemMoq.Object, 1);

            //* Testing

            Assert.False( inventory.InventoryShelf.ContainsKey("Test Item"));

        }

        [Test]
        public void SetInUse()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var inventory = new InventoryLogic(1, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);


            //* Affect
            
            inventory.SetUse(itemMoq.Object);

            //* Testing

            Assert.AreEqual(itemMoq.Object, inventory.InUse[0]);

        }

        [Test]
        public void SetMultipleInUse()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var itemMoq2 = new Mock<IItem>();
            itemMoq2.SetupGet(p => p.Name).Returns("Test Item2");


            var inventory = new InventoryLogic(2, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);
            inventory.AddItem(itemMoq2.Object, 1);


            //* Affect
            
            inventory.SetUse(itemMoq.Object);
            inventory.SetUse(itemMoq2.Object);

            //* Testing

            Assert.AreEqual(itemMoq.Object, inventory.InUse[0]);
            Assert.AreEqual(itemMoq2.Object, inventory.InUse[1]);

        }

        [Test]
        public void RemoveInUse()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var itemMoq2 = new Mock<IItem>();
            itemMoq2.SetupGet(p => p.Name).Returns("Test Item2");


            var inventory = new InventoryLogic(2, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);
            inventory.AddItem(itemMoq2.Object, 1);

            inventory.SetUse(itemMoq.Object);
            inventory.SetUse(itemMoq2.Object);

            //* Affect
            
            inventory.RemoveUse(1);

            //* Testing

            Assert.AreEqual(itemMoq.Object, inventory.InUse[0]);
            Assert.AreEqual(1, inventory.InUse.Count);

        }

        [Test]
        public void InUseInnerCounterWorkingCorrectly()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var itemMoq2 = new Mock<IItem>();
            itemMoq2.SetupGet(p => p.Name).Returns("Test Item2");

            var itemMoq3 = new Mock<IItem>();
            itemMoq3.SetupGet(p => p.Name).Returns("Test Item2");


            var inventory = new InventoryLogic(3, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);
            inventory.AddItem(itemMoq2.Object, 1);
            inventory.AddItem(itemMoq3.Object, 1);

            inventory.SetUse(itemMoq.Object);
            inventory.SetUse(itemMoq2.Object);
            inventory.SetUse(itemMoq3.Object);

            //* Affect
            
            inventory.RemoveUse(1);
            inventory.RemoveUse(0);

            inventory.SetUse(itemMoq2.Object);

            //* Testing

            Assert.AreEqual(2, inventory.InUse.Count);
            Assert.AreEqual(itemMoq2.Object, inventory.InUse[0]);
            Assert.AreEqual(itemMoq3.Object, inventory.InUse[2]);

        }


        [Test]
        public void RemoveAll()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var itemMoq2 = new Mock<IItem>();
            itemMoq2.SetupGet(p => p.Name).Returns("Test Item2");


            var inventory = new InventoryLogic(2, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);
            inventory.AddItem(itemMoq2.Object, 1);

            inventory.SetUse(itemMoq.Object);
            inventory.SetUse(itemMoq2.Object);

            //* Affect
            
            inventory.RemoveAll();

            //* Testing

            Assert.AreEqual(0, inventory.InUse.Count);
            Assert.AreEqual(0, inventory.InventoryShelf.Count);

        }

        [Test]
        public void GetItem()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            itemMoq.SetupGet(p => p.Name).Returns("Test Item");

            var itemMoq2 = new Mock<IItem>();
            itemMoq2.SetupGet(p => p.Name).Returns("Test Item2");


            var inventory = new InventoryLogic(2, itemMoq.Object);
            
            inventory.AddItem(itemMoq.Object, 1);
            inventory.AddItem(itemMoq2.Object, 2);

            inventory.SetUse(itemMoq.Object);
            inventory.SetUse(itemMoq2.Object);

            //* Affect
            
            var item = inventory.GetItem(0);
            var item2 = inventory.GetItem(1);

            //* Testing

            Assert.AreEqual(itemMoq.Object, item);
            Assert.False(inventory.InUse.ContainsKey(0));
            Assert.False(inventory.InventoryShelf.ContainsKey("Test Item"));

            Assert.AreEqual(itemMoq2.Object, inventory.InUse[1]);
            Assert.AreEqual(itemMoq2.Object, item2);
            Assert.AreEqual((itemMoq2.Object, 1), inventory.InventoryShelf["Test Item2"]);

        }
    }
}
