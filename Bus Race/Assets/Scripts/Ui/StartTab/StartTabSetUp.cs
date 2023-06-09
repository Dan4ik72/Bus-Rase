using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTabSetUp : MonoBehaviour
{
    [SerializeField] private ButtonView _playButtonView;
    
    private ButtonModel _playButtonModel;

    private ButtonPresenter _playButtonPresenter;

    public ButtonModel PlayButtoonModel => _playButtonModel;

    public void Awake()
    {
        InitStartButton();
    }

    private void InitStartButton()
    {
        _playButtonModel = new LoadSceneButtonModel();
        _playButtonPresenter = new ButtonPresenter(_playButtonModel, _playButtonView);

    }

    private void OnDestroy()
    {
        _playButtonPresenter.Disable();
    }
}
