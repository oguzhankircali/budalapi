namespace Budalapi.Services.Communication
{
    public class BudalapiResponse : BaseResponse
    {
        public BudalapiResponse(bool success) : base(success)
        {

        }
        public BudalapiResponse(bool success, string message) : base(success, message)
        {

        }
    }
}