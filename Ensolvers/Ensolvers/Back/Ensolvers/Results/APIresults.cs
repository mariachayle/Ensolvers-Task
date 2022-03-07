namespace Ensolvers.Results
{
    public class APIresults
    {
        public bool Ok { get; set; }
        public string Error { get; set; }
        public int CodeError { get; set; }
        public string MoreInfo { get; set; }
        public object Return { get; set; }
    }
}
