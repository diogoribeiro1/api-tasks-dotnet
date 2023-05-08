using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public sealed class Tasks
{
    
    public int id {get; set;}

    public string? title {get; set;}

    public string? description {get; set;}
    
    public Tasks()
    {}

    public Tasks(int id, string? title, string? description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
    }
    
    public Tasks(string? title, string? description)
    {
        this.title = title;
        this.description = description;
    }

}
