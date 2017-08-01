using System.Collections.Generic;

namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    public interface IEventStore
    {
        void Append(Event @event);
        IReadOnlyCollection<T> HoleEvents<T>(string aggregateId) where T : Event;
        IReadOnlyCollection<Event> HoleEvents(string aggregateId);
        Benutzer HoleAggregat(string aggregateId);
    }
}