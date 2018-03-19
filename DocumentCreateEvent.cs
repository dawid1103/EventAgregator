namespace EventAgregator
{
    public class DocumentCreateEvent
    {
        public string ID { get; private set; }

        private DocumentCreateEvent(string id)
        {
            ID = id;
        }

        public static DocumentCreateEvent Create(string id){
            return new DocumentCreateEvent(id);
        }
    }
}