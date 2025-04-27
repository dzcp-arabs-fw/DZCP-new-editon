namespace DZCP.Events
{
    public struct PlayerHurtEvent
    {
        public int AttackerId;
        public int VictimId;
        public float Damage;
        public string DamageType;

        public PlayerHurtEvent(int attacker, int victim, float damage, string type)
        {
            AttackerId = attacker;
            VictimId = victim;
            Damage = damage;
            DamageType = type;
        }
    }
}