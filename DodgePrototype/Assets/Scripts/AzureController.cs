using UnityEngine;
using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Pathfinding.Serialization.JsonFx;
using Unity3dAzure.AppServices;
using UnityEngine.UI;
//using Tacticsoft;
//using Prefabs;
using UnityEngine.SceneManagement;

public class AzureController : MonoBehaviour//, ITableViewDataSource 
{
	// This script handles the communication with the azure app service

	// App URL
	[SerializeField] // Forces unity to serialise this field
	private string APP_URL = "http://dangerzoneabertay.azurewebsites.net";

	// App Service REST Client
	private MobileServiceClient _client;

	// App Service Table defined using a DataModel
	private MobileServiceTable<SpawnFlag> _table;

    // Spawn flag for tree
    SpawnFlag tree = new SpawnFlag();
    bool spawn;

    // Tree prefab
    public GameObject AzureTree;

    // Use this for initialization
    void Start () 
	{
		// Create App Service client (Using factory Create method to force 'https' url)
		_client = MobileServiceClient.Create(APP_URL); // new MobileServiceClient(APP_URL);

		// Get App Service 'SpawnFlags' table
		_table = _client.GetTable<SpawnFlag>("SpawnFlags");

        // Spawn false
        spawn = false;
		tree.name = "AzureTree";
		tree.flag = false;

        // Check server whether to spawn tree every 1 second
        InvokeRepeating("CheckSpawn", 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () 
	{
        
	}

    public void Lookup(SpawnFlag item)
    {
        _table.Lookup<SpawnFlag>(item.id, OnLookupCompleted);
    }

    private void OnLookupCompleted(IRestResponse<SpawnFlag> response)
    {
        Debug.Log("OnLookupItemCompleted: " + response.Content);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            SpawnFlag item = response.Data;
            if (item.flag == true)
            {
                spawn = true;
            }
        }
        else
        {
            ResponseError err = JsonReader.Deserialize<ResponseError>(response.Content);
            Debug.Log("Lookup Error Status:" + response.StatusCode + " Code:" + err.code.ToString() + " " + err.error);
        }
    }

    private void CheckSpawn()
    {
        Debug.Log("Checking Flags");

        // Look up server SpawnFlag
        //Lookup(tree);
		Read();

        if (spawn)
        {
            // Spawn tree
            Vector3 SpawnLocation = new Vector3(0.0f, 0.0f, 0.0f);
            Instantiate(AzureTree, SpawnLocation, Quaternion.identity);

            // We now need to reset the flag 
            spawn = false;
            tree.flag = false;
            UpdateFlag(tree);
        }
    }

    public void Insert(SpawnFlag item)
	{ // Inserts new spawn flag into Azure table

        if (Validate(item))
        {
            _table.Insert<SpawnFlag>(item, OnInsertCompleted);
        }
	}

	private void OnInsertCompleted(IRestResponse<SpawnFlag> response)
	{
		if (response.StatusCode == HttpStatusCode.Created)
		{
			Debug.Log( "OnInsertItemCompleted: " + response.Data );
			tree = response.Data; // If inserted successfully, azure will return an ID
		}
		else
		{
			Debug.Log("Insert Error Status:" + response.StatusCode + " Uri: "+response.ResponseUri );
		}
	}

    public void Delete(SpawnFlag item)
    {
        // Deletes spawn flag from azure table
        if (Validate(item))
        {
            _table.Delete<SpawnFlag>(item.id, OnDeleteCompleted);
        }
       
    }

    private void OnDeleteCompleted(IRestResponse<SpawnFlag> response)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("OnDeleteItemCompleted");
        }
        else
        {
            Debug.Log("Delete Error Status:" + response.StatusCode + " " + response.ErrorMessage + " Uri: " + response.ResponseUri);
        }
    }

    public void UpdateFlag(SpawnFlag item)
    {
        // Updates item in the table
        if (Validate(item))
        {
            _table.Update<SpawnFlag>(item, OnUpdateFlagCompleted);
        }
    }

    private void OnUpdateFlagCompleted(IRestResponse<SpawnFlag> response)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("OnUpdateItemCompleted: " + response.Content);
        }
        else
        {
            Debug.Log("Update Error Status:" + response.StatusCode + " " + response.ErrorMessage + " Uri: " + response.ResponseUri);
        }
    }

	public void Read()
	{
		_table.Read<SpawnFlag>(OnReadCompleted);
	}

	private void OnReadCompleted(IRestResponse<List<SpawnFlag>> response)
	{
		if (response.StatusCode == HttpStatusCode.OK)
		{
			Debug.Log("OnReadCompleted data: " + response.ResponseUri +" data: "+ response.Content);
			List<SpawnFlag> items = response.Data;
			Debug.Log("Read items count: " + items.Count);

			foreach (SpawnFlag item in items) 
			{
				tree.id = item.id;
				if (item.flag == true)
				{
					spawn = true;
				}
			}

		}
		else
		{
			Debug.Log("Read Error Status:" + response.StatusCode + " Uri: "+response.ResponseUri );
		}
	}

    // Checks if flag is valid before sending
    private bool Validate(SpawnFlag flag)
    {
        bool isUsernameValid = true;//, isScoreValid = true;
        // Validate username
        if (String.IsNullOrEmpty(flag.name))
        {
            isUsernameValid = false;
            Debug.Log("Error, player username required");
        }

        return (isUsernameValid);// && isScoreValid);
    }
}
