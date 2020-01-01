using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using app.Models;

namespace app.Controllers.API
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class UsersController:Controller
    {
      // private readonly myContext _context;
      public UsersController()
      {
        // this._context=context;
      }
      public string index()
      {
        return new String("okej je");
      }
      // public IActionResult Index()
      // {
      //   return new OkResult();
      // }
      public IActionResult user()
      {
        
        // var conn= new SqlConnection("host:localhost");
        // MySql.Data.EntityFrameworkCore some= new MySql.Data.EntityFrameworkCore();
        User user=new User("Marc","Gonzales","Marc@mail.com");
        return new ObjectResult(user);
      }
      public string allUsers()
      {
        User u= new User();
        // return u.GetAll();
        List<User> allU= u.GetAll();
        foreach(var x in allU) {
          Console.WriteLine(x.first_name);
        }
        var json= JsonSerializer.Serialize(allU);
        return json;
      }
    }
    
}