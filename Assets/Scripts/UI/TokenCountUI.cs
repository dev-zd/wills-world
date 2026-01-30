using System.Collections;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    /// <summary>
    /// A robust, automated UI meter that creates its own Canvas and Text at runtime.
    /// This fixes visibility issues found in legacy OnGUI and removes manual setup steps.
    /// Features: Rolling numbers, Scale pulsing, and auto-scaling for high resolutions.
    /// </summary>
    public class TokenCountUI : MonoBehaviour
    {
        private PlatformerModel model;

        [Header("Animation Settings")]
        public float rollDuration = 0.5f;
        public float pulseScale = 1.25f;
        public float pulseDuration = 0.25f;

        private Text _coinText;
        private RectTransform _container;
        private int _displayedCount = 0;
        private Vector3 _originalScale;
        private Coroutine _rollCoroutine;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void AutoSpawn()
        {
            // Clean up any old instances to avoid duplicates
            var old = GameObject.Find("TokenCountUI_Runtime_Instance");
            if (old != null) DestroyImmediate(old);

            var obj = new GameObject("TokenCountUI_Runtime_Instance");
            obj.AddComponent<TokenCountUI>();
            DontDestroyOnLoad(obj);
        }

        void Awake()
        {
            model = Simulation.GetModel<PlatformerModel>();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Create Canvas
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 999; // Ensure it's on top

            CanvasScaler scaler = gameObject.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);

            gameObject.AddComponent<GraphicRaycaster>();

            // 2. Create Container (for pulsing)
            GameObject containerObj = new GameObject("Container", typeof(RectTransform));
            containerObj.transform.SetParent(transform, false);
            _container = containerObj.GetComponent<RectTransform>();
            _container.anchorMin = new Vector2(0, 1);
            _container.anchorMax = new Vector2(0, 1);
            _container.pivot = new Vector2(0, 1);
            _container.anchoredPosition = new Vector2(40, -40);
            _container.sizeDelta = new Vector2(250, 80);
            _originalScale = Vector3.one;

            // 3. Background (Making it invisible as requested)
            GameObject bgObj = new GameObject("Background", typeof(RectTransform), typeof(Image));
            bgObj.transform.SetParent(_container, false);
            Image bgImage = bgObj.GetComponent<Image>();
            bgImage.color = new Color(0, 0, 0, 0); // Transparent
            RectTransform bgRect = bgObj.GetComponent<RectTransform>();
            bgRect.anchorMin = Vector2.zero;
            bgRect.anchorMax = Vector2.one;
            bgRect.sizeDelta = Vector2.zero;

            // 4. Create Text
            GameObject textObj = new GameObject("Text", typeof(RectTransform), typeof(Text));
            textObj.transform.SetParent(_container, false);
            _coinText = textObj.GetComponent<Text>();
            
            // Try to load a standard font, fallback to LegacyRuntime for Unity 6 compatibility
            _coinText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            if (_coinText.font == null) _coinText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            _coinText.fontSize = 32;
            _coinText.fontStyle = FontStyle.Bold;
            _coinText.alignment = TextAnchor.UpperLeft;
            _coinText.color = Color.yellow;
            _coinText.supportRichText = true;

            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;

            if (model == null) model = Simulation.GetModel<PlatformerModel>();
            UpdateText(model != null ? model.tokens : 0);
        }

        void Update()
        {
            if (model == null) model = Simulation.GetModel<PlatformerModel>();
            if (model == null) return;

            if (model.tokens != _displayedCount)
            {
                // Number has changed!
                if (_rollCoroutine != null) StopCoroutine(_rollCoroutine);
                _rollCoroutine = StartCoroutine(AnimateCoinCount(model.tokens));
                
                StartCoroutine(PulseAnimation());
                _displayedCount = model.tokens;
            }
        }

        private IEnumerator AnimateCoinCount(int targetValue)
        {
            // Extract current number from text safely
            string currentStr = _coinText.text.Replace("COINS: ", "");
            int startValue;
            if (!int.TryParse(currentStr, out startValue)) startValue = _displayedCount;

            float elapsed = 0;
            while (elapsed < rollDuration)
            {
                elapsed += Time.deltaTime;
                float progress = elapsed / rollDuration;
                // Ease out cubic for more natural movement
                progress = 1f - Mathf.Pow(1f - progress, 3f);
                
                int currentValue = Mathf.RoundToInt(Mathf.Lerp(startValue, targetValue, progress));
                UpdateText(currentValue);
                yield return null;
            }
            UpdateText(targetValue);
        }

        private IEnumerator PulseAnimation()
        {
            float elapsed = 0;
            // Scale up
            while (elapsed < pulseDuration / 2)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / (pulseDuration / 2);
                _container.localScale = Vector3.Lerp(_originalScale, _originalScale * pulseScale, t);
                yield return null;
            }
            // Scale down
            elapsed = 0;
            while (elapsed < pulseDuration / 2)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / (pulseDuration / 2);
                _container.localScale = Vector3.Lerp(_originalScale * pulseScale, _originalScale, t);
                yield return null;
            }
            _container.localScale = _originalScale;
        }

        private void UpdateText(int value)
        {
            if (_coinText != null)
                _coinText.text = "COINS: " + value;
        }
    }
}
