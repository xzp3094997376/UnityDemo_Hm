#define DEBUG 

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTest
    {

      // A Test behaves as an ordinary method
        [Test]
        public void PlayTestSimplePasses()
        {
            // Use the Assert class to test conditions
            var go = new GameObject("123");
            Assert.AreEqual("123", go.name);
#if DEBUG
            Console.WriteLine("Debugging is enabled.");
#endif
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayTestWithEnumeratorPasses()
        {
            var go = new GameObject();
            go.AddComponent<Rigidbody>();
            var originalPosition = go.transform.position.y;

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(originalPosition, go.transform.position.y);
        }
        

        [Test]
        [UnityPlatform(RuntimePlatform.WindowsEditor)]
        public void TestMethod1()
        {
            Assert.AreEqual(Application.platform, RuntimePlatform.WindowsPlayer);
        }


    }
}
