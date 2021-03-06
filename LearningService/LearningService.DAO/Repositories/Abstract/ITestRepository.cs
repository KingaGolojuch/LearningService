﻿using LearningService.DAO.Entities;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Abstract
{
    public interface ITestRepository
    {
        IEnumerable<TestEntity> Get();
        TestEntity GetById(int id);
    }
}