namespace Actio.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }

        int Code { get; }
    }
}