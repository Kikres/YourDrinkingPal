﻿using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryTag
{
    Tag Create(Tag tag);

    int Delete(IEnumerable<Tag> tags);

    int Delete(Tag tag);

    List<Tag> GetAll(QueryParamTag queryParamTag);

    Tag? GetById(int id, QueryParamTag queryParamTag);

    int Update(Tag tag);
}

public class RepositoryTag : IRepositoryTag
{
    private readonly ApplicationDbContext _context;

    public RepositoryTag(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Tag> GetAll(QueryParamTag queryParamTag) => IncludeParameters(queryParamTag, _context.Tag).ToList();

    public Tag? GetById(int id, QueryParamTag queryParamTag) => IncludeParameters(queryParamTag, _context.Tag).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Tag Create(Tag tag)
    {
        _context.Tag.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public int Delete(Tag tag)
    {
        _context.Tag.Remove(tag);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Tag> tags)
    {
        foreach (Tag tag in tags) _context.Tag.Remove(tag);
        return _context.SaveChanges();
    }

    public int Update(Tag tag)
    {
        _context.Tag.Update(tag);
        return _context.SaveChanges();
    }

    private IQueryable<Tag> IncludeParameters(QueryParamTag queryParamTag, DbSet<Tag> context)
    {
        var query = context.AsQueryable();
        if (queryParamTag.Drinks != null) query = query.Include(o => o.Drinks);
        return query;
    }
}