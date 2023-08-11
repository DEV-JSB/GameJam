using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    List<Transform> riverEdge;
    GameObject player;
    Vector3 previousPosition;
    [SerializeField]float minDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerInfoManager.Instance.playerUnit.gameObject;
        this.lineRenderer = this.GetComponent<LineRenderer>();
        previousPosition = player.transform.position;
        //riverEdge = PlayerInfoManager.Instance.LstRoadRoute;
        //this.lineRenderer.positionCount = riverEdge.Count;
        this.lineRenderer.positionCount = 2;
        this.lineRenderer.SetPosition(0, PlayerInfoManager.Instance.LstRoadRoute[0].position);
        this.lineRenderer.SetPosition(1, player.transform.position);
        //for(int i =0; i<riverEdge.Count; i++)
        //{
        //    this.lineRenderer.SetPosition(i, riverEdge[i].position);

        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, previousPosition) > minDistance)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, player.transform.position);
            previousPosition = player.transform.position;
        }
        //this.lineRenderer.positionCount = player.GetComponent<RiverPioneer>().moveIndex + 1;

        //this.lineRenderer.SetPosition(player.GetComponent<RiverPioneer>().moveIndex, player.transform.position);
        //for (int i = 0; i < this.lineRenderer.positionCount; i++)
        //{
        //    if(player.GetComponent<RiverPioneer>().moveIndex > i)
        //    {
        //        this.lineRenderer.SetPosition(i, PlayerInfoManager.Instance.LstRoadRoute[i].position);
        //    }
            
        //}
    }
}
