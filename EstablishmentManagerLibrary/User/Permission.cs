namespace EstablishmentManagerLibrary.User
{
    internal class Permission
    {
        private string _id;
        private int _level;

        public string Id { get => _id; set => _id = value; }
        public int Level { get => _level; set => _level = value; }
    }
}
