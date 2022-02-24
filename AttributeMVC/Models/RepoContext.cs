using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AttributeMVC.Models
{
    public class RepoContext:DbContext
    {
        public RepoContext(DbContextOptions<RepoContext> options):base(options)
        {

        }
        public DbSet<UserInfo> userInfos { get; set; }
    }
}
