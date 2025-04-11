using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;

namespace Esper.Freeloader.Examples
{
    public class Demo : MonoBehaviour
    {
        // Loading 진행률 (progress)
        private static float progress;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            StartLoadingSequence().Forget();
        }

        // 예외처리 X, Return X
        private async UniTaskVoid StartLoadingSequence()
        {
            progress = 0;   // 진행률 0% 시작

            UIDocument doc = LoadingScreen.Instance.GetComponent<UIDocument>();
            if (doc != null) doc.enabled = true;

            await UniTask.Delay(2000);
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
    }
}