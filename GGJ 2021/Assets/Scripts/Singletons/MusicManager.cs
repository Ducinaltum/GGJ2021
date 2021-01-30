using UnityEngine;
using System.Collections;

//Agregarle un audioSource a la camara y asignarle es clip "dead"
//Ponerle volume 0.2 al audioSource del prefab Laser
//Poner 6 de valor desde el inspector a los clips de "Music Manager"

//EXTRAS
//se le le puede poner 0 al z del collider de la bomba? creo que se ve mejor
//Lo mismo con los torus, si se puede invertir el orden de los aros desde le parent queda mejor que frene de adentro para afuera
//Esos dos últimos puntos son sugerencias, no me quitan el sueño

//Eliminarle un script perdido que tiene la cámara

public enum Ambient{
	intro,
	noActionSync,
	actionOutSync,
	actionSync,
	flow,
	lowHealth,
}

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {
    
    public float bpm = 103.0F;
    public int numBeatsPerSegment = 51*4;

    [Header("In game music")]
    public AudioClip[] inGameMusicClips = new AudioClip[5];

    private double nextEventTime;
    public int flip = 0;
    
    private AudioSource[] musicClipsAuso = new AudioSource[5];
    private bool running = false;

	public int health = 5;

	int track;

    void Start() {

		track = (int)Ambient.intro;
        int i = 0;
        while (i < 2) {
            GameObject child = new GameObject("MusicPlayer");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>();
            i++;
        }
        nextEventTime = AudioSettings.dspTime + 2.0F;
        running = true;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            int track = 0;
            if (health <= 2)
            {
                track = (int)Ambient.lowHealth;
            }
            //Cuando termina el nivel CAMBIAR LA CONDICION
            if (true == false)
            {
                foreach (AudioSource source in audioSources)
                {
                    Destroy(source);
                }
                Camera.main.GetComponent<AudioSource>().Play();
            }

            if (!running)
                return;

            double time = AudioSettings.dspTime;
            if (time + 1.0F > nextEventTime)
            {
                foreach(AudioSource auso in musicClipsAuso){
                    audioSources[flip].clip = clips[(int)track];
                    audioSources[flip].PlayScheduled(nextEventTime);
                }
                nextEventTime += 60.0F / bpm * numBeatsPerSegment;
                //flip = 1 - flip;
            }
        }
    }
}