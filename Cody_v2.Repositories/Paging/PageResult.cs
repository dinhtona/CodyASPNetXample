namespace Cody_v2.Repositories.Paging
{
    public class PageResult<T>: PageResultBase where T:class
    {
        public IList<T> Results { get; set; }
        public PageResult()
        {
            Results = new List<T>();
        }
    }
}
