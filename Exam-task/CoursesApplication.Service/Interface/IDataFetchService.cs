using CoursesApplication.Domain.DomainModels;

namespace CoursesApplication.Service.Interface;

public interface IDataFetchService
{
    //http://is-lab4.ddns.net:8080/courses
    Task<List<Course>> FetchCoursesFromApi();
}