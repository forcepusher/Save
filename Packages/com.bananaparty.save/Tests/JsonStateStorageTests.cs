using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using BananaParty.Save;

namespace BananaParty.Save.Tests
{
    [TestFixture]
    public class JsonStateStorageTests
    {
        private JsonStateStorage _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new JsonStateStorage();
        }

        // Utility tests
        [UnityTest]
        public IEnumerator TestHasSaveReturnsFalseForMissingKey()
        {
            Assert.IsFalse(_storage.HasSave("nonexistent"));
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHasSaveReturnsTrueAfterSaving()
        {
            _storage.SaveInt("test", 42);
            Assert.IsTrue(_storage.HasSave("test"));
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestDeleteSaveRemovesKey()
        {
            _storage.SaveInt("test", 42);
            Assert.IsTrue(_storage.HasSave("test"));

            _storage.DeleteSave("test");
            Assert.IsFalse(_storage.HasSave("test"));
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestClearAllRemovesEverything()
        {
            _storage.SaveInt("key1", 1);
            _storage.SaveFloat("key2", 2.0f);
            _storage.SaveString("key3", "hello");

            Assert.IsTrue(_storage.HasSave("key1"));
            Assert.IsTrue(_storage.HasSave("key2"));
            Assert.IsTrue(_storage.HasSave("key3"));

            _storage.ClearAll();

            Assert.IsFalse(_storage.HasSave("key1"));
            Assert.IsFalse(_storage.HasSave("key2"));
            Assert.IsFalse(_storage.HasSave("key3"));
            yield return null;
        }

        // Int tests
        [UnityTest]
        public IEnumerator TestSaveLoadInt()
        {
            _storage.SaveInt("intKey", 42);
            int result = _storage.LoadInt("intKey");
            Assert.AreEqual(42, result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestLoadIntReturnsDefaultForMissing()
        {
            int result = _storage.LoadInt("missing", 999);
            Assert.AreEqual(999, result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadIntNegative()
        {
            _storage.SaveInt("negInt", -123);
            int result = _storage.LoadInt("negInt");
            Assert.AreEqual(-123, result);
            yield return null;
        }

        // Float tests
        [UnityTest]
        public IEnumerator TestSaveLoadFloat()
        {
            _storage.SaveFloat("floatKey", 3.14f);
            float result = _storage.LoadFloat("floatKey");
            Assert.AreEqual(3.14f, result, 0.001f);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadFloatNegative()
        {
            _storage.SaveFloat("negFloat", -2.5f);
            float result = _storage.LoadFloat("negFloat");
            Assert.AreEqual(-2.5f, result, 0.001f);
            yield return null;
        }

        // Bool tests
        [UnityTest]
        public IEnumerator TestSaveLoadBoolTrue()
        {
            _storage.SaveBool("boolKey", true);
            bool result = _storage.LoadBool("boolKey");
            Assert.IsTrue(result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadBoolFalse()
        {
            _storage.SaveBool("boolKey", false);
            bool result = _storage.LoadBool("boolKey");
            Assert.IsFalse(result);
            yield return null;
        }

        // String tests
        [UnityTest]
        public IEnumerator TestSaveLoadString()
        {
            _storage.SaveString("stringKey", "Hello World!");
            string result = _storage.LoadString("stringKey");
            Assert.AreEqual("Hello World!", result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadEmptyString()
        {
            _storage.SaveString("emptyKey", "");
            string result = _storage.LoadString("emptyKey");
            Assert.AreEqual("", result);
            yield return null;
        }

        // Vector2 tests
        [UnityTest]
        public IEnumerator TestSaveLoadVector2()
        {
            Vector2 original = new Vector2(1.5f, -2.3f);
            _storage.SaveVector2("vec2Key", original);
            Vector2 result = _storage.LoadVector2("vec2Key");
            Assert.AreEqual(original.x, result.x, 0.001f);
            Assert.AreEqual(original.y, result.y, 0.001f);
            yield return null;
        }

        // Vector3 tests
        [UnityTest]
        public IEnumerator TestSaveLoadVector3()
        {
            Vector3 original = new Vector3(1f, 2f, 3f);
            _storage.SaveVector3("vec3Key", original);
            Vector3 result = _storage.LoadVector3("vec3Key");
            Assert.AreEqual(original.x, result.x, 0.001f);
            Assert.AreEqual(original.y, result.y, 0.001f);
            Assert.AreEqual(original.z, result.z, 0.001f);
            yield return null;
        }

        // Vector2Int tests
        [UnityTest]
        public IEnumerator TestSaveLoadVector2Int()
        {
            Vector2Int original = new Vector2Int(10, -5);
            _storage.SaveVector2Int("vec2intKey", original);
            Vector2Int result = _storage.LoadVector2Int("vec2intKey");
            Assert.AreEqual(original.x, result.x);
            Assert.AreEqual(original.y, result.y);
            yield return null;
        }

        // Vector3Int tests
        [UnityTest]
        public IEnumerator TestSaveLoadVector3Int()
        {
            Vector3Int original = new Vector3Int(100, 200, 300);
            _storage.SaveVector3Int("vec3intKey", original);
            Vector3Int result = _storage.LoadVector3Int("vec3intKey");
            Assert.AreEqual(original.x, result.x);
            Assert.AreEqual(original.y, result.y);
            Assert.AreEqual(original.z, result.z);
            yield return null;
        }

        // Quaternion tests
        [UnityTest]
        public IEnumerator TestSaveLoadQuaternion()
        {
            Quaternion original = Quaternion.Euler(45f, 90f, 30f);
            _storage.SaveQuaternion("quatKey", original);
            Quaternion result = _storage.LoadQuaternion("quatKey");

            Assert.AreEqual(original.x, result.x, 0.001f);
            Assert.AreEqual(original.y, result.y, 0.001f);
            Assert.AreEqual(original.z, result.z, 0.001f);
            Assert.AreEqual(original.w, result.w, 0.001f);
            yield return null;
        }

        // Color tests
        [UnityTest]
        public IEnumerator TestSaveLoadColor()
        {
            Color original = new Color(0.2f, 0.4f, 0.6f, 0.8f);
            _storage.SaveColor("colorKey", original);
            Color result = _storage.LoadColor("colorKey");

            Assert.AreEqual(original.r, result.r, 0.001f);
            Assert.AreEqual(original.g, result.g, 0.001f);
            Assert.AreEqual(original.b, result.b, 0.001f);
            Assert.AreEqual(original.a, result.a, 0.001f);
            yield return null;
        }

        // DateTime tests
        [UnityTest]
        public IEnumerator TestSaveLoadDateTime()
        {
            DateTime original = new DateTime(2024, 3, 15, 10, 30, 45);
            _storage.SaveDateTime("dateKey", original);
            DateTime result = _storage.LoadDateTime("dateKey");

            Assert.AreEqual(original.Year, result.Year);
            Assert.AreEqual(original.Month, result.Month);
            Assert.AreEqual(original.Day, result.Day);
            Assert.AreEqual(original.Hour, result.Hour);
            Assert.AreEqual(original.Minute, result.Minute);
            Assert.AreEqual(original.Second, result.Second);
            yield return null;
        }

        // List tests
        [UnityTest]
        public IEnumerator TestSaveLoadListInt()
        {
            List<int> original = new List<int> { 1, 2, 3, 4, 5 };
            _storage.SaveList("listKey", original);
            List<int> result = _storage.LoadList<int>("listKey");

            Assert.IsNotNull(result);
            Assert.AreEqual(original.Count, result.Count);
            for (int i = 0; i < original.Count; i++)
            {
                Assert.AreEqual(original[i], result[i]);
            }
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadListString()
        {
            List<string> original = new List<string> { "a", "b", "c" };
            _storage.SaveList("stringListKey", original);
            List<string> result = _storage.LoadList<string>("stringListKey");

            Assert.IsNotNull(result);
            Assert.AreEqual(original.Count, result.Count);
            for (int i = 0; i < original.Count; i++)
            {
                Assert.AreEqual(original[i], result[i]);
            }
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadListVector3()
        {
            List<Vector3> original = new List<Vector3>
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f)
            };
            _storage.SaveList("vec3ListKey", original);
            List<Vector3> result = _storage.LoadList<Vector3>("vec3ListKey");

            Assert.IsNotNull(result);
            Assert.AreEqual(original.Count, result.Count);
            yield return null;
        }

        // Dictionary tests
        [UnityTest]
        public IEnumerator TestSaveLoadDictionaryStringInt()
        {
            Dictionary<string, int> original = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            };
            _storage.SaveDictionary("dictKey", original);
            Dictionary<string, int> result = _storage.LoadDictionary<string, int>("dictKey");

            Assert.IsNotNull(result);
            Assert.AreEqual(original.Count, result.Count);
            foreach (var kvp in original)
            {
                Assert.IsTrue(result.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, result[kvp.Key]);
            }
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadDictionaryIntVector2()
        {
            Dictionary<int, Vector2> original = new Dictionary<int, Vector2>
            {
                { 0, new Vector2(1f, 2f) },
                { 1, new Vector2(3f, 4f) }
            };
            _storage.SaveDictionary("intVec2DictKey", original);
            Dictionary<int, Vector2> result = _storage.LoadDictionary<int, Vector2>("intVec2DictKey");

            Assert.IsNotNull(result);
            Assert.AreEqual(original.Count, result.Count);
            yield return null;
        }

        // Byte array tests
        [UnityTest]
        public IEnumerator TestSaveLoadByteArray()
        {
            byte[] original = new byte[] { 0x00, 0xFF, 0xAA, 0x55 };
            _storage.SaveByteArray("byteArrayKey", original);
            byte[] result = _storage.LoadByteArray("byteArrayKey");

            Assert.IsNotNull(result);
            Assert.AreEqual(original.Length, result.Length);
            for (int i = 0; i < original.Length; i++)
            {
                Assert.AreEqual(original[i], result[i]);
            }
            yield return null;
        }

        // Enum tests
        public enum TestEnum { None, One, Two, Three }

        [UnityTest]
        public IEnumerator TestSaveLoadEnum()
        {
            _storage.SaveEnum("enumKey", TestEnum.Two);
            TestEnum result = _storage.LoadEnum<TestEnum>("enumKey");
            Assert.AreEqual(TestEnum.Two, result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadEnumNone()
        {
            _storage.SaveEnum("enumKey", TestEnum.None);
            TestEnum result = _storage.LoadEnum<TestEnum>("enumKey");
            Assert.AreEqual(TestEnum.None, result);
            yield return null;
        }

        // IPersistent tests
        [Serializable]
        private class TestPersistent : IPersistent
        {
            public int id;
            public string name;
            public Vector3 position;
        }

        [UnityTest]
        public IEnumerator TestSaveLoadIPersistent()
        {
            TestPersistent original = new TestPersistent
            {
                id = 123,
                name = "test",
                position = new Vector3(1f, 2f, 3f)
            };

            _storage.Save("persistentKey", original);
            Assert.IsTrue(_storage.HasSave("persistentKey"));

            // Note: Load returns IPersistent, type casting needed for concrete type
            IPersistent loaded = _storage.Load("persistentKey");
            Assert.IsNotNull(loaded);
            yield return null;
        }

        // Edge cases
        [UnityTest]
        public IEnumerator TestOverwriteExistingKey()
        {
            _storage.SaveInt("key", 100);
            Assert.AreEqual(100, _storage.LoadInt("key"));

            _storage.SaveInt("key", 200);
            Assert.AreEqual(200, _storage.LoadInt("key"));
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestLoadMissingListReturnsNull()
        {
            List<int> result = _storage.LoadList<int>("missing");
            Assert.IsNull(result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestLoadMissingDictionaryReturnsNull()
        {
            Dictionary<string, int> result = _storage.LoadDictionary<string, int>("missing");
            Assert.IsNull(result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestMultipleDifferentTypes()
        {
            _storage.SaveInt("int", 42);
            _storage.SaveFloat("float", 3.14f);
            _storage.SaveBool("bool", true);
            _storage.SaveString("str", "hello");
            _storage.SaveVector3("vec3", new Vector3(1f, 2f, 3f));

            Assert.AreEqual(42, _storage.LoadInt("int"));
            Assert.AreEqual(3.14f, _storage.LoadFloat("float"), 0.001f);
            Assert.IsTrue(_storage.LoadBool("bool"));
            Assert.AreEqual("hello", _storage.LoadString("str"));

            Vector3 vec = _storage.LoadVector3("vec3");
            Assert.AreEqual(1f, vec.x, 0.001f);
            Assert.AreEqual(2f, vec.y, 0.001f);
            Assert.AreEqual(3f, vec.z, 0.001f);

            yield return null;
        }
    }
}
