using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;

namespace Esper.Freeloader.Examples
{
    public class Demo : MonoBehaviour
    {
        [Header("UI Documents")]
        
        // Loading 진행률 (progress)
        private static float progress;

        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            HideUI(LoadingScreen.Instance);  // 시작 시 로딩 화면 가림
            ShowUI(MainMenu.Instance);       // 메인 메뉴 보여줌
            SetupMainMenuUI();
        }
        
        void SetupMainMenuUI()
        {
            // 2. Call Back 연결
            MainMenu.Instance._playButton.clicked += () =>
            {
                HideUI(MainMenu.Instance);           // 메인 메뉴 숨김
                ShowUI(LoadingScreen.Instance);      // 로딩 화면 표시
                StartLoadingSequence().Forget();
            };
            //_settingButton.clicked += SettingButtonClicked;
            //_exitButton.clicked += ExitButtonClicked;
        }
        
        // 예외처리 X, Return X
        private async UniTaskVoid StartLoadingSequence()
        {
            progress = 0;   // 진행률 0% 시작

            await UniTask.Delay(200);
            
            if (!LoadingScreen.Instance.IsLoading)
            {
                // Tracker 사용 : 진행률 추적(process) 
                var process = new LoadingProgressTracker("Loading...", () => progress);
                LoadingScreen.Instance.Load("Demo_Scene", process);
            }

            while (progress < 100)
            {
                progress += 10;
                await UniTask.Delay(1000);
            }
        }

        // ==================================== UI Control ====================================
        private void HideUI(MonoBehaviour mono)
        {
            var doc = mono.GetComponent<UIDocument>();
            if (doc != null)
                doc.rootVisualElement.visible = false; // root Safe
        }

        private void ShowUI(MonoBehaviour mono)
        {
            var doc = mono.GetComponent<UIDocument>();
            if (doc != null)
                doc.rootVisualElement.visible = true;
        }
    }
}