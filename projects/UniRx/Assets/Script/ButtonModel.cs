using UnityEngine;
using UniRx;

public sealed class ButtonModel
{
    public ReactiveProperty<int> PushCounter { get; private set; } = new ReactiveProperty<int>();

    public ButtonModel()
    {
        PushCounter.Value = 0;
    }

    public void PushCount()
    {
        this.PushCounter.Value++;
    }
}
