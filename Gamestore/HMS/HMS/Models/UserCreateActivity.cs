using System;
using HMS.Data;

namespace HMS.Models;

public class UserCreateActivity:UserModifyActivity
{
    public string CreatedById { get; set; }
    public ApplicationUser CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}

public class UserModifyActivity
{
    public string ModifiedById {get;set;}
    public ApplicationUser ModifiedBy {get;set;}
    public DateTime ModifiedOn {get;set;}
}