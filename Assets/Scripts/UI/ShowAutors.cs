using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAutors : MonoBehaviour
{
    [SerializeField] public GameObject Text;

    private void Start()
    {
        Text.SetActive(false);
    }

    public void SetTextActive()
    {
        Text.SetActive(true);
    }
}
