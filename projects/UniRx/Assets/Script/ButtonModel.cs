using UnityEngine;
using UniRx;

public sealed class ButtonModel
{
    public IReactiveProperty<int> PushCounter { get; private set; } = new ReactiveProperty<int>(0);

    public void PushCount()
    {
        this.PushCounter.Value++;
    }
}
