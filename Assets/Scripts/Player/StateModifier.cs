namespace SpaceJailRunner.Player
{
    internal class StateModifier : PlayerModifier
    {
        private PlayerState _playerState;
        
        public StateModifier(Player player, PlayerState playerState) : base(player)
        {
            _playerState = playerState;
        }

        public override void Handle()
        {
            _player.State = _playerState;
            base.Handle();
        }
    }
}