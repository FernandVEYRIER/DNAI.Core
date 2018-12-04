﻿using UnityEditor;
using UnityEngine;

namespace Core.Plugin.Unity.Editor.Components.Buttons
{
    class SettingsButton : Button
    {
        public SettingsButton() : base("Settings", AssetDatabase.LoadAssetAtPath<Texture>(Constants.ResourcesPath + "settings.png"))
        {
            OnClicked += () => { DulyEditor.Instance.SettingsDrawer?.ShowAuxWindow(); };
        }
    }
}