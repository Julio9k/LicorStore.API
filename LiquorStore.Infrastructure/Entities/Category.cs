﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }   
    public ICollection<Product> Products { get; private set; } = new List<Product>();
}