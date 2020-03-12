using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace LockOut
{
    
    /// <summary>
    /// работа с пользователями  
    /// </summary>
    public class UserController : BaseSerializable
    {
        /// <summary>
        /// список  пользователей
        /// </summary>
       public List<User>  Users{ get; set; }

        /// <summary>
        /// создает  новых   юзеров  по типу   User1  пароль 1
        /// </summary>
        /// <param name="count"></param>
        private UserController ( int  count)
        {
            Users = new List<User>(); 

            for (int i = 1; i<= count; i++) // создаем по  одному   - добавляем в  лист  
            {
                Users.Add(new User { Name = i + " User", Log = "User" + i, Pass = i.ToString() }); 
            }

            Save(); // сохранияем  в файл
       }


        /// <summary>
        /// получаем пользователей 
        /// </summary>
        public UserController ()
        {
            Users = Load(); // загружаем пользователей  из  файла 
            if(Users.Count==0) // если пользователей  в  файле  нет  
            {
                UserController user = new UserController(10); // создаем   новых пользователей , записываем их  в файд
                Users = Load(); // забираем  из файла 
            }
        }
        public  void Save () // сохраняем список  юзеров  в  файл
        {
            base.Save("User.bin" , Users);
        }

        public List <User> Load() //   получаем список  юзеров из файла 
        {
            if (base.Load<List<User>>("User.bin").Count == 0)
            {
                return new List<User>();
            };
            return base.Load<List<User>>("User.bin");
        }


    }
}
