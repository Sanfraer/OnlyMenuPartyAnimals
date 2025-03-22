using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;
using HarmonyLib;
using System.Reflection;

namespace PartyCheat
{
    [BepInPlugin("com.Alexander.partycheat", "Party Cheat", "1.0.0")]
    public class Loader : BasePlugin
    {
        public override void Load()
        {
            try
            {
                var harmony = new Harmony("com.Alexander.partycheat");
                harmony.PatchAll();
                Debug.Log("Загружен/Loaded.");

                AddComponent<MainMenu>();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Ошибка/Error: {ex}");
            }
        }
    }
    public class MainMenu : MonoBehaviour
    {
        //Menu
        private bool menuState = true;
        public string menuMode = "Main";

        //Main
        private Rect rectMenu = new Rect(10f, 10f, 360f, 336f);
        private Rect dragMenu = new Rect(0f, 0f, 336f, 20f);

        private GUILayoutOption[] buttonSize = new GUILayoutOption[] { GUILayout.Width(105f), GUILayout.Height(25) };

        void OnGUI()
        {
            if (menuState)
            {
                switch (menuMode)
                {
                    case "Main":
                        rectMenu = GUI.Window(0, rectMenu, (GUI.WindowFunction)Main, "SanWare - BETA");
                        break;
                }
            }
        }

        private void Main(int ID)
        {
            if (menuState)
            {
                GUI.color = Color.cyan;
                GUILayout.BeginHorizontal(GUI.skin.box, GUILayout.ExpandHeight(true));
                //1 Column
                GUILayout.BeginVertical();
                if (GUILayout.Button("Test", buttonSize)) //Name button
                {
                    Debug.Log("Test"); // Function (method, action on button)
                }

                if (GUILayout.Button("Test", buttonSize))
                {
                    Debug.Log("Test");
                }
                if (GUILayout.Button("Test", buttonSize))
                {
                    Debug.Log("Test");
                }
                if (GUILayout.Button("Test", buttonSize))
                {
                    Debug.Log("Test");
                }
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
        }

        private string MakeToggle(string name, bool toggle)
        {
            string status = toggle ? "<color=green>ON</color>" : "<color=red>OFF</color>";
            return $"{name} {status}";
        }
    }

    [HarmonyPatch(typeof(Application), nameof(Application.Quit))] //хук
    class Patch
    {
        public static bool Prefix() //хукаем метод в начале его вызова, перед выполнением его кода //hook the method at the beginning of its call, before executing its code


        {
            return false; //останавливаем выполнение кода метода  //stop execution of the method code
        }
    }
}
