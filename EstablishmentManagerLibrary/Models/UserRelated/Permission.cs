namespace EstablishmentManagerLibrary.Models.UserRelated
{
    public class Permission
    {
        private int _permission_id;
        private int _level;

        //Foreign key for User
        public int User_id { get; set; }
        public virtual User User { get; set; }


        public Permission()
        {
            
        }

        public Permission(int level)
        {
            Level = level; 
        }

        public int Permission_id { get => _permission_id; set => _permission_id = value; }
        public int Level { get => _level; set => _level = value; }
    }
}
