using budhtechjobapp.Models;

namespace budhtechjobapp.Data
{
    public interface IAuthDL
    {
        public Task<SignupResponse> SignupAsync(SignupRequest request);
        public Task<SignInResponse> SignInAsync(SignInRequest request);
    }
}
