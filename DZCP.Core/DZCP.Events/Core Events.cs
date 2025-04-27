// Core Event Types
public enum EventPriority {
    Highest = 0,
    High = 1,
    Normal = 2,
    Low = 3,
    Lowest = 4,
    Monitor = 5 // Read-only
}

public interface IEvent {
    bool IsCancellable { get; }
    bool IsCancelled { get; set; }
    EventPriority Priority { get; set; }
}