using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Hosting.Auth.Configurations;
using Peerly.Gateway.Hosting.Auth.Cookies;
using Peerly.Gateway.Hosting.Auth.Data;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.Hosting.Auth;

[ExcludeFromCodeCoverage]
internal sealed class AuthInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        services
            .AddOptions<AuthHandlerOptions>()
            .BindConfiguration(AuthHandlerOptions.SectionName);
        services
            .AddOptions<AuthCookieOptions>()
            .BindConfiguration(AuthCookieOptions.SectionName);

        services.AddHttpContextAccessor();
        services.AddMemoryCache();
        services.AddScoped<IAuthCookiesManager, AuthCookiesWriter>();
        services
            .AddAuthorizationBuilder()
            // Authorization
            .AddPolicy(ApiPermission.Logout.ToString(), p => p.RequireRole(Role.AllRoles))
            // Storage
            .AddPolicy(ApiPermission.GenerateUploadUrl.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.GenerateDownloadUrl.ToString(), p => p.RequireRole(Role.AllRoles))
            // Courses
            .AddPolicy(ApiPermission.CreateCourse.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.UpdateCourse.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.DeleteCourse.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListCourses.ToString(), p => p.RequireRole(Role.Admin))
            .AddPolicy(ApiPermission.ListTeacherCourses.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListStudentCourses.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.GetTeacherCourse.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.GetStudentCourse.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.ListCourseParticipants.ToString(), p => p.RequireRole(Role.Teacher))
            // Groups
            .AddPolicy(ApiPermission.CreateGroup.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.UpdateGroup.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.DeleteGroup.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.AddGroupStudent.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.AddGroupTeacher.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.GetTeacherGroup.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.GetStudentGroup.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.ListTeacherCourseGroups.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListStudentCourseGroups.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.ListGroupParticipants.ToString(), p => p.RequireRole(Role.Teacher, Role.Student))
            // Homeworks
            .AddPolicy(ApiPermission.CreateCourseHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.CreateGroupHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.UpdateDraftHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.PostponeHomeworkDeadlines.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.PublishHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ConfirmHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.CreateHomeworkFile.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.CreateSubmittedHomework.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.GetStudentHomework.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.GetTeacherHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListStudentCourseHomeworks.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.ListTeacherCourseHomeworks.ToString(), p => p.RequireRole(Role.Teacher));

        services
            .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = "Jwt";
                    options.DefaultChallengeScheme = "Jwt";
                })
            .AddScheme<AuthHandlerOptions, AuthHandler>("Jwt", _ => {});
    }
}
