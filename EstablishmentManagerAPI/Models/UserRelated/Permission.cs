namespace EstablishmentManagerLibrary.Models.UserRelated
{
    public class Permission
    {
        private int _permissionId;
        private int _level;

        //Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }


        public Permission()
        {
            
        }

        public Permission(int level)
        {
            Level = level; 
        }

        public int PermissionId { get => _permissionId; set => _permissionId = value; }
        public int Level { get => _level; set => _level = value; }
    }
}
