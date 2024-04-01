/*
using System.Linq.Expressions;

using FinalDAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query;

//implementation of repository patterns

namespace SampleAPI.AllInOne;
public class TEntity
{
    public int UserId { get; set; }
}

public interface IBaseRepository<T> where T : class
{
    T Get(int id);
    List<T> GetAll();

    void Add(T entity);

    // IEnumerable<T> GetAll();
    // T GetById(object id);
    // void Insert(T obj);
    // void Update(T obj);
    // void Delete(object id);
    // void Save();
}

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public readonly SampleContext _context;

    public BaseRepository(SampleContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(List<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public List<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).ToList();
    }

    public T Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
}

public interface ICourseRepository : IBaseRepository<CourseEntity>
{
    List<CourseEntity> GetTopSellingCourses(int count);
    List<CourseEntity> GetCoursesWithAuthors(int pageIndex, int pageSize);
}

public class CourseRepository : BaseRepository<CourseEntity>, ICourseRepository
{
    public CourseRepository(SampleContext _context) : base(_context)
    {
    }

    public Expression<Func<Course, bool>> Predicate { get; protected set; }
    public Func<IQueryable<Course>, IIncludableQueryable<Course, object>> IncludeExpress { get; protected set; }

    public List<CourseEntity> GetCoursesWithAuthors(int pageIndex, int pageSize)
    {
        return _context
        .Courses
        .Include(c => c.Author)
        .OrderBy(c => c.Name)
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public List<CourseEntity> GetTopSellingCourses(int count)
    {
        return _context.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
    }
}

public interface IAuthorRepository : IBaseRepository<AuthorEntity>
{
}

public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
{
    public AuthorRepository(SampleContext _context) : base(_context)
    {
    }
}
public interface IUOW : IDisposable
{
    ICourseRepository Courses { get; }
    IAuthorRepository Authors { get; }

    int Complete();
}

public class UOW : IUOW
{
    readonly SampleContext _context;

    public UOW(SampleContext context, ICourseRepository courses, IAuthorRepository authors)
    {
        _context = context;
        this.Courses = courses;
        this.Authors = authors;
    }
    public ICourseRepository Courses { get; }

    public IAuthorRepository Authors { get; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

public interface ICourseManager
{
}

public class CourseManager : ICourseManager
{
}

public class CourseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FullPrice { get; set; }
    public string Name { get; internal set; }
    public AuthorEntity Author { get; internal set; }
}

public class AuthorEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SampleContext : DbContext
{
    public SampleContext() { }
    public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data source=D:\Git Source\CSharpCodes\APIAndTest\finaldb.sdb");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
        .Property(s => s.MinAge)
        .HasColumnName("DefaultMinAge")
        .HasDefaultValue("12")
        .IsRequired();
    }

    public DbSet<CourseEntity> Courses { get; set; }

    public DbSet<AuthorEntity> Authors { get; set; }
}

*/