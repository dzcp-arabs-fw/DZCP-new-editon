// Player Events

using System.Collections.Generic;

public class PlayerJoinedEvent : IEvent {
    public ReferenceHub Player { get; }
    public bool IsCancellable => false;

    public bool IsCancelled { get; set; }

    public EventPriority Priority { get; set; }
    // ... Implementation
}

public class PlayerShootEvent : IEvent {
    public ReferenceHub Shooter { get; }
    public ItemType Weapon { get; }
    public bool IsHeadshot { get; set; }
    public bool IsCancellable => true;

    public bool IsCancelled { get; set; }

    public EventPriority Priority { get; set; }
    // ... Implementation
}

// Round Events
public class RoundStartEvent : IEvent {
    public List<ReferenceHub> Players { get; }
    // ... Implementation
    public bool IsCancellable { get; }
    public bool IsCancelled { get; set; }
    public EventPriority Priority { get; set; }
}