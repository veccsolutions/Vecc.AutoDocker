﻿namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public enum TaskState
    {
        New,
        Allocated,
        Pending,
        Assigned,
        Accepted,
        Preparing,
        Ready,
        Starting,
        Running,
        Complete,
        Shutdown,
        Failed,
        Rejected,
        Remove,
        Orphaned
    }
}
