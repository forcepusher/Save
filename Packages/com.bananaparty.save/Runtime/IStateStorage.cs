using System;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Save
{
    public interface IStateStorage
    {
        void Save(string key, IPersistent persistentObject);
        IPersistent Load(string key);

        bool HasSave(string key);
        void DeleteSave(string key);

        // Primitive types
        void SaveInt(string key, int value);
        int LoadInt(string key, int defaultValue = 0);

        void SaveFloat(string key, float value);
        float LoadFloat(string key, float defaultValue = 0f);

        void SaveDouble(string key, double value);
        double LoadDouble(string key, double defaultValue = 0.0);

        void SaveLong(string key, long value);
        long LoadLong(string key, long defaultValue = 0L);

        void SaveBool(string key, bool value);
        bool LoadBool(string key, bool defaultValue = false);

        void SaveString(string key, string value);
        string LoadString(string key, string defaultValue = null);

        // Byte array support
        void SaveByteArray(string key, byte[] value);
        byte[] LoadByteArray(string key);

        // Unity Vector types
        void SaveVector2(string key, Vector2 value);
        Vector2 LoadVector2(string key, Vector2 defaultValue = default);

        void SaveVector3(string key, Vector3 value);
        Vector3 LoadVector3(string key, Vector3 defaultValue = default);

        void SaveVector4(string key, Vector4 value);
        Vector4 LoadVector4(string key, Vector4 defaultValue = default);

        // Unity integer vectors
        void SaveVector2Int(string key, Vector2Int value);
        Vector2Int LoadVector2Int(string key, Vector2Int defaultValue = default);

        void SaveVector3Int(string key, Vector3Int value);
        Vector3Int LoadVector3Int(string key, Vector3Int defaultValue = default);

        // Unity rotation/color types
        void SaveQuaternion(string key, Quaternion value);
        Quaternion LoadQuaternion(string key, Quaternion defaultValue = default);

        void SaveColor(string key, Color value);
        Color LoadColor(string key, Color defaultValue = default);

        void SaveColor32(string key, Color32 value);
        Color32 LoadColor32(string key, Color32 defaultValue = default);

        // Unity Rect/Bounds
        void SaveRect(string key, Rect value);
        Rect LoadRect(string key, Rect defaultValue = default);

        void SaveBounds(string key, Bounds value);
        Bounds LoadBounds(string key, Bounds defaultValue = default);

        // Date/time types
        void SaveDateTime(string key, DateTime value);
        DateTime LoadDateTime(string key, DateTime defaultValue = default);

        void SaveTimeSpan(string key, TimeSpan value);
        TimeSpan LoadTimeSpan(string key, TimeSpan defaultValue = default);

        // Collections - removed class constraint to support value types
        void SaveList<T>(string key, List<T> value);
        List<T> LoadList<T>(string key);

        // Dictionary with proper constraints for JSON compatibility
        void SaveDictionary<TKey, TValue>(string key, Dictionary<TKey, TValue> value) where TKey : notnull;
        Dictionary<TKey, TValue> LoadDictionary<TKey, TValue>(string key) where TKey : notnull;

        // Array support
        void SaveStringArray(string key, string[] value);
        string[] LoadStringArray(string key);

        void SaveIntArray(string key, int[] value);
        int[] LoadIntArray(string key);

        // GUID support
        void SaveGuid(string key, Guid value);
        Guid LoadGuid(string key, Guid defaultValue = default);

        // Enum support (stored as string for versioning safety)
        void SaveEnum<T>(string key, T value) where T : Enum;
        T LoadEnum<T>(string key, T defaultValue = default) where T : Enum;

        // Clear all saves
        void ClearAll();
    }
}
