using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectToPool;//đối tượng sẽ dùng pooling
    [SerializeField]
    protected int poolSize = 2;//kích thước

    protected Queue<GameObject> objectPool;//hàng chờ của các đối tượng

    public Transform spawnedObjectsParent;//vị trí spawn của cha 

    public bool alwaysDestroy = false;//luôn luôn hủy

    private void Awake()
    {
        objectPool = new Queue<GameObject>();

    }

    //phương thức giúp sinh ra đối tượng 
    public void Initialize(GameObject objectToPool, int poolSize)
    {
        this.objectToPool = objectToPool;
        this.poolSize = poolSize;

    }

    //phương thức tạo ra đối tượng
    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();

        GameObject spawnedObject = null;


        if (objectPool.Count < poolSize)
        {
            spawnedObject = Instantiate(objectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + objectToPool.name + "_" + objectPool.Count;//tên gốc_tên nhóm_số lượng trong hàm đợi
            spawnedObject.transform.SetParent(spawnedObjectsParent);
            spawnedObject.AddComponent<DestroyIfDisabled>();
        }
        else
        {
            spawnedObject = objectPool.Dequeue();// lấy đối tượng ở đầu queue ra khỏi hàng đợi và trả về giá trị của nó. Nếu hàng đợi rỗng thì lỗi sẽ xảy ra.
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }
        //sau khi xong lại cho vào hàng đợi
        objectPool.Enqueue(spawnedObject);//thêm đối tượng vào cuối hàng đợi
        return spawnedObject;
    }


    private void CreateObjectParentIfNeeded()
    {
        if (spawnedObjectsParent == null)// nếu chưa có thì tìm
        {
            string name = "ObjectPool_" + objectToPool.name;//gán tên
            var parentObject = GameObject.Find(name);//tìm tên
            if (parentObject != null)// nếu có rồi
                spawnedObjectsParent = parentObject.transform;//spawn
            else
            {
                spawnedObjectsParent = new GameObject(name).transform;//chưa có thì tạo ra cái ms từ cái tên kia ở vị trí định sẵn
            }

        }
    }

    private void OnDestroy()
    {
        foreach (var item in objectPool)
        {
            if (item == null)
                continue;
            else if (item.activeSelf == false || alwaysDestroy)//nếu đối tượng active là false
                Destroy(item);
            else
                item.GetComponent<DestroyIfDisabled>().SelfDestructionEnabled = true;//còn đây là active là true
        }
    }
}
