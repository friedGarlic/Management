using Management;

namespace ManagementApp.Contracts
{
    public interface IDataTypeRepository : IGenericRepository<DataType>
    {
        public Task<DataType> Add(DataType datatype);
    }
}
