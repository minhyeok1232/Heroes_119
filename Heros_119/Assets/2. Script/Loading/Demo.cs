using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;

namespace Esper.Freeloader.Examples
{
    public class Demo : MonoBehaviour
    {
        [Header("UI Documents")]
        
        // Loading ����� (progress)
        private static float progress;

        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            HideUI(LoadingScreen.Instance);  // ���� �� �ε� ȭ�� ����
            ShowUI(MainMenu.Instance);       // ���� �޴� ������
            SetupMainMenuUI();
        }
        
        void SetupMainMenuUI()
        {
            // 2. Call Back ����
            {
                // Play Button
                MainMenu.Instance._playButton.clicked += () =>
                {
                    HideUI(MainMenu.Instance); 
                    ShowUI(LoadingScreen.Instance);
                    StartLoadingSequence().Forget();
                };
                
                // Setting Button
                MainMenu.Instance._settingButton.clicked += () =>
                {
                    HideUI(MainMenu.Instance); 
                    ShowUI(LoadingScreen.Instance); 
                    StartLoadingSequence().Forget();
                    
                    //_settingButton.clicked += SettingButtonClicked;
                };
                
                // Exit Button
                MainMenu.Instance._exitButton.clicked += () =>
                {
                    // Build
                    Application.Quit(); 
                    
                    // Editor
                    #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                    #endif
                };
            }
        }
        
        // ����ó�� X, Return X
        private async UniTaskVoid StartLoadingSequence()
        {
            progress = 0;   // ����� 0% ����

            await UniTask.Delay(200);
            
            if (!LoadingScreen.Instance.IsLoading)
            {
                // Tracker ��� : ����� ����(process) 
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