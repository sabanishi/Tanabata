using UnityEngine;

namespace DefaultNamespace
{
    public class StageTanzaku:MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        private TanzakuData _data;
        private InputManager _inputManager;

        public void SetData(TanzakuData data,InputManager inputManager)
        {
            _data = data;
            if(ColorUtility.TryParseHtmlString(data._color, out Color color))
            {
                _sprite.color = color;
            }
            else
            {
                Debug.Log("Cannot parse color:"+data._color);
            }
            
            _inputManager = inputManager;
        }
        
        public void OnClick()
        {
            _inputManager.StartRead(_data);
        }
    }
}