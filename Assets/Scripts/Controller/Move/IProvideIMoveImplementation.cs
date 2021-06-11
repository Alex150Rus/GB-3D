using SpaceJailRunner.Controller.Interface;

namespace SpaceJailRunner.Controller.Move
{
    internal interface IProvideIMoveImplementation
    {
        public IMove GetMoveImplementation(MoveType moveType);
    }
}