using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConventions
{
    public class DataService
    {
        private IWorkerQueue _workerQueue;

        private static IWorkerQueue s_workerQueue;

        [ThreadStatic]
        private static TimeSpan t_timeSpan;

        public void SomeMethod<T>(int someNumber, bool isValid)
        {
        }
    }

    public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode);

    public struct ValueCoordinate
    {
    }

    public interface IWorkerQueue
    {
    }

    public class ExampleEvents
    {
        // A public field, these should be used sparingly
        public bool IsValid;

        // An init-only property
        public IWorkerQueue WorkerQueue { get; init; }

        // An event
        public event Action EventProcessing;

        // Method
        public void StartEventProcessing()
        {
            // Local function
            static int CountQueueItems() =>20;
            // ...
        }
    }

}
