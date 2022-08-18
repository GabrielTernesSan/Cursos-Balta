﻿
using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            //context.Users.Add(new User()
            //{
            //    Bio = "9x Microsoft MVP",
            //    Email = "andre@balta.io",
            //    Image = "https://balta.io",
            //    Name = "André Baltieri",
            //    PasswordHash = "hash",
            //    Slug = "andre-baltieri"
            //});
            //context.SaveChanges();

            var user = context.Users.FirstOrDefault();

            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Frontend",
                    Slug = "frontend"
                },
                CreateDate = DateTime.Now,
                // LastUpdateDate = 
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir...",
                // Tags = null,
                Title = "Meu artigo"
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}