using System;

namespace CategoryService.Models;

public class Category
{
    public long Id { get; private set; }
    public string Name { get; private set; }
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
}