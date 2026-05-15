using Microsoft.EntityFrameworkCore;
using ProjectTemplate_WebApp.Models;

namespace ProjectTemplate_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        // Sau này các bảng (Table) sẽ khai báo ở đây
        // Ví dụ: public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}