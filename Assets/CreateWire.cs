using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CreateWire : MonoBehaviour
{
    public GameObject Cube1;
    public GameObject Cube2;
    public Button makeConnection;
    public Button deleteSelection;
    [SerializeField] private Material selectionMaterial = null;
    private Material[] Material = new Material[2];
    private Vector3[] position = new Vector3[2];
    private LineRenderer line;
    int i = 0;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                

                if (Physics.Raycast(ray, out hit, 100) && Material[1]==null)
                {                    
                    Material[i] = hit.transform.GetComponent<Renderer>().material;
                    position[i] = hit.transform.position;
                    var selection = hit.transform;
                    var selectionRendered = selection.GetComponent<Renderer>();
                    selectionRendered.material = selectionMaterial;
                    i++;
                }

            }
            if(Material[1]!= null)
                makeConnection.onClick.AddListener(MakeConnection);
                   
    }

    //Line renderer script
    
    public void MakeConnection()
    {
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        
        line.SetPosition(0, position[0]);
        line.SetPosition(1, position[1]);
        Debug.Log("connection made");
    }
}