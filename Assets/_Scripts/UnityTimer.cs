public class UnityTimer {

    public enum TimerState {
        Ticking, Stopped
    }

    private float totalTime;
    private float timer;

    private TimerState state;
    public TimerState State {
        get {
            return state;
        }
    }

    public UnityTimer(float totalTime) {
        this.totalTime = totalTime;
        timer = totalTime;
        state = TimerState.Stopped;
    }

    public TimerState Tick(float deltaTime) {
        if (state == TimerState.Stopped) {
            state = TimerState.Ticking;
        }

        timer -= deltaTime;

        if (timer <= 0) {
            timer = totalTime;
            state = TimerState.Stopped;
        }

        return state;
    }
}
