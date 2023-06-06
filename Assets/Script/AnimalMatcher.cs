using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalMatcher : MonoBehaviour
{
    public List<Sprite> animalImages;
    public List<AudioClip> animalSounds;
    public List<Image> animalImageObjects;
    public AudioClip denySound;
    private AudioSource audioSource;
    private int selectedIndex = -1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SelectAnimalImage(int index)
    {
        selectedIndex = index;
    }

    public void CheckMatch(int animalIndex)
    {
        if (selectedIndex == -1)
        {
            return;
        }

        string animalName = animalImages[animalIndex].name;
        string selectedAnimalImageName = animalImageObjects[selectedIndex].sprite.name;

        if (animalName.Equals(selectedAnimalImageName, System.StringComparison.OrdinalIgnoreCase))
        {
            audioSource.clip = animalSounds[animalIndex];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = denySound;
            audioSource.Play();
        }

        selectedIndex = -1;
    }
}
