namespace DefaultNamespace
{
    /// <summary>
    /// 短冊の作成に必要なデータ
    /// </summary>
    public class TanzakuData
    {
        public readonly string _color;
        public readonly string _content;
        public readonly string _name;

        public TanzakuData(string color, string content, string name)
        {
            _color = color;
            _content= content;
            _name = name;
        }
    }
}