public interface EnemyBehavior
{
    bool CanEnterBehavior();
    void EnterState();
    void Act();
    void ExitState();
}