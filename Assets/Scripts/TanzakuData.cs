namespace DefaultNamespace
{
    /// <summary>
    /// 短冊の作成に必要なデータ
    /// </summary>
    public class TanzakuData
    {
        public readonly int _posIndex;
        public readonly string _content;
        public readonly string _name;

        public TanzakuData(int posIndex, string content, string name)
        {
            _posIndex = posIndex;
            _content= content;
            _name = name;
        }
    }
}