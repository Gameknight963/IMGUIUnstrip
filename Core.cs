using MonoMod.RuntimeDetour;
using MelonLoader;
using System.Reflection;

[assembly: MelonInfo(typeof(IMGUIUnstrip.Core), "IMGUIUnstrip", "1.1.0", "gameknight963", null)]
[assembly: MelonAuthorColor(255, 86, 65, 157)]

namespace IMGUIUnstrip
{
    public class Core : MelonPlugin
    {
        public override void OnPreInitialization()
        {
            PatchType(typeof(Replacements.GUI), typeof(UnityEngine.GUI));
            PatchType(typeof(Replacements.GUILayout), typeof(UnityEngine.GUILayout));
            PatchType(typeof(Replacements.GUILayoutGroup), typeof(UnityEngine.GUILayoutGroup));
            PatchType(typeof(Replacements.GUIStateObjects), typeof(UnityEngine.GUIStateObjects));
        }

        private static readonly List<Detour> _detours = new();

        private static void PatchType(Type replacementType, Type targetType)
        {
            foreach (MethodInfo to in replacementType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
            {
                MethodInfo from = to.Name != "DoButtonGrid"
                    ? targetType.GetMethod(to.Name, to.GetParameters().Select(x => x.ParameterType).ToArray())
                    : targetType.GetMethod("DoButtonGrid");
                if (from == null) continue;
                try
                {
                    _detours.Add(new Detour(from, to));
                    MelonLogger.Msg($"Patched {targetType.Name}.{to.Name}");
                }
                catch (Exception e)
                {
                    MelonLogger.Warning($"Failed to patch {targetType.Name}.{to.Name}: {e.Message}");
                }
            }
        }
    }
}