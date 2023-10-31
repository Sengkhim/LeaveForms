namespace Share.Wapper
{
    public interface IResponse
    {
        public bool Succeed { get; set; }
        public List<string> Messages { get; set; }
        public List<string> Errors { get; set; }
    }

    public interface IResponse<out T> : IResponse
    {
        public T Data { get; }
    }
}