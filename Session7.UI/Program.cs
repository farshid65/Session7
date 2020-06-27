using Microsoft.EntityFrameworkCore;
using MVCCore.Session7.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session7.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new PersonContext();
            //ctx.Database.EnsureCreated();
            ctx.People.Add(new Person
            {
                FirstName = "Mohammad",
                LastName = "Lotfi",
                Home=new Address
                {
                    AddressLine="Address",
                    PhoneNumber="234567890"
                },
                BankAcount=new BankAcount
                {
                    AccountNumber="234567890"
                }
                
            });
            ctx.Teachers.Add(new Teacher
            {
                FirstName = "AliReza",
                LastName = "Oroumand",
                Code = "123",
                Home = new Address
                {
                    AddressLine = "Address",
                    PhoneNumber = "234567890"
                },
                BankAcount=new BankAcount
                {
                    AccountNumber="234567890"
                }
            });
            ctx.SaveChanges();
            Console.WriteLine("Hello World");
            var Person = ctx.People.ToList();
            var acc = ctx.BankAccount.ToList();
            var PersonComp = ctx.People.Include(c => c.BankAcount).ToList();
            //BlogSample();
                }
        static void BlogSample(string[] args)
        {
            var ctx = new BlogContext();
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();
            //var blog = new Blog
            //{
            //    Name = "Nikamooz",
            //    CreateDate = DateTime.Now
            //};
            //ctx.Blogs.Add(blog);
            //ctx.SaveChanges();
            //var posts = new List<Post> { new Post { BlogId=blog.Id,Body="Post01"},
            //new Post{BlogId=blog.Id,Body="Post01"},
            //new Post{BlogId=blog.Id,Body="Post01"}
            //};
            //ctx.Posts.AddRange(posts);
            //ctx.SaveChanges();
            ////ctx.Blogs.Remove(blog);
            ////ctx.SaveChanges();
            //var posts = ctx.Posts.ToList();
            //ctx.Blogs.Remove(new Blog
            //{
            //    Id = 1
            //});
            //ctx.SaveChanges();
            //Console.WriteLine("Hello World!");
        }
       
    }
}
