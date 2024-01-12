namespace EstablishmentManagerLibrary.UserRelated
{
    public class Permission
    {
        private string _id;
        private int _level;

        public Permission()
        {
            
        }

        public Permission(int level)
        {
            Level = level; 
        }

        public string Id { get => _id; set => _id = value; }
        public int Level { get => _level; set => _level = value; }
    }
}
