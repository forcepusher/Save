using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace BananaParty.Save.Tests
{
    [TestFixture]
    public class IPersistentTests
    {
        private JsonStateStorage _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new JsonStateStorage();
        }

        [Serializable]
        private class TestPersistent : IPersistent
        {
            public int id;
            public string name;
            public Vector3 position;

            public void Save(IStateStorage stateStorage)
            {
                stateStorage.SaveInt("id", id);
                stateStorage.SaveString("name", name);
                stateStorage.SaveVector3("position", position);
            }

            public void Load(IStateStorage stateStorage)
            {
                id = stateStorage.LoadInt("id");
                name = stateStorage.LoadString("name");
                position = stateStorage.LoadVector3("position");
            }
        }

        [UnityTest]
        public IEnumerator TestIPersistentSaveMethod()
        {
            TestPersistent obj = new TestPersistent
            {
                id = 123,
                name = "test",
                position = new Vector3(1f, 2f, 3f)
            };

            var storage = new JsonStateStorage();
            obj.Save(storage);

            Assert.IsTrue(storage.HasSave("id"));
            Assert.AreEqual(123, storage.LoadInt("id"));
            Assert.AreEqual("test", storage.LoadString("name"));
            Vector3 pos = storage.LoadVector3("position");
            Assert.AreEqual(1f, pos.x, 0.001f);
            Assert.AreEqual(2f, pos.y, 0.001f);
            Assert.AreEqual(3f, pos.z, 0.001f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestIPersistentLoadMethod()
        {
            var storage = new JsonStateStorage();
            storage.SaveInt("id", 456);
            storage.SaveString("name", "loaded");
            storage.SaveVector3("position", new Vector3(10f, 20f, 30f));

            TestPersistent obj = new TestPersistent();
            obj.Load(storage);

            Assert.AreEqual(456, obj.id);
            Assert.AreEqual("loaded", obj.name);
            Assert.AreEqual(10f, obj.position.x, 0.001f);
            Assert.AreEqual(20f, obj.position.y, 0.001f);
            Assert.AreEqual(30f, obj.position.z, 0.001f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestIPersistentLoadWithDefaultValues()
        {
            var storage = new JsonStateStorage();
            TestPersistent obj = new TestPersistent();
            obj.Load(storage);

            Assert.AreEqual(0, obj.id);
            Assert.IsNull(obj.name);
            Vector3 pos = obj.position;
            Assert.AreEqual(0f, pos.x, 0.001f);
            Assert.AreEqual(0f, pos.y, 0.001f);
            Assert.AreEqual(0f, pos.z, 0.001f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestIPersistentFullCycle()
        {
            TestPersistent original = new TestPersistent
            {
                id = 999,
                name = "fullcycle",
                position = new Vector3(5f, -10f, 15f)
            };

            var storage = new JsonStateStorage();
            original.Save(storage);

            TestPersistent restored = new TestPersistent();
            restored.Load(storage);

            Assert.AreEqual(original.id, restored.id);
            Assert.AreEqual(original.name, restored.name);
            Assert.AreEqual(original.position.x, restored.position.x, 0.001f);
            Assert.AreEqual(original.position.y, restored.position.y, 0.001f);
            Assert.AreEqual(original.position.z, restored.position.z, 0.001f);

            yield return null;
        }
    }
}
