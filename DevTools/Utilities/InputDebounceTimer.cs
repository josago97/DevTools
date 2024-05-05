using Timer = System.Timers.Timer;

namespace DevTools.Utilities;

public class InputDebounceTimer
{
    private static readonly TimeSpan DEFAULT_TIME = TimeSpan.FromSeconds(0.75);

    private Timer _timer;

    public bool AutoReset { get => _timer.AutoReset; set => _timer.AutoReset = value; }
    public bool Enabled { get => _timer.Enabled; set => _timer.Enabled = value; }

    public event Action Elapsed;

    public InputDebounceTimer(TimeSpan time)
    {
        _timer = new Timer(time)
        {
            AutoReset = false
        };

        _timer.Elapsed += OnTimerElapsed;
    }

    public InputDebounceTimer() : this(DEFAULT_TIME) { }

    public void Start()
    {
        _timer.Stop();
        _timer.Start();
    }

    private void OnTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        Elapsed?.Invoke();
    }
}
