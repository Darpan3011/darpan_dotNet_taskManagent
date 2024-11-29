using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Core.ServiceContracts.IUserService;
using finalSubmission.Core.ServiceContracts;
using finalSubmission.Core.Services.UsersService;
using finalSubmission.Core.Services;
using finalSubmission.Infrastructure.DbContexts;
using finalSubmission.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace finalSubmissionDotNet.BuilderExtensions
{
    public static class BuilderExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<TaskOrderDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]!);
            });

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGetAllTasks, GetAllTasks>();
            services.AddScoped<IChangeStatus, ChangeStatus>();
            services.AddScoped<ICreateTask, CreateTask>();
            services.AddScoped<IDeleteTask, DeleteTask>();
            services.AddScoped<IEditTask, EditTask>();
            services.AddScoped<IGetTaskByDueDate, GetTaskByDueDate>();
            services.AddScoped<IGetTaskByStatus, GetTaskByStatus>();
            services.AddScoped<IGetTaskByTitle, GetTaskByTitle>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<ICreateUser, CreateUser>();
            services.AddScoped<IGetAllUsers, GetAllUsers>();
            services.AddScoped<IGetByUserID, GetByUserID>();

            // for app.UseHttpLogging();
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties |
                    Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
            });


            return services;
        }
    }
}
