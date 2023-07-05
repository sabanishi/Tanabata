using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CanvasManager:MonoBehaviour
    {
        [SerializeField] private Image blackBack;
        [SerializeField] private GameObject writeObj;
        [SerializeField] private GameObject writeTanzaku;
        [SerializeField] private Image tanzakuImage;
        [SerializeField] private GameObject readObj;
        [SerializeField] private TMP_Text readContent;
        [SerializeField] private TMP_Text readName;
        [SerializeField] private Image readTanzakuImage;
        [SerializeField] private GameObject readTanzaku;

        /// <summary>
        /// 暗転させる
        /// </summary>
        public async UniTask OpenBlackBack()
        {
            //1秒かけて暗転
            await blackBack.DOFade(0, 0.5f).SetEase(Ease.Linear).ToUniTask();
            blackBack.gameObject.SetActive(false);
        }

        public async UniTask WriteStart(Color color)
        {
            tanzakuImage.color = color;
            writeObj.SetActive(true);
            await writeTanzaku.GetComponent<RectTransform>().DOAnchorPosY(0, 0.2f).SetEase(Ease.OutCirc)
                .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        }

        public async UniTask WriteFinish()
        {
            await writeTanzaku.GetComponent<RectTransform>().DOAnchorPosY(1200f, 0.2f).SetEase(Ease.OutCirc)
                .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
            writeObj.SetActive(false);
        }

        public async UniTask ReadStart(TanzakuData data)
        {
            if (ColorUtility.TryParseHtmlString(data._color, out Color color))
            {
                readTanzakuImage.color = color;
            }
            readContent.text = data._content;
            readName.text = data._name;
            readObj.SetActive(true);
            await readTanzaku.GetComponent<RectTransform>().DOAnchorPosY(0, 0.2f).SetEase(Ease.OutCirc)
                .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        }
        
        public async UniTask ReadFinish()
        {
            await readTanzaku.GetComponent<RectTransform>().DOAnchorPosY(1200f, 0.2f).SetEase(Ease.OutCirc)
                .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
            readObj.SetActive(false);
        }
    }
}