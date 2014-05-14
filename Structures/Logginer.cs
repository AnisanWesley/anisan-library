using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginControl
{
   public static class Loginner
   {
       private static readonly List<User> UserList = new List<User> { new User { Username = "admin", Password = "adminCSC" } };
       public static User CurrentUser { get; private set; }

       static Loginner()
       {
           UserList.AddRange(new Context().User.ToList());
       }
       
       public static LoginResult Login(string username, string password)
       {
           var user = UserList.FirstOrDefault(u => u.Username == username);
           if (user == null) return new LoginResult("Usuário não existe!");
           if (user.Password != password) return new LoginResult("Senha inválida!");
           CurrentUser = user;
           return new LoginResult();
       }
       
	          internal static LoginResult ValideUser(string username, string password, string confirm)
       {
           var user = UserList.FirstOrDefault(u => u.Username == username);
           if (user != null) return new LoginResult("Usuário já existe!");
           if (!password.Equals(confirm)) return new LoginResult("Senha e confirmação não coincidem.");


           return new LoginResult("Usuário Válido");
       }
       public static LoginResult ValideUser(User user)
       {
           if (user.Id == 0)
           {
               var verifyUser = UserList.FindAll(u => u.Username == user.Username).FirstOrDefault();
               if (verifyUser != null) return new LoginResult("Usuário já existe!");
           }
           return ValidacaoComum(user);
       }

       private static LoginResult ValidacaoComum(User user)
       {
           if (String.IsNullOrWhiteSpace(user.Username)) return new LoginResult("Insira o nome do usuário");
           if (user.Password.Length < 6) return new LoginResult("Senha deve ter no mínimo 6 caracteres");
           if (!user.Password.Equals(user.Confirm)) return new LoginResult("Senha e confirmação não coincidem.");


           return new LoginResult();
       }

       public static LoginResult ValideUser(User user, string senhaAtual)
       {
           var verifyUser = UserList.FindAll(u => u.Username == user.Username).FirstOrDefault();
           if (verifyUser == null || verifyUser.Password != senhaAtual)
               return new LoginResult("Senha não está correta para este usuário.");
           return ValidacaoComum(user);
       }

       public static LoginResult ValideChangePassword(User user, string senhaAtual, string novaSenha, string confirmar)
       {
           if(String.IsNullOrWhiteSpace(senhaAtual)||
              String.IsNullOrWhiteSpace(novaSenha)||
              String.IsNullOrWhiteSpace(confirmar)) return new LoginResult("Preencha todos os campos");

           if (senhaAtual != user.Password) return new LoginResult("Informe a senha atual correta");
           if (senhaAtual == novaSenha) return new LoginResult("Senha atual e nova são iguais");
           if (novaSenha != confirmar) return new LoginResult("Senha atual e confirmação nao coincidem");
           return new LoginResult();
       }
   }
   public class LoginResult
   {
       public string Message { get; private set; }
       public bool IsValid { get; private set; }

       public LoginResult(string message)
       {
           Message = message;
       }

       public LoginResult(bool first=true)
       {
           IsValid = first;
       }
      
		public class User
		{
			public int Id { get; set; }
			public string Password { get; set; }
			public string Confirm { get; set; }
			public string Username { get; set; }
			
		}
		public enum Permission
		{
			Nenhum, Restrito, Total
		}
   }

    
}
