using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DefaultNamespace
{
    /// <summary>
    /// 短冊を作成するクラス
    /// </summary>
    public class TanzakuGenerator:MonoBehaviour
    {
        [SerializeField] private StageTanzaku tanzakuPrefab;
        [SerializeField] private Transform _posTransform;
        [SerializeField] private InputManager _inputManager;
        private int amount = 0;
        private Vector3[] posArray = new Vector3[50];

        private Transform _transform;
        //50までの数字をいれたSet
        private List<int> _canUseIndexList = new List<int>();

        public void Init(TanzakuData[] allData)
        {
            _transform = transform;
            for (int i = 0; i < _posTransform.childCount; i++)
            {
                posArray[i]= _posTransform.GetChild(i).localPosition;
                _canUseIndexList.Add(i);
            }
            //_canUseIndexListをシャッフルする
            _canUseIndexList = _canUseIndexList.OrderBy(i => System.Guid.NewGuid()).ToList();

            foreach (var data in allData)
            {
                Generate(data);
            }
        }

        public void Generate(TanzakuData data)
        {
            amount++;
            if(amount>50)
            {
                Debug.LogError("短冊の数が50を超えました");
                return;
            }
            int randNum = _canUseIndexList[0];
            _canUseIndexList.RemoveAt(0);
            var tanzaku = Instantiate(tanzakuPrefab,_transform);
            tanzaku.SetData(data,_inputManager);
            tanzaku.gameObject.transform.localPosition = posArray[randNum];
        }
    }
}