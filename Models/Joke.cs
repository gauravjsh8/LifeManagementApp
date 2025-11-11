namespace LifeManagementApp.Models
{
    public class Joke
    {
        public string Content { get; set; } = string.Empty;

        public override string ToString() => Content;
    }

    public class OneLinerJoke : Joke
    { }

    public class TwoLinerJoke : Joke
    {
        public string Setup { get; set; } = string.Empty;
        public string Delivery { get; set; } = string.Empty;

        public override string ToString() => $"{Setup} {Delivery}";
    }
}