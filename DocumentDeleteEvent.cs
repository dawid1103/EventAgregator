namespace EventAgregator
{
    public class DocumentDeleteEvent
    {
        public string ID { get; private set; }

        private DocumentDeleteEvent(string id)
        {
            ID = id;
        }

        public static DocumentDeleteEvent Create(string id){
            return new DocumentDeleteEvent(id);
        }
    }
}