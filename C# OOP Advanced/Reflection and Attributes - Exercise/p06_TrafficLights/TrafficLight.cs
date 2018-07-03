using System;

public class TrafficLight
{
    private Signal signal;

    public TrafficLight(string signal)
    {
        this.signal = Enum.Parse<Signal>(signal, true);
    }

    public void Update()
    {
        int previous = (int) this.signal;

        signal = (Signal) (++previous % Enum.GetNames(typeof(Signal)).Length);
    }
}