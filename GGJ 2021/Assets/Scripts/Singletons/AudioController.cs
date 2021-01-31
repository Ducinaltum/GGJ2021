using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    
	private static AudioController _instanceAC;
    public AudioMixer masterMix;
    [SerializeField]
    AudioMixer _ambientMix;

    [SerializeField]
    AudioSource _tinnitusAS;
    
    public MusicManager music;
	public static AudioController InstanceAC {
		get {
			return _instanceAC;
		}
	}

	private void Awake()
	{
		if(_instanceAC == null) {
			_instanceAC = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			//Nunca debería entrar acá
			Destroy(this);
		}
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAmbientCaveHPF(float value){
        _ambientMix.SetFloat("ambientHPF", value);
    }

    public void SetTinnitusVolume(float value){
        _tinnitusAS.volume = value;
    }

    
}
