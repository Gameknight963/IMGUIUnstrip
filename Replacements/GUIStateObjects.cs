using static UnityEngine.GUIStateObjects;
using Il2Cpp;

namespace IMGUIUnstrip.Replacements
{
    internal class GUIStateObjects
    {
        private static readonly Dictionary<int, Il2CppSystem.Object> s_StateCache = new();

        public static Il2CppSystem.Object GetStateObject(Il2CppSystem.Type t, int controlID)
        {
            if (!s_StateCache.TryGetValue(controlID, out Il2CppSystem.Object obj) || obj.GetType() != t.GetType())
            {
                obj = Il2CppSystem.Activator.CreateInstance(t);
                s_StateCache[controlID] = obj;
            }
            return obj;
        }

        public static Il2CppSystem.Object QueryStateObject(Il2CppSystem.Type t, int controlID)
        {
            if (!s_StateCache.TryGetValue(controlID, out Il2CppSystem.Object obj))
                return null;
            return t.IsInstanceOfType(obj.Cast<Il2CppSystem.Object>()) ? obj.Cast<Il2CppSystem.Object>() : null;
        }
    }
}
