using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class CheckpointUI : MonoBehaviour
    {
        private static CheckpointUI instance;
        private GameObject popupPanel;
        private Text popupText;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void AutoSpawn()
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("CheckpointUI_System");
                instance = obj.AddComponent<CheckpointUI>();
                DontDestroyOnLoad(obj);
            }
        }

        void Awake()
        {
            // Build the UI programmatically
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 1000; // Above everything

            gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            gameObject.AddComponent<GraphicRaycaster>();

            // Panel
            popupPanel = new GameObject("PopupPanel");
            popupPanel.transform.SetParent(transform, false);
            
            // Background Image
            Image bg = popupPanel.AddComponent<Image>();
            bg.color = new Color(0, 0, 0, 0.8f);

            RectTransform rect = popupPanel.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(400, 100);
            rect.anchoredPosition = new Vector2(0, 0);

            // Text
            GameObject textObj = new GameObject("PopupText");
            textObj.transform.SetParent(popupPanel.transform, false);
            popupText = textObj.AddComponent<Text>();
            
            // Try LegacyRuntime font first (Unity 6), fallback to Arial
            Font font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            if (font == null) font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            popupText.font = font;

            popupText.fontSize = 32;
            popupText.alignment = TextAnchor.MiddleCenter;
            popupText.color = Color.green;
            popupText.text = "CHECKPOINT SAVED!";
            
            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = Vector2.zero;
            textRect.offsetMax = Vector2.zero;

            // Start hidden
            popupPanel.SetActive(false);
        }

        public static void Show()
        {
            if (instance != null)
            {
                instance.StopAllCoroutines();
                instance.StartCoroutine(instance.ShowPopupRoutine());
            }
        }

        private IEnumerator ShowPopupRoutine()
        {
            popupPanel.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            popupPanel.SetActive(false);
        }
    }
}
