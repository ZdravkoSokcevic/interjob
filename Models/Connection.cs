using System.Data;
using System;
using System.Data.Common;

namespace app.Models
{
  public class MyConnection
  {
    private static string host="localhost";
    private static string username="zdravko";
    private static string password="aptzdravko";
    private string database;
    private static string db_name="elektronska_evidencija";
    public string DbName
    {
      get{ return database; }
      set{ database= value; }
    } 
    private static DbConnection _instance = null;
    public DbConnection Connector
    {
      get{return _instance;}
    }
    public static DbConnection Instance()
    {
      if(_instance==null)
      {

          // bool isconnect=_instance.Connector.IsConnect();
          return _instance;
        // _instance.ConnectionString= "host:localhost;username=zdravko";
      }
      return _instance;
    }
    public bool IsConnect()
    {
        return true;
    }
  }
}