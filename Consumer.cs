using System;

namespace EventAgregator
{
    public class Consumer
    {
        public Consumer(IEventAgregator ea)
        {
            ea.Subscribe<DocumentCreateEvent>((a) =>
            {
                Console.WriteLine($"{typeof(DocumentCreateEvent)} ID : {a.ID}");
            });

            ea.Subscribe<DocumentDeleteEvent>((a) =>
            {
                Console.WriteLine($"{typeof(DocumentDeleteEvent)} ID : {a.ID}");
            });
        }
    }
}