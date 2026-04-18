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
            .AddPolicy(ApiPermission.ListCourses.ToString(), p => p.RequireRole(Role.Admin))
            .AddPolicy(ApiPermission.ListTeacherCourses.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListStudentCourses.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.DeleteCourse.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.GetStudentCourse.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.GetTeacherCourse.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.GetTeacherGroup.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListStudentCourseHomeworks.ToString(), p => p.RequireRole(Role.Student))
            .AddPolicy(ApiPermission.ListCourseParticipants.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.ListGroupParticipants.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.AddCourseParticipant.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.DeleteCourseParticipant.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.AddCourseHomework.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.GetHomework.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.DeleteCourseHomework.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.UpdateHomeworkStatus.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.AddSubmission.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.UpdateSubmission.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.ListSubmissions.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.ListGroupHomeworks.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.AddGroupHomework.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.GetGroup.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.ListCourseGroups.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.AddCourseGroup.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.DeleteGroup.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.AddGroupParticipant.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.DeleteGroupParticipant.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.DeleteGroupHomework.ToString(), p => p.RequireRole(Role.EditorRoles))
            .AddPolicy(ApiPermission.CreateHomeworkFile.ToString(), p => p.RequireRole(Role.Teacher))
            .AddPolicy(ApiPermission.CreateSubmittedHomework.ToString(), p => p.RequireRole(Role.Student));
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
