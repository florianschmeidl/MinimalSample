namespace Straumann.Core
{
    public interface IApplicationState
    {
        ApplicationStateType ApplicationStateType { get; }
        void Enter();
        void Exit();
    }
}