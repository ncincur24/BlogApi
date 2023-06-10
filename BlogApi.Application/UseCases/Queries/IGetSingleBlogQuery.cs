﻿using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.Queries
{
    public interface IGetSingleBlogQuery : IQuerySingle<int, SingleBlogDTO>
    {
    }
}
