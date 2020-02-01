//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

namespace UnityEngine.AI
{
    [ExecuteAlways]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class NavMeshExtract : MonoBehaviour
    {
        public bool updateDynamically = false;

        public void Update()
        {
            if (updateDynamically)
            {
                UpdateMesh();
            }
        }

        public void UpdateMesh()
        {
            Mesh mesh = GetMesh();

            GetComponent<MeshCollider>().sharedMesh = mesh;
            GetComponent<MeshFilter>().sharedMesh = mesh;
        }

        /// <summary>
        /// Triangulate and return a mesh based on every NavMesh currently loaded.
        /// Unity's triangulation system is very broken, so triangulation works correctly only for flat NavMeshes (no slopes).
        /// </summary>
        public Mesh GetMesh()
        {
            NavMeshTriangulation navTriangulation = NavMesh.CalculateTriangulation();
            Mesh output = new Mesh();
            output.name = "NavMeshTriangulated";
            output.vertices = navTriangulation.vertices;
            output.triangles = navTriangulation.indices;
            return output;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(NavMeshExtract))]
    public class NavMeshExtractEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            NavMeshExtract extract = (NavMeshExtract)target;

            if (GUILayout.Button("Generate All Surfaces"))
            {
                int builtSurfaces = 0;
                GameObject[] allObjects = FindObjectsOfType<GameObject>();
                foreach (GameObject go in allObjects)
                {
                    NavMeshSurface surface = go.GetComponent<NavMeshSurface>();
                    if (surface != null)
                    {
                        surface.BuildNavMesh();
                        builtSurfaces++;
                    }
                }
                Debug.Log(this + " Re-built " + builtSurfaces + " surfaces.");
            }

            if (GUILayout.Button("Update Mesh"))
            {
                extract.UpdateMesh();
                Debug.Log(this + " Updated mesh.");
            }
        }
    }
#endif

}
