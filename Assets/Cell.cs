using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    private UnityEvent<Cell> clicked = new UnityEvent<Cell>();

    public void subscribeToClicked(UnityAction<Cell> action) {
        this.clicked.AddListener(action);
    }

    public void invokeClicked() {
        this.clicked.Invoke(this);
    }
}
