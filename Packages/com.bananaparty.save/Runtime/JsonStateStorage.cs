using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BananaParty.Save
{
    public class JsonStateStorage : IStateStorage
    {
        private readonly Dictionary<string, object> _storage = new();

        // Wrapper classes for JSONUtility (primitives need boxing)
        [Serializable] private class IntWrapper { public int value; }
        [Serializable] private class FloatWrapper { public float value; }
        [Serializable] private class BoolWrapper { public bool value; }
        [Serializable] private class StringWrapper { public string value; }
        [Serializable] private class Vector2Wrapper { public Vector2 value; }
        [Serializable] private class Vector3Wrapper { public Vector3 value; }
        [Serializable] private class Vector2IntWrapper { public Vector2Int value; }
        [Serializable] private class Vector3IntWrapper { public Vector3Int value; }
        [Serializable] private class QuaternionWrapper { public float x, y, z, w; }
        [Serializable] private class ColorWrapper { public float r, g, b, a; }
        [Serializable] private class DateTimeWrapper { public long ticks; }
        [Serializable] private class ByteArrayWrapper { public byte[] value; }

        // Utility methods
        public bool HasState(string key) => _storage.ContainsKey(key);
        public void DeleteState(string key) => _storage.Remove(key);
        public void ClearAllState() => _storage.Clear();



        // Primitive types
        public void SaveInt(string key, int value) => _storage[key] = JsonUtility.ToJson(new IntWrapper { value = value });
        public int LoadInt(string key, int defaultValue = 0)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<IntWrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        public void SaveFloat(string key, float value) => _storage[key] = JsonUtility.ToJson(new FloatWrapper { value = value });
        public float LoadFloat(string key, float defaultValue = 0f)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<FloatWrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        public void SaveBool(string key, bool value) => _storage[key] = JsonUtility.ToJson(new BoolWrapper { value = value });
        public bool LoadBool(string key, bool defaultValue = false)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<BoolWrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        public void SaveString(string key, string value) => _storage[key] = JsonUtility.ToJson(new StringWrapper { value = value });
        public string LoadString(string key, string defaultValue = null)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<StringWrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        // Unity Vector types
        public void SaveVector2(string key, Vector2 value) => _storage[key] = JsonUtility.ToJson(new Vector2Wrapper { value = value });
        public Vector2 LoadVector2(string key, Vector2 defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<Vector2Wrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        public void SaveVector3(string key, Vector3 value) => _storage[key] = JsonUtility.ToJson(new Vector3Wrapper { value = value });
        public Vector3 LoadVector3(string key, Vector3 defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<Vector3Wrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        // Unity integer vectors
        public void SaveVector2Int(string key, Vector2Int value) => _storage[key] = JsonUtility.ToJson(new Vector2IntWrapper { value = value });
        public Vector2Int LoadVector2Int(string key, Vector2Int defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<Vector2IntWrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        public void SaveVector3Int(string key, Vector3Int value) => _storage[key] = JsonUtility.ToJson(new Vector3IntWrapper { value = value });
        public Vector3Int LoadVector3Int(string key, Vector3Int defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<Vector3IntWrapper>(json);
            return wrapper?.value ?? defaultValue;
        }

        // Unity types
        public void SaveQuaternion(string key, Quaternion value) => _storage[key] = JsonUtility.ToJson(new QuaternionWrapper { x = value.x, y = value.y, z = value.z, w = value.w });
        public Quaternion LoadQuaternion(string key, Quaternion defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<QuaternionWrapper>(json);
            if (wrapper == null) return defaultValue;
            return new Quaternion(wrapper.x, wrapper.y, wrapper.z, wrapper.w);
        }

        public void SaveColor(string key, Color value) => _storage[key] = JsonUtility.ToJson(new ColorWrapper { r = value.r, g = value.g, b = value.b, a = value.a });
        public Color LoadColor(string key, Color defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<ColorWrapper>(json);
            if (wrapper == null) return defaultValue;
            return new Color(wrapper.r, wrapper.g, wrapper.b, wrapper.a);
        }

        // Date/time types
        public void SaveDateTime(string key, DateTime value) => _storage[key] = JsonUtility.ToJson(new DateTimeWrapper { ticks = value.Ticks });
        public DateTime LoadDateTime(string key, DateTime defaultValue = default)
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<DateTimeWrapper>(json);
            if (wrapper == null) return defaultValue;
            return new DateTime(wrapper.ticks);
        }

        // Collections
        public void SaveList<T>(string key, List<T> value)
        {
            if (value == null) return;
            string json = JsonUtility.ToJson(new ListWrapper<T> { items = value.ToArray() });
            _storage[key] = json;
        }

        public List<T> LoadList<T>(string key)
        {
            if (!_storage.TryGetValue(key, out var obj)) return null;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return null;
            var wrapper = JsonUtility.FromJson<ListWrapper<T>>(json);
            return wrapper?.items?.ToList();
        }

        [Serializable] private class ListWrapper<T> { public T[] items; }

        // Dictionary with proper constraints for JSON compatibility
        public void SaveDictionary<TKey, TValue>(string key, Dictionary<TKey, TValue> value) where TKey : notnull
        {
            if (value == null) return;
            var pairs = new KeyValuePairWrapper<TKey, TValue>[value.Count];
            int i = 0;
            foreach (var kvp in value) pairs[i++] = new KeyValuePairWrapper<TKey, TValue> { key = kvp.Key, value = kvp.Value };
            string json = JsonUtility.ToJson(new DictionaryWrapper<TKey, TValue> { pairs = pairs });
            _storage[key] = json;
        }

        public Dictionary<TKey, TValue> LoadDictionary<TKey, TValue>(string key) where TKey : notnull
        {
            if (!_storage.TryGetValue(key, out var obj)) return null;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return null;
            var wrapper = JsonUtility.FromJson<DictionaryWrapper<TKey, TValue>>(json);
            if (wrapper?.pairs == null) return null;

            var dict = new Dictionary<TKey, TValue>();
            foreach (var pair in wrapper.pairs)
                dict[pair.key] = pair.value;
            return dict;
        }

        [Serializable] private class KeyValuePairWrapper<TKey, TValue> { public TKey key; public TValue value; }
        [Serializable] private class DictionaryWrapper<TKey, TValue> { public KeyValuePairWrapper<TKey, TValue>[] pairs; }

        // Byte array
        public void SaveByteArray(string key, byte[] value) => _storage[key] = JsonUtility.ToJson(new ByteArrayWrapper { value = value });
        public byte[] LoadByteArray(string key)
        {
            if (!_storage.TryGetValue(key, out var obj)) return null;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return null;
            var wrapper = JsonUtility.FromJson<ByteArrayWrapper>(json);
            return wrapper?.value;
        }

        // Enum types - store as int
        public void SaveEnum<T>(string key, T value) where T : Enum => _storage[key] = JsonUtility.ToJson(new IntWrapper { value = (int)(object)value });
        public T LoadEnum<T>(string key, T defaultValue = default) where T : Enum
        {
            if (!_storage.TryGetValue(key, out var obj)) return defaultValue;
            string json = obj as string;
            if (string.IsNullOrEmpty(json)) return defaultValue;
            var wrapper = JsonUtility.FromJson<IntWrapper>(json);
            int val = wrapper?.value ?? 0;
            return (T)(object)Enum.ToObject(typeof(T), val);
        }
    }
}
