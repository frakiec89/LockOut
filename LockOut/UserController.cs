using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace LockOut
{
    
    /// <summary>
    /// работа с пользователями  
    /// </summary>
    public class UserController
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
            BinaryFormatter formatter = new BinaryFormatter(); // формтарор
            using (var fille = new FileStream("user.bin", FileMode.OpenOrCreate)) // поток данных  в  файл  
            {
              formatter .Serialize(fille, Users); // сириализация 
            }

        }

        public List <User> Load() //   получаем список  юзеров из файла 
        {
            BinaryFormatter formatter = new BinaryFormatter(); // формтарор

            using (var fille = new FileStream("user.bin", FileMode.OpenOrCreate)) // поток данных  из  файла   
            {

                try
                {
                    var us = formatter.Deserialize(fille); // забираем объект  из  файла
                    if (us == null) // если файл  пустой
                    {
                        return new List<User>(); // создаем пустой  лист
                    }
                    else
                    {
                        return us as List<User>; // преобразуем объект  в  список листов 
                    }
                }
                catch
                {
                    return new List<User>(); // если поток данных пустой создаем пустой  лист
                }
            }

        }


    }
}
