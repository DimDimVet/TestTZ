namespace RegistratorObject
{
    public interface IRegistrator
    {
        public void SetData(Construction registrator);
        public bool ClearData();
        public Construction[] SetList();
        public Construction SetObjectHash(int hash);
        public Construction SetPlayer();
        public Construction[] SetEnemys();
        public void Rewrite(Construction _construction);
    }
}

