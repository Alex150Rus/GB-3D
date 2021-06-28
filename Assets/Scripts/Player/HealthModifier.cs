namespace SpaceJailRunner.Player
{
    internal class HealthModifier: PlayerModifier
    {
        private float _hp;
        
        public HealthModifier(Player player, float hp) : base(player)
        {
            _hp = hp;
        }
        
        public override void Handle()
        {
            _player.Health.HealthPoints = _hp;
            base.Handle();
        }
    }
}