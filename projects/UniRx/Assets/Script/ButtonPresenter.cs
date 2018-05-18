using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ButtonPresenter : MonoBehaviour
{
    // View
    [SerializeField] private Button m_button;

    // View
    [SerializeField] private Text m_buttonText;

    // Model
    private ButtonModel m_buttonModel;

    private void InitializeField()
    {
        m_buttonModel = new ButtonModel();
    }

    private void AttachEvent()
    {
        // ボタンにイベントをアタッチする
        m_button.OnClickAsObservable()
            .Subscribe(_ => m_buttonModel.PushCount());

        m_buttonModel.PushCounter
            .Subscribe(count => m_buttonText.text = count.ToString());
    }
    private void Awake()
    {
        InitializeField();

        AttachEvent();
    }
}