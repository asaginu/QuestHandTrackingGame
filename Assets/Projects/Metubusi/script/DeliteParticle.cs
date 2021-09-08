using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliteParticle : MonoBehaviour
{
    private ParticleSystem ps;

    private List<ParticleSystem.Particle> enterLists = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleTrigger()
    {
        int enterNum = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterLists);

        for (int i = 0; i < enterNum; i++)
        {
            ParticleSystem.Particle p = enterLists[i];
            p.remainingLifetime = 0f;
            enterLists[i] = p;
        }

    }
}
