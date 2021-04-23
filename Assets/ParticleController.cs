using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem goodRedParticles;
    [SerializeField] ParticleSystem goodBlueParticles;
    [SerializeField] ParticleSystem goodGreenParticles;
    [SerializeField] ParticleSystem goodYellowParticles;

    [SerializeField] ParticleSystem perfectRedParticles;
    [SerializeField] ParticleSystem perfectBlueParticles;
    [SerializeField] ParticleSystem perfectGreenParticles;
    [SerializeField] ParticleSystem perfectYellowParticles;



    public void GoodHit(string noteType)
    {
        switch (noteType)
        {
            case "Red":
                goodRedParticles.Play();
                break;
            case "Blue":
                goodBlueParticles.Play();
                break;
            case "Green":
                goodGreenParticles.Play();
                break;
            case "Yellow":
                goodYellowParticles.Play();
                break;
        }
    }

    public void PerfectHit(string noteType)
    {
        switch (noteType)
        {
            case "Red":
                perfectRedParticles.Play();
                break;
            case "Blue":
                perfectBlueParticles.Play();
                break;
            case "Green":
                perfectGreenParticles.Play();
                break;
            case "Yellow":
                perfectYellowParticles.Play();
                break;
        }
    }

}
