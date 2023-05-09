using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public sealed class Tasks
{
    
    public int Id {get; set;}

    public string? Title {get; set;}

    public string? Description {get; set;}
    
    public Tasks()
    {}

    public Tasks(int id, string? title, string? description)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
    }
    
    public Tasks(string? title, string? description)
    {
        this.Title = title;
        this.Description = description;
    }

}
