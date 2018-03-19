using System;

namespace EventAgregator
{
    public class Manager
    {
        private readonly IEventAgregator eventAgregator;

        public Manager(IEventAgregator eventAgregator)
        {
            this.eventAgregator = eventAgregator;
        }
        
        public void Create()
        {
            eventAgregator.Publish<DocumentCreateEvent>(DocumentCreateEvent.Create(GetId()));
        }

        public void Delete()
        {
            eventAgregator.Publish<DocumentDeleteEvent>(DocumentDeleteEvent.Create(GetId()));
        }

        private string GetId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}