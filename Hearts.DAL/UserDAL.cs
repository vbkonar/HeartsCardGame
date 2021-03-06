﻿using NLog;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Hearts.DAL
{
    public class UserDAL
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public User AddUser(User user)
        {
            using (var db = new HeartsEntities())
            {
                if (db.Users.FirstOrDefault(x => x.Username.Equals(user.Username)) != null)
                    throw new CustomException("User name already taken.");
                if (db.Users.FirstOrDefault(x => x.EmailId.Equals(user.EmailId)) != null)
                    throw new CustomException("Email Id already exists.");

                db.Users.Add(user);
                db.SaveChanges();
                logger.Info("UserId: {0} - Registered.", user.UserId);
                return user;
            }
        }

        public string Validate(string userName)
        {
            using (var db = new HeartsEntities())
            {
                var u = db.Users.FirstOrDefault(x => x.Username.Equals(userName));
                if (u != null)
                {
                    logger.Info("UserId: {0} - Logged in.", u.UserId);
                    return u.Password;
                }
                logger.Info("User name: {0} - not found.", userName);
                throw new CustomException("Username or password incorrect.");
            }
        }

        public User GetUserById(int userId)
        {
            using (var db = new HeartsEntities())
            {
                var u = db.Users.FirstOrDefault(x =>
                        x.UserId.Equals(userId));
                if (u == null)
                {
                    logger.Info("UserId: {0} - Not found.", userId);
                    throw new CustomException("Invalid User");
                }
                return u;
            }
        }

        public User GetUserByUserName(string userName)
        {
            using (var db = new HeartsEntities())
            {
                var u = db.Users.FirstOrDefault(x =>
                        x.Username.Equals(userName));
                if (u == null)
                {
                    logger.Info("User name: {0} - Not found.", userName);
                    throw new CustomException("Invalid User");
                }
                return u;
            }
        }

        public bool UpdateActiveGame(int userId, int? gameId)
        {
            using (var db = new HeartsEntities())
            {
                var user = db.Users.FirstOrDefault(x =>
                        x.UserId.Equals(userId));

                if (gameId != null)
                {
                    var game = db.Games.FirstOrDefault(x =>
                          x.GameId == gameId);
                    if (game == null)
                        throw new CustomException("Invalid Game.");
                }

                if (user == null)
                {
                    logger.Info("User name: {0} - Not found.", userId);
                    throw new CustomException("Invalid User");
                }

                user.ActiveGameId = gameId;
                db.SaveChanges();
                return true;
            }
        }

        public List<User> GetAllUsers() {
            using (var db = new HeartsEntities())
            {
                return db.Users.OrderByDescending(x=>x.Points).ToList();
            }
        }
    }
}
