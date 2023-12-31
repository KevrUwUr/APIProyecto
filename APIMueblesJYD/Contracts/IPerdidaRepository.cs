﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaRepository
    {
        IEnumerable<Perdida> GetAllLoses(bool trackChanges);
        Perdida GetLose(Guid lostId, bool trackChanges);
        void CreateLose(Perdida Lose);
        IEnumerable<Perdida> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteLose(Perdida Lose);
    }
}
