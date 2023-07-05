using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// 入力を受け取るクラス
    /// </summary>
    public class InputManager:MonoBehaviour
    {
        [SerializeField] private TMP_InputField textInput;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField]private MyNCMBManager myNCMBManager;
        [SerializeField] private CanvasManager canvasManager;
        [SerializeField] private TanzakuGenerator tanzakuGenerator;

        private List<Color> _colorList = new List<Color>()
        {
            new Color(210f/255f,198f/255f,1f),
            new Color(1,1,1),
            new Color(1,253f/255f,198f/255f),
            new Color(1,198f/255f,198f/255f),
            new Color(188f/255f,225f/255f,164f/255f),
        };

        private Color _nowColor;

        public void Create()
        {
            textInput.text = "";
            nameInput.text = "";
            Color color = _colorList[new System.Random().Next(0, _colorList.Count)];
            canvasManager.WriteStart(color).Forget();
            _nowColor = color;
        }
        
        public void Decide()
        {
            TanzakuData data = new TanzakuData("#"+ColorUtility.ToHtmlStringRGB(_nowColor), textInput.text, nameInput.text);
            myNCMBManager.Save(data);
            tanzakuGenerator.Generate(data);
            canvasManager.WriteFinish().Forget();
        }

        public void Cancel()
        {
            canvasManager.WriteFinish().Forget();
        }
        
        public void CancelRead()
        {
            canvasManager.ReadFinish().Forget();
        }

        public void StartRead(TanzakuData data)
        {
            canvasManager.ReadStart(data).Forget();
        }
    }
}