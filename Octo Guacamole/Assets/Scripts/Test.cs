using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button create, delete;
    public GameObject tower, towerPart;
    string[] materials;
    void Start()
    {
        create.onClick.AddListener(Create);
        delete.onClick.AddListener(Delete);

        materials = FilesName.GetFilesNames("Assets/Resources/Thirdparty/Materials/", ".mat").ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create() {
        GameObject newPart = Instantiate(towerPart);
        newPart.name = "Tower Part";
        newPart.transform.localPosition = new Vector3(0,5,0);
        tower.transform.position += new Vector3(0,10,0);
        newPart.transform.SetParent(tower.transform);

        newPart.GetComponent<Renderer>().material = (Material) Resources.Load(randMaterial());
        Debug.Log("Created");
    }

    public void Delete() {
        GameObject secondChild = tower.transform.GetChild(1).gameObject;
        Destroy(secondChild);
        tower.transform.GetChild(0).transform.localPosition -= new Vector3(0,10,0);
        Debug.Log("Deleted");
        // tower.transform.position -= new Vector3(0,10,0);
        // Debug.Log(tower.transform.childCount);
    }

    public string randMaterial() {
        return "Thirdparty/Materials/" + materials[Random.Range(0, materials.Length)];;
    }
}
