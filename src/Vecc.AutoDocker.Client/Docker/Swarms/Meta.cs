﻿using System;

namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Meta
    {
        public SwarmVersion Version { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
