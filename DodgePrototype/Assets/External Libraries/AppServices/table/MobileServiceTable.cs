﻿using UnityEngine;
using System.Collections;
using RestSharp;
using System.Collections.Generic;
using System;

namespace Unity3dAzure.AppServices
{
//	[CLSCompliant(false)]
    public class MobileServiceTable<E> : IAzureMobileServiceTable
    {
        private MobileServiceClient _client;
        private string _name;
        
        public const string URI_TABLES = "tables/";
        
        public MobileServiceTable(string tableName, MobileServiceClient client)
        {
            _client = client;
            _name = tableName; // NB: The table name could be infered from the Table's DataModel using typeof(E).Name; but passing Table name as a string allows for the case when the Classname is not the same as the Table name.
        }
        
        public override string ToString()
        {
            return _name;
        }
        
        public void Insert<T>(T item, Action<IRestResponse<T>> callback = null) where T : new()
        {
            string uri = URI_TABLES + _name;
            ZumoRequest request = new ZumoRequest(_client, uri, Method.POST);
            Debug.Log( "Insert Request: " + uri );
            request.AddBody(item);
            _client.ExecuteAsync<T>(request, callback);
        }
        
        public void Read<T>(Action<IRestResponse<List<T>>> callback = null) where T : new()
        {
            string uri = URI_TABLES + _name;
            ZumoRequest request = new ZumoRequest(_client, uri, Method.GET);
            Debug.Log( "Read Request: " + uri );
            _client.ExecuteAsync<List<T>>(request, callback);
        }
        
        public void Query<T>(CustomQuery query, Action<IRestResponse<List<T>>> callback = null) where T : new()
        {
            string uri = string.Format("{0}{1}{2}", URI_TABLES, _name, query);
            ZumoRequest request = new ZumoRequest(_client, uri, Method.GET);
			Debug.Log( "Query Request: " + uri +" Query:"+ query );
			_client.ExecuteAsync<List<T>> (request, callback);
        }

		public void Query<T>(CustomQuery query, Action<IRestResponse<T>> callback = null) where T : INestedResults, new()
		{
			string queryResults = query.ToString ();
			string q = queryResults.Length > 0 ? "&" : "?";
			queryResults += string.Format("{0}$inlinecount=allpages", q);
			string uri = string.Format("{0}{1}{2}", URI_TABLES, _name, queryResults);
			ZumoRequest request = new ZumoRequest(_client, uri, Method.GET);
			Debug.Log( "Query Request: " + uri +" Query with inlinecount:"+ queryResults );
			_client.ExecuteAsync<T> (request, callback);
		}
        
        public void Update<T>(T item, Action<IRestResponse<T>> callback = null) where T : new()
        {
            string id = null;
            // Check if model uses the 'IDataModel' Interface to get id property, otherwise try Refelection (using 'Model' helper).
            IDataModel model = item as IDataModel;
            if (model != null)
            {
                id = model.GetId();
            }
            else if ( Model.HasProperty(item, "id") ) 
            {
				var x = Model.GetProperty(item, "id");
                id = x.GetValue(item, null) as string;
            }
            else
            {
                Debug.LogError("Unable to get 'id' data model property");
            }
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogError("Error 'id' value is missing");
                return;
            }
            string uri = URI_TABLES + _name + "/" + id;
            ZumoRequest request = new ZumoRequest(_client, uri, Method.PATCH);
            Debug.Log("Update Request Uri: " + uri);
            request.AddBody(item);
            _client.ExecuteAsync<T>(request, callback);
        }
        
        public void Delete<T>(string id, Action<IRestResponse<T>> callback = null) where T : new()
        {
            string uri = URI_TABLES + _name + "/" + id;
            ZumoRequest request = new ZumoRequest(_client, uri, Method.DELETE);
            Debug.Log( "Delete Request Uri: " + uri );
            _client.ExecuteAsync<T>(request, callback);
        }
        
        public void Lookup<T>(string id, Action<IRestResponse<T>> callback = null) where T : new()
        {
            string uri = URI_TABLES + _name + "/" + id;
            ZumoRequest request = new ZumoRequest(_client, uri, Method.GET);
            Debug.Log( "Lookup Request Uri: " + uri );
            _client.ExecuteAsync<T>(request, callback);
        }

    }
}