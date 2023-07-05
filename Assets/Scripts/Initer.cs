using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace
{
    public class Initer:MonoBehaviour
    {
        [SerializeField]private MyNCMBManager myNCMBManager;
        [SerializeField] private CanvasManager canvasManager;
        [SerializeField]private TanzakuGenerator tanzakuGenerator;

        private void Start()
        {
            AwakeInternal().Forget();
        }

        private async UniTask AwakeInternal()
        {
            // サーバーからデータを取得する
            var tanzakuData = await myNCMBManager.Fetch();
            // 短冊を作成する
            tanzakuGenerator.Init(tanzakuData);
            
            //暗転させる
            await canvasManager.OpenBlackBack();
        }
    }
}