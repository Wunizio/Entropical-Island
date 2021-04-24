using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStarField : MonoBehaviour
{
    public int starsMax = 100;
    public float starSize = 1.0f;
    public float starDistance = 10f;
    public float starClipDistance = 1f;

    private Transform tx;
    private ParticleSystem.Particle[] points;
    private float starDistanceSqr;
    private float starClipDistanceSqr;

    void Start()
    {
        tx = transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }


    void Update()
    {
        if (points == null)
        {
            CreateStars();
        }

        for (int i = 0; i < starsMax; i++)
        {
            if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            }

            if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
                points[i].color = new Color(1,1,1, percent);
                points[i].size = percent * starSize;
            }
        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].startColor = Color.white;
            points[i].startSize = starSize;
        }
    }
}
