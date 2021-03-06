namespace PortalRowerowy.API.Helpers
{
    public class MessageParams
    {
        public const int MaxPageSize = 24;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 12;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public int UserId { get; set; }

        public string MessageContainer { get; set; } = "Nieprzeczytane";
    }
}