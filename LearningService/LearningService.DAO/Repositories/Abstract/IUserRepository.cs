using LearningService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Repositories.Abstract
{
    public interface IUserRepository
    {
        ApplicationUser Get(int id);
    }
}