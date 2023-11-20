using Microsoft.AspNetCore.Identity;

namespace examMVC.Services
{
    public class PasswordService
    { 
        private readonly PasswordHasher<string> _passwordHasher;  //底線 _ 通常表示字段（Field）或私有成員

        public PasswordService() 
        {
           _passwordHasher = new PasswordHasher<string>();
        }


        //註冊時 密碼加密
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);  //這裡，null 被視為不提供特定用戶識別信息的標誌
        }


        //登入時 密碼解密驗證
        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
