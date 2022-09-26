namespace my_book_store_v1.Exceptions
{
    [Serializable]
    public class PublisherNameException:Exception
    {
        public string PublisherName { get; set; }
        public PublisherNameException()
        {
            Console.WriteLine("ex1");
        }
        public PublisherNameException(string message):base(message)
        {
            Console.WriteLine(message+2);
        }
        public PublisherNameException(string message,Exception inner):base(message, inner)
        {
            Console.WriteLine(message+3);
        }
        public PublisherNameException(string message,string publisherName):this(message)
        {
            PublisherName = publisherName;       
        }
    }
}
