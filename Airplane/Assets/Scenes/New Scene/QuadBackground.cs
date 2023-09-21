using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBackground : MonoBehaviour
{
    public MeshRenderer mRenderer;
    public Vector2 offset;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = mRenderer.materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = material.mainTextureOffset;
        vector2 += (offset * Time.deltaTime);
        material.mainTextureOffset = vector2;
    }
}
