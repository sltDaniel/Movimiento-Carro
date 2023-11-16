// Use matrices ti modify the vertices of a mesh using the basic transforms

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    [SerializeField] Vector3 displacement;
    [SerializeField] float angle;
    //[SerializeField] AXIS rotationAxis;
    [SerializeField] GameObject Rueda1;
    [SerializeField] GameObject Rueda2;
    [SerializeField] GameObject Rueda3;
    [SerializeField] GameObject Rueda4;


    Mesh mesh;
    Mesh meshRueda1;
    Mesh meshRueda2;
    Mesh meshRueda3;
    Mesh meshRueda4;

    Vector3[] baseVertices;
    Vector3[] newVertices;

    Vector3[] baseVerticesRueda1;
    Vector3[] newVerticesRueda1;
    Vector3[] baseVerticesRueda2;
    Vector3[] newVerticesRueda2;
    Vector3[] baseVerticesRueda3;
    Vector3[] newVerticesRueda3;
    Vector3[] baseVerticesRueda4;
    Vector3[] newVerticesRueda4;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().mesh;
        baseVertices = mesh.vertices;

        meshRueda1 = GetComponentInChildren<MeshFilter>().mesh;
        baseVerticesRueda1 = meshRueda1.vertices;
        meshRueda2 = GetComponentInChildren<MeshFilter>().mesh;
        baseVerticesRueda2 = meshRueda2.vertices;
        meshRueda3 = GetComponentInChildren<MeshFilter>().mesh;
        baseVerticesRueda3 = meshRueda3.vertices;
        meshRueda4 = GetComponentInChildren<MeshFilter>().mesh;
        baseVerticesRueda4 = meshRueda4.vertices;

        //Create a copy of the original vertices
        newVertices = new Vector3[baseVertices.Length];
        for (int i = 0; i < baseVertices.Length; i++)
        {
            newVertices[i] = baseVertices[i];
        }

        newVerticesRueda1 = new Vector3[baseVerticesRueda1.Length];
        for (int i = 0; i < baseVerticesRueda1.Length; i++)
        {
            newVerticesRueda1[i] = baseVerticesRueda1[i];
        }
        newVerticesRueda2 = new Vector3[baseVerticesRueda2.Length];
        for (int i = 0; i < baseVerticesRueda2.Length; i++)
        {
            newVerticesRueda2[i] = baseVerticesRueda2[i];
        }
        newVerticesRueda3 = new Vector3[baseVerticesRueda3.Length];
        for (int i = 0; i < baseVerticesRueda3.Length; i++)
        {
            newVerticesRueda3[i] = baseVerticesRueda3[i];
        }
        newVerticesRueda4 = new Vector3[baseVerticesRueda4.Length];
        for (int i = 0; i < baseVerticesRueda4.Length; i++)
        {
            newVerticesRueda4[i] = baseVerticesRueda4[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        DoTransform();
    }

    void DoTransform()
    {
        Matrix4x4 move = HW_Transforms.TranslationMat(displacement.x * Time.time,
                                                        0,
                                                        displacement.z * Time.time);
        Matrix4x4 rotate = HW_Transforms.RotateMat(angle * Time.time, AXIS.X); //rotationAxis);
        Matrix4x4 posOrigin = HW_Transforms.TranslationMat(-displacement.x,
                                                            -displacement.y,
                                                            -displacement.z);
        Matrix4x4 posObject = HW_Transforms.TranslationMat(displacement.x,
                                                            displacement.y,
                                                            displacement.z);
        Matrix4x4 rotarCarro = HW_Transforms.RotateMat(-angle, AXIS.Y);

        //Matrix4x4 composite = posObject * rotate * posOrigin;
        //Matrix4x4 composite = move * rotate;
        Matrix4x4 composite = move * rotarCarro;

        for (int i = 0; i < newVertices.Length; i++)
        {
            var prev = baseVertices[i];
            Vector4 temp = new Vector4(baseVertices[i].x,
                                        baseVertices[i].y,
                                        baseVertices[i].z, 1);
            newVertices[i] = composite * temp;
        }

        // Replace the vertices in the mesh
        mesh.vertices = newVertices;
        mesh.RecalculateNormals(); //calcula las normales. 

        for (int i = 0; i < newVertices.Length; i++)
        {
            Vector4 temp = new Vector4(baseVertices[i].x,
                                        baseVertices[i].y,
                                        baseVertices[i].z, 1);
            newVertices[i] = composite * temp;
        }
        mesh.vertices = newVertices;
        mesh.RecalculateNormals();

        for (int i = 0; i < newVerticesRueda1.Length; i++)
        {
            Vector4 temp = new Vector4(baseVerticesRueda1[i].x,
                                        baseVerticesRueda1[i].y,
                                        baseVerticesRueda1[i].z, 1);
            newVerticesRueda1[i] = composite * temp;
        }
        meshRueda1.vertices = newVerticesRueda1;
        meshRueda1.RecalculateNormals();

        for (int i = 0; i < newVerticesRueda2.Length; i++)
        {
            Vector4 temp = new Vector4(baseVerticesRueda2[i].x,
                                        baseVerticesRueda2[i].y,
                                        baseVerticesRueda2[i].z, 1);
            newVerticesRueda2[i] = composite * temp;
        }
        meshRueda2.vertices = newVerticesRueda2;
        meshRueda2.RecalculateNormals();

        for (int i = 0; i < newVerticesRueda3.Length; i++)
        {
            Vector4 temp = new Vector4(baseVerticesRueda3[i].x,
                                        baseVerticesRueda3[i].y,
                                        baseVerticesRueda3[i].z, 1);
            newVerticesRueda3[i] = composite * temp;
        }
        meshRueda3.vertices = newVerticesRueda3;
        meshRueda3.RecalculateNormals();

        for (int i = 0; i < newVerticesRueda4.Length; i++)
        {
            Vector4 temp = new Vector4(baseVerticesRueda4[i].x,
                                        baseVerticesRueda4[i].y,
                                        baseVerticesRueda4[i].z, 1);
            newVerticesRueda4[i] = composite * temp;
        }
        meshRueda4.vertices = newVerticesRueda4;
        meshRueda4.RecalculateNormals();

    }
}
