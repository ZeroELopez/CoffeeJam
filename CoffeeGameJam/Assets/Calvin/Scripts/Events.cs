namespace Assets.Scripts.Base.Events
{
    public class EnemySpawned : DispatchableEvent
    {
        //Intentionally Empty class.
    }

    public class EnemyDisposed : DispatchableEvent
    {
        //Intentionally Empty class.
    }

    public class PlayerPowerUpStart : DispatchableEvent { }
    public class PlayerPowerUpEnd : DispatchableEvent { }

    public class TogglePause : DispatchableEvent
    {
        
    }

    public class EnemyIsHit : DispatchableEvent {
        public EnemyEntity hitEnemy;
    }
    public class PlayerIsHit : DispatchableEvent { }

    public class HideHealthbar : DispatchableEvent { }
    public class ShowHealthbar : DispatchableEvent { }

    public class TryAgain : DispatchableEvent { }
    public class ExitToMainMenu : DispatchableEvent { }
}
