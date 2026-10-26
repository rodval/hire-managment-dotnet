namespace HireManagement.Persistence.Entities
{
    /// <summary>
    /// Pre-computed PBKDF2 hashes for the development seed users ("P@ssword1" … "P@ssword4").
    /// They are constants so that model snapshots stay deterministic across migrations.
    /// </summary>
    internal static class SeedPasswordHashes
    {
        public const string Password1 = "AQAAAAIAAYagAAAAELPq+hY9Z71CyxxHiZeGangJypuVg6nZnxVJIqkXnngZVdpMq9sOeTt0cQxl3L2AeA==";
        public const string Password2 = "AQAAAAIAAYagAAAAEP/KL4fCXUwayqMRuQvV5vsbnZKls+Gi0aM6/hJQdURNc7XnW62io1z3effu/gLXdQ==";
        public const string Password3 = "AQAAAAIAAYagAAAAEE+uB2FjxI7+/OZp7o9GIGii89uNWlL9uAUCSn2etz4vL3HYNNbQ3qVNylFfur4Y1A==";
        public const string Password4 = "AQAAAAIAAYagAAAAEPfcs6EROgM0MdKcRpvnizut39TBlMOZ2sOcWnhYCX4TrBkKvt3bGhV/ptyM6xz7pw==";
    }
}
