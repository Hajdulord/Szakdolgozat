using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Logic;

namespace HMF.Thesis.Tests.Logic
{
    public class MoveLogicTest
    {
        [Test]
        public void MoveLogicConstructorTest()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.baseSpeed = 10;

            var rigidbody = new Rigidbody2D();

            //* Affect
            var move = new MoveLogic(data, rigidbody);

            //* Testing

            Assert.AreEqual(data.baseSpeed, move.Speed);
        }
        
        [UnityTest]
        public IEnumerator DashInitialTest()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            //* Affect

            var successfulDash =  move.Dash();

            yield return new WaitForFixedUpdate();

            //* Testing

            Assert.AreEqual(5.0f, rigidbody.position.x, 0.01f);
            Assert.IsTrue(successfulDash);
        }

        [UnityTest]
        public IEnumerator CannotDashYetTest()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            move.DashRate = 0.3f;

            //* Affect

            var successfulDash = move.Dash();

            yield return new WaitForFixedUpdate();

            yield return new WaitForSeconds(1);
            
            successfulDash = move.Dash();

            yield return new WaitForFixedUpdate();

            //* Testing

            Assert.AreEqual(5.0f, rigidbody.position.x, 0.01f);
            Assert.IsFalse(successfulDash);
        }

        [UnityTest]
        public IEnumerator CanDashSecondTimeAfterDelayTest()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            move.DashRate = 0.3f;

            //* Affect

            var successfulDash = move.Dash();

            yield return new WaitForFixedUpdate();

            yield return new WaitForSeconds(4);
            
            successfulDash = move.Dash();

            yield return new WaitForFixedUpdate();

            //* Testing

            Assert.AreEqual(10.0f, rigidbody.position.x, 0.01f);
            Assert.IsTrue(successfulDash);
        }

        [Test]
        public void PushBackToRight()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            move.PushBackSpeed = 5f;

            //* Affect

            move.PushBack(1);

            //* Testing

            Assert.AreEqual(5.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void PushBackToLeftt()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            move.PushBackSpeed = 5f;

            //* Affect

            move.PushBack(-1);

            //* Testing

            Assert.AreEqual(-5.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void PushBackToRightWithYVelocity()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;
            rigidbody.velocity = Vector2.up;

            var move = new MoveLogic(data, rigidbody);

            move.PushBackSpeed = 5f;

            //* Affect

            move.PushBack(1);

            //* Testing

            Assert.AreEqual(5.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(1.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void PushBackToLeftWithYVelocity()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;
            rigidbody.velocity = Vector2.up;

            var move = new MoveLogic(data, rigidbody);

            move.PushBackSpeed = 5f;

            //* Affect

            move.PushBack(-1);

            //* Testing

            Assert.AreEqual(-5.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(1.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void NotMove()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.Move(0);

            //* Testing

            Assert.AreEqual(0.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void MoveToRight()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.Move(1);

            //* Testing

            Assert.AreEqual(10.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void MoveToLeft()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.Move(-1);

            //* Testing

            Assert.AreEqual(-10.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void NotMoveWithYVelocity()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;
            rigidbody.velocity = Vector2.up;


            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.Move(0);

            //* Testing

            Assert.AreEqual(0.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(1.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void MoveToRightWithYVelocity()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;
            rigidbody.velocity = Vector2.up;


            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.Move(1);

            //* Testing

            Assert.AreEqual(10.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(1.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void MoveToLeftWithYVelocity()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;
            rigidbody.velocity = Vector2.up;


            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.Move(-1);

            //* Testing

            Assert.AreEqual(-10.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(1.0f, rigidbody.velocity.y, 0.01f);
        }

        [UnityTest]
        public IEnumerator JumpTest()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            rigidbody.gravityScale = 0;

            var move = new MoveLogic(data, rigidbody);

            move.JumpSpeed = 5;

            //* Affect

            move.Jump();

            yield return new WaitForFixedUpdate();

            //* Testing

            Assert.Greater(rigidbody.position.y, 0.0f);
            Assert.AreEqual(0.0f, rigidbody.position.x, 0.01f);
        }

        [UnityTest]
        public IEnumerator FallTest()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;
            rigidbody.gravityScale = 0;

            var move = new MoveLogic(data, rigidbody);

            move.FallSpeed = 5;

            //* Affect

            move.Fall();

            yield return new WaitForFixedUpdate();

            //* Testing

            Assert.Less(rigidbody.position.y, 0.0f);
            Assert.AreEqual(0.0f, rigidbody.position.x, 0.01f);
        }

        [Test]
        public void MoveToPointLeft()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.MoveToPoint(Vector2.left);

            //* Testing

            Assert.AreEqual(-10.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

        [Test]
        public void MoveToPointRight()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();

            data.baseSpeed = 10;

            var dummyGameobject = new GameObject();
            
            var rigidbody = dummyGameobject.AddComponent<Rigidbody2D>();

            rigidbody.position = Vector2.zero;

            var move = new MoveLogic(data, rigidbody);

            //* Affect

            move.MoveToPoint(Vector2.right);

            //* Testing

            Assert.AreEqual(10.0f, rigidbody.velocity.x, 0.01f);
            Assert.AreEqual(0.0f, rigidbody.velocity.y, 0.01f);
        }

    }
}
