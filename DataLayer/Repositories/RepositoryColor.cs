﻿using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Color = DataLayer.Models.Domain.Color;

namespace DataLayer.Repositories;

public interface IRepositoryColor
{
    Color Create(Color color);

    int Delete(IEnumerable<Color> colors);

    int Delete(Color color);

    List<Color> GetAll(QueryParamColor queryParamColor);

    Color? GetById(int id, QueryParamColor queryParamColor);

    int Update(Color color);
}

public class RepositoryColor : IRepositoryColor
{
    private readonly ApplicationDbContext _context;

    public RepositoryColor(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Color> GetAll(QueryParamColor queryParamColor) => IncludeParameters(queryParamColor, _context.Color).ToList();

    public Color? GetById(int id, QueryParamColor queryParamColor) => IncludeParameters(queryParamColor, _context.Color).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Color Create(Color color)
    {
        try
        {
            _context.Color.Add(color);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return color;
    }

    public int Delete(Color color)
    {
        try
        {
            _context.Color.Remove(color);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Delete(IEnumerable<Color> colors)
    {
        try
        {
            foreach (Color color in colors) _context.Color.Remove(color);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(Color color)
    {
        try
        {
            _context.Color.Update(color);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<Color> IncludeParameters(QueryParamColor queryParamColor, DbSet<Color> context)
    {
        var query = context.AsQueryable();
        if (queryParamColor.Styles != null) query = query.Include(o => o.Styles);
        return query;
    }
}