using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NCMB;
using UnityEngine;

namespace DefaultNamespace
{
    public class MyNCMBManager:MonoBehaviour
    {
        private const string APP_KEY = "Content";
        /// <summary>
        /// サーバーにデータを保存する
        /// </summary>
        /// <param name="data"></param>
        public void Save(TanzakuData data)
        {
            NCMBObject saveClass = new NCMBObject(APP_KEY);
            saveClass["color"] = data._color;
            saveClass["content"] = data._content;
            saveClass["name"] = data._name;
            saveClass.SaveAsync();
        }

        public async UniTask<TanzakuData[]> Fetch()
        {
            List<NCMBObject> results = null;
            bool isDone = false;
            
            NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(APP_KEY);
            query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
            {
                if (e != null)
                {
                    Debug.Log("Error:" + e.ErrorMessage);
                }
                else
                {
                    results = objList;
                }
                isDone = true;
            });

            await UniTask.WaitUntil(() => isDone, cancellationToken: this.GetCancellationTokenOnDestroy());
            
            var tanzakuData = new TanzakuData[results.Count];
            for (int i = 0; i < results.Count; i++)
            {
                tanzakuData[i] = new TanzakuData(results[i]["color"].ToString(), results[i]["content"].ToString(), results[i]["name"].ToString());
            }
            return tanzakuData;
        }
    }
}