namespace User.Helpers
{
    public class Permission
    {
        public int activityid { get; set; }
        public int roleid { get; set; }
        public int RAid { get; set; }
        public string activityname { get; set; }
        public string rolename { get; set; }
        public bool create { get; set; }
        public bool read { get; set; }
        public bool delete { get; set; }
        public bool update { get; set; }
    }
}
