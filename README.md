# IMGUIUnstrip
An Il2Cpp Melonloader plugin that will bring light to your IMGUI again.

The Il2Cpp compiler strips IMGUI methods if they are not used, leading to silent faliures. This plugin fixes that.

Based on
[IMGUIModule.Il2Cpp.CoreCLR.Patcher](https://github.com/IllusionMods/BepisPlugins/tree/master/src/IMGUIModule.Il2Cpp.CoreCLR.Patcher) 
which was contributed to 
[IllusionMods/BepisPlugins](https://github.com/IllusionMods/BepisPlugins) by
[ManlyMacro](https://github.com/ManlyMarco) and was itself based on prior work by an unknown author. See [this pull request](https://github.com/IllusionMods/BepisPlugins/pull/187) for more details on the original author.

## How it works

At runtime, IMGUIUnstrip uses MonoMod Detours to redirect calls to stripped methods to managed C# reimplementations. MonoMod is used directly rather than through Harmony because Harmony prefixes use `__result` and return false to override return values, which would require rewriting every replacement method's signature, and I don't really want to do that lol.

IMGUIUnstrip should work with these types:

- `GUI`
- `GUI.GUIStateObjects`
- `GUI.ScrollViewState`
- `GUI.SliderHandler`
- `GUI.SliderState`
- `GUILayout`
- `GUILayout.GUIGridSizer`
- `GUILayoutGroup`
- `GUIStateObjects`
- `TextEditor`

## Installation

Put the latest release in `Plugins/`.

## Building

Clone this repo, and adjust `GamePath` in `Directory.Build.props` to match the path of your game. Then build it with Visual Studio or `dotnet build`.
