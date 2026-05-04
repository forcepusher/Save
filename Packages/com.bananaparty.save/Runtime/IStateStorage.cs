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

        // Unity Vector types
        void SaveVector2(string key, Vector2 value);
        Vector2 LoadVector2(string key, Vector2 defaultValue = default);

        void SaveVector3(string key, Vector3 value);
        Vector3 LoadVector3(string key, Vector3 defaultValue = default);

        void SaveVector4(string key, Vector4 value);
        Vector4 LoadVector4(string key, Vector4 defaultValue = default);

        // Unity rotation/color types
        void SaveQuaternion(string key, Quaternion value);
        Quaternion LoadQuaternion(string key, Quaternion defaultValue = default);

        void SaveColor(string key, Color value);
        Color LoadColor(string key, Color defaultValue = default);

        void SaveColor32(string key, Color32 value);
        Color32 LoadColor32(string key, Color32 defaultValue = default);

        // Unity Rect types
        void SaveRect(string key, Rect value);
        Rect LoadRect(string key, Rect defaultValue = default);

        void SaveRectInt(string key, RectInt value);
        RectInt LoadRectInt(string key, RectInt defaultValue = default);

        // Collections
        void SaveList<T>(string key, List<T> value) where T : class;
        List<T> LoadList<T>(string key) where T : class;

        void SaveStringList(string key, List<string> value);
        List<string> LoadStringList(string key);

        void SaveIntList(string key, List<int> value);
        List<int> LoadIntList(key: string, defaultValue: List<int> = null);

        // Dictionary (string keys only for JSON compatibility)
        void SaveDictionary<TKey, TValue>(string key, Dictionary<TKey, TValue> value) where TKey : notnull;
        Dictionary<TKey, TValue> LoadDictionary<TKey, TValue>(string key) where TKey : notnull;

        // GUID support
        void SaveGuid(string key, Guid value);
        Guid LoadGuid(string key, Guid defaultValue = default);

        // Enum support (stored as string for safety)
        void SaveEnum<T>(string key, T value) where T : Enum;
        T LoadEnum<T>(string key, T defaultValue = default) where T : Enum;

        // Clear all saves
        void ClearAll();
    }
}
