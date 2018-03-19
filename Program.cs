using System;

namespace EventAgregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumer = new Consumer(EventAgregator.Instance);
            var manager = new Manager(EventAgregator.Instance);

            manager.Create();
            manager.Delete();
        }
    }
}
