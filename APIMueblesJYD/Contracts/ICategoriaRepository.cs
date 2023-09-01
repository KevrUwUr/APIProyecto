﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAllCategories(bool trackChanges);
        Categoria GetCategory(Guid categoryId, bool trackChanges);
    }
}
