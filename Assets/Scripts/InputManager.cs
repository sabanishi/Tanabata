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
        
        public void Decide()
        {
            myNCMBManager.Save(new TanzakuData(0, textInput.text, nameInput.text));
        }

        public void Cancel()
        {
            
        }
    }
}