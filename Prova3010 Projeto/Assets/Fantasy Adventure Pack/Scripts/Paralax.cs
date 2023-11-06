using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(5f, 0.06f)]
    public float parallaxSpeed;

    int currentBackground = 0;


    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int BackCount = transform.childCount;
        mat = new Material[BackCount];
        backSpeed = new float[BackCount];
        backgrounds = new GameObject[BackCount];

        for (int i = 0; i < BackCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        backSpeedCalculate(BackCount);
    }
    void backSpeedCalculate(int BackCount)
    {
        for (int i = 0; i < BackCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < BackCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }


    }
    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }

        // Check if the player has traveled a certain distance
        if (distance > 500f)
        {
            // Increment the current background counter
            currentBackground++;

            // If the counter exceeds the number of backgrounds, reset it to zero
            if (currentBackground >= backgrounds.Length)
            {
                currentBackground = 0;
            }

            // Change the background
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].SetActive(false);
            }
            backgrounds[currentBackground].SetActive(true);

            // Reset the distance
            camStartPos = cam.position;
        }
    }
}