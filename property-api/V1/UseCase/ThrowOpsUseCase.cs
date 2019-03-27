namespace property_api.V1.UseCase
{
    public class ThrowOpsErrorUsecase
    {
        public static void  Execute()
        {
            throw new TestOpsErrorException();
        }
    }
}