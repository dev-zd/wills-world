using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.UI
{
    public class TokenCountUI : MonoBehaviour
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void AutoSpawn()
        {
            if (GameObject.Find("TokenCountUI_Instance") == null)
            {
                var obj = new GameObject("TokenCountUI_Instance");
                obj.AddComponent<TokenCountUI>();
                Object.DontDestroyOnLoad(obj);
                Debug.Log("TokenCountUI Instance spawned successfully.");
            }
        }

        void OnGUI()
        {
            if (model == null) model = Simulation.GetModel<PlatformerModel>();
            int tokens = (model != null) ? model.tokens : 0;

            // Simple, reliable background box
            GUI.color = new Color(0, 0, 0, 0.7f);
            GUI.Box(new Rect(10, 10, 180, 60), "");
            
            // Bright Yellow Text
            GUIStyle style = new GUIStyle();
            style.fontSize = 24;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleLeft;
            style.normal.textColor = Color.yellow;
            
            GUI.Label(new Rect(25, 20, 150, 40), "COINS: " + tokens, style);
        }
    }
}
