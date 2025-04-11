using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;

namespace Esper.Freeloader.Examples
{
    public class Demo : MonoBehaviour
    {
        // Loading ����� (progress)
        private static float progress;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            StartLoadingSequence().Forget();
        }

        // ����ó�� X, Return X
        private async UniTaskVoid StartLoadingSequence()
        {
            progress = 0;   // ����� 0% ����

            UIDocument doc = LoadingScreen.Instance.GetComponent<UIDocument>();
            if (doc != null) doc.enabled = true;

            await UniTask.Delay(2000);
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
    }
}