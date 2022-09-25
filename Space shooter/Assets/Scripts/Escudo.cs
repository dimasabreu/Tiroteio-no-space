using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField] private AudioClip somEscudoUp;
    [SerializeField] private AudioClip somEscudoDown;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(somEscudoUp, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        AudioSource.PlayClipAtPoint(somEscudoDown, Vector3.zero);
    }
}


