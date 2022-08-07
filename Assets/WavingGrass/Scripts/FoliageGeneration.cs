using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoliageGeneration : MonoBehaviour
{

    GameObject cell;
    public Material grassMaterial;
    public Material targetMaterial;

    public float xSize = 45;
    public float ySafe = 5000;
    public float zSize = 45;

    [Range(0, 1)]
    public static double progress = 0.0;
    //public static double progressMade = 0.0;

    List<Vector3> spawnPoints = new List<Vector3>();
    GameObject environment;
    GameObject environmentCell;
    public GameObject[] foliage;

    private int[] subMeshesFaceTotals;
    private int totalSubMeshes;


    public void CellScan()
    {
        MeshFilter mf = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
        Mesh mesh = mf.mesh;

        totalSubMeshes = mesh.subMeshCount;
        subMeshesFaceTotals = new int[totalSubMeshes];
        for (int i = 0; i < totalSubMeshes; i++)
        {
            subMeshesFaceTotals[i] = mesh.GetTriangles(i).Length / 3;
        }

        InitialParentSetUp();

        Debug.Log("Scanning");

        progress = 0;
        //progressMade = 1 / xSize + zSize;

        //Scan the cell and determine where to place objects.
        for (float x = -(xSize / 2); x <= (xSize / 2); x++)
        {
            for (float z = -(zSize / 2); z <= (zSize / 2); z++)
            {
                float xPosition = cell.transform.localPosition.x + x;
                float yPosition = cell.transform.localPosition.y + ySafe;
                float zPosition = cell.transform.localPosition.z + z;

                Vector3 rayPosition = new Vector3(xPosition, yPosition, zPosition);
                //Debug.Log("Coordinates: " + rayPosition);
                Ray ray = new Ray(rayPosition, Vector3.down);
                RaycastHit hit = new RaycastHit();

                Physics.Raycast(ray, out hit);
                if (hit.collider != null)
                {
                    if (hit.transform == gameObject.transform)
                    {
                        int hitSubMeshNumber = 0;
                        int maxVal = 0;

                        for (int i = 0; i < totalSubMeshes; i++)
                        {
                            maxVal += subMeshesFaceTotals[i];

                            if (hit.triangleIndex <= maxVal - 1)
                            {
                                hitSubMeshNumber = i + 1;
                                break;
                            }
                        }

                        if (targetMaterial != false)
                        {
                            //Debug.Log("Material Hit: " + targetMaterial.name);
                            if (hitSubMeshNumber == 0)
                            {
                                //not used
                                //spawnPoints.Add(hit.point);
                                //progress += progressMade;
                            }
                            else if (hitSubMeshNumber == 1)
                            {
                                //Grass
                                spawnPoints.Add(hit.point);
                            }
                            else if (hitSubMeshNumber == 2)
                            {
                                //Dirt
                                //spawnPoints.Add(hit.point);
                            }
                            else if (hitSubMeshNumber == 3)
                            {
                                //Stone
                                //spawnPoints.Add(hit.point);
                            }
                            else if (hitSubMeshNumber == 4)
                            {
                                //Cliff
                                //spawnPoints.Add(hit.point);
                            }
                            //else Debug.Log("Error 0x0004: Target material does not match");
                        }
                        //else Debug.Log("Error 0x0003: Target material could not be loaded");
                    }
                    //else Debug.Log("Error 0x0002: Cell scan out of bounds");
                }
                //else Debug.Log("Error 0x0001: Could not find cell");
            }
        }
        targetMaterial.name = grassMaterial.name;
        progress = 0.0;
        Generate();
    }

    public void InitialParentSetUp()
    {
        //Debug.Log("Clearing existing cell data");
        ClearCell();

        cell = gameObject;

        //Debug.Log("Finding parents");
        if (gameObject.transform.parent.parent.FindChild("Environment") == null)
        {
            //Debug.Log("Creating environment folder");
            environment = new GameObject();
            environment.transform.position = Vector3.zero;
            environment.transform.parent = gameObject.transform.parent.parent;
            environment.transform.name = "Environment";
        }
        else environment = gameObject.transform.parent.parent.FindChild("Environment").gameObject;

        if (environment.transform.FindChild(gameObject.name) == null)
        {
            //Debug.Log("Creating cell folder");
            environmentCell = new GameObject();
            environmentCell.transform.position = gameObject.transform.position;
            environmentCell.transform.parent = environment.transform;
            environmentCell.transform.name = cell.name;
        }
        else environmentCell = environment.transform.FindChild(gameObject.name).gameObject;
    }

    public void ClearCell()
    {
        if (gameObject.transform.parent.parent.FindChild("Environment") != null)
        {
            GameObject environment = gameObject.transform.parent.parent.FindChild("Environment").gameObject;
            if (environment.transform.FindChild(gameObject.name) != null)
            {
                GameObject environmentCell = environment.transform.FindChild(gameObject.name).gameObject;
                DestroyImmediate(environmentCell);
            }
            //else Debug.Log("No cell data could be found");
        }
        //else Debug.Log("No environment data could be found");
    }

    public void Generate()
    {
        //Debug.Log("Spawning Foliage");
        //progressMade = 1 / spawnPoints.Count;

        foreach (Vector3 spawnPoint in spawnPoints)
        {
            int i = Random.Range(0, foliage.Length);
            GameObject spawnedFoliage = foliage[i];

            spawnedFoliage = Instantiate(spawnedFoliage);
            spawnedFoliage.transform.position = spawnPoint;
            spawnedFoliage.transform.parent = environmentCell.transform;
            spawnedFoliage.transform.name = foliage[i].name;

            //progress += progressMade;
            //Debug.Log("Spawned grass on cell at " + spawnPoint);
        }

        progress = 0.0;
    }
}