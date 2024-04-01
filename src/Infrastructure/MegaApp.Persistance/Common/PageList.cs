public static class IQueryableExt
{
    public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
    {
        return new PagedList<T>(source, index, pageSize);
    }

    //We create a new instance of IEnumerable that only includes items, from the original IEnumerable, which match the predicate condition
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        // Loop and simply yield each item where the predicate is true...
        foreach (T item in source)
            if (predicate(item))
                yield return item;
    }

    // We create a new instance of IQueryable that has a slightly altered version of the original expression tree(passed in as a parameter).
    /* public static IQueryable<T> MyWhere<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
     {
         if (source == null)
             throw new ArgumentNullException(nameof(source));

         if (predicate == null)
             throw new ArgumentNullException(nameof(predicate));

         // Get the method information for the true Queryable.Where method
         MethodInfo whereMethodInfo = GetMethodInfo<T>((s, p) => Queryable.Where(s, p));

         // Create arguments for a call to the true Queryable.Where method. Note that
         // we quote the Lambda expression for the predicate, which seems to be necessary
         // (not certain why).
         var callArguments = new[] { source.Expression, Expression.Quote(predicate) };

         // Create an expression that calls the true Queryable.Where method
         var callToWhere = Expression.Call(null, whereMethodInfo, callArguments);

         // Return the new query that wraps the original expression in a call to the Queryable.Where method
         return source.Provider.CreateQuery<T>(callToWhere);
     }*/
}

public class TestPageList
{
    // [TestMethod]
    public void PagedList_Contains_Correct_Number_Of_Elements()
    {
        var query = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.AsQueryable();

        var pagedList = query.ToPagedList(0, 5);

        //  Assert.AreEqual(5, pagedList.Count);
        //  Assert.AreEqual(10, pagedList.TotalCount);
    }
}

public interface IPagedList
{
}

public class PagedList<T> : List<T>, IPagedList
{
    public PagedList(IQueryable<T> source, int index, int pageSize)
    {
        this.TotalCount = source.Count();
        this.PageSize = pageSize;
        this.PageIndex = index;
        this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
    }

    public PagedList(List<T> source, int index, int pageSize)
    {
        this.TotalCount = source.Count();
        this.PageSize = pageSize;
        this.PageIndex = index;
        this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
    }

    public int TotalCount
    {
        get; set;
    }

    public int PageIndex
    {
        get; set;
    }

    public int PageSize
    {
        get; set;
    }

    public bool IsPreviousPage
    {
        get
        {
            return (PageIndex > 0);
        }
    }

    public bool IsNextPage
    {
        get
        {
            return (PageIndex * PageSize) <= TotalCount;
        }
    }
}