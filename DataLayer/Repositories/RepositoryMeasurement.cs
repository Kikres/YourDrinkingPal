using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryMeasurement
{
    Measurement Create(Measurement measurement);

    int Delete(IEnumerable<Measurement> measurements);

    int Delete(Measurement measurement);

    List<Measurement> GetAll(QueryParamMeasurement queryParamMeasurement);

    Measurement? GetById(int id, QueryParamMeasurement queryParamMeasurement);

    int Update(Measurement measurement);
}

public class RepositoryMeasurement : IRepositoryMeasurement
{
    private readonly ApplicationDbContext _context;

    public RepositoryMeasurement(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Measurement> GetAll(QueryParamMeasurement queryParamMeasurement) => IncludeParameters(queryParamMeasurement, _context.Measurement).ToList();

    public Measurement? GetById(int id, QueryParamMeasurement queryParamMeasurement) => IncludeParameters(queryParamMeasurement, _context.Measurement).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Measurement Create(Measurement measurement)
    {
        _context.Measurement.Add(measurement);
        _context.SaveChanges();
        return measurement;
    }

    public int Delete(Measurement measurement)
    {
        _context.Measurement.Remove(measurement);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Measurement> measurements)
    {
        foreach (Measurement measurement in measurements) _context.Measurement.Remove(measurement);
        return _context.SaveChanges();
    }

    public int Update(Measurement measurement)
    {
        _context.Measurement.Update(measurement);
        return _context.SaveChanges();
    }

    private IQueryable<Measurement> IncludeParameters(QueryParamMeasurement queryParamMeasurement, DbSet<Measurement> context)
    {
        var query = context.AsQueryable();
        if (queryParamMeasurement.Ingridient != null) query = query.Include(o => o.Ingridient);
        if (queryParamMeasurement.Unit != null) query = query.Include(o => o.Unit);
        return query;
    }
}