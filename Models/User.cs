using System.Data;
using System;
using System.Data.Common;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
// using System.Configuration;

namespace app.Models
{
    public class User
    {
      public string first_name;
      public string last_name;
      public string Email;
      public List<User> AllUsers;
      public User()
      {
          this.AllUsers= new List<User>();
      }
      public User(string first_name,string last_name,string email)
      {
        this.first_name= first_name;
        this.last_name= last_name;
        this.Email= email;
        this.AllUsers= new List<User>();
      }
      public string ime
      {
        get { return this.first_name; }
        set {}
      }
      public string prezime
      {
        get { return this.last_name; }
        set {}
      }
      public string email
      {
          get { return this.Email; }
          set {}
      }
      public List<User> GetAll()
      {
        string ConnString= @"server=localhost;userid=zdravko;password=aptzdravko;database=interjob";
        // string ConnString1= System.Configuration.ConfigurationManager.GetSection("Logging").ToString();

        // Console.WriteLine(ConnString1);
        using var Conn= new MySqlConnection(ConnString);
        Conn.Open();
        // Conn.BeginTransaction();
        this.AllUsers.Add(new User("Pera","Peric","pera@mail.com"));
        this.AllUsers.Add(new User("Marko","Markovic","marko@mail.com"));
        MySqlCommand my= new MySqlCommand("SELECT * FROM users",Conn);
        using(var reader= my.ExecuteReader())
        {
            while(reader.Read())
            {
                // reader.GetString('last_name');
                
                this.AllUsers.Add(new User(reader.GetString("first_name"),reader.GetString("last_name"),reader.GetString("email")));
            }
        }
        // Conn.Close();
        Console.WriteLine("MySql Version {0}",Conn.ServerVersion);
        return this.AllUsers;
      }
}

}