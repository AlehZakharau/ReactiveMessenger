using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ReactiveSystem.Editor
{
    public class EventBusLogActivator : EditorWindow
    {
        private const string Define = "EVENTBUS_LOG";
        
        [MenuItem("Tools/EventBusLogActivator")]
        private static void EnableLog()
        {
            var target = EditorUserBuildSettings.selectedBuildTargetGroup;
            var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);

            var listDefines = defines.Split(';').ToList();
            if (listDefines.Contains(Define))
            {
                Debug.Log("Deactivate <b>EventBus</b> logger");
                listDefines.Remove(Define);
            }
            else
            {
                Debug.Log("Activate <b>EventBus</b> logger");
                listDefines.Add(Define);
            }
            
            PlayerSettings.SetScriptingDefineSymbolsForGroup(target, string.Join(';', listDefines.ToArray()));
        }
    }
}