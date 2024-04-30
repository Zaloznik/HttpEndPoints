namespace HttpEndPointsApi
{
    public static class Globals
    {
        public static List<ClientObj> ClientData
        {
            get;
            set;
        }
    }

    public class ClientObj
    {
        public ClientObj(Guid id, byte[] leftData, byte[] rightData)
        {
            this.id = id;
            this.leftData = leftData;
            this.rightData = rightData;
        }

        public Guid id
        {
            get;
            set;
        }

        public byte[] leftData
        {
            get;
            set;
        }

        public byte[] rightData
        {
            get;
            set;
        }
    }

}
