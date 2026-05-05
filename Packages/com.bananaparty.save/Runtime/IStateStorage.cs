using System;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Save
{
    public interface IStateStorage
    {
        // Utility
        bool HasState(string key);
        void DeleteState(string key);
        void ClearAllState();

        // Primitive types
        void SaveInt(string key, int value);
        int LoadInt(string key, int defaultValue = 0);

        void SaveFloat(string key, float value);
        float LoadFloat(string key, float defaultValue = 0f);

        void SaveBool(string key, bool value);
        bool LoadBool(string key, bool defaultValue = false);

        void SaveString(string key, string value);
        string LoadString(string key, string defaultValue = null);

        // Unity Vector types
        void SaveVector2(string key, Vector2 value);
        Vector2 LoadVector2(string key, Vector2 defaultValue = default);

        void SaveVector3(string key, Vector3 value);
        Vector3 LoadVector3(string key, Vector3 defaultValue = default);

        // Unity integer vectors
        void SaveVector2Int(string key, Vector2Int value);
        Vector2Int LoadVector2Int(string key, Vector2Int defaultValue = default);

        void SaveVector3Int(string key, Vector3Int value);
        Vector3Int LoadVector3Int(string key, Vector3Int defaultValue = default);

        // Unity types
        void SaveQuaternion(string key, Quaternion value);
        Quaternion LoadQuaternion(string key, Quaternion defaultValue = default);

        void SaveColor(string key, Color value);
        Color LoadColor(string key, Color defaultValue = default);

        // Date/time types
        void SaveDateTime(string key, DateTime value);
        DateTime LoadDateTime(string key, DateTime defaultValue = default);

        // Collections
        void SaveList<T>(string key, List<T> value);
        List<T> LoadList<T>(string key);

        // Dictionary with proper constraints for JSON compatibility
        void SaveDictionary<TKey, TValue>(string key, Dictionary<TKey, TValue> value) where TKey : notnull;
        Dictionary<TKey, TValue> LoadDictionary<TKey, TValue>(string key) where TKey : notnull;

        void SaveByteArray(string key, byte[] value);
        byte[] LoadByteArray(string key);

        void SaveEnum<T>(string key, T value) where T : Enum;
        T LoadEnum<T>(string key, T defaultValue = default) where T : Enum;
    }
}
