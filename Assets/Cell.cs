using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    private UnityEvent clicked = new UnityEvent();

    public void subscribeToClicked(UnityAction action) {
        this.clicked.AddListener(action);
    }

    public void invokeClicked() {
        this.clicked.Invoke();
        Debug.Log(this.transform.position);
    }
}
