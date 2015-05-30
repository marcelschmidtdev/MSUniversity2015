﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour, IUIScreen 
{
	public UIState StateId { get { return UIState.PauseScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
        var selectedGo = GetComponentInChildren<Button>().gameObject;
        EventSystem.current.SetSelectedGameObject(selectedGo);
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void GotoMainMenu () {
		UIScreenHandler.Instance.ChangeState( UIState.MainScreen );
	}

	public void Continue () {
		UIScreenHandler.Instance.ChangeState( UIState.IngameScreen );
	}

    void Update()
    {
        if( Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))
        {
            Continue();
        }
    }
}
