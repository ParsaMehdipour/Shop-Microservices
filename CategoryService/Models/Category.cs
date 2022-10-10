using System;

namespace CategoryService.Models;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string From { get; private set; }
    public DateTime CreateDate { get; private set; }

    public Category(string name)
    {
        SetName(name);

        CreateDate = DateTime.Now;
    }

    private void SetName(string name)
    {
        if (Name == name)
            return;

        Name = name;
    }

    public void SetFrom(string from)
    {
        if(From == from)
            return;

        From = from;
    }
}