namespace BananaParty.Save
{
    public interface IPersistent
    {
        void Save(IStateStorage stateStorage);
        void Load(IStateStorage stateStorage);
    }
}
