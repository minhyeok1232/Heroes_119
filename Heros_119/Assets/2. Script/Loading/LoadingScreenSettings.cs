using System.Collections.Generic;
using UnityEngine;

// SO ==> 로딩 화면을 커스터마이징
namespace Esper.Freeloader
{
    [CreateAssetMenu(fileName = "LoadingScreenSettings", menuName = "Freeloader/Loading Screen Settings", order = 1)]
    public class LoadingScreenSettings : ScriptableObject
    {
        public string settingsName = "Name";

        public string tipAnimatorPseudoClassName;

        public string loadingLabelAnimatorPseudoClassName;

        public string continueLabelAnimatorPseudoClassName;

        public string backgroundScaleAnimatorPseudoClassName;

        public bool hideBar;

        public string defaultLoadingText = "Loading...";

        public bool showPercentage = true;

        public bool showSpinner = true;

        public float spinnerSpeed = 1f;

        public Texture2D spinnerIcon;

        public List<Texture2D> backgrounds;

        public float backgroundDisplayLength = 6;

        public bool enableBackgroundZoom;

        public bool showTips = true;
        
        public List<string> tips;
        
        public string tipsTitle = "Tip";
        
        public float tipDisplayLength = 6;
        
        public bool requireInputToContinue;

        public string continueText = "Continue";

#if UNITY_EDITOR
        public void Save()
        {
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.AssetDatabase.SaveAssetIfDirty(this);
        }
#endif
    }
}