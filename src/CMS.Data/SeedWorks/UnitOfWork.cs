using AutoMapper;
using CMS.Core.Repositories;
using CMS.Core.SeedWorks;
using CMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TeduBlogContext _context;

        public UnitOfWork(TeduBlogContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }
        public IPostRepository Posts { get; private set; }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
