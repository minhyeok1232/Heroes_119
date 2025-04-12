using UnityEngine;
using UnityEngine.UIElements;
namespace Esper.Freeloader
{
    public class MainMenu : MonoBehaviour
    {
        // UI Document
        protected UIDocument document;

        // root
        protected VisualElement root;

        // Button
        public Button _playButton;
        public Button _settingButton;
        public Button _exitButton;

        // SingleTon
        public static MainMenu Instance { get; private set; }

        protected virtual void Awake()
        {
            // Singleton
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            document = GetComponent<UIDocument>();
            root = document.rootVisualElement.Q<VisualElement>("Root");

            // 1. 각 버튼을 가져옴
            _playButton = document.rootVisualElement.Q<Button>("PlayButton");
            _settingButton = document.rootVisualElement.Q<Button>("SettingButton");
            _exitButton = document.rootVisualElement.Q<Button>("ExitButton");
        }
    }
}