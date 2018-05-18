using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using System;

public class ButtonPresenter : MonoBehaviour
{
    // View
    [SerializeField] private Button m_button;

    // View
    [SerializeField] private Text m_buttonText;

    private bool m_isA = false;

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
            .Subscribe(count => m_buttonText.text = count.ToString())
            .AddTo(gameObject);

        // 毎フレーム監視して条件式がtrueのときに処理を実行
        this.ObserveEveryValueChanged(a => a.m_isA).Subscribe(_ => Debug.Log("m_isAがtrueになりました")).AddTo(gameObject);
    }
    private void Awake()
    {
        InitializeField();

        AttachEvent();
    }

    private void Start()
    {
        this.FixedUpdateAsObservable() // 毎フレームごとに
            .Where(_ => m_buttonModel.PushCounter.Value >= 10) // 10以上かのチェックを行い
            .Subscribe(_ => Destroy(m_button)); // 10以上ならDestroy
    }
}